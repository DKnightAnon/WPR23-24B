// UserOrCompanyChoice.js
import React from "react";
import "./SignUpStyle.css";

const UserOrCompanyChoice = ({ onSelectUser, onSelectCompany }) => {
  return (
    <div>
      <div className="progress-bar" style={{ width: "0%" }}></div>
      <div className="triangle-background"></div>
      <div style={styles.container}>
        <h2 style={styles.header}>Registratiekeuze</h2>
        <div style={styles.choiceContainer}>
          <button onClick={onSelectUser} style={styles.choiceButton}>
            Registreer jezelf als gebruiker
          </button>
          <button onClick={onSelectCompany} style={styles.choiceButton}>
            Registreer als bedrijf
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
    width: "80%", // Adjusted width for better responsiveness
    maxWidth: "600px", // Maximum width for larger screens
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
  choiceContainer: {
    display: "flex",
    flexDirection: "column",
    alignItems: "center",
  },
  choiceButton: {
    background: "#108670",
    color: "#fff",
    padding: "10px 20px",
    borderRadius: "4px",
    fontSize: "16px",
    cursor: "pointer",
    margin: "10px",
  },
};

export default UserOrCompanyChoice;
