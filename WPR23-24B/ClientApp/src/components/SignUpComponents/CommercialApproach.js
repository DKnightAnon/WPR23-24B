// CommercialApproach.js
import React from "react";
import "./SignUpStyle.css";

const CommercialApproach = ({ onPrev, onSubmit, values, handleChange }) => {
  return (
    <div>
      <div className="triangle-background"></div>
      <div style={styles.container}>
        <h2 style={styles.header}>Toestaan benaderingen</h2>
        <div style={styles.checkboxContainer}>
          <label style={styles.checkboxLabel}>
            Sta commerciële benadering toe:
            <input
              type="checkbox"
              name="allowCommercialApproach"
              checked={values.allowCommercialApproach}
              onChange={handleChange}
              style={styles.checkbox}
            />
          </label>
          <label style={styles.checkboxLabel}>
            Sta benadering via portal toe:
            <input
              type="checkbox"
              name="allowPortalApproach"
              checked={values.allowPortalApproach}
              onChange={handleChange}
              style={styles.checkbox}
            />
          </label>
          <label style={styles.checkboxLabel}>
            Sta telefonische benadering toe:
            <input
              type="checkbox"
              name="allowPhoneApproach"
              checked={values.allowPhoneApproach}
              onChange={handleChange}
              style={styles.checkbox}
            />
          </label>
        </div>
        <div style={styles.buttonContainer}>
          <button onClick={onPrev} style={styles.previousButton}>
            Vorige pagina
          </button>
          <button onClick={onSubmit} style={styles.button}>
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
    marginBottom: "10px",
  },
  checkbox: {
    marginTop: "5px", // Adjust the spacing as needed
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

  // Media Query for mobile responsiveness
  "@media only screen and (max-width: 768px)": {
    container: {
      width: "80%", // Adjusted width for better responsiveness on smaller screens
      maxWidth: "none", // Remove the maximum width for smaller screens
    },
  },
};

export default CommercialApproach;
