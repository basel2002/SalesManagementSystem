# Sales Management System

A desktop-based enterprise application designed to manage complex sales data, including customers, employees, offices, products, and transaction records. Built with modern .NET technologies and a clean separation between data persistence and graphical user interface. [1](#0-0) 

## Features

- **Complete CRUD Operations**: Create, Read, Update, and Delete functionality for all major entities
- **Organizational Management**: Manage offices and employee hierarchies with reporting relationships
- **Inventory Control**: Track products and product lines with detailed specifications
- **Sales Lifecycle**: Full order processing from customer management through order details and payments
- **Data Validation**: Built-in validation rules and duplicate detection
- **User-Friendly Interface**: Windows Forms-based UI with grid views and form-based data entry

## Technology Stack

| Component | Technology | Version |
| :--- | :--- | :--- |
| **Runtime** | .NET | 9.0 |
| **ORM** | Entity Framework Core | 9.0 |
| **Database** | SQL Server | - |
| **UI Framework** | Windows Forms | - |

## Architecture

The solution follows a two-project architecture to separate concerns between data modeling and user interaction:

```mermaid
graph TD
    subgraph "ProjectForm (WinForms UI)"
        [Form1] --> [DbContextHelper]
        [Form1] --> [EntityForms]
    end

    subgraph "CodeFirst (Data Layer)"
        [MyContext] --> [Models]
        [MyContext] --> [Migrations]
    end

    [ProjectForm] -- "References" --> [CodeFirst]
    [MyContext] -- "EF Core / SQL Provider" --> [ClassicModels_DB]

    style [ClassicModels_DB] stroke-dasharray: 5 5
```

### Project Components

**CodeFirst (Data Layer)**
- Defines database schema through C# classes using Code-First approach
- Contains entity models (`Customer`, `Employee`, `Product`, etc.)
- `MyContext` manages SQL Server connection and configures model relationships via Fluent API
- Includes EF Core migrations for database version control

**ProjectForm (UI Layer)**
- Executable Windows Forms application
- `Form1` serves as the main navigation hub
- `DbContextHelper` manages the lifecycle of the shared `MyContext` instance
- Entity-specific forms (`CustomerForm`, `EmployeeForm`, `ProductForm`, etc.) provide data entry interfaces

## Getting Started

### Prerequisites
- .NET 9.0 SDK
- SQL Server (local or remote instance)
- Visual Studio 2022 or compatible IDE

### Installation

1. Clone the repository
2. Open `EFCore_Project.slnx` in Visual Studio
3. Configure the database connection string in `CodeFirst/Context/MyContext.cs` [2](#0-1) 
4. Run EF Core migrations to create the database:
   ```bash
   dotnet ef database update --project CodeFirst
   ```
5. Set `ProjectForm` as the startup project
6. Run the application

## Project Structure

```
SalesManagementSystem/
├── CodeFirst/                 # Data layer project
│   ├── Context/              # DbContext and configuration
│   │   └── MyContext.cs
│   ├── Models/               # Entity classes
│   ├── Migrations/           # EF Core migrations
│   └── CodeFirst.csproj
├── ProjectForm/              # UI layer project
│   ├── Forms/                # Windows Forms
│   │   ├── Form1.cs          # Main navigation
│   │   ├── CustomerForm.cs
│   │   ├── EmployeeForm.cs
│   │   ├── ProductForm.cs
│   │   └── ...
│   ├── DbContextHelper.cs    # Context lifecycle management
│   └── ProjectForm.csproj
└── EFCore_Project.slnx       # Solution file
```

## Database Schema

The application uses the `ClassicModels` database schema with the following main entities:
- **Customers**: Customer information and credit limits
- **Employees**: Staff details with office assignments and reporting hierarchy
- **Offices**: Office locations and contact information
- **Products**: Inventory items with pricing and vendor details
- **ProductLines**: Product categorization
- **Orders**: Sales orders with customer references
- **OrderDetails**: Line items for orders with pricing
- **Payments**: Customer payment records

## Usage

The application provides a main navigation form (`Form1`) that allows access to various management forms. Each form follows a consistent pattern:
- Grid view displaying all records
- Create/Update/Delete buttons for data manipulation
- Validation rules to ensure data integrity
- Related data loading (e.g., offices for employee assignment)

