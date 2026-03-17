import { createPortal } from 'react-dom';
import './StudentForm.scss';
import { useContext, useEffect, useRef } from 'react';
import StudentFormModalContext from '../../contexts/StudentFormModalContext';
import useAddStudent from '../../hooks/student/useAddStudent';
import useUpdateStudent from '../../hooks/student/useUpdateStudent';
const StudentForm = () => {
    const { closeModal, mode, studentToEdit } = useContext(
        StudentFormModalContext,
    );
    const addStudent = useAddStudent();
    const updateStudent = useUpdateStudent();
    const nameRef = useRef<HTMLInputElement>(null);
    const emailRef = useRef<HTMLInputElement>(null);
    const isEdit = mode === 'edit';

    useEffect(() => {
        if (!isEdit || !studentToEdit) return;
        if (nameRef.current) nameRef.current.value = studentToEdit.name;
        if (emailRef.current) emailRef.current.value = studentToEdit.email;
    }, [isEdit, studentToEdit]);

    const handleSubmit = (e: React.SubmitEvent<HTMLFormElement>) => {
        e.preventDefault();
        const name = nameRef.current?.value ?? '';
        const email = emailRef.current?.value ?? '';

        if (!name || !email) {
            return alert('Please fill the fields');
        }

        if (isEdit && studentToEdit?.id) {
            updateStudent.mutate(
                { ...studentToEdit, name, email },
                { onSuccess: () => closeModal() },
            );
        } else {
            addStudent.mutate(
                { name, email },
                { onSuccess: () => closeModal() },
            );
        }
    };

    if (mode == null) return null;

    const title = isEdit ? 'Edit Student' : 'Add Student';
    const submitLabel = isEdit
        ? updateStudent.isPending
            ? 'Saving...'
            : 'Save Changes'
        : addStudent.isPending
          ? 'Adding...'
          : 'Add Student';

    const isPending = updateStudent.isPending || addStudent.isPending;

    return createPortal(
        <div className="student-form-modal-overlay">
            <div className="student-form-modal">
                <div className="student-form-modal-header">
                    <h2 className="student-form-modal-title">{title}</h2>
                    <button
                        type="button"
                        className="student-form-modal-close"
                        aria-label="Close"
                        onClick={closeModal}
                    >
                        x
                    </button>
                </div>
                <form className="student-form-form" onSubmit={handleSubmit}>
                    <input
                        ref={nameRef}
                        type="text"
                        placeholder="Name"
                        className="student-form-input"
                    />
                    <input
                        ref={emailRef}
                        type="email"
                        placeholder="Email"
                        className="student-form-input"
                    />
                    <button
                        type="submit"
                        className="student-form-submit"
                        disabled={isPending}
                    >
                        {submitLabel}
                    </button>
                </form>
            </div>
        </div>,
        document.getElementById('root-modal') as HTMLElement,
    );
};
export default StudentForm;
