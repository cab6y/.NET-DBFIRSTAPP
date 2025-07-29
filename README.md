# TODOAPP-ANGULAR-.NET

## Initial Setup

### 1. Running the Project
Before running the project for the first time, you need to create the database tables.

1. **Set EFCore as Startup Project**  
   - In Visual Studio, right-click on the **EFCore** project in the **Solution Explorer**.  
   - Select **Set as Startup Project**.

2. **Apply Database Migration**  
   - Open the **Package Manager Console** (PMC) window.  
   - Run the following command:
     ```powershell
     Update-Database
     ```
   This command will use the existing migration files in the project to create the database.

### 2. Database Information
- The application runs on **LocalDB**.  
- The database connection string is defined in the `appsettings.json` file.

### 3. Temporal Table Structure
This project uses the **TodoItems** table with **Temporal Table (System-Versioned)** support.

- **Main Table**: `TodoItems`  
  Holds the current records used by the application.
- **History Table**: (Automatically created by SQL Server)  
  Stores historical data for all changes made to the `TodoItems` table.

With Temporal Table, historical data is automatically maintained and can be queried as follows:
```sql
SELECT * FROM TodoItems FOR SYSTEM_TIME ALL;

