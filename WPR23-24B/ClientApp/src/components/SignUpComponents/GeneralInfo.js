import React, { useState } from "react";
import "./SignUpStyle.css";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

const GeneralInfo = ({ onNext, values, handleChange }) => {
  const handleDateChange = (date) => {
    setStartDate(date);
  };

  const [startDate, setStartDate] = useState(new Date());

  return (
    <div>
      <div className="progress-bar" style={{ width: "33.33%" }}></div>
      <div className="triangle-background"></div>
      <div style={styles.container}>
        <h2 style={styles.header}>Gebruiker Registratie</h2>
        <div style={styles.inputContainer}>
          <label style={styles.label}>Bent u jonger dan 18 jaar?</label>
          <div style={styles.radioContainer}>
            <label style={styles.radioLabel}>
              <input
                type="radio"
                name="isUnder18"
                value="yes"
                checked={values.isUnder18 === "yes"}
                onChange={handleChange}
              />
              Ja
            </label>
            <label style={styles.radioLabel}>
              <input
                type="radio"
                name="isUnder18"
                value="no"
                checked={values.isUnder18 === "no"}
                onChange={handleChange}
              />
              Nee
            </label>
          </div>
          {values.isUnder18 === "yes" && (
            <div>
              <label style={styles.label}>
                Naam ouder/verzorger:
                <input
                  placeholder="Vul hier de naam in"
                  type="text"
                  name="parentName"
                  value={values.parentName}
                  onChange={handleChange}
                  style={styles.input}
                />
              </label>
              <label style={styles.label}>
                Email ouder/verzorger:
                <input
                  placeholder="Vul hier het email-adres in"
                  type="text"
                  name="parentEmail"
                  value={values.parentEmail}
                  onChange={handleChange}
                  style={styles.input}
                />
              </label>
              <label style={styles.label}>
                Telefoonnummer ouder/verzorger:
                <input
                  placeholder="Vul hier het telefoonnummer in"
                  type="text"
                  name="parentTelefoonnummer"
                  value={values.parentTelefoonnummer}
                  onChange={handleChange}
                  style={styles.input}
                />
              </label>
            </div>
          )}
          <label style={styles.label}>
            Naam:
            <input
              placeholder="Vul hier je volledige naam in"
              type="text"
              name="name"
              value={values.name}
              onChange={handleChange}
              style={styles.input}
            />
          </label>
          <label style={styles.label}>
            Email:
            <input
              placeholder="Vul hier je email-adres in"
              type="text"
              name="email"
              value={values.email}
              onChange={handleChange}
              style={styles.input}
            />
          </label>
          <label style={styles.label}>
            Postcode:
            <input
              placeholder="Vul hier je postcode in"
              type="text"
              name="postcode"
              value={values.postcode}
              onChange={handleChange}
              style={styles.input}
            />
          </label>
          <label style={styles.label}>
            Geboortedatum:
            <div style={styles.label}>
              <DatePicker
                selected={startDate}
                onChange={handleDateChange}
                dateFormat="dd/MM/yyyy"
                isClearable
                placeholderText="Selecteer een datum"
                style={styles.label}
              />
            </div>
          </label>
          <label style={styles.label}>
            Telefoonnummer:
            <input
              placeholder="Vul hier je telefoonnummer in"
              type="text"
              name="telefoonnummer"
              value={values.telefoonnummer}
              onChange={handleChange}
              style={styles.input}
            />
          </label>
        </div>
        <button onClick={onNext} style={styles.button}>
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
