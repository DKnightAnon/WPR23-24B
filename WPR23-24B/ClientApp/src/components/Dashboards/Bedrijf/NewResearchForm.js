// NewResearchForm.js

import React, { useState } from 'react';
import styles from './NewResearchForm.module.css';

const NewResearchForm = ({ addNewResearch, closeModal }) => {
  const [researchData, setResearchData] = useState({
    Id: '',
    Titel: '',
    Beschrijving: '',
    Datum: '',
    Locatie: '',
    Status: '',
  });

  const [errors, setErrors] = useState({
    Id: '',
    Titel: '',
    Beschrijving: '',
    Datum: '',
    Locatie: '',
    Status: '',
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setResearchData((prevData) => ({ ...prevData, [name]: value }));
    // Clear the error when the user starts typing again
    setErrors((prevErrors) => ({ ...prevErrors, [name]: '' }));
  };

  const validateForm = () => {
    let isValid = true;
    const newErrors = { Id: '',
    Titel: '',
    Beschrijving: '',
    Datum: '',
    Locatie: '',
    Status: ''};

    // Simple validation - check if the fields are not empty
    if (!researchData.Id.trim()) {
      newErrors.Id = 'Id is verplicht';
      isValid = false;
    }
    
    if (!researchData.Titel.trim()) {
      newErrors.Titel = 'Titel is verplicht';
      isValid = false;
    }

    if (!researchData.Beschrijving.trim()) {
      newErrors.Beschrijving = 'Beschrijving verplicht';
      isValid = false;
    }

    if (!researchData.Datum.trim()) {
      newErrors.Datum = 'Datum is verplicht';
      isValid = false;
    }

    if (!researchData.Locatie.trim()) {
      newErrors.Locatie = 'Locatie is verplicht';
      isValid = false;
    }

    if (!researchData.Status.trim()) {
      newErrors.Status = 'Status is verplicht';
      isValid = false;
    }
    
    setErrors(newErrors);
    return isValid;
  };

  const handleSubmit = () => {
    if (validateForm()) {
      // Form is valid, add the new research
      const researchJSON = JSON.stringify(researchData);
      console.log('JSON Data: ', researchJSON)// log naar de console
      addNewResearch(researchJSON);
      closeModal();
    }
  };

  const handleCancel = () => {
    closeModal();
  };

  return (
    <div className={styles.modal}>
      <div className={styles['modal-content']}>
        <h2>Nieuw onderzoek aanmaken:</h2>

        <label htmlFor="Id">Onderzoeks ID:</label>
        <input type="text" name="Id" value={researchData.Id} onChange={handleChange} placeholder='Vul hier id van het onderzoek in'/>
        <span className={styles.error}>{errors.Id}</span>

        <label htmlFor="Titel">Titel:</label>
        <input type="text" name="Titel" value={researchData.Titel} onChange={handleChange} placeholder='Vul hier de titel in'/>
        <span className={styles.error}>{errors.Titel}</span>

        <label htmlFor="Beschrijving">Beschrijving van het onderzoek:</label>
        <textarea name="Beschrijving" value={researchData.Beschrijving} onChange={handleChange} placeholder='Vul hier de beschrijving van het onderzoek in'></textarea>
        <span className={styles.error}>{errors.Beschrijving}</span>

        <label htmlFor="Datum">Datum van het onderzoek:</label>
        <input type="text" name="Datum" value={researchData.Datum} onChange={handleChange} placeholder='Vul hier de datum van het onderzoek in'/>
        <span className={styles.error}>{errors.Datum}</span>

        <label htmlFor="Locatie">Locatie:</label>
        <input type="text" name="Locatie" value={researchData.Locatie} onChange={handleChange} placeholder='Vul hier de locatie van het onderzoek in'/>
        <span className={styles.error}>{errors.Locatie}</span>

        <label htmlFor="Status">Status:</label>
        <input type="text" name="Status" value={researchData.Status} onChange={handleChange} placeholder='Vul hier de status van het onderzoek in'/>
        <span className={styles.error}>{errors.Status}</span>

        <div className={styles['button-container']}>
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
