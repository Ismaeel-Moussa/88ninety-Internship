import { createPortal } from 'react-dom';
import './StudentForm.scss';
const StudentForm = () => {
    return createPortal(
        <div className="student-form-modal-overlay">
            <div className="student-form-modal">
                <div className="student-form-modal-header">
                    <h2 className="student-form-modal-title">Add Student</h2>
                    <button
                        type="button"
                        className="student-form-modal-close"
                        aria-label="Close"
                    >
                        x
                    </button>
                </div>
                <form className="student-form-form">
                    <input
                        type="text"
                        placeholder="Name"
                        className="student-form-input"
                    />
                    <input
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
