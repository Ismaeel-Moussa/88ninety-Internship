import { useParams, Link } from 'react-router-dom';
import './CourseDetail.scss';
import useGetCourses from '../../hooks/course/useGetCourses';

const CourseDetail = () => {
    const { id } = useParams();
    const { data: coursesData, isLoading, isError, error } = useGetCourses();

    if (isLoading) {
        <div className="course-detail-page">loading Courses</div>;
    }

    if (isError) {
        <div className="course-detail-page">error: {error.message}</div>;
    }

    const Course = coursesData?.find((s) => s.id == id);

    if (!Course) {
        return (
            <div className="page course-detail-page">
                <p className="not-found-message">Course not found</p>
                <Link to="/courses" className="btn btn-primary">
                    Back to list
                </Link>
            </div>
        );
    }

    return (
        <div className="page course-detail-page">
            <Link to="/courses" className="back-link">
                Back to list
            </Link>
            <div className="detail-card">
                <h1 className="detail-name">{Course.name}</h1>
                <dl className="detail-fields">
                    <dt>Credit</dt>
                    <dd>{Course.credit}</dd>
                </dl>
            </div>
        </div>
    );
};

export default CourseDetail;
