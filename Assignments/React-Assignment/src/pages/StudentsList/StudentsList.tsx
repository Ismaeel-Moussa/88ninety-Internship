import { Link } from 'react-router';
import './StudentsList.scss';
import useGetStudents from '../../hooks/student/useGetStudents';
import type { Student } from '../../types/Student';
import { useContext } from 'react';
import StudentFormModalContext from '../../contexts/StudentFormModalContext';
import useDeleteStudent from '../../hooks/student/useDeleteStudent';

const StudentsList = () => {
    const { data: studentsData, isLoading, isError, error } = useGetStudents();
    const deleteStudent = useDeleteStudent();
    const { openAddModal, openEditModal } = useContext(StudentFormModalContext);

    if (isLoading) {
        return <div className="student-list-page">loading students...</div>;
    }

    if (isError) {
        return <div className="student-list-page">error: {error.message}</div>;
    }

    if (studentsData?.length === 0) {
        return <div className="student-list-page">No students found</div>;
    }

    return (
        <>
            <div className="students-list-page-header">
                <h1 className="page-title">Students</h1>
                <button onClick={openAddModal}>Add Student</button>
            </div>
            <div className="page students-list-page">
                <ul className="student-list">
                    {studentsData?.map((s: Student) => (
                        <li key={s.id} className="student-list-item">
                            <Link
                                to={`/students/${s.id}`}
                                className="student-link"
                            >
                                <span className="student-name">{s.name}</span>
                                <span className="student-email">{s.email}</span>
                            </Link>
                            <div className="student-list-actions">
                                <button
                                    type="button"
                                    className="student-list-edit-btn"
                                    onClick={(e) => {
                                        e.preventDefault();
                                        openEditModal(s);
                                    }}
                                >
                                    Edit
                                </button>
                                <button
                                    type="button"
                                    className="student-list-delete-btn"
                                    onClick={() =>
                                        s.id != null &&
                                        deleteStudent.mutate(s.id)
                                    }
                                    disabled={deleteStudent.isPending}
                                >
                                    {deleteStudent.isPending
                                        ? 'Deleting...'
                                        : 'Delete'}
                                </button>
                            </div>
                        </li>
                    ))}
                </ul>
            </div>
        </>
    );
};
export default StudentsList;
