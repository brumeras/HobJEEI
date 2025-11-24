namespace HobJeei.Services
{
    using HobJeei.Models;

    public class MockDataService
    {
        private List<HobbyGroup> _groups;

        public MockDataService()
        {
            _groups = InitializeMockData();
        }

        public List<HobbyGroup> GetAllGroups() => _groups;

        public HobbyGroup? GetGroupById(int id) => _groups.FirstOrDefault(g => g.Id == id);

        public void UpdateAttendance(int groupId, int sessionId, int memberId, AttendanceStatus status)
        {
            var group = GetGroupById(groupId);
            if (group != null)
            {
                var session = group.UpcomingSessions.FirstOrDefault(s => s.Id == sessionId);
                if (session != null)
                {
                    session.Attendance[memberId] = status;
                }
                
                var member = group.Members.FirstOrDefault(m => m.Id == memberId);
                if (member != null)
                {
                    member.Status = status;
                }
            }
        }

        public void AddMessage(int groupId, string sender, string message, bool isCoach)
        {
            var group = GetGroupById(groupId);
            if (group != null)
            {
                group.Messages.Add(new ChatMessage
                {
                    Id = group.Messages.Count + 1,
                    SenderName = sender,
                    Message = message,
                    Timestamp = DateTime.Now,
                    IsCoach = isCoach
                });
            }
        }

        private List<HobbyGroup> InitializeMockData()
        {
            return new List<HobbyGroup>
            {
                new HobbyGroup
                {
                    Id = 1,
                    Name = "Badminton Beginners",
                    HobbyType = "Sports",
                    CoachName = "Sarah Johnson",
                    Location = "Central Sports Center",
                    Latitude = 54.687,
                    Longitude = 25.279,
                    Schedule = "Monday 18:00 - 20:00",
                    Price = 15.00m,
                    MaxMembers = 12,
                    CurrentMembers = 8,
                    Members = new List<Member>
                    {
                        new Member { Id = 1, Name = "John Doe", Email = "john@email.com", Status = AttendanceStatus.Going, AvailableForSubstitute = true },
                        new Member { Id = 2, Name = "Emma Smith", Email = "emma@email.com", Status = AttendanceStatus.Maybe, AvailableForSubstitute = false },
                        new Member { Id = 3, Name = "Mike Wilson", Email = "mike@email.com", Status = AttendanceStatus.Going, AvailableForSubstitute = true },
                        new Member { Id = 4, Name = "Lisa Brown", Email = "lisa@email.com", Status = AttendanceStatus.NotSet, AvailableForSubstitute = true },
                        new Member { Id = 5, Name = "Tom Harris", Email = "tom@email.com", Status = AttendanceStatus.Going, AvailableForSubstitute = false }
                    },
                    UpcomingSessions = new List<Session>
                    {
                        new Session { Id = 1, DateTime = DateTime.Now.AddDays(2), Location = "Court 1" },
                        new Session { Id = 2, DateTime = DateTime.Now.AddDays(9), Location = "Court 1" }
                    },
                    Messages = new List<ChatMessage>
                    {
                        new ChatMessage { Id = 1, SenderName = "Sarah Johnson", Message = "Great session today everyone! Remember to bring water next time.", Timestamp = DateTime.Now.AddHours(-2), IsCoach = true },
                        new ChatMessage { Id = 2, SenderName = "John Doe", Message = "Thanks coach! Will do.", Timestamp = DateTime.Now.AddHours(-1), IsCoach = false }
                    }
                },
                new HobbyGroup
                {
                    Id = 2,
                    Name = "Intermediate Badminton",
                    HobbyType = "Sports",
                    CoachName = "David Chen",
                    Location = "Central Sports Center",
                    Latitude = 54.687,
                    Longitude = 25.279,
                    Schedule = "Wednesday 19:00 - 21:00",
                    Price = 20.00m,
                    MaxMembers = 10,
                    CurrentMembers = 9,
                    Members = new List<Member>
                    {
                        new Member { Id = 6, Name = "Alex Turner", Email = "alex@email.com", Status = AttendanceStatus.Going, AvailableForSubstitute = false },
                        new Member { Id = 7, Name = "Sophie Lee", Email = "sophie@email.com", Status = AttendanceStatus.Going, AvailableForSubstitute = true }
                    },
                    UpcomingSessions = new List<Session>
                    {
                        new Session { Id = 3, DateTime = DateTime.Now.AddDays(4), Location = "Court 2" }
                    },
                    Messages = new List<ChatMessage>()
                },
                new HobbyGroup
                {
                    Id = 3,
                    Name = "Ceramics - Open Studio",
                    HobbyType = "Arts & Crafts",
                    CoachName = "Maria Garcia",
                    Location = "Creative Arts Studio",
                    Latitude = 54.695,
                    Longitude = 25.285,
                    Schedule = "Thursday 20:00 - 22:00",
                    Price = 25.00m,
                    MaxMembers = 8,
                    CurrentMembers = 5,
                    Members = new List<Member>
                    {
                        new Member { Id = 8, Name = "Oliver Green", Email = "oliver@email.com", Status = AttendanceStatus.Going, AvailableForSubstitute = false }
                    },
                    UpcomingSessions = new List<Session>
                    {
                        new Session { Id = 4, DateTime = DateTime.Now.AddDays(5), Location = "Studio A" }
                    },
                    Messages = new List<ChatMessage>()
                },
                new HobbyGroup
                {
                    Id = 4,
                    Name = "Morning Yoga Flow",
                    HobbyType = "Fitness",
                    CoachName = "Priya Patel",
                    Location = "Wellness Center",
                    Latitude = 54.682,
                    Longitude = 25.275,
                    Schedule = "Tuesday & Friday 07:00 - 08:00",
                    Price = 12.00m,
                    MaxMembers = 15,
                    CurrentMembers = 12,
                    Members = new List<Member>
                    {
                        new Member { Id = 9, Name = "Rachel Kim", Email = "rachel@email.com", Status = AttendanceStatus.Maybe, AvailableForSubstitute = true }
                    },
                    UpcomingSessions = new List<Session>
                    {
                        new Session { Id = 5, DateTime = DateTime.Now.AddDays(1), Location = "Studio 1" }
                    },
                    Messages = new List<ChatMessage>()
                },
                new HobbyGroup
                {
                    Id = 5,
                    Name = "Oil Painting Basics",
                    HobbyType = "Arts & Crafts",
                    CoachName = "Thomas Anderson",
                    Location = "Art House Vilnius",
                    Latitude = 54.690,
                    Longitude = 25.290,
                    Schedule = "Saturday 14:00 - 17:00",
                    Price = 30.00m,
                    MaxMembers = 10,
                    CurrentMembers = 7,
                    Members = new List<Member>(),
                    UpcomingSessions = new List<Session>
                    {
                        new Session { Id = 6, DateTime = DateTime.Now.AddDays(6), Location = "Studio B" }
                    },
                    Messages = new List<ChatMessage>()
                }
            };
        }
    }
}