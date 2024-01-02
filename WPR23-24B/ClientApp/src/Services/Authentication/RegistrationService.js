import { makeApiRequest } from "../Utils/ApiHelper";

export const handleSignUp = async (userType, formData) => {
  try {
    const endpoint =
      userType === "user"
        ? "Registratie/ervaringsdeskundige"
        : "Registratie/bedrijf";
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
