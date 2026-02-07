# API and Desktop App Configuration Guide

## Current Configuration ✅

Both projects are now properly configured to work together:

### API Configuration
- **Port**: `https://localhost:7254`
- **Configured in**: [launchSettings.json](file:///d:/ProjectTask/CustomerSupportTicketSystem.Api/Properties/launchSettings.json)
- HTTP URL: `http://localhost:5257` (fallback)

### Desktop App Configuration
- **API Base URL**: `https://localhost:7254/api`
- **Configured in**: [ApiService.cs](file:///d:/ProjectTask/CustomerSupportTicketSystem.Desktop/Services/ApiService.cs) (line 14)

---

## How to Run Both Projects

### Step 1: Start the API Backend
```powershell
cd d:\ProjectTask\CustomerSupportTicketSystem.Api
dotnet run
```

**Expected output:**
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7254
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5257
```

✅ **Leave this terminal running!**

### Step 2: Start the Desktop Application
Open a **new terminal**:
```powershell
cd d:\ProjectTask\CustomerSupportTicketSystem.Desktop
dotnet run
```

The login form should appear.

---

## Troubleshooting

### Issue 1: SSL Certificate Warning

If you get an SSL certificate error when the desktop app tries to connect:

**Solution**: Trust the development certificate
```powershell
dotnet dev-certs https --trust
```

Click "Yes" when prompted to install the certificate.

### Issue 2: "Connection refused" or "No connection"

**Possible causes:**
1. API is not running
2. API is running on a different port
3. Firewall blocking the connection

**Solution:**
- Make sure the API terminal shows "Now listening on: https://localhost:7254"
- Check Windows Firewall settings
- Try using HTTP instead (see below)

### Issue 3: Want to use HTTP instead of HTTPS?

If you prefer to run without SSL for development:

**Option A: Change Desktop App to use HTTP**

Edit [ApiService.cs](file:///d:/ProjectTask/CustomerSupportTicketSystem.Desktop/Services/ApiService.cs):
```csharp
private const string BaseUrl = "http://localhost:5257/api";  // Changed to HTTP
```

**Option B: Run API in HTTP mode**
```powershell
dotnet run --launch-profile http
```

This will start the API on `http://localhost:5257` (no certificate needed).

---

## Changing the Port (If Needed)

If you need to use a different port:

### 1. Update API Port
Edit [launchSettings.json](file:///d:/ProjectTask/CustomerSupportTicketSystem.Api/Properties/launchSettings.json):
```json
"applicationUrl": "https://localhost:YOUR_PORT;http://localhost:5257"
```

### 2. Update Desktop App
Edit [ApiService.cs](file:///d:/ProjectTask/CustomerSupportTicketSystem.Desktop/Services/ApiService.cs):
```csharp
private const string BaseUrl = "https://localhost:YOUR_PORT/api";
```

### 3. Rebuild Both Projects
```powershell
# Rebuild API
cd d:\ProjectTask\CustomerSupportTicketSystem.Api
dotnet build

# Rebuild Desktop
cd d:\ProjectTask\CustomerSupportTicketSystem.Desktop
dotnet build
```

---

## Quick Test

1. **Start API** (Terminal 1)
2. **Start Desktop** (Terminal 2)
3. **Try to login** with your admin credentials
4. If successful → Everything is configured correctly! ✅
5. If error → Check the error message and refer to troubleshooting above

---

## Current Status

✅ API configured on port **7254** (HTTPS)  
✅ Desktop app configured to connect to **7254**  
✅ Both projects build successfully  
⏳ Ready to test!
