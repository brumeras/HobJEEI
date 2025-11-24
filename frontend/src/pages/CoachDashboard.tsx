import '../styles/dashboard.css';

type SessionStatus = 'Green' | 'Amber' | 'Red';

type Session = {
  id: string;
  group: string;
  date: string;
  status: SessionStatus;
};

const upcomingSessions: Session[] = [
  { id: '1', group: 'Beginners · Mon 18:00', date: 'Mon • 18:00', status: 'Green' },
  { id: '2', group: 'Intermediate · Tue 19:30', date: 'Tue • 19:30', status: 'Amber' },
  { id: '3', group: 'Singles Drills · Thu 17:00', date: 'Thu • 17:00', status: 'Red' },
];

const substitutionQueue = [
  { member: 'Alice', group: 'Beginners · Mon', requested: '1 hr ago' },
  { member: 'Leo', group: 'Intermediate · Tue', requested: '3 hr ago' },
];

const groupCards = [
  { name: 'Beginners · Mon 18:00', capacity: '8 / 10', next: 'Tonight', trend: '+12% RSVPs' },
  { name: 'Intermediate · Tue 19:30', capacity: '10 / 12', next: 'Tomorrow', trend: '-5% RSVPs' },
  { name: 'Singles Drills · Thu 17:00', capacity: '6 / 8', next: 'Thu', trend: 'Stable' },
];

export default function CoachDashboard() {
  return (
    <div className="dashboard">
      <aside className="sidebar">
        <div className="logo">HobJEEI</div>
        <nav>
          <button>Dashboard</button>
          <button>Groups</button>
          <button>Sessions</button>
          <button>Substitutions</button>
          <button>Chats</button>
          <button>Announcements</button>
          <button>Reports</button>
          <button>Settings</button>
        </nav>
      </aside>

      <main className="content">
        <header className="top-bar">
          <div>
            <h1>Coach Dashboard</h1>
            <p>Live overview of today’s trainings, attendance, and alerts.</p>
          </div>
          <div className="top-actions">
            <button>Create Group</button>
            <button className="ghost">Send Reminder</button>
          </div>
        </header>

        <section className="metrics">
          <div className="card">
            <h3>Upcoming Sessions</h3>
            {upcomingSessions.map((session) => (
              <div key={session.id} className={`session status-${session.status.toLowerCase()}`}>
                <div>
                  <strong>{session.group}</strong>
                  <p>{session.date}</p>
                </div>
                <span className="chip">{session.status}</span>
              </div>
            ))}
          </div>

          <div className="card">
            <h3>Attendance Snapshot</h3>
            <div className="chart-placeholder">Pie chart placeholder</div>
            <p>Going: 32 · Maybe: 4 · Can’t: 3</p>
          </div>

          <div className="card">
            <h3>Reminder Rules</h3>
            <ul>
              <li>Beginners · Mon — 24h & 3h before</li>
              <li>Intermediate · Tue — 12h before</li>
              <li>Singles · Thu — no reminder</li>
            </ul>
          </div>
        </section>

        <section className="substitution">
          <div className="card">
            <div className="card-header">
              <h3>Substitution Queue</h3>
              <button className="ghost">View All</button>
            </div>
            <table>
              <thead>
                <tr>
                  <th>Member</th>
                  <th>Group</th>
                  <th>Requested</th>
                  <th>Action</th>
                </tr>
              </thead>
              <tbody>
                {substitutionQueue.map((item) => (
                  <tr key={item.member + item.group}>
                    <td>{item.member}</td>
                    <td>{item.group}</td>
                    <td>{item.requested}</td>
                    <td>
                      <button>Assign</button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </section>

        <section className="groups">
          <h3>Group Overview</h3>
          <div className="group-grid">
            {groupCards.map((group) => (
              <div key={group.name} className="card">
                <h4>{group.name}</h4>
                <p>Capacity: {group.capacity}</p>
                <p>Next session: {group.next}</p>
                <p>Trend: {group.trend}</p>
                <div className="card-actions">
                  <button>Open Group</button>
                  <button className="ghost">Send Announcement</button>
                </div>
              </div>
            ))}
          </div>
        </section>

        <section className="communications">
          <div className="card">
            <h3>Recent Messages</h3>
            <ul className="message-list">
              <li>
                <strong>Ana</strong> Need shuttlecocks for Thursday?
              </li>
              <li>
                <strong>Coach Marco</strong> Reminder: bring indoor shoes.
              </li>
              <li>
                <strong>Leo</strong> Can I join Friday doubles?
              </li>
            </ul>
          </div>
          <div className="card">
            <h3>Quick Announcement</h3>
            <textarea placeholder="Type announcement…" rows={4} />
            <div className="card-actions">
              <button>Broadcast</button>
              <button className="ghost">Save Draft</button>
            </div>
          </div>
        </section>
      </main>
    </div>
  );
}

