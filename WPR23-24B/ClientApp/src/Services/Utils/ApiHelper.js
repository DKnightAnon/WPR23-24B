const apiURL = "https://localhost:7180/api";

// Function to handle API requests
const makeApiRequest = (endpoint, method, body) => {
  // Log the initiation of an API request (commented for security)
  // console.log('Making API request to:', `${apiURL}/${endpoint}`);

  return fetch(`${apiURL}/${endpoint}`, {
    method,
    headers: {
      "Content-Type": "application/json",
      Accept: "application/json",
    },
    body: JSON.stringify(body),
  })
    .then((response) => {
      // Log the response status and the server response (commented for security)
      // console.log('Response status:', response.status);
      // console.log('Server response:', response);

      if (!response.ok) {
        return response.json().then((errorData) => {
          // Log the server response data (commented for security)
          // console.error(`Error at ${endpoint}:`, errorData)
          throw new Error(
            `API error: ${response.status} - ${response.statusText}`
          );
        });
      }

      return response.status !== 204 ? response.json() : null;
    })
    .then((responseData) => {
      // Log the server response data (commented for security)
      // console.log('Server response data:', responseData)
      return responseData;
    })
    .catch((error) => {
      // Log an error message without exposing detailed error information
      // console.error(`An error occurred during ${endpoint}:`, error);
      throw error;
    });
};

export { makeApiRequest };
