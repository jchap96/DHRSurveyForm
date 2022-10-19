IF OBJECT_ID('users', 'U') IS NOT NULL
 DROP TABLE users;
GO
-- Create the table in the specified schema
CREATE TABLE users
(
 id int NOT NULL IDENTITY(1,1) PRIMARY KEY ,
 first_name Varchar(50) NOT NULL,
 last_name Varchar(50) NOT NULL,
 phone_number Varchar(50) NOT NULL,
 entry_time DATETIME NOT NULL,
 q1 Varchar(10) NOT NULL, 
 q2 Varchar(10) NOT NULL, 
 q3 Varchar(10) NOT NULL, 
 q4 Varchar(10) NOT NULL, 
 q5 Varchar(10) NOT NULL 
);
GO