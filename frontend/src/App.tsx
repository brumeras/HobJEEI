import { useState } from 'react';
import CoachDashboard from './pages/CoachDashboard';
import ParticipantDashboard from './pages/ParticipantDashboard';

type ViewMode = 'coach' | 'participant';

function App() {
  const [mode, setMode] = useState<ViewMode>('coach');

  return (
    <>
      <div className="view-toggle">
        <button
          className={mode === 'coach' ? 'active' : ''}
          onClick={() => setMode('coach')}
        >
          Coach View
        </button>
        <button
          className={mode === 'participant' ? 'active' : ''}
          onClick={() => setMode('participant')}
        >
          Participant View
        </button>
      </div>
      {mode === 'coach' ? <CoachDashboard /> : <ParticipantDashboard />}
    </>
  );
}

export default App;

