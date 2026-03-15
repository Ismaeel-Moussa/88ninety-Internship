import { NavLink } from 'react-router-dom';
import './Navbar.scss';

const Navbar = () => {
    return (
        <nav className="nav">
            <div className="nav-logo-container">
                <img
                    src="../../assets/altinbas-logo.png"
                    alt="logo"
                    className="nav-logo"
                />
                <span className="nav-brand">University System</span>
            </div>
            <div className="nav-links">
                <NavLink
                    to="/"
                    className={({ isActive }) =>
                        isActive ? 'nav-link active' : 'nav-link'
                    }
                >
                    Home
                </NavLink>
                <NavLink
                    to="/students"
                    className={({ isActive }) =>
                        isActive ? 'nav-link active' : 'nav-link'
                    }
                >
                    Students
                </NavLink>
                <NavLink
                    to="/courses"
                    className={({ isActive }) =>
                        isActive ? 'nav-link active' : 'nav-link'
                    }
                >
                    Courses
                </NavLink>
            </div>
        </nav>
    );
};
export default Navbar;
