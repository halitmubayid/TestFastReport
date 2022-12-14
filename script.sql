USE [FastReportExample]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 19.10.2022 15:05:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SectionId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[EmployeeNo] [nvarchar](50) NOT NULL,
	[WorkStatus] [bit] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Section]    Script Date: 19.10.2022 15:05:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Section](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Data] [nvarchar](50) NULL,
 CONSTRAINT [PK_Section] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [SectionId], [FirstName], [LastName], [EmployeeNo], [WorkStatus]) VALUES (1, 1, N'محمد', N'محمد', N'000001/01/21', 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Section] ON 

INSERT [dbo].[Section] ([Id], [Data]) VALUES (1, N'General Manager')
SET IDENTITY_INSERT [dbo].[Section] OFF
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Section] FOREIGN KEY([SectionId])
REFERENCES [dbo].[Section] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Section]
GO
/****** Object:  StoredProcedure [dbo].[ProcedureExample]    Script Date: 19.10.2022 15:05:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProcedureExample]
	/*exec GetInsActionsById 2*/
	/*exec GetInsActionsById @InsActionsId*/
	@Id int
	AS
		BeGIN
			SELECT 
				*
			FROM Employee employee 
			INNER JOIN Section section ON section.Id = employee.SectionId
			where employee.Id = @Id
END
GO
