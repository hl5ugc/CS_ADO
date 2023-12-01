CREATE PROCEDURE [dbo].[AppointmentsTypes_Update]
	@Id INT,
	@AppointmentsNameType NVARCHAR(50)
AS
BEGIN
	UPDATE AppointmentsType
	SET @AppointmentsNameType = @AppointmentsNameType
	WHERE Id = @Id;
END
