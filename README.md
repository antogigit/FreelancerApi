GitHub Profile URL
URL: https://github.com/antogigit
________________________________________
How My Code Works
This project is a .NET 6 Web API application built for managing a directory of freelancers. The main features include:
•	CRUD Operations: You can create, update, delete, and retrieve freelancer records.
•	Search Function: A wildcard search filters freelancers by username or email.
•	Archiving: Freelancers can be archived/unarchived without being deleted.
•	Database: SQL Server is used for persistent storage with EF Core handling the ORM.
•	Models: Freelancers have related Skillsets and Hobbies stored in separate tables (one-to-many relationship).
•	Controllers: The FreelancersController handles all endpoints via standard RESTful conventions.
•	Swagger: Included for API documentation and testing.
•	In-Memory Option: Can switch to in-memory DB for quick tests or demonstrations.
________________________________________
Technologies Used
•	ASP.NET Core Web API
•	Entity Framework Core
•	SQL Server
•	Swagger / OpenAPI
•	Git, GitHub, Gitfront.io
________________________________________
Demo Plan During Interview
I’ll demonstrate the following features using Swagger or Postman:
1.	Query Data
o	GET /api/freelancers to list all freelancers.
o	GET /api/freelancers/search?query=name to filter by username or email.
2.	Add Data
o	POST /api/freelancers with a new freelancer payload.
3.	Update Data
o	PUT /api/freelancers/{id} to modify freelancer details.
4.	Delete Data
o	DELETE /api/freelancers/{id} to remove a freelancer.
5.	Archive / Unarchive
o	POST /api/freelancers/{id}/archive
o	POST /api/freelancers/{id}/unarchive
