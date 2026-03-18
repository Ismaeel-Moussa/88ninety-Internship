import './App.scss';
import Navbar from './components/Navbar/Navbar';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import StudentsList from './pages/StudentsList/StudentsList';
import CoursesList from './pages/CoursesList/CoursesList';
import HomePage from './pages/HomePage/HomePage';
import StudentForm from './components/StudentForm/StudentForm';
import { useContext } from 'react';
import StudentFormModalContext from './contexts/StudentFormModalContext';
import CourseFormModalContext from './contexts/CourseFormModalContext';
import CourseForm from './components/CourseForm/CourseForm';

function App() {
    const { studentFormMode } = useContext(StudentFormModalContext);
    const { courseFormMode } = useContext(CourseFormModalContext);

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
            {studentFormMode != null && <StudentForm />}
            {courseFormMode != null && <CourseForm />}
        </BrowserRouter>
    );
}

export default App;
