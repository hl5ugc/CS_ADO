CREATE PROCEDURE [dbo].[AppointmentsTypes_GetAll]
AS
BEGIN
	SELECT [Id], [AppointmentTypeName], [IsActive], [DateCreate] 
	FROM AppointmentsType;
END