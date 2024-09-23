import React, { useState, useContext } from 'react';
import api from '../services/api';
import { useNavigate } from 'react-router-dom';
import { AuthContext } from '../contexts/AuthContext.js';
import { toast } from 'react-toastify';

function CreateAdvertisement() {
  const navigate = useNavigate();
  const { authState } = useContext(AuthContext);
  const [formData, setFormData] = useState({
    title: '',
    description: '',
    location: '',
    advertisementType: 'Adoption',
  });
  const [pets, setPets] = useState([
    {
      name: '',
      petTypeId: '', // Replace with actual pet type IDs
      breed: '',
      age: 0,
      gender: '',
      description: '',
    },
  ]);
  const [images, setImages] = useState([]);

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handlePetChange = (index, e) => {
    const newPets = [...pets];
    newPets[index][e.target.name] = e.target.value;
    setPets(newPets);
  };

  const addPet = () => {
    setPets([
      ...pets,
      {
        name: '',
        petTypeId: '',
        breed: '',
        age: 0,
        gender: '',
        description: '',
      },
    ]);
  };

  const handleImages = (e) => {
    setImages([...e.target.files]);
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const data = new FormData();
    data.append('UserId', authState.userId);
    Object.keys(formData).forEach((key) => {
      data.append(key, formData[key]);
    });
    data.append('Pets', JSON.stringify(pets));
    images.forEach((image) => {
      data.append('AdvertisementImages', image);
    });

    try {
      await api.post('/ads', data, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      });
      toast.success('Advertisement created successfully!');
      navigate('/advertisements');
    } catch (error) {
      console.error('Failed to create advertisement:', error);
      toast.error('Failed to create advertisement.');
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <h1>Create Advertisement</h1>
      <input
        name="title"
        placeholder="Title"
        onChange={handleChange}
        required
      />
      <textarea
        name="description"
        placeholder="Description"
        onChange={handleChange}
        required
      />
      <input
        name="location"
        placeholder="Location"
        onChange={handleChange}
        required
      />
      <select
        name="advertisementType"
        onChange={handleChange}
        value={formData.advertisementType}
      >
        <option value="Adoption">Adoption</option>
        <option value="Job">Job</option>
        <option value="Lost">Lost</option>
      </select>

      {/* Pets Information */}
      {pets.map((pet, index) => (
        <div key={index}>
          <h3>Pet {index + 1}</h3>
          <input
            name="name"
            placeholder="Pet Name"
            value={pet.name}
            onChange={(e) => handlePetChange(index, e)}
            required
          />
          <input
            name="petTypeId"
            placeholder="Pet Type ID"
            value={pet.petTypeId}
            onChange={(e) => handlePetChange(index, e)}
            required
          />
          <input
            name="breed"
            placeholder="Breed"
            value={pet.breed}
            onChange={(e) => handlePetChange(index, e)}
          />
          <input
            name="age"
            type="number"
            placeholder="Age"
            value={pet.age}
            onChange={(e) => handlePetChange(index, e)}
          />
          <input
            name="gender"
            placeholder="Gender"
            value={pet.gender}
            onChange={(e) => handlePetChange(index, e)}
          />
          <textarea
            name="description"
            placeholder="Description"
            value={pet.description}
            onChange={(e) => handlePetChange(index, e)}
          />
        </div>
      ))}
      <button type="button" onClick={addPet}>
        Add Another Pet
      </button>

      <input type="file" multiple onChange={handleImages} />
      <button type="submit">Create Advertisement</button>
    </form>
  );
}

export default CreateAdvertisement;
