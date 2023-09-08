SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gordillo Federico>
-- Create date: <25-08-2023>
-- Description:	<Función relacionada al ejercicio 30.4>
-- =============================================
CREATE FUNCTION [TEST].fn_AntiguedadEmpleado (@ID int)
RETURNS int
AS
BEGIN

	DECLARE @Antiguedad int = (SELECT DATEDIFF(YEAR, HIRE_DATE, GETDATE()) as 'Antiguedad en años'from TEST.EMPLOYEES where ID = @ID)

	RETURN @Antiguedad

END
GO

select TEST.[fn_AntiguedadEmpleado] (14) as 'Antiguedad en años'
select TEST.[fn_AntiguedadEmpleado] (1) as 'Antiguedad en años'
