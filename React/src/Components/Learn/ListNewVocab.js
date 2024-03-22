import React, { useEffect } from 'react';
import { useLearn } from '../../Context/LearnContext';
import { fetchFlashcards } from '../../Services/LearnService';

function ListNewVocab() {
  const { flashcards, setFlashcards } = useLearn();

  useEffect(() => {
    const loadFlashcards = async () => {
      try {
        const data = await fetchFlashcards();
        setFlashcards(data);
      } catch (error) {
        // Handle error
      }
    };

    loadFlashcards();
  }, [setFlashcards]);

  return (
    <div>
      <h2>New flashcards</h2>
      <table className="table">
        <thead>
          <tr>
            <th>ID</th>
            <th>Question</th>
            <th>Answer</th>
          </tr>
        </thead>
        <tbody>
          {flashcards.map((flashcard) => (
            <tr key={flashcard.id}>
              <td className="cell-small">{flashcard.id}</td>
              <td className="cell-medium">{flashcard.question}</td>
              <td className="cell-large">{flashcard.answer}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ListNewVocab;