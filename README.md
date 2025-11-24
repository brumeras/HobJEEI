# HobJEEI  
### Smart Attendance, Scheduling & Substitute Matching for Hobbies  
*A demo app built for the ISM University Student Vibe Coding Hackathon*

HobJEEI is a modern, simplified attendance and communication app designed for hobby groups—especially badminton trainings—where scheduling currently happens through messy WhatsApp/Messenger chats, manual attendance checks, and inefficient substitute searching.

This project demonstrates how clean UX, smart automation, and real-time updates can modernize how coaches and participants manage their hobby sessions.

---

## 🎯 Why HobJEEI?
Most hobby groups still rely on:
- WhatsApp/Messenger chats  
- Manual “Who’s coming?” messages  
- Coaches tracking attendance manually  
- Asking multiple groups for substitutes  

This creates confusion, wasted time, and constant disorganization.

**HobJEEI solves all of this with one centralized, intuitive platform.**

---

## 👥 Target Users

### 1. Coaches / Organizers (Admins)
- Create and manage multiple training groups  
- Set schedules, time, price, and location  
- Add/remove participants  
- Send announcements or messages  
- See attendance at a glance  
- Enable auto-substitute matching  
- Configure attendance reminders  

### 2. Participants / Hobby Members
- Join groups via link or code  
- Mark attendance (Going / Maybe / Can’t)  
- Chat with coach or group  
- Set availability for substitute slots  
- Receive alerts when a spot opens  
- View personal schedule and sessions  

---

## 🚀 Core Features

### 1. Coach/Organizer Dashboard
- Login as creator/editor  
- Create and configure training groups  
- Set group capacity, price, location  
- Send announcements (mock push notifications)  

### 2. Participant Onboarding
- Join groups via invite link/code  
- Minimal login (demo-friendly)  
- Automatic group assignment  
- Includes 1:1 and group chat  

### 3. Simple Attendance System
Each session shows:
- **Going**  
- **Maybe**  
- **Can’t**  

Real-time updates (mocked) let coaches instantly track attendance without chat spam.

### 4. Automatic Substitute Finder (Flagship Feature)
When a participant selects **Can’t**:
1. System checks users available during that time slot  
2. Sends them a notification:  
   *“A spot opened for Badminton Beginners – Monday 18:00. Want to join?”*  
3. First substitute to accept fills the spot (mock logic)  

This eliminates manual searching across groups.

### 5. Integrated Chat
- Group chat  
- 1:1 chat with coach  
- Push-style notifications in the demo  

### 6. Attendance Reminders
Coaches can configure:
- 24h reminder  
- 3h reminder  
- No reminders  
- Multiple reminders  

Participants receive attendance confirmation alerts.

### 7. Hobby Discovery Map (Future Vision)
A simple demo map showing:
- Nearby hobby centers  
- Filters for type, distance, time, price  
- Clickable locations showing available groups  

### 8. User Profiles
Each user profile includes:
- Name  
- Groups joined  
- Substitute availability time slots  
- Notification preferences  
- Hobbies followed  

### 9. Bonus Demo Features
- Light/Dark mode  
- CSV export of attendance (mock)  
- Calendar view of upcoming sessions  
- Suggested hobbies screen  
- Coach dashboard with group overview  

---

## 🌟 Future Improvements

### Auto-Fill Group Capacity
When someone cancels:
- The first substitute who accepts is added automatically  
- Spot is locked to avoid duplicates  

### Attendance Analytics
Charts showing:
- Frequent attendees  
- Cancellation patterns  
- Average attendance over time  

### Last-Minute Alerts
If cancellation occurs <1h before:
- Mark as urgent  
- Send fast substitute request  
- Notify coach separately  

---

## Workspace Layout (local repo)

Alongside the Blazor/Razor project above, this repo now includes a full-stack playground with:

- `backend/HobJEEI/`: original hackathon Blazor app (this repo’s earlier state).
- `backend/HobJeei.Api`: placeholder ASP.NET Core Web API (to be scaffolded).
- `backend/HobJeei.Api.Tests`: placeholder for backend unit/integration tests.
- `frontend/`: React SPA prototype that visualizes the coach & participant dashboards.
- `shared/contracts`: future home for shared DTOs/OpenAPI specs.
- `docs/`: architecture and setup notes.

### Getting started locally

1. **React frontend**
   ```
   cd frontend
   npm install
   npm run dev
   ```
   Toggle between Coach/Participant dashboards from the UI.

2. **Blazor backend**
   ```
   cd backend/HobJEEI/HobJEEI
   dotnet run
   ```
   Serves the original Razor-based prototype.

3. **Future Web API**
   - `cd backend/HobJeei.Api && dotnet new webapi -n HobJeei.Api`
   - Add EF Core, controllers, etc., as needed.

Keep Razor views if you want server-rendered UI; otherwise expose JSON endpoints and let the React frontend handle the experience.
