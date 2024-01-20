import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Card, Button, Container } from "react-bootstrap";
import { makeApiRequest } from "../../Services/Utils/ApiHelper";
import styled from "styled-components";
import DeskundigeNavbar from "../Dashboards/Ervaringsdeskundige/ErvaringsdeskundigeNavbar";

const ResearchDetailPage = () => {
  const { id } = useParams();
  const [research, setResearch] = useState(null);

  useEffect(() => {
    if (!id) {
      // Handle the case where id is undefined (e.g., when directly accessing the page without parameters)
      console.error("Research ID is undefined");
      return;
    }

    // Fetch the research data using the makeApiRequest function
    makeApiRequest(`Onderzoeks/${id}`, "GET")
      .then((response) => setResearch(response))
      .catch((error) =>
        console.error(`Error fetching research with ID ${id}:`, error)
      );
  }, [id]);

  if (!research) {
    return <StyledLoading>Loading...</StyledLoading>; // You can replace this with a loading spinner or any other loading indicator
  }

  return (
    <div>
      <DeskundigeNavbar />
      <StyledContainer>
        {research ? (
          <StyledCard>
            <Card.Body>
              <StyledCardTitle>{research.titel}</StyledCardTitle>
              <Card.Text>Locatie: {research.locatie}</Card.Text>
              <Card.Text>Datum: {research.datum}</Card.Text>
              <Card.Text>
                Beschrijving van het onderzoek: {research.beschrijving}
              </Card.Text>
              {/* Add more details as needed */}
            </Card.Body>
          </StyledCard>
        ) : (
          <p>Loading...</p>
        )}
      </StyledContainer>
    </div>
  );
};

const StyledContainer = styled(Container)`
  margin-top: 100px;
`;

const StyledCard = styled(Card)`
  border: 2px solid #1ca883;
  border-radius: 10px;
`;

const StyledCardTitle = styled(Card.Title)`
  font-size: 36px;
  margin-bottom: 20px;
`;

const StyledLoading = styled.div`
  text-align: center;
  margin-top: 50px;
  font-size: 18px;
`;

export default ResearchDetailPage;
