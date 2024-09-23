import React, { useEffect, useState } from 'react';
import api from '../services/api';
import { useParams } from 'react-router-dom';

function PostDetails() {
  const { id } = useParams();
  const [post, setPost] = useState(null);

  useEffect(() => {
    const fetchPost = async () => {
      try {
        const response = await api.get(`/posts/${id}`);
        setPost(response.data);
      } catch (error) {
        console.error('Failed to fetch post:', error);
      }
    };

    fetchPost();
  }, [id]);

  if (!post) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h1>{post.title}</h1>
      <p>{post.content}</p>
      {post.mediaUrls && post.mediaUrls.map((url, index) => (
        <img key={index} src={url} alt={post.title} width="200" />
      ))}
      {/* Add components for comments, likes, etc. */}
    </div>
  );
}

export default PostDetails;
