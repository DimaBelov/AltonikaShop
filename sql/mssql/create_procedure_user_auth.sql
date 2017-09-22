CREATE PROCEDURE User_Auth
@user_login NVARCHAR(255),
@user_password NVARCHAR(255)
AS
BEGIN
	SELECT * FROM Users
	WHERE 
		user_login=@user_login AND
		user_password=@user_password
END