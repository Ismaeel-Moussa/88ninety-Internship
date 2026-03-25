import { useParams, Link } from 'react-router-dom';
import './StudentDetail.scss';
import useGetStudents from '../../hooks/student/useGetStudents';

const StudentDetail = () => {
    const { id } = useParams();
    const { data: studentsData, isLoading, isError, error } = useGetStudents();

    if (isLoading) {
        <div className="student-detail-page">loading students</div>;
    }

    if (isError) {
        <div className="student-detail-page">error: {error.message}</div>;
    }

    const student = studentsData?.find((s) => s.id == id);
    console.log(student);
    if (!student) {
        return (
            <div className="page student-detail-page">
                <p className="not-found-message">Student not found</p>
                <Link to="/students" className="btn btn-primary">
                    Back to list
                </Link>
            </div>
        );
    }

    return (
        <div className="page student-detail-page">
            <Link to="/students" className="back-link">
                Back to list
            </Link>
            <div className="detail-card">
                <h1 className="detail-name">{student.name}</h1>
                <dl className="detail-fields">
                    <dt>Email</dt>
                    <dd>{student.email}</dd>
                </dl>
            </div>
        </div>
    );
};

export default StudentDetail;
