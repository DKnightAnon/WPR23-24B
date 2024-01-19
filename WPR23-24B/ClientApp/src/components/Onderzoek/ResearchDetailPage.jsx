// ResearchDetailPage.jsx
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Card, Button } from "react-bootstrap";
import { makeApiRequest } from "../../Services/Utils/ApiHelper";

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
    return <div>Loading...</div>; // You can replace this with a loading spinner or any other loading indicator
  }

  return (
    <div className="container mt-5">
      {research ? (
        <Card>
          <Card.Body>
            <Card.Title>{research.titel}</Card.Title>
            <Card.Text>Location: {research.locatie}</Card.Text>
            <Card.Text>Date: {research.datum}</Card.Text>
            <Card.Text>Description: {research.beschrijving}</Card.Text>
            {/* Add more details as needed */}
          </Card.Body>
        </Card>
      ) : (
        <p>Loading...</p>
      )}
    </div>
  );
};

export default ResearchDetailPage;
