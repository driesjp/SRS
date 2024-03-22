import { fetchAPI } from './Api';

export function fetchFlashcards() {
  return fetchAPI('Process/GetFlashcardsReview', 'POST', {});
}

export function submitDifficulty(flashcardId, difficulty) {
  return fetchAPI('Update/SubmitDifficulty', 'POST', { flashcardId, difficulty });
}