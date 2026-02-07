# Customer Support Ticket System

A complete full-stack solution for managing customer support tickets, featuring a **Web API** backend and a **Windows Desktop (WinForms)** client.

## 📋 Prerequisites

Before running the project, ensure you have the following installed:

1.  **.NET 9.0 SDK**: [Download here](https://dotnet.microsoft.com/download/dotnet/9.0)
2.  **MySQL Server (8.0+)**: [Download here](https://dev.mysql.com/downloads/mysql/)

---

## 🚀 Quick Start Guide

Follow these steps to get the application running.

### Step 1: Configure Database

1.  Navigate to the API project directory:
    ```bash
    cd CustomerSupportTicketSystem.Api
    ```
2.  Open `appsettings.json` in a text editor.
3.  **CRITICAL**: Update the `ConnectionStrings` section with your MySQL credentials (Password is usually the most important part).

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=CustomerSupportDB;User=root;Password=YOUR_ACTUAL_PASSWORD;"
    }
    ```
    *Replace `YOUR_ACTUAL_PASSWORD` with the password you set when installing MySQL.*

### Step 2: Run the API (Backend)

1.  Open a terminal/command prompt in the `CustomerSupportTicketSystem.Api` folder.
2.  Run the application:
    ```bash
    dotnet run
    ```
    *   The API will start and automatically create the database (`CustomerSupportDB`) and seed a default admin user.
    *   **Keep this terminal window open.** The Desktop app needs the API to be running.
    *   API URL: `https://localhost:7254`

### Step 3: Run the Desktop Application (Frontend)

1.  Open a **new** terminal/command prompt.
2.  Navigate to the Desktop project directory:
    ```bash
    cd ../CustomerSupportTicketSystem.Desktop
    ```
3.  Run the application:
    ```bash
    dotnet run
    ```
4.  The Login screen should appear.

---

## 🔑 Login Credentials

The system comes with a default administrator account:

*   **Username**: `admin`
*   **Password**: `admin123`

---

## 🛠 Project Structure

*   **CustomerSupportTicketSystem.Api**: ASP.NET Core Web API (Backend)
    *   Handles authentications, data persistence (EF Core), and business logic.
    *   Documentation: [API README](./CustomerSupportTicketSystem.Api/README.md)
*   **CustomerSupportTicketSystem.Desktop**: .NET WinForms Application (Frontend)
    *   Modern UI for users and admins to manage tickets.
    *   Connects to the API for all operations.

## 🧪 Testing

*   **Swagger API Docs**: https://localhost:7254/swagger
*   You can use the Desktop App to fully test the flow (Login -> Dashboard -> Create Ticket -> Manage Users).
