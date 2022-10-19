using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TestFastReport.Models;
using Mapster;

namespace TestFastReport.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DBConntext dBConntext = new DBConntext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StoredProcedureFastReport(int id)
        {
            WebReport web = new WebReport();
            string path = Directory.GetCurrentDirectory() + "\\wwwroot\\StoredProcedureExample.frx";
            web.Report.Load(path);

            var conn = new MsSqlDataConnection();
            conn.ConnectionString = DBConntext.connectionString;

            web.Report.SetParameterValue("CONN", DBConntext.connectionString);

            web.Report.SetParameterValue("Id", id);

            web.Report.Prepare();

            Stream stream = new MemoryStream();

            web.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;
            return File(stream, "application/pdf", "Example.pdf");
        }

        public IActionResult SetModelFastReport(int id)
        {
            List<Employee> employees = dBConntext.Employees.Where(x => x.Id == id).Include(x => x.Section).ToList();

            List<EmployeeDTO> employeeDTOs = employees.Adapt<List<EmployeeDTO>>();

            WebReport web = new WebReport();
            string path = Directory.GetCurrentDirectory() + "\\wwwroot\\SetModelExample.frx";
            web.Report.Load(path);

            var conn = new MsSqlDataConnection();
            conn.ConnectionString = DBConntext.connectionString;

            web.Report.RegisterData(employeeDTOs, "Emplayee");

            web.Report.Prepare();

            Stream stream = new MemoryStream();

            web.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;
            return File(stream, "application/pdf", "Example.pdf");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
