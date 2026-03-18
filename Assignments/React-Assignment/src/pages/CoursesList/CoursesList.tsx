import { Link } from 'react-router';
import './CoursesList.scss';
import useGetCourses from '../../hooks/course/useGetCourses';
import useDeleteCourse from '../../hooks/course/useDeleteCourse';
import type { Course } from '../../types/Course';
import CourseFormModalContext from '../../contexts/CourseFormModalContext';
import { useContext } from 'react';

const CoursesList = () => {
    const { data: coursesData, isLoading, isError, error } = useGetCourses();
    const deleteCourse = useDeleteCourse();
    const { openAddModal, openEditModal } = useContext(CourseFormModalContext);

    if (isLoading) {
        return <div className="course-list-page">loading courses...</div>;
    }

    if (isError) {
        return <div className="course-list-page">error: {error.message}</div>;
    }

    if (coursesData?.length === 0) {
        return <div className="course-list-page">No courses found</div>;
    }

    return (
        <>
            <div className="courses-list-page-header">
                <h1 className="page-title">Courses</h1>
                <button onClick={openAddModal}>Add Course</button>
            </div>
            <div className="page courses-list-page">
                <ul className="course-list">
                    {coursesData?.map((s: Course) => (
                        <li key={s.id} className="course-list-item">
                            <Link
                                to={`/Courses/${s.id}`}
                                className="course-link"
                            >
                                <span className="course-name">{s.name}</span>
                                <span className="course-credit">
                                    {s.credit}
                                </span>
                            </Link>
                            <div className="course-list-actions">
                                <button
                                    type="button"
                                    className="course-list-edit-btn"
                                    onClick={(e) => {
                                        e.preventDefault();
                                        openEditModal(s);
                                    }}
                                >
                                    Edit
                                </button>
                                <button
                                    type="button"
                                    className="course-list-delete-btn"
                                    onClick={() =>
                                        s.id != null &&
                                        deleteCourse.mutate(s.id)
                                    }
                                    disabled={deleteCourse.isPending}
                                >
                                    {deleteCourse.isPending
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
export default CoursesList;
