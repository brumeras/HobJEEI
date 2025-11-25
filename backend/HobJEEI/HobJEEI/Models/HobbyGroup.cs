namespace HobJeei.Models
{
    public class HobbyGroup
    {
        public int Id { get; set; }
        public int CompanyId { get; set; } // Foreign key to Company
        public string Name { get; set; } = "";
        public string HobbyType { get; set; } = "";
        public string CoachName { get; set; } = "";
        public string Location { get; set; } = "";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Schedule { get; set; } = "";
        public decimal Price { get; set; }
        public int MaxMembers { get; set; }
        public int CurrentMembers { get; set; }
        public List<Member> Members { get; set; } = new();
        public List<Session> UpcomingSessions { get; set; } = new();
        public List<ChatMessage> Messages { get; set; } = new();
    }

    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public AttendanceStatus Status { get; set; }
        public bool AvailableForSubstitute { get; set; }
    }

    public class Session
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; } = "";
        public Dictionary<int, AttendanceStatus> Attendance { get; set; } = new();
    }

    public class ChatMessage
    {
        public int Id { get; set; }
        public string SenderName { get; set; } = "";
        public string Message { get; set; } = "";
        public DateTime Timestamp { get; set; }
        public bool IsCoach { get; set; }
    }

    public enum AttendanceStatus
    {
        NotSet,
        Going,
        Maybe,
        Cant
    }
}