SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gordillo Federico>
-- Create date: <25-08-2023>
-- Description:	<Trigger relacionado al ejercicio 31.3>
-- =============================================
CREATE TRIGGER [TEST].trigger_EmpleadoXAuditoria
ON  [TEST].Employees
   AFTER INSERT, DELETE, UPDATE
AS 
BEGIN
    if exists (SELECT * FROM inserted)
    BEGIN
        insert into Auditoria(Operacion, Fecha)
        select 'INSERT', GETDATE()
        from inserted e;
    END;

    if exists (SELECT * FROM deleted)
    BEGIN
        insert into Auditoria(Operacion, Fecha)
        select 'DELETE', GETDATE()
        from deleted d;
    END;

    -- Registro de operación de actualización
    IF exists (SELECT * FROM inserted) and exists (SELECT * FROM deleted)
    BEGIN
        insert into Auditoria(Operacion, Fecha)
        select 'UPDATE', GETDATE()
        from inserted i join deleted d on i.ID = d.ID;
    END;
END;
GO
