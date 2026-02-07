# Customer Support Ticket System - Web API

A comprehensive ASP.NET Web API for managing customer support tickets with role-based access control, built with MySQL database.

## 📋 Table of Contents
- [Technology Stack](#technology-stack)
- [Features](#features)
- [Project Structure](#project-structure)
- [Setup Instructions](#setup-instructions)
- [Database Configuration](#database-configuration)
- [Running the API](#running-the-api)
- [API Endpoints](#api-endpoints)
- [Authentication](#authentication)
- [Business Rules](#business-rules)
- [Testing with Swagger](#testing-with-swagger)

## 🛠 Technology Stack

- **Framework**: ASP.NET Core 9.0 Web API
- **Database**: MySQL 8.0+
- **ORM**: Entity Framework Core
- **Authentication**: JWT (JSON Web Tokens)
- **Password Hashing**: BCrypt
- **API Documentation**: Swagger/OpenAPI
- **Language**: C# 12

## ✨ Features

- ✅ JWT-based authentication and authorization
- ✅ Role-based access control (User and Admin roles)
- ✅ Auto-generated ticket numbers (TKT-XXXXXX format)
- ✅ Ticket status flow enforcement (Open → In Progress → Closed)
- ✅ Complete ticket lifecycle management
- ✅ Comment system (public and internal admin comments)
- ✅ Status change history tracking
- ✅ Ticket assignment to admins
- ✅ Closed ticket protection
- ✅ Global error handling
- ✅ Swagger UI for API testing

## 📁 Project Structure

```
CustomerSupportTicketSystem/
│
├── Controllers/
│   ├── AuthController.cs          # Login endpoint
│   └── TicketsController.cs       # All ticket operations
│
├── Models/
│   ├── User.cs                    # User entity
│   ├── Ticket.cs                  # Ticket entity
│   ├── TicketStatusHistory.cs     # Status tracking
│   └── TicketComment.cs           # Comments
│
├── DTOs/
│   ├── AuthDTOs.cs                # Login request/response
│   └── TicketDTOs.cs              # Ticket operations DTOs
│
├── Data/
│   └── ApplicationDbContext.cs    # EF Core DbContext
│
├── Services/
│   ├── IAuthService.cs            # Auth interface
│   ├── AuthService.cs             # Authentication logic
│   ├── ITicketService.cs          # Ticket interface
│   └── TicketService.cs           # Business logic
│
├── Middleware/
│   └── ErrorHandlingMiddleware.cs # Global exception handling
│
├── Program.cs                     # Application configuration
├── appsettings.json              # Configuration settings
└── DatabaseScript.sql            # MySQL database script
```

## 🚀 Setup Instructions

### Prerequisites

1. **.NET 9.0 SDK** - [Download here](https://dotnet.microsoft.com/download)
2. **MySQL Server 8.0+** - [Download here](https://dev.mysql.com/downloads/)
3. **Visual Studio 2022** or **VS Code** (optional)
4. **MySQL Workbench** or any MySQL client (optional)

### Step 1: Clone/Download the Project

```bash
cd d:\ProjectTask\CustomerSupportTicketSystem
```

### Step 2: Restore NuGet Packages

```bash
dotnet restore
```

### Step 3: Configure Database Connection

1. Open `appsettings.json`
2. Update the connection string with your MySQL credentials:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CustomerSupportDB;User=root;Password=YOUR_MYSQL_PASSWORD;"
  }
}
```

Replace:
- `localhost` with your MySQL server address
- `root` with your MySQL username
- `YOUR_MYSQL_PASSWORD` with your MySQL password

## 🗄 Database Configuration

The application automatically initializes the database on startup using `DbInitializer`. 
It will:
1. Create the database if it doesn't exist.
2. Apply any pending migrations.
3. Create a default admin user if one doesn't exist.

### Default Admin Credentials

- **Username**: `admin`
- **Password**: `admin123`

⚠️ **Important**: Change the default password after first login in production!

## ▶️ Running the API

### Using Command Line

```bash
dotnet run
```

### Using Visual Studio

1. Open the solution/project
2. Press `F5` or click "Start Debugging"

The API will start on:
- **HTTPS**: `https://localhost:5001`
- **HTTP**: `http://localhost:5000`

### Accessing Swagger UI

Open your browser and navigate to:
```
https://localhost:5001/swagger
```

## 📡 API Endpoints

### Authentication

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| POST | `/api/auth/login` | User login | No |

### Tickets

| Method | Endpoint | Description | Auth Required | Role |
|--------|----------|-------------|---------------|------|
| POST | `/api/tickets` | Create a ticket | Yes | User/Admin |
| GET | `/api/tickets` | Get ticket list (role-based) | Yes | User/Admin |
| GET | `/api/tickets/{id}` | Get ticket details | Yes | User/Admin |
| PUT | `/api/tickets/{id}/assign` | Assign ticket to admin | Yes | Admin |
| PUT | `/api/tickets/{id}/status` | Update ticket status | Yes | Admin |
| POST | `/api/tickets/{id}/comments` | Add comment | Yes | User/Admin |
| GET | `/api/tickets/admins` | Get list of admins | Yes | Admin |

### User Management (Admin Only)
200: 
201: | Method | Endpoint | Description | Auth Required | Role |
202: |--------|----------|-------------|---------------|------|
203: | GET | `/api/users` | List all users | Yes | Admin |
204: | GET | `/api/users/{id}` | Get user details | Yes | Admin |
205: | POST | `/api/users` | Create new user | Yes | Admin |
206: | PUT | `/api/users/{id}` | Update user profile | Yes | Admin |
207: | DELETE | `/api/users/{id}` | Delete user | Yes | Admin |
208: | POST | `/api/users/{id}/status` | Block/Unblock user | Yes | Admin |
209: | POST | `/api/users/{id}/reset-password` | Reset user password | Yes | Admin |
210: 
211: ## 🔐 Authentication

### How to Authenticate

1. **Login**: Call `POST /api/auth/login` with username and password
2. **Receive Token**: You'll get a JWT token in the response
3. **Use Token**: Include the token in subsequent requests:

```
Authorization: Bearer YOUR_JWT_TOKEN
```

### Example Login Request

```json
POST /api/auth/login
Content-Type: application/json

{
  "username": "admin",
  "password": "admin123"
}
```

### Example Login Response

```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "userId": 1,
  "username": "admin",
  "fullName": "System Administrator",
  "email": "admin@customersupport.com",
  "role": "Admin"
}
```

## 📜 Business Rules

### Ticket Creation
- Ticket number is auto-generated in format `TKT-000001`
- Initial status is always "Open"
- Server timestamp is used for creation date

### Ticket Status Flow
- **Open** → **In Progress** ✅
- **Open** → **Closed** ✅
- **In Progress** → **Closed** ✅
- No transitions FROM **Closed** status ❌

### Access Control

**Users can:**
- Create tickets
- View only their own tickets
- Add comments to their own tickets
- Cannot modify closed tickets

**Admins can:**
- View all tickets
- Assign tickets to other admins
- Update ticket status
- Add internal (admin-only) comments
- Cannot modify closed tickets

### Validation Rules
- All status changes are logged in history
- Comments cannot be added to closed tickets
- Only admins can add internal comments
- Ticket assignment requires admin role

## 🧪 Testing with Swagger

### Step 1: Start the API
```bash
dotnet run
```

### Step 2: Open Swagger UI
Navigate to: `https://localhost:5001/swagger`

### Step 3: Login

1. Click on `POST /api/auth/login`
2. Click "Try it out"
3. Enter credentials:
```json
{
  "username": "admin",
  "password": "admin123"
}
```
4. Click "Execute"
5. Copy the token from the response

### Step 4: Authorize

1. Click the "Authorize" button at the top
2. Enter: `Bearer YOUR_TOKEN_HERE` (replace with actual token)
3. Click "Authorize"
4. Now you can test all protected endpoints

### Step 5: Test Endpoints

Try creating a ticket:
```json
POST /api/tickets
{
  "subject": "Cannot login to account",
  "description": "I forgot my password and cannot reset it",
  "priority": "High"
}
```

## 📊 Database Schema

```
Users (1) ----< (M) Tickets
  |                    |
  |                    +----< (M) TicketComments
  |                    |
  |                    +----< (M) TicketStatusHistories
  |                           
  +-------------------+
  (ChangedBy)         (CreatedBy)
```

## 🔧 Configuration Options

### JWT Settings (appsettings.json)

```json
{
  "JwtSettings": {
    "SecretKey": "Your-Secret-Key-Min-32-Chars",
    "Issuer": "CustomerSupportAPI",
    "Audience": "CustomerSupportClient"
  }
}
```

### CORS Configuration

Currently configured to allow all origins (for development):
```csharp
policy.AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader();
```

For production, restrict to specific origins in `Program.cs`.

## 🐛 Troubleshooting

### Database Connection Issues

1. Verify MySQL is running
2. Check connection string in `appsettings.json`
3. Ensure database `CustomerSupportDB` exists
4. Verify user credentials have proper permissions

### JWT Token Issues

1. Ensure token is included in Authorization header
2. Token format: `Bearer YOUR_TOKEN`
3. Check if token has expired (24-hour validity)

### Build Errors

```bash
# Clean and rebuild
dotnet clean
dotnet restore
dotnet build
```

## 📝 Notes

- Default admin password should be changed in production
- JWT secret key should be stored securely (use environment variables in production)
- Database connection string should use secure credential storage in production
- CORS policy should be restricted to specific origins in production

## 👨‍💻 Development

### Adding New Users

You can add users directly via SQL or create a registration endpoint:

```sql
INSERT INTO Users (Username, PasswordHash, FullName, Email, Role)
VALUES ('newuser', 'BCRYPT_HASH_HERE', 'User Name', 'email@example.com', 'User');
```

Generate BCrypt hash using the `PasswordHashGenerator.cs` helper.

## 📄 License

This project is for educational/assignment purposes.

---

**For questions or issues, please contact the development team.**
