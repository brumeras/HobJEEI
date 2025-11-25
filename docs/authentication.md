# Authentication System Documentation

## Overview
The application now supports dual registration and login for two types of users:
- **Companies**: Organizations that can upload and manage hobby groups
- **Customers**: Individuals who can register and participate in hobby groups

## Database Schema

### User Models
- **User** (abstract base class)
  - `Id`: Primary key
  - `Email`: Unique email address
  - `PasswordHash`: BCrypt hashed password
  - `UserType`: "Company" or "Customer"
  - `CreatedAt`: Registration timestamp
  - `IsActive`: Account status

- **Company** (inherits from User)
  - `CompanyName`: Business name
  - `ContactPerson`: Primary contact name
  - `PhoneNumber`: Contact phone
  - `Address`: Business address
  - `BusinessRegistrationNumber`: Optional registration number
  - `Groups`: Collection of HobbyGroups owned by the company

- **Customer** (inherits from User)
  - `FirstName`: Customer's first name
  - `LastName`: Customer's last name
  - `PhoneNumber`: Contact phone
  - `DateOfBirth`: Optional birth date
  - `Memberships`: Collection of GroupMemberships

### Relationships
- Companies can own multiple HobbyGroups
- Customers can have multiple GroupMemberships
- HobbyGroups are linked to Companies via `CompanyId` foreign key

## Authentication Flow

### Registration
1. User navigates to `/register`
2. Selects account type (Company or Customer)
3. Fills in required information:
   - **Company**: Company name, email, password, contact person (optional), phone (optional), address (optional)
   - **Customer**: First name, last name, email, password, phone (optional), date of birth (optional)
4. Password is hashed using BCrypt
5. User is created in database
6. Session is established
7. User is redirected to home page

### Login
1. User navigates to `/login`
2. Selects account type (Company or Customer)
3. Enters email and password
4. Credentials are verified against database
5. If valid, session is established
6. User is redirected to home page

### Session Management
- Sessions are stored server-side using ASP.NET Core Session
- Session contains:
  - `UserId`: User's ID
  - `UserType`: "Company" or "Customer"
  - `UserEmail`: User's email address
- Sessions expire after 30 minutes of inactivity

## Security Features
- Passwords are hashed using BCrypt (one-way hashing)
- Email addresses are unique per user type
- Session-based authentication (no tokens stored client-side)
- Password minimum length: 6 characters

## API/Service Layer

### AuthService
Located in `Services/AuthService.cs`

**Methods:**
- `RegisterCompanyAsync()`: Creates a new company account
- `RegisterCustomerAsync()`: Creates a new customer account
- `LoginCompanyAsync()`: Authenticates a company user
- `LoginCustomerAsync()`: Authenticates a customer user
- `SetUserSession()`: Establishes user session
- `ClearUserSession()`: Clears user session
- `GetCurrentUser()`: Returns current logged-in user info
- `GetUserEmail()`: Returns current user's email

## Pages

### Register Page (`/register`)
- Account type selector (Company/Customer)
- Dynamic form based on selected type
- Validation and error handling
- Link to login page

### Login Page (`/login`)
- Account type selector (Company/Customer)
- Email and password fields
- Error handling for invalid credentials
- Link to registration page

## Navigation
- Navigation menu shows login/register links when not authenticated
- Shows user info and logout button when authenticated
- User type and email displayed in sidebar

## Database Setup

### Connection String
Configured in `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=HobJEEI;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

### Database Initialization
Database is automatically created on first run using `EnsureCreated()`.

### Migration (Optional)
To use migrations instead:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Next Steps
1. Add password reset functionality
2. Add email verification
3. Add role-based authorization for protected routes
4. Add profile management pages
5. Connect HobbyGroups to Company accounts
6. Implement customer group joining functionality

