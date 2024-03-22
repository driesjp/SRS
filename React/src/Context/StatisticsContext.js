import React, { createContext, useContext, useState } from 'react';

const StatisticsContext = createContext();

export function useStatistics() {
  return useContext(StatisticsContext);
}

export function StatisticsProvider({ children }) {
  const [reviewCount, setReviewCount] = useState('');

  const value = {
    reviewCount,
    setReviewCount,
  };

  return <StatisticsContext.Provider value={value}>{children}</StatisticsContext.Provider>;
}