USE MieAyamPakAgus;
GO

-- Fix missing password column for Binding
CREATE OR ALTER VIEW vw_DataAdmin
AS
SELECT
    id_user,
    username,
    password
FROM Admin;
GO
