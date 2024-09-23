import React, { useEffect, useState } from 'react';
import api from '../services/api';
import { useParams } from 'react-router-dom';

function AdvertisementDetails() {
  const { id } = useParams();
  const [ad, setAd] = useState(null);

  useEffect(() => {
    const fetchAd = async () => {
      try {
        const response = await api.get(`/ads/${id}`);
        setAd(response.data);
      } catch (error) {
        console.error('Failed to fetch advertisement:', error);
      }
    };

    fetchAd();
  }, [id]);

  if (!ad) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h1>{ad.title}</h1>
      <p>{ad.description}</p>
      {/* Display media if available */}
      {ad.mediaUrls && ad.mediaUrls.map((url, index) => (
        <img key={index} src={url} alt={ad.title} width="200" />
      ))}
      {/* Display other details */}
      <p>Location: {ad.location}</p>
      <p>Type: {ad.advertisementType}</p>
      {/* Add components for comments, likes, etc. */}
    </div>
  );
}

export default AdvertisementDetails;
