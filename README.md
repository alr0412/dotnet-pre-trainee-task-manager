# Task Manager Application

## Project Description
This is a console-based application for managing a list of tasks, with data persisted in a SQL Server database. The application allows users to create, view, update, and delete tasks, as well as perform searches and filtering.

## Technologies
* **C#**
* **SQL Server**
* **Dapper**
* **Microsoft.Data.SqlClient**

## Features
The application supports the following operations via a console menu:
**CRUD Operations:**
* Create a new task (specifying a title and description). 
* View all tasks (displaying ID, title, status, and creation date). 
* Search for a task by its ID. 
* Update the title, description, and status of an existing task. 
* Delete a task by ID (with confirmation). 
* Mark a task as completed.
**Additional Features:**
* View only completed tasks. 
* View only incomplete tasks. 
* Search for tasks by title (using `LIKE`). 
* Sort tasks by creation date (newest first or oldest first). 
* Replace a task: within a single transaction, the old task is marked as completed, and a new one is created.

## Database Setup
To run the application, you must create a database and a table.
The `db/` folder contains SQL scripts to prepare the environment:

1. **`create-database.sql`** — creates the `TaskManagementDb` database.
2. **`create-table.sql`** — creates the `Tasks` table with the required columns.
3. **`seed-data.sql`** (optional) — populates the table with initial test data. **Instructions:**
1. Open SQL Server Management Studio (SSMS).
2. Connect to your local SQL Server instance.
3. Execute the scripts from the `db/` folder one by one.

## Application Setup
1. Ensure that you have the **.NET SDK** (version 8.0 or higher) installed.
2. Clone the repository:
```bash
git clone https://github.com/staskon315/dotnet-pre-trainee-task-manager.git
```
3. Navigate to the project folder:
```bash
cd dotnet-pre-trainee-task-manager
```
4. Open the `Program.cs` file and check the connection string. By default, it is configured for a local server:
```csharp
string connectionString = """
Server=localhost;
Database=TaskManagementDb;
Integrated Security=True;
TrustServerCertificate=True;
""";
```
If your SQL Server instance uses a different name (e.g., `localhost\SQLEXPRESS`), update the connection string accordingly.

5. Restore dependencies and run the project.

## Project Structure

* **`Models/`** — contains the `TaskItem` data model. It is responsible for storing task data and performing object-level validation.
* **`Repositories/`** — contains the `ITaskRepository` interface and its implementation, `TaskRepository`. All SQL code, Dapper-related logic, and database connectivity are encapsulated here.
* **`ConnectionFactory/`** — contains `IDbConnectionFactory` and `SqlConnectionFactory`. It handles the creation and opening of database connections (using the Factory pattern).
* **`TaskService.cs`** — the business logic layer. It acts as a bridge between the console interface and the repository, handling user actions.
* **`Validation.cs`** — a static class used for safe console input (preventing issues such as entering letters instead of numbers, providing empty strings, etc.).
* **`Program.cs`** — the application entry point. It contains the console menu and dependency configuration.

## Concepts Applied
The following concepts were applied during the development of this project:
* **CRUD** (Create, Read, Update, Delete) — the complete data management lifecycle.
* **Asynchronous database access** — all database operations utilize `async/await` to avoid blocking threads.
* **Repository Pattern** — isolating data access logic from business logic. * **Parameterized queries** — all SQL queries use parameters (e.g., `@Id`, `@Title`), which protects the application against SQL injection.
* **Transactions** — the `ReplaceTaskAsync` method uses transactions to ensure the atomicity of operations (all-or-nothing).
* **Data persistence in SQL Server** — ensures data remains intact when the application is restarted.