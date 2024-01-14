import { makeApiRequest } from "../Utils/ApiHelper";

export const handleSignUp = async (userType, formData, isUnder18) => {
  try {
    let endpoint;

    if (userType === "user") {
      // Determine the appropriate endpoint based on the usertype and user's age
      endpoint = isUnder18
        ? "Registratie/ervaringsdeskundige/registerUnder18"
        : "Registratie/ervaringsdeskundige/registerOver18";
    } else if (userType === "company") {
      endpoint = "Registratie/bedrijf/register";
    } else {
      throw new Error("Invalid userType");
    }

    const method = "POST";

    const response = await makeApiRequest(endpoint, method, formData);

    if (!response.ok) {
      const errorData = await response.json();
      console.error("Fout bij registratie:", errorData);
      throw new Error("Registratiefout");
    }

    const responseData = await response.json();
    // Log important details without exposing sensitive information (commented for security)
    // console.log('Response data:', responseData);
    return responseData;
  } catch (error) {
    // Log a generic error message without exposing detailed error information
    console.error("Error during registration: An error occurred.");
    throw error;
  }
};
