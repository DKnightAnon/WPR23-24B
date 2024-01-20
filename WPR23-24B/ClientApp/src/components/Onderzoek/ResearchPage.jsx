import React, { useState, useEffect } from "react";
import {
  Card,
  Button,
  Alert,
  Container,
  Row,
  Col,
  Modal,
} from "react-bootstrap";

import { Link } from "react-router-dom";
import { makeApiRequest } from "../../Services/Utils/ApiHelper";
import DeskundigeNavbar from "../Dashboards/Ervaringsdeskundige/ErvaringsdeskundigeNavbar";
import styled from "styled-components";
import ClaimForm from "./ClaimForm";

// ResearchPage is a react component that displays available researches and allows users
// to claim and enroll in them.
const ResearchPage = () => {
  // State variables to manage research data, claim messages, selected research ID, and modal visibility
  const [researches, setResearches] = useState([]);
  const [claimMessage, setClaimMessage] = useState(null);
  const [selectedResearchId, setSelectedResearchId] = useState(null);
  const [showClaimModal, setShowClaimModal] = useState(false);

  useEffect(() => {
    // Fetch the research data using the makeApiRequest function
    makeApiRequest("Onderzoeks/available", "GET")
      .then((response) => setResearches(response))
      .catch((error) =>
        console.error("Fout bij het ophalen van onderzoeken:", error)
      );
  }, []);

  // Callback function for successful claim
  const handleClaimSuccess = (response) => {
    if (response.message === "Enrollment successful") {
      // Fetch the updated list of available researches
      makeApiRequest("Onderzoeks/available", "GET")
        .then((updatedResearches) => setResearches(updatedResearches))
        .catch((error) =>
          console.error("Fout bij het ophalen van onderzoeken:", error)
        );

      // Reset the selectedResearchId after successful claim
      setSelectedResearchId(null);

      // Set the claim success message
      setClaimMessage("Onderzoek succesvol geclaimd");
      setShowClaimModal(false);
    } else {
      // Handle unexpected success response
      console.error("Unexpected success response:", response);
    }
  };

  const handleClaimError = (error) => {
    console.error("Error claiming research:", error);
    setClaimMessage("Fout bij het claimen van onderzoek. Probeer het opnieuw.");
  };

  const handleClaimResearch = (researchId) => {
    // Set the selected research for claiming
    setSelectedResearchId(researchId);

    // Open the modal
    setShowClaimModal(true);
  };

  // Function to close the modal
  const handleCloseModal = () => {
    // Reset the selectedResearchId when the modal is closed
    setSelectedResearchId(null);

    // Close the modal
    setShowClaimModal(false);
  };

  return (
    <div>
      <DeskundigeNavbar />
      <StyledContainer>
        <StyledContent>
          <StyledHeader>
            <h2>Beschikbare Onderzoeken</h2>
            <h3>Enroll nu!</h3>
          </StyledHeader>
          {/* Display the claim message if it exists */}
          {claimMessage && (
            <Alert
              variant={
                claimMessage.includes("succesvol") ? "success" : "danger"
              }
            >
              {claimMessage}
            </Alert>
          )}
          <Row>
            {researches.map((research) => (
              <Col key={research.id} xs={12} md={6} lg={4} className="mb-4">
                <StyledCard>
                  <Card.Body>
                    <StyledCardTitle>{research.titel}</StyledCardTitle>
                    <Card.Text>Locatie: {research.locatie}</Card.Text>
                    <Card.Text>Datum: {research.datum}</Card.Text>
                    <Link to={`/research/${research.id}`}>
                      <StyledButton variant="primary">Lees Meer</StyledButton>
                    </Link>
                    <StyledButton
                      variant="success"
                      onClick={() => handleClaimResearch(research.id)}
                      className="ml-2"
                    >
                      Inschrijven
                    </StyledButton>
                  </Card.Body>
                </StyledCard>
              </Col>
            ))}
          </Row>
        </StyledContent>
      </StyledContainer>
      {/* Claim Research Modal */}
      <StyledClaimModal show={showClaimModal} onHide={handleCloseModal}>
        <Modal.Header closeButton>
          <Modal.Title>Onderzoek Inschrijven</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <ClaimForm
            researchId={selectedResearchId}
            onClaimSuccess={handleClaimSuccess}
            onClaimError={handleClaimError}
            closeModal={handleCloseModal}
          />
        </Modal.Body>
      </StyledClaimModal>
      ;
    </div>
  );
};

const StyledContainer = styled(Container)`
  padding-top: 20px;
`;

const StyledContent = styled.div`
  margin-top: 20px;
`;

const StyledHeader = styled.div`
  text-align: center;
  margin-bottom: 20px;

  h2 {
    font-size: 36px;
    color: ${({ theme }) => theme.colors.heading};
  }
`;

const StyledCard = styled(Card)`
  border: 2px solid #1ca883;
  border-radius: 7px;
  transition: box-shadow 0.3s ease;

  &:hover {
    box-shadow: 0 10px 12px rgba(0, 0, 0, 0.4);
  }
`;

const StyledCardTitle = styled(Card.Title)`
  font-size: 24px;
  margin-bottom: 10px;
`;

const StyledButton = styled(Button)`
  font-size: 14px;
`;

const StyledClaimModal = styled(Modal)`
  .modal-content {
    border-radius: 10px;
  }

  .modal-header {
    border-bottom: none;
  }

  .modal-title {
    font-size: 24px;
    margin-bottom: 0;
  }

  .modal-body {
    padding: 20px;

    input {
      font-size: 16px;
      text-transform: none;
    }

    label {
      font-size: 18px;
    }

    .btn-success {
      font-size: 18px;
      margin-top: 10px;
    }
  }
`;

export default ResearchPage;
