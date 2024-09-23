import React, { useState, useContext } from 'react';
import api from '../services/api';
import { useNavigate } from 'react-router-dom';
import { AuthContext } from '../contexts/AuthContext.js';
import { toast } from 'react-toastify';

function CreatePost() {
  const navigate = useNavigate();
  const { authState } = useContext(AuthContext);
  const [formData, setFormData] = useState({
    title: '',
    content: '',
  });
  const [mediaFiles, setMediaFiles] = useState([]);

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleMediaFiles = (e) => {
    setMediaFiles([...e.target.files]);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const data = new FormData();
    data.append('UserId', authState.userId);
    data.append('Title', formData.title);
    data.append('Content', formData.content);
    mediaFiles.forEach((file) => {
      data.append('PostMedias', file);
    });

    try {
      await api.post('/posts', data, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      });
      toast.success('Post created successfully!');
      navigate('/posts');
    } catch (error) {
      console.error('Failed to create post:', error);
      toast.error('Failed to create post.');
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <h1>Create Post</h1>
      <input
        name="title"
        placeholder="Title"
        onChange={handleChange}
        required
      />
      <textarea
        name="content"
        placeholder="Content"
        onChange={handleChange}
        required
      />
      <input type="file" multiple onChange={handleMediaFiles} />
      <button type="submit">Create Post</button>
    </form>
  );
}

export default CreatePost;
