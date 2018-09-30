Solution name - PatientDemographics

WEB API Project - PatientDemographics
Data Layer - PatientDemographicsDAL
Test Project - PatientDemographicsUnitTest
Client Project - PatientDemographicsClient

NOte- Data is saving as XML in Table
Serilzation and Deserilization happening at WebAPI level.


DB Script- Database is created in Sql Server Express
DB details- data source=<<System Name>>\SQLEXPRESS;initial catalog=PatientDemographicDB

Run the below DB script .

USE [master]
GO
CREATE DATABASE [PatientDemographicDB]

USE [PatientDemographicDB]
GO

/****** Object:  Table [dbo].[Patient]    Script Date: 01-10-2018 00:06:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Patient](
	[Patient_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Patient_Details] [xml] NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[Patient_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

