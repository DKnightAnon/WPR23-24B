import {
  handleSignIn,
  handleAuthResponse,
} from "../Authentication/AuthenticationService";

// Function to handle user signin
const handleUserSignIn = async (email, password) => {
  try {
    // Make a POST request to the endpoint handling the signin using the function
    const response = await handleSignIn(email, password);

    await handleAuthResponse(response);
    // Return the response to the caller
    return response;
  } catch (error) {
    // Log a generic error message without exposing detailed error information
    console.error("An error occurred during login.");
    // console.error('An error occurred during login:', error);
    throw error; // Rethrow the error to the caller
  }
};

export default handleUserSignIn;
