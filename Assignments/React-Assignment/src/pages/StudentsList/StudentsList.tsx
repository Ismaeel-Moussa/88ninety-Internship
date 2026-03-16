import { Link } from 'react-router';
import './StudentsList.scss';
import useGetStudents from '../../hooks/student/useGetStudents';
import type { Student } from '../../types/Student';

const StudentsList = () => {
    const { data: studentsData } = useGetStudents();

    return (
        <div className="page students-list-page">
            <h1 className="page-title">Students</h1>
            <ul className="student-list">
                {studentsData?.map((s: Student) => (
                    <li key={s.id} className="student-list-item">
                        <Link to={`/students/${s.id}`} className="student-link">
                            <span className="student-name">{s.name}</span>
                            <span className="student-email">{s.email}</span>
                        </Link>
                        <div className="student-list-actions">
                            <button
                                type="button"
                                className="student-list-edit-btn"
                            >
                                Edit
                            </button>
                            <button
                                type="button"
                                className="student-list-delete-btn"
                            >
                                Delete
                            </button>
                        </div>
                    </li>
                ))}
            </ul>
        </div>
    );
};
export default StudentsList;
