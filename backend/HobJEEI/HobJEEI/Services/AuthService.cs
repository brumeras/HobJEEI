using HobJeei.Data;
using HobJeei.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace HobJeei.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Company?> RegisterCompanyAsync(string email, string password, string companyName, string? contactPerson = null, string? phoneNumber = null, string? address = null)
        {
            if (await _context.Companies.AnyAsync(c => c.Email == email))
            {
                return null; // Email already exists
            }

            var company = new Company
            {
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                UserType = "Company",
                CompanyName = companyName,
                ContactPerson = contactPerson,
                PhoneNumber = phoneNumber,
                Address = address,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return company;
        }

        public async Task<Customer?> RegisterCustomerAsync(string email, string password, string firstName, string lastName, string? phoneNumber = null, DateTime? dateOfBirth = null)
        {
            if (await _context.Customers.AnyAsync(c => c.Email == email))
            {
                return null; // Email already exists
            }

            var customer = new Customer
            {
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                UserType = "Customer",
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                DateOfBirth = dateOfBirth,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<Company?> LoginCompanyAsync(string email, string password)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.Email == email && c.IsActive);
            if (company == null || !BCrypt.Net.BCrypt.Verify(password, company.PasswordHash))
            {
                return null;
            }

            return company;
        }

        public async Task<Customer?> LoginCustomerAsync(string email, string password)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email && c.IsActive);
            if (customer == null || !BCrypt.Net.BCrypt.Verify(password, customer.PasswordHash))
            {
                return null;
            }

            return customer;
        }

        public void SetUserSession(User user)
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            if (session != null)
            {
                session.SetString("UserId", user.Id.ToString());
                session.SetString("UserType", user.UserType);
                session.SetString("UserEmail", user.Email);
                
                if (user is Company company)
                {
                    session.SetString("CompanyName", company.CompanyName);
                }
                else if (user is Customer customer)
                {
                    session.SetString("CustomerName", $"{customer.FirstName} {customer.LastName}");
                }
            }
        }

        public void ClearUserSession()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            session?.Clear();
        }

        public (int? userId, string? userType) GetCurrentUser()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            if (session == null) return (null, null);

            var userIdStr = session.GetString("UserId");
            var userType = session.GetString("UserType");

            if (int.TryParse(userIdStr, out var userId))
            {
                return (userId, userType);
            }

            return (null, null);
        }

        public string? GetUserEmail()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            return session?.GetString("UserEmail");
        }

        public string? GetCompanyName()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            return session?.GetString("CompanyName");
        }

        public string? GetCustomerName()
        {
            var session = _httpContextAccessor.HttpContext?.Session;
            return session?.GetString("CustomerName");
        }

        public HttpContext? GetHttpContext()
        {
            return _httpContextAccessor.HttpContext;
        }
    }
}

