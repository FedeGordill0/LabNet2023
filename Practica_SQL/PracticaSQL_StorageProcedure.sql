SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Gordillo Federico>
-- Create date: <25-08-2023>
-- Description:	<SP relacionado al ejercicio 31>
-- =============================================
CREATE PROCEDURE [test].sp_GetNombreAntiguedad
	@ID int
AS
BEGIN
	SET NOCOUNT ON;

   SELECT	FIRST_NAME + ', ' + LAST_NAME  as 'Nombre y Apellido',
		[test].[fn_AntiguedadEmpleado] (@ID) as 'Antiguedad en años'				
FROM TEST.EMPLOYEES WHERE ID = @ID
END
GO

SELECT	FIRST_NAME + ', ' + LAST_NAME  as 'Nombre y Apellido',
		[test].[fn_AntiguedadEmpleado] (14) as 'Antiguedad en años'				
FROM TEST.EMPLOYEES WHERE ID = 14

EXEC test.sp_GetNombreAntiguedad 14