import React from 'react';
import Menu from '../Menu/Menu';
import ReviewFlashcards from './ReviewFlashcards';
import { ReviewFlashcardsProvider } from '../../Context/ReviewFlashcardsContext';

function Review() {
  return (
    <div className="Review">
      <Menu />
      <h1>Review</h1>
      <ReviewFlashcardsProvider>
        <ReviewFlashcards />
      </ReviewFlashcardsProvider>
    </div>
  );
}

export default Review;