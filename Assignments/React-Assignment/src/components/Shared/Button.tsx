import type { MouseEventHandler } from 'react';
import './Button.scss';

type Props = {
    type: string;
    onClick: MouseEventHandler<HTMLButtonElement>;
    label: string;
    disabled?: boolean;
};
const Button = ({ type, onClick, label, disabled }: Props) => {
    return (
        <button
            type="button"
            className={type === 'edit' ? 'list-edit-btn' : 'list-delete-btn'}
            onClick={onClick}
            disabled={disabled}
        >
            {label}
        </button>
    );
};
export default Button;
