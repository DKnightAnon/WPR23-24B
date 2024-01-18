import React from "react";
import "./SignUpStyle.css";
import { validateApproach } from "./SignUpValidation";
import { useNavigate } from "react-router-dom";

const CommercialApproach = ({ onPrev, onSubmit, values, handleChange }) => {
  const [validationErrors, setValidationErrors] = React.useState({});
  const navigate = useNavigate(); // Initialize the useNavigate hook

  const handleValidation = () => {
    const errors = validateApproach(values);

    if (Object.keys(errors).length > 0) {
      setValidationErrors(errors);
      return false;
    }
    return true;
  };

  const handleRedirect = () => {
    // Redirect to the desired route (e.g., "/signin")
    navigate("/login");
  };

  const handleRadioKeyDown = (e) => {
    if (e.key === "Enter") {
      e.preventDefault(); // Prevent the default behavior of the Enter key
      e.target.click(); // Simulate a click on the radio button
    }
  };

  return (
    <div>
      <div className="triangle-background"></div>
      <div style={styles.container}>
        <h2 style={styles.header}>Toestaan benaderingen</h2>
        <div style={styles.checkboxContainer}>
          <label style={styles.checkboxLabel} htmlFor="BenaderingCommericeel">
            <input
              type="checkbox"
              id="BenaderingCommericeel"
              name="BenaderingCommericeel"
              checked={values.BenaderingCommericeel}
              onChange={handleChange}
              style={styles.checkbox}
              onKeyDown={handleRadioKeyDown} // Add keydown event listener
            />
            Sta commerciële benaderingen toe
          </label>
          <label style={styles.checkboxLabel} htmlFor="BenaderingViaPortaal">
            <input
              type="checkbox"
              id="BenaderingPortal"
              name="BenaderingPortal"
              checked={values.BenaderingPortal}
              onChange={handleChange}
              style={styles.checkbox}
              onKeyDown={handleRadioKeyDown} // Add keydown event listener
            />
            Sta benadering via portaal toe
          </label>
          <label style={styles.checkboxLabel} htmlFor="BenaderingTelefonisch">
            <input
              type="checkbox"
              id="BenaderingTelefonisch"
              name="BenaderingTelefonisch"
              checked={values.BenaderingTelefonisch}
              onChange={handleChange}
              style={styles.checkbox}
              onKeyDown={handleRadioKeyDown} // Add keydown event listener
            />
            Sta telefonische benaderingen toe
          </label>
        </div>
        {Object.keys(validationErrors).length > 0 && (
          <div style={styles.errorContainer} role="alert" aria-live="assertive">
            <p style={styles.errorText}>
              {Object.values(validationErrors).join(" ")}
            </p>
          </div>
        )}
        <div style={styles.buttonContainer}>
          <button
            onClick={onPrev}
            style={styles.previousButton}
            aria-label="Vorige pagina"
          >
            Vorige pagina
          </button>
          <button
            onClick={() => handleValidation() && onSubmit() && handleRedirect()} // Add handleRedirect to the onClick event
            style={styles.button}
            aria-label="Afronden Registratie"
            aria-disabled={Object.keys(validationErrors).length > 0}
          >
            Afronden Registratie
          </button>
        </div>
      </div>
    </div>
  );
};

const styles = {
  container: {
    textAlign: "center",
    margin: "auto",
    width: "600px",
    marginTop: "50px",
    padding: "20px",
    borderRadius: "8px",
    boxShadow: "0 0 10px rgba(0, 0, 0, 0.1)",
    position: "relative",
    zIndex: 1,
  },
  header: {
    color: "#2B50EC",
    fontSize: "24px",
    fontWeight: "700",
    marginBottom: "20px",
  },
  checkboxContainer: {
    display: "flex",
    flexDirection: "column",
    alignItems: "flex-start",
    marginBottom: "10px",
  },
  checkboxLabel: {
    display: "flex",
    alignItems: "center",
    marginBottom: "5px",
    color: "black",
    cursor: "pointer",
  },
  checkbox: {
    marginLeft: "5px",
  },
  buttonContainer: {
    display: "flex",
    justifyContent: "space-between",
  },
  button: {
    background: "#108670",
    color: "#fff",
    padding: "10px 20px",
    borderRadius: "4px",
    fontSize: "16px",
    cursor: "pointer",
  },
  previousButton: {
    background: "#FF5757",
    cursor: "pointer",
    borderRadius: "5px",
    padding: "5px",
  },
  errorContainer: {
    backgroundColor: "#FFCCCC",
    padding: "10px",
    borderRadius: "4px",
    marginBottom: "10px",
  },
  errorText: {
    color: "#2B50EC",
    fontWeight: 700,
    fontSize: "1.5rem",
  },
};

export default CommercialApproach;
