namespace HobJeei.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string UserType { get; set; } = ""; // "Company" or "Customer"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }

    public class Company : User
    {
        public string CompanyName { get; set; } = "";
        public string? ContactPerson { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? BusinessRegistrationNumber { get; set; }
        public List<HobbyGroup> Groups { get; set; } = new();
    }

    public class Customer : User
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public List<GroupMembership> Memberships { get; set; } = new();
    }

    public class GroupMembership
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public int HobbyGroupId { get; set; }
        public HobbyGroup HobbyGroup { get; set; } = null!;
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}

