import React, { useState } from "react";
import "./SignUpStyle.css";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { validateGeneralInfo } from "./SignUpValidation";

const GeneralInfo = ({ onNext, values, handleChange }) => {
  const [validationErrors, setValidationErrors] = useState({}); // Add state for validation errors

  const handleDateChange = (e) => {
    const selectedDate = e.target.value;  // Renamed the variable to selectedDate
    handleChange({
      target: {
        name: "Geboortedatum",
        value: selectedDate,
      },
    });
  };


  const handleRadioChange = (e) => {
    handleChange({
      target: {
        name: "isJongerDan18",
        value: e.target.value === "true",
      },
    });
  };

  const [startDate, setStartDate] = useState(new Date());
  const [passwordsMatch, setPasswordsMatch] = useState(true);

  const handleInputChange = (e) => {
    handleChange(e);

    // Check if passwords match
    if (e.target.name === "HerhaalWachtwoord") {
      setPasswordsMatch(e.target.value === values.Wachtwoord);
    } else if (e.target.name === "Wachtwoord") {
      setPasswordsMatch(e.target.value === values.HerhaalWachtwoord);
    }
  };

  const handleValidation = () => {
    const errors = validateGeneralInfo(values);

    console.log(errors); // Log the errors to check if they are being generated

    if (Object.keys(errors).length > 0) {
      setValidationErrors(errors);
      return false; // Validation failed
    }
    return true; // Validation passed
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
        <h2 style={styles.header}>Gebruiker Registratie</h2>
        <div style={styles.inputContainer}>
          <label style={styles.label}>Bent u jonger dan 18 jaar?</label>
          <div style={styles.radioContainer}>
            <label style={styles.radioLabel} htmlFor="jaOuderDan18">
              <input
                type="radio"
                name="isJongerDan18"
                defaultChecked={values.isJongerDan18 === true}
                onChange={handleRadioChange}
                onKeyDown={handleRadioKeyDown} // Add keydown event listener
                value={"true"}
              />
              Ja
            </label>
            <label style={styles.radioLabel} htmlFor="neeOuderDan18">
              <input
                type="radio"
                name="isJongerDan18"
                defaultChecked={values.isJongerDan18 === false}
                onChange={handleRadioChange}
                onKeyDown={handleRadioKeyDown} // Add keydown event listener
                value={"false"}
              />
              Nee
            </label>
            {validationErrors.isJongerDan18 && (
              <p
                style={{
                  color: "red",
                  marginTop: "5px",
                  fontSize: "1.2rem",
                  width: "400px",
                }}
                role="alert"
                aria-live="assertive"
              >
                {validationErrors.isJongerDan18}
              </p>
            )}
          </div>
          {values.isJongerDan18 === true && (
            <div>
              <label
                style={styles.label}
                htmlFor="Volledige Naam ouder/verzorger"
              >
                Naam ouder/verzorger:
                <input
                  placeholder="Vul hier de naam in"
                  type="text"
                  name="voogdNaam"
                  value={values.voogdNaam}
                  onChange={handleChange}
                  style={styles.input}
                />
              </label>
              <label style={styles.label} htmlFor="Emailadres ouder/verzorger">
                Emailadres ouder/verzorger:
                <input
                  placeholder="Vul hier het email-adres in"
                  type="text"
                  name="voogdEmail"
                  value={values.voogdEmail}
                  onChange={handleChange}
                  style={styles.input}
                />
              </label>
              <label
                style={styles.label}
                htmlFor="Telefoonnummer ouder/verzorger"
              >
                Telefoonnummer ouder/verzorger:
                <input
                  placeholder="Vul hier het telefoonnummer in"
                  type="text"
                  name="voogdTelNummer"
                  value={values.voogdTelNummer}
                  onChange={handleChange}
                  style={styles.input}
                  aria-invalid={!!validationErrors.TelefoonNummer}
                />
              </label>
            </div>
          )}
          <label style={styles.label} htmlFor="Volledige naam">
            Naam:
            <input
              placeholder="Vul hier je volledige naam in"
              type="text"
              name="Naam"
              value={values.Naam}
              onChange={handleChange}
              style={styles.input}
              aria-invalid={!!validationErrors.Naam}
            />
            {validationErrors.Naam && (
              <p
                style={{
                  color: "red",
                  marginTop: "5px",
                  fontSize: "1.2rem",
                  width: "400px",
                }}
                role="alert"
                aria-live="assertive"
              >
                {validationErrors.Naam}
              </p>
            )}
          </label>
          <label style={styles.label} htmlFor="Emailadres">
            Email:
            <input
              placeholder="Vul hier je email-adres in"
              type="text"
              name="Email"
              value={values.Email}
              onChange={handleChange}
              style={styles.input}
              aria-invalid={!!validationErrors.Email}
            />
            {validationErrors.Email && (
              <p
                style={{
                  color: "red",
                  marginTop: "5px",
                  fontSize: "1.2rem",
                  width: "400px",
                }}
                role="alert"
                aria-live="assertive"
              >
                {validationErrors.Email}
              </p>
            )}
          </label>
          <label style={styles.label} htmlFor="Wachtwoord">
            Wachtwoord:
            <input
              placeholder="Vul hier je wachtwoord in"
              type="password"
              name="Wachtwoord"
              value={values.Wachtwoord}
              onChange={handleInputChange}
              style={styles.input}
              aria-invalid={!!validationErrors.Wachtwoord}
            />
            {validationErrors.Wachtwoord && (
              <p
                style={{
                  color: "red",
                  marginTop: "5px",
                  fontSize: "1.2rem",
                  width: "400px",
                }}
                role="alert"
                aria-live="assertive"
              >
                {validationErrors.Wachtwoord}
              </p>
            )}
          </label>
          <label style={styles.label} htmlFor="Herhaal Wachtwoord">
            Herhaal wachtwoord:
            <input
              placeholder="Vul hier je wachtwoord opnieuw in"
              type="password"
              name="HerhaalWachtwoord"
              value={values.HerhaalWachtwoord}
              onChange={handleInputChange}
              style={styles.input}
            />
            {!passwordsMatch && (
              <p
                style={{
                  color: "red",
                  marginTop: "5px",
                  fontSize: "1.2rem",
                  width: "400px",
                }}
              >
                Wachtwoorden komen niet overeen
              </p>
            )}
          </label>
          <label style={styles.label} htmlFor="Postcode">
            Postcode:
            <input
              placeholder="Vul hier je postcode in"
              type="text"
              name="Postcode"
              value={values.Postcode}
              onChange={handleChange}
              style={styles.input}
              aria-invalid={!!validationErrors.Postcode}
            />
            {validationErrors.Postcode && (
              <p
                style={{
                  color: "red",
                  marginTop: "5px",
                  fontSize: "1.2rem",
                  width: "400px",
                }}
                role="alert"
                aria-live="assertive"
              >
                {validationErrors.Postcode}
              </p>
            )}
          </label>
          <label style={styles.label} htmlFor="Geboortedatum picker">
            Geboortedatum:
            <div style={styles.label}>
          <input
            placeholder="Vul hier uw geboortedatum in"
            type="text"  // Change the type to "text"
            name="Geboortedatum"
            value={values.Geboortedatum}
            onChange={handleDateChange}
            style={styles.input}
            aria-invalid={!!validationErrors.Geboortedatum}
            aria-describedby="geboortedatumError"
            onClick={(e) => {
              e.target.type = 'date';
            }}
          />
            </div>
            {validationErrors.Geboortedatum && (
              <p
                style={{
                  color: "red",
                  marginTop: "5px",
                  fontSize: "1.2rem",
                  width: "400px",
                }}
                role="alert"
                aria-live="assertive"
              >
                {validationErrors.Geboortedatum}
              </p>
            )}
          </label>
          <label style={styles.label} htmlFor="Telefoonnummer">
            Telefoonnummer:
            <input
              placeholder="Vul hier je telefoonnummer in"
              type="text"
              name="TelefoonNummer"
              value={values.TelefoonNummer}
              onChange={handleChange}
              style={styles.input}
            />
          </label>
          {validationErrors.TelefoonNummer && (
            <p
              style={{
                color: "red",
                marginTop: "5px",
                fontSize: "1.2rem",
                width: "400px",
              }}
              role="alert"
              aria-live="assertive"
            >
              {validationErrors.TelefoonNummer}
            </p>
          )}
        </div>
        <button
          onClick={() => handleValidation() && onNext()}
          style={styles.button}
          aria-label="Volgende pagina"
        >
          Volgende pagina
        </button>
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
    zIndex: 1 /* Ensure the content is above the triangle background */,
  },
  header: {
    color: "#2B50EC",
    fontSize: "24px",
    fontWeight: "700",
    marginBottom: "20px",
  },
  datePickerContainer: {
    display: "flex",
    flexDirection: "column",
    alignItems: "flex-start",
    marginBottom: "10px",
    background: "#EAEAEA",
  },
  datePickerInput: {
    height: "30px",
    width: "400px",
    background: "#EAEAEA",
    border: "1px solid #ccc",
    borderRadius: "4px",
    paddingLeft: "10px",
    fontSize: "16px",
    marginTop: "5px",
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
    marginBottom: "10px",
    color: "black",
    fontWeight: 600,
    letterSpacing: ".5px",
  },
  input: {
    height: "30px",
    width: "400px",
    background: "#EAEAEA",
    border: "1px solid #ccc",
    borderRadius: "4px",
    paddingLeft: "10px",
    fontSize: "16px",
    textTransform: "initial",
  },
  button: {
    background: "#108670",
    color: "#fff",
    padding: "10px 20px",
    borderRadius: "4px",
    fontSize: "16px",
    cursor: "pointer",
  },
};

export default GeneralInfo;
