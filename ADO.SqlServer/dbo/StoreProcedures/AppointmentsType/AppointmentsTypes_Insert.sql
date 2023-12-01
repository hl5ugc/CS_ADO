CREATE PROCEDURE [dbo].[AppointmentsTypes_Insert]
	@AppointmentTypeName NVARCHAR(50)
 
AS
BEGIN 
	INSERT INTO AppointmentsType (AppointmentTypeName)
	VALUES (@AppointmentTypeName);
END
