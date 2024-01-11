import { makeApiRequest } from "../Utils/ApiHelper";

export const handleSignIn = async (email, password) => {
  try {
    const endpoint = "Auth/";
    const method = "POST";

    const formData = { email, password };
    const response = await makeApiRequest(endpoint, method, formData);

    if (response) {
      console.log("Response from server:", response);
      await handleAuthResponse(response);
    } else {
      // Log a generic error message without exposing detailed information
      console.error("Invalid response: Response is undefined.");
    }
  } catch (error) {
    // Log a generic error message without exposing detailed error information
    console.error("An error occurred during login.");
  }
};

// Function to handle authentication response
export const handleAuthResponse = async (response) => {
  try {
    if (!response) {
      return null;
    }

    if (!response.ok) {
      const contentType = response.headers
        ? response.headers.get("Content-Type")
        : null;

      if (contentType && contentType.includes("application/json")) {
        const errorData = await response.json().catch(() => null);
        console.error(
          "Error logging in:",
          errorData?.message,
          errorData?.errors
        );
      } else {
        console.error("Error logging in. Non-JSON response received.");
      }
      return;
    }

    // Log success message for user sign-in
    const responseData = await response.json();
    console.log("User logged in successfully");
    console.log("Token:", responseData?.Token);
    console.log("Message:", responseData?.Message);
  } catch (error) {
    // Log and handle unexpected errors during sign-in
    console.error("An error occurred during login:", error);
  }
};
