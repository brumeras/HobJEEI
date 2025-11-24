import '../styles/dashboard.css';

const upcomingSessions = [
  { id: '1', name: 'Beginners · Mon 18:00', status: 'Going', coach: 'Marco', location: 'Court 2' },
  { id: '2', name: 'Intermediate · Tue 19:30', status: 'Maybe', coach: 'Sara', location: 'Court 1' },
  { id: '3', name: 'Singles Drills · Thu 17:00', status: 'Need RSVP', coach: 'Marco', location: 'Court 3' },
];

const substituteSlots = [
  { day: 'Wed', time: '19:30', type: 'Intermediate', active: true },
  { day: 'Fri', time: '17:00', type: 'Singles', active: false },
  { day: 'Sun', time: '10:00', type: 'Open Play', active: true },
];

const notifications = [
  { id: 'n1', text: 'Spot opened in Beginners · Mon 18:00. Join?', time: '5m ago' },
  { id: 'n2', text: 'Coach Marco: Bring indoor shoes.', time: '1h ago' },
  { id: 'n3', text: 'Reminder: RSVP for Thu Singles', time: '3h ago' },
];

export default function ParticipantDashboard() {
  return (
    <div className="dashboard participant">
      <aside className="sidebar">
        <div className="logo">HobJEEI</div>
        <nav>
          <button>My Groups</button>
          <button>Calendar</button>
          <button>Substitution Slots</button>
          <button>Notifications</button>
          <button>Chats</button>
          <button>Profile</button>
          <button>Discovery Map</button>
        </nav>
      </aside>

      <main className="content">
        <header className="top-bar">
          <div>
            <h1>Participant Dashboard</h1>
            <p>See today’s sessions, RSVP quickly, and manage substitute availability.</p>
          </div>
          <div className="top-actions">
            <button>Invite Friend</button>
            <button className="ghost">Update Profile</button>
          </div>
        </header>

        <section className="metrics">
          <div className="card">
            <h3>Next Sessions</h3>
            {upcomingSessions.map((session) => (
              <div key={session.id} className="session participant-session">
                <div>
                  <strong>{session.name}</strong>
                  <p>
                    Coach {session.coach} • {session.location}
                  </p>
                </div>
                <div className="chip-row">
                  <span className="chip neutral">{session.status}</span>
                  <button className="ghost small">Change RSVP</button>
                </div>
              </div>
            ))}
          </div>

          <div className="card">
            <h3>Attendance</h3>
            <div className="chart-placeholder">Calendar heatmap placeholder</div>
            <p>Streak: 4 sessions • Avg attendance 82%</p>
          </div>

          <div className="card">
            <h3>Reminders</h3>
            <ul>
              <li>RSVP for Thu Singles by 12:00</li>
              <li>Confirm substitute slot for Fri 17:00</li>
              <li>New hobby near you: Yoga Flow</li>
            </ul>
          </div>
        </section>

        <section className="substitution">
          <div className="card">
            <div className="card-header">
              <h3>My Substitution Slots</h3>
              <button className="ghost">Manage</button>
            </div>
            <div className="slot-grid">
              {substituteSlots.map((slot) => (
                <div key={slot.day + slot.time} className={`slot ${slot.active ? 'active' : ''}`}>
                  <strong>
                    {slot.day} · {slot.time}
                  </strong>
                  <p>{slot.type}</p>
                  <button className="ghost small">{slot.active ? 'Disable' : 'Enable'}</button>
                </div>
              ))}
            </div>
          </div>
        </section>

        <section className="groups">
          <h3>Notifications & Requests</h3>
          <div className="group-grid">
            <div className="card">
              <h4>Live Alerts</h4>
              <ul className="message-list">
                {notifications.map((note) => (
                  <li key={note.id}>
                    <strong>{note.time}</strong> {note.text}
                    <div className="card-actions">
                      <button className="ghost small">Dismiss</button>
                      <button className="small">Respond</button>
                    </div>
                  </li>
                ))}
              </ul>
            </div>
            <div className="card">
              <h4>Group Chat</h4>
              <div className="chat-preview">
                <p>
                  <strong>Coach Marco:</strong> Need one more for Monday. Anyone available?
                </p>
                <p>
                  <strong>You:</strong> I can confirm by 3pm.
                </p>
                <p>
                  <strong>Ana:</strong> I’m in! see you there.
                </p>
              </div>
              <textarea placeholder="Send a quick reply…" rows={4} />
              <div className="card-actions">
                <button>Send</button>
                <button className="ghost">Attach</button>
              </div>
            </div>
          </div>
        </section>

        <section className="communications">
          <div className="card">
            <h3>Upcoming Map Spots</h3>
            <div className="chart-placeholder">Mini map placeholder</div>
            <p>Suggested: Yoga Flow • Ceramics Lab • Pickleball Social</p>
          </div>
          <div className="card">
            <h3>Profile Snapshot</h3>
            <ul>
              <li>Groups: Beginners Mon, Intermediate Tue</li>
              <li>Preferred roles: Doubles / Singles</li>
              <li>Notifications: Push + Email</li>
            </ul>
            <button className="ghost">Edit Preferences</button>
          </div>
        </section>
      </main>
    </div>
  );
}

