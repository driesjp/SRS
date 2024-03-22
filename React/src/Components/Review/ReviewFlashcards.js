import React, { useState, useEffect } from 'react';
import { useReviewFlashcards } from '../../Context/ReviewFlashcardsContext';
import { fetchFlashcards, submitDifficulty } from '../../Services/ReviewFlashcardsService';

function ReviewFlashcards() {
  const { flashcards, setFlashcards, currentCardIndex, setCurrentCardIndex } = useReviewFlashcards();
  const [showAnswer, setShowAnswer] = useState(false);

  useEffect(() => {
    async function loadFlashcards() {
      try {
        const data = await fetchFlashcards();
        setFlashcards(data);
      } catch (error) {
        // Handle error
      }
    }
    loadFlashcards();
  }, [setFlashcards]);

  const handleShowAnswer = () => {
    setShowAnswer(true);
  };

  const handleDifficulty = async (difficulty) => {
    const flashcardId = flashcards[currentCardIndex]?.id;

    try {
      await submitDifficulty(flashcardId, difficulty);
      setShowAnswer(false); // Hide answer and difficulty buttons
      setCurrentCardIndex((prevIndex) => prevIndex + 1 >= flashcards.length ? 0 : prevIndex + 1);
    } catch (error) {
      // Handle error
    }
  };

  if (flashcards.length === 0) {
    return <div>Loading flashcards...</div>;
  }

  const flashcard = flashcards[currentCardIndex];

  return (
    <div>
      <div>Question: {flashcard.question}</div>
      {showAnswer && <div>Answer: {flashcard.answer}</div>}
      {!showAnswer ? (
        <button onClick={handleShowAnswer}>Show Answer</button>
      ) : (
        <>
          <button onClick={() => handleDifficulty(1)}>Hard</button>
          <button onClick={() => handleDifficulty(2)}>Medium</button>
          <button onClick={() => handleDifficulty(3)}>Easy</button>
        </>
      )}
    </div>
  );
}

export default ReviewFlashcards;