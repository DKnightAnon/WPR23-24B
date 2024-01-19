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

  const handleDelete = async (id) => {
    try{{
      const endpoint = "Onderzoeks/${id}";
      const method = "DELETE";
      const response = await makeApiRequest(endpoint, method);

      console.log("API Repsonse:", response)
       // If the deletion is successful, update the state or perform any other necessary actions
      deleteResearch(id)
      
    }} catch(error){
      console.error("Error submitting research:", error);
        console.log("API Response status:", error.response?.status);
        console.log("API Response data:", error.response?.data);
    }
  }

  return (
    <div className={styles['research-list']}>
      {researches.map((research, index) => (
        <div key={research.id} className={styles['research-item']}>
          <h3>{research.Titel}</h3>
          <button className={styles['details-button']} onClick={() => openModal(index)}>
            Bekijk Details
          </button>
          <button className={styles['delete-button']} onClick={() => handleDelete(research.id)}>
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
