/*
   Wednesday, October 11, 20173:18:46 PM
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
ALTER TABLE dbo.QUYDINH SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.QUYDINH', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.QUYDINH', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.QUYDINH', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.MONHOC SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.MONHOC', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.MONHOC', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.MONHOC', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.KHOI SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.KHOI', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.KHOI', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.KHOI', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.LOP ADD CONSTRAINT
	FK_LOP_KHOI FOREIGN KEY
	(
	MAKHOI
	) REFERENCES dbo.KHOI
	(
	MAKHOI
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.LOP SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.LOP', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.LOP', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.LOP', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.HOCSINH SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.HOCSINH', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.HOCSINH', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.HOCSINH', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.HOCKY SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.HOCKY', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.HOCKY', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.HOCKY', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.DIEMKIEMTRA ADD CONSTRAINT
	FK_DIEMKIEMTRA_HOCSINH FOREIGN KEY
	(
	MAHS
	) REFERENCES dbo.HOCSINH
	(
	MAHS
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO

ALTER TABLE dbo.DIEMKIEMTRA ADD CONSTRAINT
	FK_DIEMKIEMTRA_HOCKY FOREIGN KEY
	(
	MAHK
	) REFERENCES dbo.HOCKY
	(
	MAHK
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO

ALTER TABLE dbo.DIEMKIEMTRA ADD CONSTRAINT
	FK_DIEMKIEMTRA_MONHOC FOREIGN KEY
	(
	MAMH
	) REFERENCES dbo.MONHOC
	(
	MAMH
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO

ALTER TABLE dbo.DIEMKIEMTRA SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.DIEMKIEMTRA', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.DIEMKIEMTRA', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.DIEMKIEMTRA', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.CTLOP ADD CONSTRAINT
	FK_CTLOP_LOP FOREIGN KEY
	(
	MALOP
	) REFERENCES dbo.LOP
	(
	MALOP
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.CTLOP ADD CONSTRAINT
	FK_CTLOP_HOCSINH FOREIGN KEY
	(
	MAHS
	) REFERENCES dbo.HOCSINH
	(
	MAHS
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.CTLOP SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.CTLOP', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.CTLOP', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.CTLOP', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.DIEMHOCKY ADD CONSTRAINT
	FK_DIEMHOCKY_HOCSINH FOREIGN KEY
	(
	MAHS
	) REFERENCES dbo.HOCSINH
	(
	MAHS
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE  
	
GO

ALTER TABLE dbo.DIEMHOCKY SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.DIEMHOCKY', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.DIEMHOCKY', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.DIEMHOCKY', 'Object', 'CONTROL') as Contr_Per 

BEGIN TRANSACTION
GO
ALTER TABLE dbo.DIEMDATMON ADD CONSTRAINT
	FK_DIEMDATMON_MONHOC FOREIGN KEY
	(
	MAMH
	) REFERENCES dbo.MONHOC
	(
	MAMH
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.DIEMDATMON SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.DIEMDATMON', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.DIEMDATMON', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.DIEMDATMON', 'Object', 'CONTROL') as Contr_Per 