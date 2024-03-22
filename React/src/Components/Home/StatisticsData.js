import React, { useEffect } from 'react';
import { useStatistics } from '../../Context/StatisticsContext';
import { fetchReviewCount } from '../../Services/StatisticsService';

function StatisticsData() {
  const { reviewCount, setReviewCount } = useStatistics();

  useEffect(() => {
    const loadData = async () => {
      try {
        const count = await fetchReviewCount();
        setReviewCount(count);
      } catch (error) {
        setReviewCount('Error fetching data');
      }
    };

    loadData();
  }, [setReviewCount]);

  return (
    <div className="statistics-data">
      <p>Up for review (next 24 hours):</p>
      <h2>{reviewCount}</h2>
    </div>
  );
}

export default StatisticsData;