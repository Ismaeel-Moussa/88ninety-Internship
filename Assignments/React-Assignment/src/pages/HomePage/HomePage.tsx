import { NavLink } from 'react-router-dom';
import './HomePage.scss';
const HomePage = () => {
    return (
        <div className="home-page">
            <h1>Welcome to our university system</h1>
            <NavLink to="/students">Go to students</NavLink>
        </div>
    );
};
export default HomePage;
