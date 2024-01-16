// NieuwOnderzoekButton.js

import React, { useState } from 'react';
import NewResearchForm from './NewResearchForm'; // Import the new component
import styles from './NieuwOnderzoekButton.module.css';

const NieuwOnderzoekButton = ({ createNewResearch }) => {
  const [formOpen, setFormOpen] = useState(false);

  const openForm = () => {
    setFormOpen(true);
  };

  const closeForm = () => {
    setFormOpen(false);
  };

  return (
    <div className="nieuw-onderzoek">
      <button className={styles['nieuw-button']} onClick={openForm}>Nieuw Onderzoek</button>
      {formOpen && <NewResearchForm addNewResearch={createNewResearch} closeModal={closeForm} />}
    </div>
  );
};

export default NieuwOnderzoekButton;
