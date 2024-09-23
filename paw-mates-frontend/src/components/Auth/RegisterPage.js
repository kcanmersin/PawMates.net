import React from 'react';
import { useForm } from 'react-hook-form';
import api from '../../services/api';
import { useNavigate } from 'react-router-dom';
import { toast } from 'react-toastify';

function RegisterPage() {
  const navigate = useNavigate();
  const { register, handleSubmit } = useForm();

  const onSubmit = async (data) => {
    try {
      await api.post('/users/register', data);
      toast.success('Registration successful! Please confirm your email.');
      navigate('/login');
    } catch (error) {
      toast.error('Registration failed. Please try again.');
    }
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <h1>Register</h1>
      <input {...register('email')} type="email" placeholder="Email" required />
      <input
        {...register('password')}
        type="password"
        placeholder="Password"
        required
      />
      <input
        {...register('firstName')}
        type="text"
        placeholder="First Name"
        required
      />
      <input
        {...register('lastName')}
        type="text"
        placeholder="Last Name"
        required
      />
      <input
        {...register('phoneNumber')}
        type="text"
        placeholder="Phone Number"
        required
      />
      <button type="submit">Register</button>
    </form>
  );
}

export default RegisterPage;
