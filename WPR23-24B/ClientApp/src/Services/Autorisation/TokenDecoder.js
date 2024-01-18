// TokenDecoder.js
import { jwtDecode } from "jwt-decode";

// Function for decoding the JWT token
// The token contains the user's email and role, which are going to be used in the authService
const TokenDecoder = {
    decodeToken: (token) => {
        const decodedToken = jwtDecode(token);
        //console.log(decodedToken);
    return decodedToken;
  },
};

export default TokenDecoder;
