// Define the base URL for the API by reading the environment variable 'REACT_APP_API_URL'.
const BASE_URL = process.env.REACT_APP_API_URL;

// Define and export an asynchronous function 'fetchAPI' for making API requests.
// 'endpoint' specifies the API endpoint to append to the BASE_URL.
// 'method' is the HTTP method to use for the request, with 'POST' set as the default value.
// 'body' is the data to be sent with the request, defaulting to an empty object if not provided.
export async function fetchAPI(endpoint, method = 'POST', body = {}) {
    // Construct the full URL by appending the endpoint to the BASE_URL.
  const url = `${BASE_URL}/${endpoint}`;
  // Define the options for the fetch request, including the method, content type, and the request body serialized as a JSON string.
  const options = {
    method,
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(body)
  };
  try {
    // Perform the fetch request with the specified URL and options.
    const response = await fetch(url, options);
    // Check if the response status indicates success (response.ok is true for status codes 200-299).
    // If not, throw an error to indicate the request was not successful.
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    // Parse the JSON response body and return the resulting object.
    return await response.json();
  } catch (error) {
    // If an error occurs during the fetch operation or processing the response, log the error and rethrow it.
    console.error('There was a problem with the fetch operation:', error);
    throw error;
  }
}