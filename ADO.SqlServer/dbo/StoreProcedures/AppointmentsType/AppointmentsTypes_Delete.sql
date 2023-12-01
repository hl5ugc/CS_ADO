CREATE PROCEDURE [dbo].[AppointmentsTypes_Delete]
	@Id INT
AS
BEGIN
	DELETE FROM AppointmentsType
	WHERE Id = @Id;
END
