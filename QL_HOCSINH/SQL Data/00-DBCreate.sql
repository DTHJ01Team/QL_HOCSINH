USE master;  
GO  
IF DB_ID (N'QL_HOCSINH') IS NOT NULL  
DROP DATABASE QL_HOCSINH;  
GO  
CREATE DATABASE QL_HOCSINH ;
--COLLATE Vietnamese_CI_AS;  
GO  

--CREATE DATABASE STDMNGT  
--COLLATE Vietnamese_CI_AS;  
--GO  

--Verify the collation setting.  
SELECT name, collation_name  
FROM sys.databases  
WHERE name = N'QL_HOCSINH';  
GO  