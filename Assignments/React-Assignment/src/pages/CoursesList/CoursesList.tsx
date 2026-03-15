import { Link } from 'react-router';
import './CoursesList.scss';

const CoursesList = () => {
    return (
        <div className="page courses-list-page">
            <h1 className="page-title">courses</h1>
            <ul className="course-list">
                <li className="course-list-item">
                    <Link to={`/course/id`} className="course-link">
                        <span className="course-name">OOP</span>
                        <span className="course-credit">Credit : 3</span>
                    </Link>
                    <div className="course-list-actions">
                        <button type="button" className="course-list-edit-btn">
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
            </ul>
        </div>
    );
};
export default CoursesList;
