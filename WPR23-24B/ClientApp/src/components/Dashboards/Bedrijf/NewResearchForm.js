// NewResearchForm.js

import React, { useState } from "react";
import styles from "./NewResearchForm.module.css";
import { makeApiRequest } from "../../../Services/Utils/ApiHelper";

const NewResearchForm = ({ addNewResearch, closeModal }) => {
  const [researchData, setResearchData] = useState({
    Titel: "",
    Beschrijving: "",
    Datum: Date,
    Locatie: "",
    Status: "",
    Resultaten: [],
    OnderzoekSoorten: [],
  });

  const [errors, setErrors] = useState({
    Titel: "",
    Beschrijving: "",
    Datum: "",
    Locatie: "",
    Status: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setResearchData((prevData) => ({ ...prevData, [name]: value }));
    // Clear the error when the user starts typing again
    setErrors((prevErrors) => ({ ...prevErrors, [name]: "" }));
  };

  const validateForm = () => {
    let isValid = true;
    const newErrors = {
      Titel: "",
      Beschrijving: "",
      Datum: "",
      Locatie: "",
      Status: "",
    };

    if (!researchData.Titel.trim()) {
      newErrors.Titel = "Titel is verplicht";
      isValid = false;
    }

    if (!researchData.Beschrijving.trim()) {
      newErrors.Beschrijving = "Beschrijving verplicht";
      isValid = false;
    }

    if (!researchData.Datum.trim()) {
      newErrors.Datum = "Datum is verplicht";
      isValid = false;
    }

    if (!researchData.Locatie.trim()) {
      newErrors.Locatie = "Locatie is verplicht";
      isValid = false;
    }

    if (!researchData.Status.trim()) {
      newErrors.Status = "Status is verplicht";
      isValid = false;
    }

    setErrors(newErrors);
    return isValid;
  };

  const handleSubmit = async () => {
    console.log("State before API request:", researchData);

    try {
        // Make API request to add new research
        const endpoint = "Onderzoeks/addNewItem";
        const method = "POST";
        const response = await makeApiRequest(endpoint, method, researchData);

       
        console.log("API Response:", response);

        // Check if the response is successful 
        if (validateForm) {
            // Add new research 
            researchData.Id = response.onderzoekId;
            addNewResearch(researchData); 

            closeModal();
        } else {
            console.error("Error submitting research.");
        }
    } catch (error) {
        console.error("Error submitting research:", error);
        console.log("API Response status:", error.response?.status);
        console.log("API Response data:", error.response?.data);
    }
};

  const handleCancel = () => {
    closeModal();
  };

  return (
    <div className={styles.modal}>
      <div className={styles["modal-content"]}>
        <h2>Nieuw onderzoek aanmaken:</h2>

        <label htmlFor="Titel">Titel:</label>
        <input
          type="text"
          name="Titel"
          value={researchData.Titel}
          onChange={handleChange}
          placeholder="Vul hier de titel in"
        />
        <span className={styles.error}>{errors.Titel}</span>

        <label htmlFor="Beschrijving">Beschrijving van het onderzoek:</label>
        <textarea
          name="Beschrijving"
          value={researchData.Beschrijving}
          onChange={handleChange}
          placeholder="Vul hier de beschrijving van het onderzoek in"
        ></textarea>
        <span className={styles.error}>{errors.Beschrijving}</span>

        <label htmlFor="Datum">Datum van het onderzoek:</label>
        <input
          type="date"
          name="Datum"
          value={researchData.Datum}
          onChange={handleChange}
          placeholder="Vul hier de datum van het onderzoek in"
        />
        <span className={styles.error}>{errors.Datum}</span>

        <label htmlFor="Locatie">Locatie:</label>
        <input
          type="text"
          name="Locatie"
          value={researchData.Locatie}
          onChange={handleChange}
          placeholder="Vul hier de locatie van het onderzoek in"
        />
        <span className={styles.error}>{errors.Locatie}</span>

        <label htmlFor="Status">Status:</label>
        <input
          type="text"
          name="Status"
          value={researchData.Status}
          onChange={handleChange}
          placeholder="Vul hier de status van het onderzoek in"
        />
        <span className={styles.error}>{errors.Status}</span>

        <div className={styles["button-container"]}>
          <button onClick={handleSubmit}>Onderzoek toevoegen</button>
          <button className={styles.cancel} onClick={handleCancel}>
            Annuleer
          </button>
        </div>
      </div>
    </div>
  );
};

export default NewResearchForm;
