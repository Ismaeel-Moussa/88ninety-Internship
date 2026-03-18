import { Link } from 'react-router';
import './CoursesList.scss';
import useGetCourses from '../../hooks/course/useGetCourses';
import useDeleteCourse from '../../hooks/course/useDeleteCourse';
import type { Course } from '../../types/Course';
import CourseFormModalContext from '../../contexts/CourseFormModalContext';
import { useContext } from 'react';
import Button from '../../components/Shared/Button';

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
                    {coursesData?.map((c: Course) => (
                        <li key={c.id} className="course-list-item">
                            <Link
                                to={`/Courses/${c.id}`}
                                className="course-link"
                            >
                                <span className="course-name">{c.name}</span>
                                <span className="course-credit">
                                    Credit: {c.credit}
                                </span>
                            </Link>
                            <div className="course-list-actions">
                                <Button
                                    type="edit"
                                    onClick={(e) => {
                                        e.preventDefault();
                                        openEditModal(c);
                                    }}
                                    label="Edit"
                                />
                                <Button
                                    type="delete"
                                    onClick={() =>
                                        c.id != null &&
                                        deleteCourse.mutate(c.id)
                                    }
                                    label={
                                        deleteCourse.isPending
                                            ? 'Deleting...'
                                            : 'Delete'
                                    }
                                    disabled={deleteCourse.isPending}
                                />
                            </div>
                        </li>
                    ))}
                </ul>
            </div>
        </>
    );
};
export default CoursesList;
