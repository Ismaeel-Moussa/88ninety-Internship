import './App.scss';
import Navbar from './components/Navbar/Navbar';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import StudentsList from './pages/StudentsList/StudentsList';
import CoursesList from './pages/CoursesList/CoursesList';
import HomePage from './pages/HomePage/HomePage';

function App() {
    return (
        <BrowserRouter>
            <Navbar />
            <main className="main">
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/students" element={<StudentsList />} />
                    <Route path="/courses" element={<CoursesList />} />
                </Routes>
            </main>
        </BrowserRouter>
    );
}

export default App;
