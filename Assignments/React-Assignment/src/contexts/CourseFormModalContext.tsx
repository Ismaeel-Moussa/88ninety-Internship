import { createContext, useState } from 'react';
import type { Course } from '../types/Course';

export type CourseFormMode = 'add' | 'edit' | null;

type CourseFormModalContextValue = {
    courseFormMode: CourseFormMode;
    CourseToEdit: Course | null;
    openAddModal: () => void;
    openEditModal: (Course: Course) => void;
    closeModal: () => void;
};

const CourseFormModalContext = createContext<CourseFormModalContextValue>({
    courseFormMode: null,
    CourseToEdit: null,
    openAddModal: () => {},
    openEditModal: () => {},
    closeModal: () => {},
});

export const CourseFormModalContextProvider = ({
    children,
}: {
    children: React.ReactNode;
}) => {
    const [courseFormMode, setCourseFormMode] = useState<CourseFormMode>(null);
    const [CourseToEdit, setCourseToEdit] = useState<Course | null>(null);

    const openAddModal = () => {
        setCourseToEdit(null);
        setCourseFormMode('add');
    };

    const openEditModal = (Course: Course) => {
        setCourseToEdit(Course);
        setCourseFormMode('edit');
    };

    const closeModal = () => {
        setCourseFormMode(null);
        setCourseToEdit(null);
    };

    return (
        <CourseFormModalContext.Provider
            value={{
                courseFormMode,
                CourseToEdit,
                openAddModal,
                openEditModal,
                closeModal,
            }}
        >
            {children}
        </CourseFormModalContext.Provider>
    );
};

export default CourseFormModalContext;
