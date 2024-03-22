import { fetchAPI } from './Api';

export function fetchReviewCount() {
  return fetchAPI('Process/CountFlashcards24h', 'POST', {})
    .then(data => {
      return data.number; 
    });
}