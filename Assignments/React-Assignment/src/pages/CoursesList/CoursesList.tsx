import { Link } from 'react-router';
import './CoursesList.scss';
import useGetCourses from '../../hooks/course/useGetCourses';
import type { Course } from '../../types/Course';

const CoursesList = () => {
    const { data: coursesData } = useGetCourses();

    return (
        <div className="page courses-list-page">
            <h1 className="page-title">courses</h1>
            <ul className="course-list">
                {coursesData?.map((c: Course) => (
                    <li key={c.id} className="course-list-item">
                        <Link to={`/course/${c.id}`} className="course-link">
                            <span className="course-name">{c.name}</span>
                            <span className="course-credit">
                                Credit : {c.credit}
                            </span>
                        </Link>
                        <div className="course-list-actions">
                            s
                            <button
                                type="button"
                                className="course-list-edit-btn"
                            >
                                Edit
                            </button>
                            <button
                                type="button"
                                className="course-list-delete-btn"
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
export default CoursesList;
