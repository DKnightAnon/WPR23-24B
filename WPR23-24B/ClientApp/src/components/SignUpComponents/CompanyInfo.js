// CompanyInfo.js
import React from "react";
import "./SignUpStyle.css";

const CompanyInfo = ({ onNext, onSubmit, values, handleChange }) => {
  const {
    Naam,
    ContactPersoon,
    Email,
    TelefoonNummer,
    Postcode,
    Adres,
    Website,
    Wachtwoord,
    TrackingId,
  } = values;

  return (
    <div>
      <div className="progress-bar" style={{ width: "33.33%" }}></div>
      <div className="triangle-background"></div>
      <div style={styles.container}>
        <h2 style={styles.header}>Bedrijf Registratie</h2>
        <div style={styles.inputContainer}>
          <label style={styles.label}>
            Bedrijfsnaam:
            <input
              placeholder="Vul hier de naam in van het bedrijf"
              type="text"
              name="Naam"
              value={Naam}
              onChange={(e) => handleChange(e, "company")}
              style={styles.input}
            />
          </label>
          <label style={styles.label}>
            Contactpersoon:
            <input
              placeholder="Vul hier de volledige naam in van jullie contactpersoon"
              type="text"
              name="ContactPersoon"
              value={ContactPersoon}
              onChange={(e) => handleChange(e, "company")}
              style={styles.input}
            />
          </label>
          <label style={styles.label}>
            Email:
            <input
              placeholder="Vul hier het e-mailadres in van het bedrijf"
              type="text"
              name="Email"
              value={Email}
              onChange={(e) => handleChange(e, "company")}
              style={styles.input}
            />
          </label>
          <label style={styles.label}>
            Telefoonnummer:
            <input
              placeholder="Vul hier het telefoonnummer in van het bedrijf"
              type="text"
              name="TelefoonNummer"
              value={TelefoonNummer}
              onChange={(e) => handleChange(e, "company")}
              style={styles.input}
            />
          </label>
          <label style={styles.label}>
            Postcode:
            <input
              placeholder="Vul hier het postcode in van het bedrijf"
              type="text"
              name="Postcode"
              value={Postcode}
              onChange={(e) => handleChange(e, "company")}
              style={styles.input}
            />
          </label>
          <label style={styles.label}>
            Adres:
            <input
              placeholder="Vul hier het adres in van het bedrijf"
              type="text"
              name="Adres"
              value={Adres}
              onChange={(e) => handleChange(e, "company")}
              style={styles.input}
            />
          </label>
          <label style={styles.label}>
            Website (https://example.com):
            <input
              placeholder="Vul hier de URL in van het bedrijf"
              type="text"
              name="Website"
              value={Website}
              onChange={(e) => handleChange(e, "company")}
              style={styles.input}
            />
          </label>
          <label style={styles.label}>
            Wachtwoord:
            <input
              placeholder="Vul hier het wachtwoord in van het bedrijfsaccount"
              type="password"
              name="Wachtwoord"
              value={Wachtwoord}
              onChange={(e) => handleChange(e, "company")}
              style={styles.input}
            />
          </label>
          <label style={styles.label}>
            Tracking ID:
            <input
              placeholder="Vul hier het tracking ID in van het bedrijf"
              type="text"
              name="TrackingId"
              value={TrackingId}
              onChange={(e) => handleChange(e, "company")}
              style={styles.input}
            />
          </label>
        </div>
        <button
          onClick={() => {
            onNext();
            onSubmit(values);
          }}
          style={styles.button}
        >
          Registratie Afronden
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
    zIndex: 1,
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

export default CompanyInfo;
