import { fetchAPI } from './Api'; 

export function fetchFlashcards() {
    // Utilize the fetchAPI function to make an HTTP POST request to the 'Process/GetFlashcards' endpoint.
  return fetchAPI('Process/GetFlashcards', 'POST', {});
}