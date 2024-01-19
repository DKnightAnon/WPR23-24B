// ResearchPage.jsx
import React, { useState, useEffect } from "react";
import { Card, Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import { makeApiRequest } from "../../Services/Utils/ApiHelper";

const ResearchPage = () => {
  const [researches, setResearches] = useState([]);

  useEffect(() => {
    // Fetch the research data using the makeApiRequest function
    makeApiRequest("Onderzoeks", "GET")
      .then((response) => setResearches(response))
      .catch((error) => console.error("Error fetching researches:", error));
  }, []);

  const handleClaimResearch = (researchId) => {
    // Implement logic to handle claiming a research
    console.log(`Research with ID ${researchId} claimed`);
  };

  return (
    <div className="container mt-5">
      <h2 className="mb-4">Available Researches</h2>
      <div className="row">
        {researches.map((research) => (
          <div key={research.id} className="col-md-6 mb-4">
            <Card>
              <Card.Body>
                <Card.Title>{research.titel}</Card.Title>
                <Card.Text>Location: {research.locatie}</Card.Text>
                <Card.Text>Date: {research.datum}</Card.Text>
                <Link to={`/research/${research.id}`}>
                  <Button variant="primary">Read More</Button>
                </Link>
                <Button
                  variant="success"
                  onClick={() => handleClaimResearch(research.id)}
                  className="ml-2"
                >
                  Claim
                </Button>
              </Card.Body>
            </Card>
          </div>
        ))}
      </div>
    </div>
  );
};

export default ResearchPage;
