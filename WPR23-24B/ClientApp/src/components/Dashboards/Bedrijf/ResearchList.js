// ResearchList.js

import React, { useState } from 'react';
import styles from './researchList.module.css';
import NewResearchForm from './NewResearchForm';
import { makeApiRequest } from '../../../Services/Utils/ApiHelper';

const ResearchList = ({ researches, deleteResearch }) => {
  const [modalOpen, setModalOpen] = useState(false);
  const [selectedResearch, setSelectedResearch] = useState(null);

  const openModal = (index) => {
    setSelectedResearch(researches[index]);
    setModalOpen(true);
  };

  const closeModal = () => {
    setSelectedResearch(null);
    setModalOpen(false);
  };

  const handleDelete = async (Id) => {
    try {
      console.log("Deleting research with ID:", Id); // Log the ID being deleted

      const endpoint = `Onderzoeks/${Id}`; // Fix the endpoint to include the correct ID
      const method = "DELETE";
      const response = await makeApiRequest(endpoint, method);

      console.log("API Response:", response);

      // If the deletion is successful, update the state or perform any other necessary actions
      deleteResearch(Id);
    } catch (error) {
      console.error("Error deleting research:", error);
      console.log("API Response status:", error.response?.status);
      console.log("API Response data:", error.response?.data);
    }
  };

  return (
    <div className={styles['research-list']}>
      {researches.map((research, index) => (
        <div key={research.Id} className={styles['research-item']}>
          <h3>{research.Titel}</h3>
          <button className={styles['details-button']} onClick={() => openModal(index)}>
            Bekijk Details
          </button>
          <button className={styles['delete-button']} onClick={() => handleDelete(research.Id)}>
            Verwijder onderzoek
          </button>
        </div>
      ))}



  {modalOpen && selectedResearch && (
            <div className={styles['modal']}>
              <div className={styles['modal-content']}>
                <h2>{selectedResearch.Titel}</h2>
                <p>{selectedResearch.Beschrijving}</p>
                <p><strong>Locatie:</strong> {selectedResearch.Locatie}</p>
                <p><strong>Datum:</strong> {selectedResearch.Datum}</p>
                <button onClick={closeModal}>Close</button>
              </div>
            </div>
          )}
    </div>
  );
};

export default ResearchList;
