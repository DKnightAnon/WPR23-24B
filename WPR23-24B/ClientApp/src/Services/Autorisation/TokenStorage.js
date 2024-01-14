// TokenStorage.js
const TOKEN_KEY = "jwtToken";

// TokenStorage manages the storage of JWT tokens
const TokenStorage = {
  // Save the token to local storage
  saveToken: (token) => {
    localStorage.setItem(TOKEN_KEY, token);
  },

  // Remove the token from local storage
  removeToken: () => {
    localStorage.removeItem(TOKEN_KEY);
  },

  // Get the token from local storage
  getToken: () => {
    return localStorage.getItem(TOKEN_KEY);
  },
};
export default TokenStorage;
