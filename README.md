# Expense-Tracking-App
Simple expense tracking web application built with ASP.NET Core Razor Pages and Entity Framework Core. It allows users to add, edit, delete, and view expenses, as well as visualize spending by category with a dynamic pie chart (Char.js)

## Features

- Add, edit, and delete expenses
- List all expenses in a table
- Visualize expenses by category using a Chart.js pie chart
- Data stored in a SQL Server database via Entity Framework Core
- Server-side and client-side validation

## Technologies

- ASP.NET Core 9 (Razor Pages)
- Entity Framework Core 9
- SQL Server
- Chart.js (for charts)
- jQuery Validation

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or SQL Server Express)

### Setup

1. **Clone the repository:**
   git clone https://github.com/Souheyl7Gouadria/Expense-Tracking-App.git
2. **Configure the database connection:**
   - Edit `appsettings.json` and set your SQL Server connection string under `DefaultConnection`.
3. **Apply database migrations:**
4. **Run the application:**
