CREATE PROCEDURE [dbo].[AppointmentsTypes_GetById]
	@Id INT  
AS
BEGIN
	SELECT [Id], [AppointmentTypeName], [IsActive], [DateCreate] 
	FROM AppointmentsType
	WHERE Id = @Id;
END
