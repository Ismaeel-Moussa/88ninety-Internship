import { createContext, useState } from 'react';
import type { Student } from '../types/Student';

export type StudentFormMode = 'add' | 'edit' | null;

type StudentFormModalContextValue = {
    studentFormMode: StudentFormMode;
    studentToEdit: Student | null;
    openAddModal: () => void;
    openEditModal: (student: Student) => void;
    closeModal: () => void;
};

const StudentFormModalContext = createContext<StudentFormModalContextValue>({
    studentFormMode: null,
    studentToEdit: null,
    openAddModal: () => {},
    openEditModal: () => {},
    closeModal: () => {},
});

export const StudentFormModalContextProvider = ({
    children,
}: {
    children: React.ReactNode;
}) => {
    const [studentFormMode, setStudentFormMode] =
        useState<StudentFormMode>(null);
    const [studentToEdit, setStudentToEdit] = useState<Student | null>(null);

    const openAddModal = () => {
        setStudentToEdit(null);
        setStudentFormMode('add');
    };

    const openEditModal = (student: Student) => {
        setStudentToEdit(student);
        setStudentFormMode('edit');
    };

    const closeModal = () => {
        setStudentFormMode(null);
        setStudentToEdit(null);
    };

    return (
        <StudentFormModalContext.Provider
            value={{
                studentFormMode,
                studentToEdit,
                openAddModal,
                openEditModal,
                closeModal,
            }}
        >
            {children}
        </StudentFormModalContext.Provider>
    );
};

export default StudentFormModalContext;
