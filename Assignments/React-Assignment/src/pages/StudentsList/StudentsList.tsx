import { Link } from 'react-router';
import './StudentsList.scss';

const StudentsList = () => {
    return (
        <div className="page students-list-page">
            <h1 className="page-title">Students</h1>
            <ul className="student-list">
                <li className="student-list-item">
                    <Link to={`/student/id`} className="student-link">
                        <span className="student-name">Ismaeel Moussa</span>
                        <span className="student-email">
                            ismaeel.moussa@email.com
                        </span>
                    </Link>
                    <div className="student-list-actions">
                        <button type="button" className="student-list-edit-btn">
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
            </ul>
        </div>
    );
};
export default StudentsList;
