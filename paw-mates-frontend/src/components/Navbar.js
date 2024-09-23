import React, { useContext } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { AuthContext } from '../contexts/AuthContext.js';

function Navbar() {
  const { authState, logout } = useContext(AuthContext);
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
    navigate('/');
  };

  return (
    <nav>
      <Link to="/">Home</Link> | <Link to="/advertisements">Advertisements</Link> |{' '}
      <Link to="/posts">Posts</Link>
      {authState.token ? (
        <>
          {' '}
          | <button onClick={handleLogout}>Logout</button>
        </>
      ) : (
        <>
          {' '}
          | <Link to="/login">Login</Link> | <Link to="/register">Register</Link>
        </>
      )}
    </nav>
  );
}

export default Navbar;
