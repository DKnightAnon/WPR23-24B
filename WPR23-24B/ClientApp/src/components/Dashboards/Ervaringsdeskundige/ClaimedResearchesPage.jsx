import React, { useState, useEffect } from "react";
import { Card, Button, Container, Row, Col } from "react-bootstrap";
import DeskundigeNavbar from "./ErvaringsdeskundigeNavbar";
import styled from "styled-components";
import { makeApiRequest } from "../../../Services/Utils/ApiHelper";
import { useNavigate } from "react-router-dom";
// ClaimedResearchesPage is a React component that displays researches
// claimed by the user and provides options to view details or remove them.
const ClaimedResearchesPage = () => {
  // State variable to manage claimed research data
  const navigate = useNavigate();
  const [claimedResearches, setClaimedResearches] = useState([]);
  const [userId, setUserId] = useState(null);

  useEffect(() => {
    // Fetch claimed researches when the component mounts
    makeApiRequest("User/claimed", "GET")
      .then((response) => setClaimedResearches(response))
      .catch((error) =>
        console.error("Error fetching claimed researches:", error)
      );
  }, []);

  // Function to handle "Read More" button click
  const handleReadMore = (researchId) => {
    navigate(`/research/${researchId}`);
  };

  const handleRemoveResearch = async (researchId) => {
    try {
      const response = await makeApiRequest("User/unsubscribe-user-id", "GET");
      const userId = response.userId;

      await makeApiRequest(`User/claimed/${researchId}`, "DELETE");

      // Log the action on the frontend
      const unsubscribeLog = {
        userId: userId,
        researchId: researchId,
        timestamp: new Date().toISOString(),
      };

      // Send the log to your backend for further processing
      // await makeApiRequest("User/logUnsubscribe", "POST", unsubscribeLog);

      setClaimedResearches((prevResearches) =>
        prevResearches.filter((research) => research.id !== researchId)
      );
    } catch (error) {
      console.error("Error removing research:", error);
    }
  };

  return (
    <div>
      <DeskundigeNavbar />
      <StyledContainer>
        <StyledHeader>
          <h2>Claimed Researches</h2>
        </StyledHeader>
        <Row>
          {claimedResearches.map((research) => (
            <Col key={research.id} xs={12} md={6} lg={4} className="mb-4">
              <StyledCard>
                <Card.Body>
                  <StyledCardTitle>{research.titel}</StyledCardTitle>
                  <Card.Text>Locatie: {research.locatie}</Card.Text>
                  <Card.Text>Datum: {research.datum}</Card.Text>
                  <Card.Text>
                    Beschrijving van het onderzoek: {research.beschrijving}
                  </Card.Text>
                  <Button
                    variant="primary"
                    onClick={() => handleReadMore(research.id)}
                    className="mr-2"
                  >
                    Lees meer
                  </Button>
                  <Button
                    variant="danger"
                    onClick={() => handleRemoveResearch(research.id)}
                    className="ml-2"
                  >
                    Uitschrijven
                  </Button>
                </Card.Body>
              </StyledCard>
            </Col>
          ))}
        </Row>
      </StyledContainer>
    </div>
  );
};

const StyledContainer = styled(Container)`
  padding-top: 20px;
`;

const StyledCardTitle = styled(Card.Title)`
  font-size: 24px;
  margin-bottom: 10px;
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

export default ClaimedResearchesPage;
