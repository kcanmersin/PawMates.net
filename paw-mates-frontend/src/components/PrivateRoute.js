import React, { useContext } from 'react';
import { Navigate } from 'react-router-dom';
import { AuthContext } from '../contexts/AuthContext.js';

const PrivateRoute = ({ children }) => {
  const { authState } = useContext(AuthContext);
  return authState.token ? children : <Navigate to="/login" />;
};

export default PrivateRoute;
