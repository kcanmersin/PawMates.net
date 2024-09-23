import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from './components/Home';
import AdvertisementList from './components/AdvertisementList';
import PostList from './components/PostList';
import CreateAdvertisement from './components/CreateAdvertisement';
import CreatePost from './components/CreatePost';
import AdvertisementDetails from './components/AdvertisementDetails';
import PostDetails from './components/PostDetails';
import LoginPage from './components/Auth/LoginPage';
import RegisterPage from './components/Auth/RegisterPage';
import PrivateRoute from './components/PrivateRoute';
import Navbar from './components/Navbar';
import { AuthProvider } from './contexts/AuthContext.js';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

function App() {
  return (
    <AuthProvider>
      <Router>
        <Navbar />
        <div className="App">
          <Routes>
            {/* Public Routes */}
            <Route path="/" element={<Home />} />
            <Route path="/advertisements" element={<AdvertisementList />} />
            <Route path="/advertisements/:id" element={<AdvertisementDetails />} />
            <Route path="/posts" element={<PostList />} />
            <Route path="/posts/:id" element={<PostDetails />} />
            <Route path="/login" element={<LoginPage />} />
            <Route path="/register" element={<RegisterPage />} />

            {/* Protected Routes */}
            <Route
              path="/advertisements/create"
              element={
                <PrivateRoute>
                  <CreateAdvertisement />
                </PrivateRoute>
              }
            />
            <Route
              path="/posts/create"
              element={
                <PrivateRoute>
                  <CreatePost />
                </PrivateRoute>
              }
            />
            {/* Add other protected routes here */}
          </Routes>
        </div>
      </Router>
      <ToastContainer position="top-right" autoClose={5000} />
    </AuthProvider>
  );
}

export default App;
