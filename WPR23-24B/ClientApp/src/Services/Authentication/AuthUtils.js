import TokenStorage from "../Autorisation/TokenStorage";
import TokenDecoder from "../Autorisation/TokenDecoder";

// AuthUtils provides utility functions for handling tokens
const AuthUtils = {
    // Save the token using TokenStorage
    saveToken: (token) => {
        TokenStorage.saveToken(token);
    },

    // Remove the token using TokenStorage
    removeToken: () => {
        TokenStorage.removeToken();
    },

    // Get the token using TokenStorage
    getToken: () => {
        return TokenStorage.getToken();
    },

    // Decode the token using TokenDecoder
    decodeToken: (token) => {
        return TokenDecoder.decodeToken(token);
    },

    tokenExpired: () => {

        try {
            const token = AuthUtils.decodeToken(TokenStorage.getToken());

            if ((!token) || (token === null || undefined)) { return true }
            else {

                if ((token * 1000) < Date.now()) {
                    return true
                }
            }
            return false
}
        catch (error) {console.log(error) }



    }
};

export default AuthUtils;
