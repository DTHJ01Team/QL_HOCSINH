/*
   Sunday, October 08, 20178:19:20 PM
   User: anhquoc
   Server: ANHQUOC-PC\ANHQUOCPC
   Database: QL_HOCSINH
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

CREATE TABLE dbo.DIEMHOCKY
	(
	MAHS varchar(10) NOT NULL,
	MALOP varchar (5) NOT NULL,
	MAHK varchar (5) NOT NULL,
	DTBHK float NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.DIEMHOCKY ADD CONSTRAINT
	PK_DIEMHOCKY PRIMARY KEY CLUSTERED 
	(
	MAHS,
	MALOP,
	MAHK
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.DIEMHOCKY', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.DIEMHOCKY', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.DIEMHOCKY', 'Object', 'CONTROL') as Contr_Per 
 