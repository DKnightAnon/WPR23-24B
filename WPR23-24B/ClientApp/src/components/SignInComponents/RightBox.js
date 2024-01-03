import React, { useState } from "react";
import handleUserSignIn from "../../Services/Utils/SignInHandler";

function RightBox() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSignInClick = async () => {
    console.log("Trying to login with:", { email, password });

    try {
      const response = await handleUserSignIn(email, password);
    } catch (error) {
      console.error("An error occurred during login:", error);
    }
  };

  return (
    <div className="col-md-6 right-box">
      <div className="row align-items-center">
        <div className="header-text mb-4">
          <h2>Mijn Portaal</h2>
          <p>Inloggen</p>
        </div>

        {/* Email Input */}
        <div className="mb-3">
          <label htmlFor="email">Email adres</label>
          <input
            type="text"
            id="email"
            name="email"
            className="form-control form-control-lg bg-light fs-6"
            placeholder="Email adres"
            aria-label="Email Address"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>

        {/* Password Input */}
        <div className="mb-3">
          <label htmlFor="password">Wachtwoord</label>
          <input
            type="password"
            id="password"
            name="password"
            className="form-control form-control-lg bg-light fs-6"
            placeholder="Wachtwoord"
            aria-label="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>

        {/* Remember Me Checkbox
                <div className="form-check mb-3">
                    <input type="checkbox" id="formCheck" className="form-check-input" />
                    <label htmlFor="formCheck" className="form-check-label text-secondary">
                        <small>Onthoud Mij</small>
                    </label>
                </div> */}

        {/* Forgot Password Link */}
        <div className="forgot mb-3">
          <small>
            <a href="/password-reset">Wachtwoord Vergeten?</a>
          </small>
        </div>

        {/* Login Button */}
        <div className="mb-3">
          <button
            className="btn btn-lg btn-primary w-100 fs-6"
            type="button"
            onClick={handleSignInClick}
          >
            Login
          </button>
        </div>

        {/* Registration Link */}
        <div className="row">
          <small>
            Meld je aan bij onze Stichting Accessibility!{" "}
            <a href="/register">Registreren</a>
          </small>
        </div>
      </div>
    </div>
  );
}

export default RightBox;
