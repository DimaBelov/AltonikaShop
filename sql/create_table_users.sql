CREATE TABLE Users (
    user_id int IDENTITY(1,1) PRIMARY KEY,
    user_login varchar(255) NOT NULL,
	user_password varchar(255) NOT NULL
);