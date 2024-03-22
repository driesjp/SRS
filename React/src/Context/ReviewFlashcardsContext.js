import React, { createContext, useContext, useState } from 'react';

const ReviewFlashcardsContext = createContext();

export function useReviewFlashcards() {
  return useContext(ReviewFlashcardsContext);
}

export function ReviewFlashcardsProvider({ children }) {
  const [flashcards, setFlashcards] = useState([]);
  const [currentCardIndex, setCurrentCardIndex] = useState(0);

  const value = {
    flashcards,
    setFlashcards,
    currentCardIndex,
    setCurrentCardIndex
  };

  return (
    <ReviewFlashcardsContext.Provider value={value}>
      {children}
    </ReviewFlashcardsContext.Provider>
  );
}