import { NavLink } from 'react-router-dom';
import './HomePage.scss';
const HomePage = () => {
    return (
        <div className="home-page">
            <h1>Welcome To Altinbas University System</h1>
            <NavLink className="link" to="/students">
                Go to students
            </NavLink>
        </div>
    );
};
export default HomePage;
