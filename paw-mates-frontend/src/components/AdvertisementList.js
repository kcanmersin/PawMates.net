import React, { useEffect, useState } from 'react';
import api from '../services/api';
import { Link } from 'react-router-dom';

function AdvertisementList({ type = 'All' }) {
  const [ads, setAds] = useState([]);
  const [pageNumber, setPageNumber] = useState(1);
  const pageSize = 10;

  useEffect(() => {
    const fetchAds = async () => {
      try {
        const response = await api.get('/ads', {
          params: {
            pageNumber,
            pageSize,
            adType: type !== 'All' ? type : undefined,
          },
        });
        setAds(response.data.ads);
      } catch (error) {
        console.error('Failed to fetch ads:', error);
      }
    };

    fetchAds();
  }, [pageNumber, type]);

  const handleNextPage = () => {
    setPageNumber((prev) => prev + 1);
  };

  const handlePrevPage = () => {
    setPageNumber((prev) => Math.max(prev - 1, 1));
  };

  return (
    <div>
      <h1>Advertisements</h1>
      <Link to="/advertisements/create">Create Advertisement</Link>
      {ads.map((ad) => (
        <div key={ad.id}>
          <h2>{ad.title}</h2>
          <p>{ad.description}</p>
          {ad.mediaUrls && ad.mediaUrls.length > 0 && (
            <img src={ad.mediaUrls[0]} alt={ad.title} width="200" />
          )}
          <Link to={`/advertisements/${ad.id}`}>View Details</Link>
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

export default AdvertisementList;
