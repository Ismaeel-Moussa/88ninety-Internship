import './App.scss';
import Navbar from './components/Navbar/Navbar';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import StudentsList from './pages/StudentsList/StudentsList';
import CoursesList from './pages/CoursesList/CoursesList';
import HomePage from './pages/HomePage/HomePage';
import StudentForm from './components/StudentForm/StudentForm';
import { useContext } from 'react';
import StudentFormModalContext from './contexts/StudentFormModalContext';

function App() {
    const { mode } = useContext(StudentFormModalContext);

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
            {mode != null && <StudentForm />}
        </BrowserRouter>
    );
}

export default App;
