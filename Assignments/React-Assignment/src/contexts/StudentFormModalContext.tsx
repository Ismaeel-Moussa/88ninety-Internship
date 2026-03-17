import { createContext, useState } from 'react';
import type { Student } from '../types/Student';

export type StudentFormMode = 'add' | 'edit' | null;

type StudentFormModalContextValue = {
    mode: StudentFormMode;
    studentToEdit: Student | null;
    openAddModal: () => void;
    openEditModal: (student: Student) => void;
    closeModal: () => void;
};

const StudentFormModalContext = createContext<StudentFormModalContextValue>({
    mode: null,
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
    const [mode, setMode] = useState<StudentFormMode>(null);
    const [studentToEdit, setStudentToEdit] = useState<Student | null>(null);

    const openAddModal = () => {
        setStudentToEdit(null);
        setMode('add');
    };

    const openEditModal = (student: Student) => {
        setStudentToEdit(student);
        setMode('edit');
    };

    const closeModal = () => {
        setMode(null);
        setStudentToEdit(null);
    };

    return (
        <StudentFormModalContext.Provider
            value={{
                mode,
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
