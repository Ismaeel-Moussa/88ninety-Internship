import { createPortal } from 'react-dom';
import './CourseForm.scss';
import { useContext, useEffect, useRef } from 'react';
import CourseFormModalContext from '../../contexts/CourseFormModalContext';
import useAddCourse from '../../hooks/course/useAddCourse';
import useUpdateCourse from '../../hooks/course/useUpdateCourse';

const CourseForm = () => {
    const { closeModal, courseFormMode, CourseToEdit } = useContext(
        CourseFormModalContext,
    );
    const addCourse = useAddCourse();
    const updateCourse = useUpdateCourse();
    const nameRef = useRef<HTMLInputElement>(null);
    const creditRef = useRef<HTMLInputElement>(null);
    const isEdit = courseFormMode === 'edit';

    useEffect(() => {
        if (!isEdit || !CourseToEdit) return;
        if (nameRef.current) nameRef.current.value = CourseToEdit.name;
        if (creditRef.current) creditRef.current.value = CourseToEdit.credit;
    }, [isEdit, CourseToEdit]);

    const handleSubmit = (e: React.SubmitEvent<HTMLFormElement>) => {
        e.preventDefault();
        const name = nameRef.current?.value ?? '';
        const credit = creditRef.current?.value ?? '';

        if (!name || !credit) {
            return alert('Please fill the fields');
        }

        if (isEdit && CourseToEdit?.id) {
            updateCourse.mutate(
                { ...CourseToEdit, name, credit },
                { onSuccess: () => closeModal() },
            );
        } else {
            addCourse.mutate(
                { name, credit },
                { onSuccess: () => closeModal() },
            );
        }
    };

    if (courseFormMode == null) return null;

    const title = isEdit ? 'Edit Course' : 'Add Course';
    const submitLabel = isEdit
        ? updateCourse.isPending
            ? 'Saving...'
            : 'Save Changes'
        : addCourse.isPending
          ? 'Adding...'
          : 'Add Course';

    const isPending = updateCourse.isPending || addCourse.isPending;

    return createPortal(
        <div className="course-form-modal-overlay">
            <div className="course-form-modal">
                <div className="course-form-modal-header">
                    <h2 className="course-form-modal-title">{title}</h2>
                    <button
                        type="button"
                        className="course-form-modal-close"
                        aria-label="Close"
                        onClick={closeModal}
                    >
                        x
                    </button>
                </div>
                <form className="course-form-form" onSubmit={handleSubmit}>
                    <input
                        ref={nameRef}
                        type="text"
                        placeholder="Name"
                        className="course-form-input"
                    />
                    <input
                        ref={creditRef}
                        type="credit"
                        placeholder="credit"
                        className="course-form-input"
                    />
                    <button
                        type="submit"
                        className="course-form-submit"
                        disabled={isPending}
                    >
                        {submitLabel}
                    </button>
                </form>
            </div>
        </div>,
        document.getElementById('root-course-modal') as HTMLElement,
    );
};
export default CourseForm;
