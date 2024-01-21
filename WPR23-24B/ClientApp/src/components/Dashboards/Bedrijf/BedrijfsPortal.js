import React from 'react';
import NavBar from './NavBar';
import NewResearchForm from './NewResearchForm';
import NieuwOnderzoekButton from './NieuwOnderzoekButton';
import ResearchList from './ResearchList';
import InfoPage from './InfoPage';
import { useState } from 'react';

const BedrijfsPortal = () => {
    const [researches, setResearches] = useState([]);
    const [researchListVisible, setResearchListVisible] = useState(true); 
    const [newResearchButtonVisible, setNewResearchButtonVisible] = useState(true);
    const [newComponentVisible, setNewComponentVisible] = useState(false); 
  
    
    const showDetails = (index) => {
      alert(`Details for research: ${researches[index].details}`);
    };
  
    const createNewResearch = (newResearch) => {
      setResearches([...researches, newResearch]);
    };
  
    const toggleVisibility = () => {
      setResearchListVisible(!researchListVisible);
      setNewResearchButtonVisible(!newResearchButtonVisible);
      // Update the text inside the 'Gegevens' button based on the current visibility state
      setNewComponentVisible(!newComponentVisible);
    };
  
    const closeComponent = () => {
      setNewComponentVisible(false);
    };
  
    return (
      <div>
        <NavBar toggleResearchListVisibility={toggleVisibility} />
        <div className="main-content">
          {researchListVisible && (
            <ResearchList researches={researches} showDetails={showDetails}/>
          )}
          {newResearchButtonVisible && (
            <NieuwOnderzoekButton createNewResearch={createNewResearch} />
          )}
          {newComponentVisible && <InfoPage closeComponent={closeComponent} />}
        </div>
      </div>
    );
};

export default BedrijfsPortal;