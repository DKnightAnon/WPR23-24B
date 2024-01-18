
import styled from "styled-components";
import { useGlobalContext } from "./context";
import axios from 'axios';
import React, { useEffect, useState } from "react";
import Card from 'react-bootstrap/Card';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Logo from '../src/download.png' 

//const CardContainer = styled.div`
  //border: 1px solid #ddd;
  //padding: 10px;
 // margin: 10px;
  //text-align: center;
//`;

//const CardImage = styled.img`
  //width: 100%;
  //height: 200px; /* Set a fixed height or use 'auto' based on your design */
  //object-fit: cover; /* Ensure the image covers the entire container */
//`;

//const CardTitle = styled.h3`
  //margin-top: 10px;
//`;

//const CardDescription = styled.p`
  //margin-top: 10px;
//`;

const CustomCardImage = styled(Card.Img)`
  height: 200px; 
  object-fit: cover; 
`;

const CustomCard = styled(Card)`
  margin: 50px;  
`;

const titleStyle = {
  fontFamily: 'Montserrat, sans-serif', 
  fontSize: '40px', 
  textAlign: 'center',
  fontWeight: 'bold',
};


function News() {

    const [newsData, setNewsData] = useState([]);

    useEffect(() => {
        const fetchNews = async () => {
            try {
                const apiKey = '14638f8e4ca14306bc9571ac51ab78c8';
                const apiUrl = 'https://newsapi.org/v2/top-headlines';

                const response = await axios.get(apiUrl, {
                    params: {
                        apiKey,
                        country: 'nl',
                        category: 'health',
                    },
                });


                setNewsData(response.data.articles);
            } catch (error) {

                console.error('Error fetching news:', error);
            }
        };


        fetchNews();
    }, []);

    return (
        <div className="container News">
      <h2 style={titleStyle} className="main-title text-center">Nieuws</h2>
      <Row>
        {newsData.map((article, index) => (
          <Col md={4} key={index}>
            <Card>
              <CustomCardImage
                variant="top"
                src={article.urlToImage ? article.urlToImage : Logo}
                alt={article.title}
                onError={(e) => {
                  e.target.src = Logo;
                  e.target.alt = "News Logo";
                }}
              />
              <Card.Body>
                <Card.Title>{article.title}</Card.Title>
                <Card.Text>{article.description}</Card.Text>
              </Card.Body>
            </Card>
          </Col>
        ))}
      </Row>
    </div>
  );
}


    export default News;
