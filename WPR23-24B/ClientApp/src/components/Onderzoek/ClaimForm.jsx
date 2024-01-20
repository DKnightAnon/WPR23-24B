import React, { useState } from "react";
import { Form, Button, Alert } from "react-bootstrap";
import { makeApiRequest } from "../../Services/Utils/ApiHelper";

const ClaimForm = ({ researchId, onClaimSuccess, onClaimError }) => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [errorMessage, setErrorMessage] = useState(null);

  const handleClaimResearch = async () => {
    try {
      // Validate user credentials using the SignIn endpoint
      const signInResponse = await makeApiRequest(
        "auth/claim-research",
        "POST",
        {
          email: email,
          password: password,
        }
      );

      console.log("SignIn Response:", signInResponse);

      // Check for success in the response
      if (signInResponse) {
        // If successful, call the enroll-in-onderzoek endpoint
        const enrollResponse = await makeApiRequest(
          `User/enroll-in-onderzoek/${researchId}`,
          "POST"
        );

        console.log("Enroll Response:", enrollResponse);

        // Check for success in the enroll response
        if (enrollResponse) {
          // If successful, call the callback function
          onClaimSuccess(enrollResponse);
        } else {
          // If there's a specific callback function for error, call it
          onClaimError && onClaimError();

          // Set the error message from the enroll response if available
          setErrorMessage(
            enrollResponse ? enrollResponse.message : "Unknown error occurred."
          );
        }
      } else {
        // If there's a specific callback function for error, call it
        onClaimError && onClaimError();

        // Set the error message from the sign-in response if available
        setErrorMessage(
          signInResponse ? signInResponse.error : "Invalid email or password."
        );
      }
    } catch (error) {
      console.error("Error claiming research:", error);

      // Set the error message
      setErrorMessage("Invalid email or password. Please try again.");

      // If there's a specific callback function for error, call it
      onClaimError && onClaimError();
    }
  };

  return (
    <Form>
      <Form.Group controlId="formEmail">
        <Form.Label>Emailadres</Form.Label>
        <Form.Control
          type="email"
          placeholder="Enter email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
      </Form.Group>

      <Form.Group controlId="formPassword">
        <Form.Label>Wachtwoord</Form.Label>
        <Form.Control
          type="password"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </Form.Group>

      {errorMessage && <Alert variant="danger">{errorMessage}</Alert>}

      <Button variant="success" onClick={handleClaimResearch}>
        Registratie Afronden
      </Button>
    </Form>
  );
};

export default ClaimForm;
