import React, { useEffect, useState } from 'react';
import api from '../services/api';
import { Link } from 'react-router-dom';

function PostList() {
  const [posts, setPosts] = useState([]);
  const [pageNumber, setPageNumber] = useState(1);
  const pageSize = 10;

  useEffect(() => {
    const fetchPosts = async () => {
      try {
        const response = await api.get('/posts', {
          params: {
            pageNumber,
            pageSize,
          },
        });
        setPosts(response.data.posts);
      } catch (error) {
        console.error('Failed to fetch posts:', error);
      }
    };

    fetchPosts();
  }, [pageNumber]);

  const handleNextPage = () => {
    setPageNumber((prev) => prev + 1);
  };

  const handlePrevPage = () => {
    setPageNumber((prev) => Math.max(prev - 1, 1));
  };

  return (
    <div>
      <h1>Posts</h1>
      <Link to="/posts/create">Create Post</Link>
      {posts.map((post) => (
        <div key={post.id}>
          <h2>{post.title}</h2>
          <p>{post.content}</p>
          {post.mediaUrls && post.mediaUrls.length > 0 && (
            <img src={post.mediaUrls[0]} alt={post.title} width="200" />
          )}
          <Link to={`/posts/${post.id}`}>View Details</Link>
        </div>
      ))}
      <div>
        <button onClick={handlePrevPage} disabled={pageNumber === 1}>
          Previous
        </button>
        <button onClick={handleNextPage}>Next</button>
      </div>
    </div>
  );
}

export default PostList;
