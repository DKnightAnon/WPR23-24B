// NewResearchForm.js

import React, { useState } from 'react';
import styles from './NewResearchForm.module.css';

const NewResearchForm = ({ addNewResearch, closeModal }) => {
  const [researchData, setResearchData] = useState({
    title: '',
    details: '',
    location: '',
    disabilityType: '',
  });

  const [errors, setErrors] = useState({
    title: '',
    details: '',
    location: '',
    disabilityType: '',
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setResearchData((prevData) => ({ ...prevData, [name]: value }));
    // Clear the error when the user starts typing again
    setErrors((prevErrors) => ({ ...prevErrors, [name]: '' }));
  };

  const validateForm = () => {
    let isValid = true;
    const newErrors = { title: '', details: '', location: '', disabilityType: '' };

    // Simple validation - check if the fields are not empty
    if (!researchData.title.trim()) {
      newErrors.title = 'Bedrijfsnaam is verplicht';
      isValid = false;
    }

    if (!researchData.details.trim()) {
      newErrors.details = 'Details zijn verplicht';
      isValid = false;
    }

    if (!researchData.location.trim()) {
      newErrors.location = 'Locatie is verplicht';
      isValid = false;
    }

    if (!researchData.disabilityType.trim()) {
      newErrors.disabilityType = 'Beperking type is verplicht';
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
        <h2>Nieuw onderzoek aanmaken</h2>
        <label htmlFor="title">Bedrijfsnaam:</label>
        <input type="text" name="title" value={researchData.title} onChange={handleChange} placeholder='Vul hier bedrijfsnaam in'/>
        <span className={styles.error}>{errors.title}</span>

        <label htmlFor="details">Details van het onderzoek:</label>
        <textarea name="details" value={researchData.details} onChange={handleChange} placeholder='Vul hier de details van het onderzoek in'></textarea>
        <span className={styles.error}>{errors.details}</span>

        <label htmlFor="location">Locatie:</label>
        <input type="text" name="location" value={researchData.location} onChange={handleChange} placeholder='Vul hier de locatie van het onderzoek in'/>
        <span className={styles.error}>{errors.location}</span>

        <label htmlFor="disabilityType">Beperking type:</label>
        <input type="text" name="disabilityType" value={researchData.disabilityType} onChange={handleChange} placeholder='Vul hier de gewenste beperking voor het onderzoek in'/>
        <span className={styles.error}>{errors.disabilityType}</span>

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
