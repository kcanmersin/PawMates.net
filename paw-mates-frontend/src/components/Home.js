import React from 'react';
import { Link } from 'react-router-dom';

function Home() {
  return (
    <div>
      <h1>Welcome to PawMates</h1>
      <p>Your one-stop platform for pet adoption, jobs, and lost pet ads.</p>
      <nav>
        <Link to="/advertisements">View Advertisements</Link> |{' '}
        <Link to="/posts">View Posts</Link>
      </nav>
    </div>
  );
}

export default Home;
