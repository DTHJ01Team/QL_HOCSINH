/*
   Sunday, October 15, 20179:06:56 AM
   User: anhquoc
   Server: ANHQUOC-PC\ANHQUOCPC
   Database: vd
   Application: 
*/
USE [QL_HOCSINH]
GO
/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.DIEMDATMON
	(
	MAMH varchar(5) NOT NULL,
	DiemDat float(53) NULL
	)  ON [PRIMARY]
GO

ALTER TABLE dbo.DIEMDATMON ADD CONSTRAINT
	PK_DIEMDATMON PRIMARY KEY CLUSTERED 
	(
	MAMH
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

COMMIT
select Has_Perms_By_Name(N'dbo.DIEMDATMON', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.DIEMDATMON', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.DIEMDATMON', 'Object', 'CONTROL') as Contr_Per