import { useState, useEffect } from 'react'
import axios from 'axios'

function App() {
  const [habits, setHabits] = useState([]);

  useEffect(() => {
    // Fungsi untuk mengambil data dari Backend
    const fetchHabits = async () => {
      try {
        const response = await axios.get('http://localhost:5207/api/Habit');
        setHabits(response.data);
      } catch (error) {
        console.error("Gagal mengambil data:", error);
      }
    };

    fetchHabits();
  }, []);

  return (
    <div className="min-h-screen bg-gray-900 text-white p-10">
      <h1 className="text-4xl font-bold text-green-400 mb-6">Daftar Habit Saya</h1>
      
      {habits.length === 0 ? (
        <p className="text-gray-400">Belum ada habit yang dimuat...</p>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          {habits.map((habit) => (
            <div key={habit.habitId} className="bg-gray-800 p-5 rounded-lg shadow-md border border-gray-700">
              <h2 className="text-xl font-semibold text-blue-300">{habit.habitName}</h2>
              <p className="text-gray-400 mt-2">Kategori: <span className="text-orange-400">{habit.groupName}</span></p>
              <p className="text-gray-400">Waktu: {habit.reminderTime}</p>
            </div>
          ))}
        </div>
      )}
    </div>
  )
}

export default App