// DisabilityType.js
import React from "react";
import "./SignUpStyle.css";

const DisabilityType = ({ onNext, onPrev, values, handleChange }) => {
  return (
    <div>
      <div className="progress-bar" style={{ width: "66.66%" }}></div>

      <div className="triangle-background"></div>

      <div style={styles.container}>
        <h2 style={styles.header}>Type Beperking</h2>
        <div style={styles.inputContainer}>
          <label style={styles.label}>
            Selecteer hier u beperking
            <select
              name="disability"
              value={values.disability}
              onChange={handleChange}
              style={styles.select}
            >
              <option value="">Selecteer</option>
              <option value="physical">Fysieke Berking</option>
              <option value="visual">Visuele Beperking</option>
              <option value="hearing">Auditore Beperking</option>
            </select>
          </label>

          <div style={styles.inputContainer}>
            <label style={styles.label}>
              Anders, namelijk..
              <input
                placeholder="Vul hier een eventuele andere beperking in"
                type="text"
                name="beperking"
                value={values.beperking}
                onChange={handleChange}
                style={styles.input}
              />
            </label>
          </div>
        </div>
        <div style={styles.buttonContainer}>
          <button onClick={onPrev} style={styles.previousButton}>
            Vorige pagina
          </button>
          <button onClick={onNext} style={styles.button}>
            Volgende pagina
          </button>
        </div>
      </div>
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
  },
  icon: {
    width: "20px", // Adjust the size as needed
    height: "20px",
    marginLeft: "1020px",
  },
};

export default DisabilityType;
