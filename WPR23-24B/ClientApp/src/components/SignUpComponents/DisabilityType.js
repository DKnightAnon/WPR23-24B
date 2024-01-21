// DisabilityType.js
import React from "react";
import "./SignUpStyle.css";
import { validateDisabilityType } from "./SignUpValidation";

const DisabilityType = ({ onNext, onPrev, values, handleChange }) => {
  const [validationErrors, setValidationErrors] = React.useState({});

  const handleValidation = () => {
    const errors = validateDisabilityType(values);
    console.log("Values:", values); // Log values to check the state

    if (Object.keys(errors).length > 0) {
      setValidationErrors(errors);
      return false;
    }
    return true;
  };

  const handleRadioKeyDown = (e) => {
    if (e.key === "Enter") {
      e.preventDefault(); // Prevent the default behavior of the Enter key
      e.target.click(); // Simulate a click on the radio button
    }
  };

  return (
    <div>
      {/* Triangle background */}
      <div className="triangle-background"></div>
      {/* Main container */}
      <div style={styles.container}>
        {/* Header */}
        <h2 style={styles.header}>Type Beperking</h2>

        {/* First input container */}
        <div style={styles.checkboxContainer}>
          <label style={styles.checkboxLabel} htmlFor="Fysieke Beperking">
            Fysieke beperking:
            <input
              type="checkbox"
              name="FysiekeBeperking"
              checked={values.FysiekeBeperking}
              onChange={handleChange}
              style={styles.checkbox}
              id="fysiekeBeperkingCheckbox"
              onKeyDown={handleRadioKeyDown} // Add keydown event listener
            />
          </label>
          <label style={styles.checkboxLabel} htmlFor="Visuele Beperking">
            Visuele beperking:
            <input
              type="checkbox"
              name="VisueleBeperking"
              checked={values.VisueleBeperking}
              onChange={handleChange}
              style={styles.checkbox}
              id="visueleBeperkingCheckbox"
              onKeyDown={handleRadioKeyDown} // Add keydown event listener
            />
          </label>
          <label style={styles.checkboxLabel} htmlFor="Auditore Beperking">
            Auditore beperking:
            <input
              type="checkbox"
              name="AuditieveBeperking"
              checked={values.AuditieveBeperking}
              onChange={handleChange}
              style={styles.checkbox}
              id="auditieveBeperkingCheckbox"
              onKeyDown={handleRadioKeyDown} // Add keydown event listener
            />
          </label>
        </div>

        {/* Second input container for the dropdown */}
        <div style={styles.inputContainer}>
          <label style={styles.label}>
            Anders, namelijk..
            <select
              name="OverigeBeperking"
              value={values.beperking}
              onChange={handleChange}
              style={styles.select}
              aria-invalid={!!validationErrors.OverigeBeperking}
              aria-describedby="overigeBeperkingError"
              onKeyDown={handleRadioKeyDown} // Add keydown event listener
            >
              <option
                value=""
                aria-label="Selecteer een beperking"
                onKeyDown={handleRadioKeyDown} // Add keydown event listener
              >
                Selecteer
              </option>
              <option
                value="mobility"
                aria-label="Beperkte mobiliteit"
                onKeyDown={handleRadioKeyDown} // Add keydown event listener
              >
                Beperkte mobiliteit
              </option>
              <option
                value="cognitive"
                aria-label="Cognitieve beperking"
                onKeyDown={handleRadioKeyDown}
              >
                Cognitieve beperking
              </option>
              <option
                value="psychiatric"
                aria-label="Psychiatrische beperking"
                onKeyDown={handleRadioKeyDown}
              >
                Psychiatrische beperking
              </option>
              <option
                value="prothese"
                aria-label="Prothese van arm of been"
                onKeyDown={handleRadioKeyDown}
              >
                Prothese van arm of been
              </option>
              {/* Add more options as needed */}
            </select>
          </label>
          {validationErrors.OverigeBeperking && (
            <p
              style={{
                color: "#FF0000",
                marginTop: "5px",
                fontSize: "1.2rem",
                width: "400px",
              }}
              role="alert"
              aria-live="assertive"
              id="overigeBeperkingError"
            >
              {validationErrors.OverigeBeperking}
            </p>
          )}
        </div>

        {/* Button container for navigation */}
        <div style={styles.buttonContainer}>
          <button
            onClick={onPrev}
            style={styles.previousButton}
            aria-label="Vorige pagina"
          >
            Vorige pagina
          </button>
          <button
            onClick={() => handleValidation() && onNext()}
            style={styles.button}
            aria-label="Volgende pagina"
          >
            Volgende pagina
          </button>
        </div>

        {Object.keys(validationErrors).length > 0 && (
          <div style={styles.errorContainer}>
            <p style={styles.errorText}>
              {Object.values(validationErrors).join(" ")}
            </p>
          </div>
        )}
      </div>{" "}
      {/* End of the main container div */}
    </div>
  );
};

const styles = {
  label: {
    display: "flex",
    flexDirection: "column",
    alignItems: "flex-start",
    marginBottom: "10px",
  },

  inputContainer: {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    marginBottom: "10px",
  },
  input: {
    height: "30px",
    width: "400px",
    background: "#EAEAEA",
    border: "1px solid #ccc",
    borderRadius: "4px",
    paddingLeft: "10px",
    fontSize: "16px",
  },
  container: {
    textAlign: "center",
    margin: "auto",
    width: "600px",
    marginTop: "50px",
    padding: "20px",
    borderRadius: "8px",
    boxShadow: "0 0 10px rgba(0, 0, 0, 0.1)",
    position: "relative",
    zIndex: 1 /* Ensure the content is above the triangle background */,
  },
  header: {
    color: "#2B50EC",
    fontSize: "24px",
    fontWeight: "700",
    marginBottom: "20px",
  },
  inputContainer: {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    marginBottom: "20px",
  },
  label: {
    display: "flex",
    flexDirection: "column",
    alignItems: "flex-start",
    marginBottom: "15px",
    color: "black",
  },
  select: {
    height: "30px",
    width: "416px",
    background: "#EAEAEA",
    border: "1px solid #ccc",
    borderRadius: "4px",
    paddingLeft: "10px",
    fontSize: "16px",
  },
  buttonContainer: {
    display: "flex",
    justifyContent: "space-between",
  },
  button: {
    background: "#108670", //achtergrond
    color: "#fff", // text
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
  icon: {
    width: "20px", // Adjust the size as needed
    height: "20px",
    marginLeft: "1020px",
  },
  select: {
    height: "30px",
    width: "400px",
    background: "#EAEAEA",
    border: "1px solid #ccc",
    borderRadius: "4px",
    paddingLeft: "10px",
    fontSize: "16px",
  },

  checkboxContainer: {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
    marginBottom: "10px",
  },

  checkboxLabel: {
    display: "flex",
    alignItems: "center",
    marginBottom: "5px",
    color: "black",
  },

  checkbox: {
    marginLeft: "5px",
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
    justifyContent: "center",
  },
};

export default DisabilityType;
