import React, { useState } from "react";
import styled from "styled-components";
import saLogo from "./signinImages/stichting_accessibility.png";
import AuthService from "../../Services/Authentication/AuthService";
import { useNavigate } from "react-router-dom";
import SignInMessages from "./SignInMessages";

const SignInComponent = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [signInMessage, setSignInMessage] = useState(null);
  const navigate = useNavigate();

  const handleSignInClick = async () => {
    try {
      setSignInMessage({
        type: "loading",
        message: "U wordt ingelogd, even geduld aub...",
      });
      const response = await AuthService.signIn(email, password, navigate);

      if (response && response.token) {
        // Display a success message
        setSignInMessage(response);
      }
    } catch (error) {
      // Display an error message
      setSignInMessage({
        type: "error",
        message:
          "Ongeldige inloggegevens of er is een fout opgetreden. Probeer het opnieuw...",
      });
    }
  };

  return (
    <SignInWrapper>
      <SignInContainer>
        <SignInLeftBox>
          <SignInLogo src={saLogo} alt="Stichting Accessibility Logo" />
        </SignInLeftBox>
        <SignInRightBox>
          <SignInHeader>Mijn Portaal</SignInHeader>
          <SignInSubHeader>Inloggen</SignInSubHeader>
          {signInMessage && (
            <SignInMessages
              type={signInMessage.type}
              message={signInMessage.message}
            />
          )}
          <SignInForm>
            <SignInFormRow>
              <SignInLabel htmlFor="email">Emailadres</SignInLabel>
              <SignInInput
                type="text"
                id="email"
                name="email"
                placeholder="Emailadres"
                required
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                alt="Email adres"
              />
            </SignInFormRow>
            <SignInFormRow>
              <SignInLabel htmlFor="password">Wachtwoord</SignInLabel>
              <SignInInput
                type="password"
                id="password"
                name="password"
                placeholder="Wachtwoord"
                required
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                alt="Wachtwoord"
              />
            </SignInFormRow>

            <SignInSmall>
              <ForgotLink>
                <SignInLink href="/password-reset" aria-label="Login">
                  Wachtwoord Vergeten?
                </SignInLink>
              </ForgotLink>
            </SignInSmall>

            <SignInSubmitButton
              type="button"
              onClick={handleSignInClick}
              aria-label="Login Knop"
            >
              Sign In
            </SignInSubmitButton>
          </SignInForm>
          <div className="forgot mb-3"></div>
          <div className="row">
            <SignInSmall>
              Meld je aan bij onze Stichting Accessibility!{" "}
              <SignInLink href="/register" aria-label="Registreer u hier">
                Registreren
              </SignInLink>
            </SignInSmall>
          </div>
        </SignInRightBox>
      </SignInContainer>
    </SignInWrapper>
  );
};

const darkBlueColor = "#2B50EC";
const bgColor = "#103cbe";

const SignInWrapper = styled.div`
  margin-top: 10rem;
`;

const SignInContainer = styled.div`
  max-width: 800px;
  margin: 0 auto;
  display: flex;
  background-color: white;
  border: 2px solid #000;
  border-radius: 20px;
  overflow: hidden;
  box-shadow: 0 0 20px rgba(0, 0, 0, 0.3);

  @media (max-width: ${({ theme }) => theme.media.tab}) {
    max-width: 85%;
    flex-direction: column;
  }
`;

const SignInLeftBox = styled.div`
  flex: 0 0 50%;
  background-color: ${bgColor};
  padding: 40px;
  text-align: left;
  display: flex;
  justify-content: center;
  align-items: center;

  @media (max-width: ${({ theme }) => theme.media.tab}) {
    flex: 0 0 100%;
  }
`;

const SignInLogo = styled.img`
  max-width: 120%;
  height: auto;
  justify-content: center;
  max-height: 100%;
`;

const SignInRightBox = styled.div`
  flex: 1;
  padding: 40px;
  text-align: left;
  display: flex;
  flex-direction: column;
`;

const SignInHeader = styled.h2`
  font-size: 3.2rem;
  margin-bottom: 0rem;
  color: black;
  font-weight: 550;
  text-align: left;
`;

const SignInSubHeader = styled.p`
  font-size: 2rem;
  margin-bottom: 3rem;
  color: black;
  font-weight: 450;
`;

const SignInForm = styled.form`
  display: flex;
  flex-direction: column;
`;

const SignInFormRow = styled.div`
  display: flex;
  flex-direction: column; /* Changed to column */
  margin-bottom: 20px;
`;

const SignInLabel = styled.label`
  font-size: 1.3rem;
  font-weight: 500;
  color: ${darkBlueColor};
  margin-right: 10px;
  display: flex;
  align-items: center;
  margin-bottom: 5px; /* Added margin-bottom */
  letter-spacing: 0.5px;
`;

const SignInInput = styled.input`
  flex: 1;
  padding: 10px;
  border: 1px solid ${darkBlueColor};
  border-radius: 10px;
  font-size: 16px;
  text-transform: initial;

  ::placeholder {
    font-size: 14px;
  }
  &::-webkit-input-placeholder {
    text-transform: initial;
  }

  &:-moz-placeholder {
    text-transform: initial;
  }

  &::-moz-placeholder {
    text-transform: initial;
  }

  &:-ms-input-placeholder {
    text-transform: initial;
  }
`;

const SignInSubmitButton = styled.button`
  width: 100%;
  padding: 15px;
  margin-bottom: 25px;
  background-color: ${darkBlueColor};
  color: #fff;
  border: none;
  border-radius: 30px;
  cursor: pointer;
  font-size: 1.8rem;
  transition: background-color 0.3s ease;

  &:hover {
    background-color: #1c389f;
  }

  @media (min-width: ${({ theme }) => theme.media.tab}) {
    width: auto;
  }
`;

const SignInLink = styled.a`
  color: #2b50ec;
  text-decoration: none;
  font-weight: 500;
  font-size: 1.4rem;
  text-decoration: underline;
  &:hover {
    color: black;
  }
`;

const SignInSmall = styled.small`
  font-size: 1.5rem;
`;

const ForgotLink = styled.div`
  text-align: right;
  margin-bottom: 10px;
  margin-top: 10px;
  margin-left: auto;
`;

export default SignInComponent;
