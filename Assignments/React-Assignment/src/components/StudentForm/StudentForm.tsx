import { createPortal } from 'react-dom';
import './StudentForm.scss';
import { useContext, useRef } from 'react';
import StudentFormModalContext from '../../contexts/StudentFormModalContext';
import useAddStudent from '../../hooks/student/useAddStudent';
const StudentForm = () => {
    const { closeModal } = useContext(StudentFormModalContext);

    const addStudent = useAddStudent();

    const nameRef = useRef<HTMLInputElement>(null);
    const emailRef = useRef<HTMLInputElement>(null);

    const handleSubmit = (e: React.SubmitEvent<HTMLFormElement>) => {
        e.preventDefault();
        const name = nameRef.current?.value ?? '';
        const email = emailRef.current?.value ?? '';

        if (!name || !email) {
            return alert('Please fill the fields');
        }

        addStudent.mutate({ name, email });
        closeModal();
    };

    return createPortal(
        <div className="student-form-modal-overlay">
            <div className="student-form-modal">
                <div className="student-form-modal-header">
                    <h2 className="student-form-modal-title">Add Student</h2>
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
                    <button type="submit" className="student-form-submit">
                        Submit
                    </button>
                </form>
            </div>
        </div>,
        document.getElementById('root-modal') as HTMLElement,
    );
};
export default StudentForm;
