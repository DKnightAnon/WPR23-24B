// ResearchList.js

import React, { useState } from 'react';
import styles from './researchList.module.css';

const ResearchList = ({ researches, showDetails, deleteResearch }) => {
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

  const handleDelete = (index) => {
    // Call the deleteResearch function passed from App
    deleteResearch(index);
  };

  return (
    <div className={styles['research-list']}>
      {researches.map((research, index) => (
        <div key={research.id} className={styles['research-item']}>
          <h3>{research.title}</h3>
          <button className={styles['details-button']} onClick={() => openModal(index)}>
            Bekijk Details
          </button>
          <button className={styles['delete-button']} onClick={() => handleDelete(index)}>
            Verwijder onderzoek
          </button>
        </div>
      ))}



  {modalOpen && selectedResearch && (
            <div className={styles['modal']}>
              <div className={styles['modal-content']}>
                <h2>{selectedResearch.title}</h2>
                <p>{selectedResearch.details}</p>
                <p><strong>Locatie:</strong> {selectedResearch.location}</p>
                <p><strong>Beperking type:</strong> {selectedResearch.disabilityType}</p>
                <button onClick={closeModal}>Close</button>
              </div>
            </div>
          )}
    </div>
  );
};

export default ResearchList;
