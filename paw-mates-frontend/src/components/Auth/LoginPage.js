import React, { useContext } from 'react';
import { useForm } from 'react-hook-form';
import api from '../../services/api';
import { AuthContext } from '../../contexts/AuthContext.js';
import { useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';

function LoginPage() {
  const { login } = useContext(AuthContext);
  const navigate = useNavigate();
  const { register, handleSubmit } = useForm();

  const onSubmit = async (data) => {
    try {
      const response = await api.post('/users/login', data);
      login(response.data.token, response.data.userId);
      toast.success('Logged in successfully!');
      navigate('/');
    } catch (error) {
      toast.error('Login failed. Please check your credentials.');
    }
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <h1>Login</h1>
      <input {...register('email')} type="email" placeholder="Email" required />
      <input
        {...register('password')}
        type="password"
        placeholder="Password"
        required
      />
      <button type="submit">Login</button>
    </form>
  );
}

export default LoginPage;
