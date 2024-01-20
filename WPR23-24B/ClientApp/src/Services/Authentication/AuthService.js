// AuthService.js
import { makeApiRequest } from "../Utils/ApiHelper";
import AuthUtils from "./AuthUtils";

// AuthService handles authentication-related functions
const AuthService = {
  // Attempt to sign in with provided email and password
  signIn: async (email, password, navigate) => {
    try {
      const signInData = {
        Email: email,
        Password: password,
      };

      const endpoint = "Auth/";
      const method = "POST";
      // Make an API request to sign in
      const response = await makeApiRequest(endpoint, method, signInData);
      if (response && response.token) {
        // Save the token using AuthUtils
        AuthUtils.saveToken(response.token);

        // Display a success message
        const successMessage = {
          type: "success",
          message: "Succesvolle inlogpoging",
        };

        return new Promise((resolve) => {
          // Wait for 2 seconds before redirecting
          setTimeout(() => {
            // Redirect based on user's role
            AuthService.redirectBasedOnUserRole(navigate);
            // Resolve the promise with the success message
            resolve(successMessage);
          }, 2000);
        });
      }

      return response;
    } catch (error) {
      console.error("An error occurred during login:", error);
      throw error;
    }
  },

  // Redirect user based on their role after successful sign-in
  redirectBasedOnUserRole: (navigate) => {
    const userRole = AuthService.getUserRole();
    if (userRole && navigate) {
      const roleRedirectMap = {
        Ervaringsdeskundige: "/dashboard/portaal",
        AnotherUserRole: "/anotherRoute",
        // Add more mappings for future user roles
      };

      const redirectPath = roleRedirectMap[userRole] || "/defaultRoute";
      navigate(redirectPath);
    }
  },

  // Sign out the user
  signOut: () => {
    // Remove the token using AuthUtils
    AuthUtils.removeToken();

    // Log the sign-out action
    console.log("User signed out.");
  },

  // Get user information from the token
  getUserInfo: () => {
    const token = AuthUtils.getToken();

    if (token) {
      // Decode the token using AuthUtils
      const decodedToken = AuthUtils.decodeToken(token);

      return decodedToken;
    }

    return null;
  },

  // Check if the user is authenticated
  isUserAuthenticated: () => {
    // Check if the user is authenticated based on the token using AuthUtils
    const token = AuthUtils.getToken();
    const isAuthenticated = !!token;

    // Log the authentication status
    // console.log("User Authenticated:", isAuthenticated);

    return isAuthenticated;
  },

  // Get the user role from the decoded token
  getUserRole: () => {
    const userInfo = AuthService.getUserInfo();

    if (
      userInfo &&
      userInfo["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]
    ) {
      // Extract user role from decoded token
      const userRole =
        userInfo[
          "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
        ];

      // Log the user role
      //   console.log("User Role:", userRole);

      return userRole;
    }

    // Log if the user role is not found
    console.warn("User Role not found in the token.");

    return null;
  },
};

export default AuthService;
