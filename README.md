*****************AppSetting*************************************************************************************************************************************

# appsettings.json instructions:
- Replace the "DefaultConnection" string with your own database connection info.
- Make sure the server, user ID, and password are correct for your environment.

*****************DatabaseSetting********************************************************************************************************************************

Create the Database Sql Server
-- Create the database
CREATE DATABASE FreelancerDB;
GO

-- Use the newly created database
USE FreelancerDB;
GO

-- Create the Freelancers table
CREATE TABLE Freelancers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20),
    IsArchived BIT DEFAULT 0
);
GO

-- Create the Skillsets table
CREATE TABLE Skillsets (
    Id INT PRIMARY KEY IDENTITY(1,1),
    SkillName NVARCHAR(100) NOT NULL,
    FreelancerId INT,
    CONSTRAINT FK_Skillsets_Freelancer FOREIGN KEY (FreelancerId) REFERENCES Freelancers(Id) ON DELETE CASCADE
);
GO

-- Create the Hobbies table
CREATE TABLE Hobbies (
    Id INT PRIMARY KEY IDENTITY(1,1),
    HobbyName NVARCHAR(100) NOT NULL,
    FreelancerId INT,
    CONSTRAINT FK_Hobbies_Freelancer FOREIGN KEY (FreelancerId) REFERENCES Freelancers(Id) ON DELETE CASCADE
);
GO

USE FreelancerDB;
GO

-- Insert 20 Freelancers
INSERT INTO Freelancers (Username, Email, PhoneNumber, IsArchived)
VALUES 
('alice01', 'alice01@example.com', '1234567890', 0),
('bob02', 'bob02@example.com', '1234567891', 0),
('carol03', 'carol03@example.com', '1234567892', 0),
('dave04', 'dave04@example.com', '1234567893', 0),
('eve05', 'eve05@example.com', '1234567894', 0),
('frank06', 'frank06@example.com', '1234567895', 0),
('grace07', 'grace07@example.com', '1234567896', 0),
('heidi08', 'heidi08@example.com', '1234567897', 0),
('ivan09', 'ivan09@example.com', '1234567898', 0),
('judy10', 'judy10@example.com', '1234567899', 0),
('kyle11', 'kyle11@example.com', '1234567800', 0),
('linda12', 'linda12@example.com', '1234567801', 0),
('mike13', 'mike13@example.com', '1234567802', 0),
('nina14', 'nina14@example.com', '1234567803', 0),
('oscar15', 'oscar15@example.com', '1234567804', 0),
('peggy16', 'peggy16@example.com', '1234567805', 0),
('quentin17', 'quentin17@example.com', '1234567806', 0),
('ruth18', 'ruth18@example.com', '1234567807', 0),
('sybil19', 'sybil19@example.com', '1234567808', 0),
('trent20', 'trent20@example.com', '1234567809', 0);
GO

-- Insert sample Skillsets (2 per freelancer)
INSERT INTO Skillsets (SkillName, FreelancerId)
SELECT SkillName, FreelancerId FROM (
    VALUES 
    ('C#', 1), ('SQL', 1),
    ('JavaScript', 2), ('React', 2),
    ('Python', 3), ('Django', 3),
    ('Java', 4), ('Spring Boot', 4),
    ('PHP', 5), ('Laravel', 5),
    ('Go', 6), ('Microservices', 6),
    ('Node.js', 7), ('Express.js', 7),
    ('Flutter', 8), ('Dart', 8),
    ('Swift', 9), ('iOS', 9),
    ('Kotlin', 10), ('Android', 10),
    ('Ruby', 11), ('Rails', 11),
    ('C++', 12), ('QT', 12),
    ('HTML', 13), ('CSS', 13),
    ('Vue.js', 14), ('Nuxt', 14),
    ('Angular', 15), ('TypeScript', 15),
    ('R', 16), ('Data Analysis', 16),
    ('TensorFlow', 17), ('AI', 17),
    ('Power BI', 18), ('SQL Server', 18),
    ('Unity', 19), ('C#', 19),
    ('Blazor', 20), ('.NET Core', 20)
) AS s(SkillName, FreelancerId);
GO

-- Insert sample Hobbies (1 per freelancer)
INSERT INTO Hobbies (HobbyName, FreelancerId)
SELECT HobbyName, FreelancerId FROM (
    VALUES
    ('Reading', 1), ('Gaming', 2), ('Music', 3), ('Cooking', 4),
    ('Traveling', 5), ('Photography', 6), ('Hiking', 7), ('Drawing', 8),
    ('Running', 9), ('Swimming', 10), ('Chess', 11), ('Gardening', 12),
    ('Blogging', 13), ('Cycling', 14), ('Fishing', 15), ('Painting', 16),
    ('Coding', 17), ('Dancing', 18), ('Singing', 19), ('Crafting', 20)
) AS h(HobbyName, FreelancerId);
GO



*****************URL link to Front End********************************************************************************************************************************

Freelancer API URLs

----------------------------------------------------------------------------------------------------------------------
| Method   | Request URL                                                   | Description                             |
|----------|---------------------------------------------------------------|-----------------------------------------|
| `GET`    | `https://localhost:7081/api/Freelancers`                      | Get all non-archived freelancers        |
| `GET`    | `https://localhost:7081/api/Freelancers/search?query=keyword` | Search freelancers by username or email |
| `POST`   | `https://localhost:7081/api/Freelancers`                      | Create a new freelancer                 |
| `PUT`    | `https://localhost:7081/api/Freelancers/{id}`                 | Update a freelancer by ID               |
| `DELETE` | `https://localhost:7081/api/Freelancers/{id}`                 | Delete a freelancer by ID               |
| `POST`   | `https://localhost:7081/api/Freelancers/{id}/archive`         | Archive a freelancer                    |
| `POST`   | `https://localhost:7081/api/Freelancers/{id}/unarchive`       | Unarchive a freelancer                  |
----------------------------------------------------------------------------------------------------------------------
