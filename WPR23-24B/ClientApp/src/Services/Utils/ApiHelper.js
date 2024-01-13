// Get the base URL from the environment variable
const apiURL = process.env.REACT_APP_API_BASE_URL;

// This module provides a function for making API requests using the Fetch API.
// The function takes an endpoint, method, and body as parameters, constructs
// the request, sends it to the specified API endpoint, and handles the response.
const makeApiRequest = (endpoint, method, body) => {
  // Construct the full URL by combining the base API URL and the provided endpoint
  const fullUrl = `${apiURL}${endpoint}`;

  // Configure the Fetch API options for the request
  const requestOptions = {
    method,
    headers: {
      "Content-Type": "application/json; charset=utf-8",
      Accept: "application/json",
    },
    body: JSON.stringify(body),
  };

  // Use Fetch API to send the request to the API endpoint
  return fetch(fullUrl, requestOptions)
    .then((response) => {
      // Check if the response status is OK (2xx)
      if (!response.ok) {
        // If not OK, parse the error response and throw an error
        return response.json().then((errorData) => {
          throw new Error(
            `API error: ${response.status} - ${response.statusText}`
          );
        });
      }

      // If the response status is 204 (No Content), return null
      return response.status !== 204 ? response.json() : null;
    })
    .then((responseData) => responseData) // Return the parsed response data
    .catch((error) => {
      // Catch any errors that occur during the request or response handling
      throw error;
    });
};

export { makeApiRequest };
