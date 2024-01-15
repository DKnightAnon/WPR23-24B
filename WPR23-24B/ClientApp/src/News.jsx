
import styled from "styled-components";
import { useGlobalContext } from "./context";
import axios from 'axios';
import React, { useEffect, useState } from "react";

const CardContainer = styled.div`
  border: 1px solid #ddd;
  padding: 10px;
  margin: 10px;
  text-align: center;
`;

const CardImage = styled.img`
  width: 100%;
  height: 200px; /* Set a fixed height or use 'auto' based on your design */
  object-fit: cover; /* Ensure the image covers the entire container */
`;

const CardTitle = styled.h3`
  margin-top: 10px;
`;

const CardDescription = styled.p`
  margin-top: 10px;
`;


function News() {

    const [newsData, setNewsData] = useState([]);

    useEffect(() => {
        const fetchNews = async () => {
            try {
                const apiKey = '4e310e0c4dad46f2bf7a464bc2cda45d';
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
        <h2 className="main-title text-center">NEWS</h2>
        <div className="card-cover">
          <div className="col-md-12">
            <div className="row">
              {newsData.map((article, index) => (
                <div className="col-md-4 mb-2" key={index}>
                  <CardContainer>
                    <CardImage src={article.urlToImage} alt={article.title} />
                    <CardTitle>{article.title}</CardTitle>
                    <CardDescription>{article.description}</CardDescription>
                  </CardContainer>
                </div>
              ))}
            </div>
          </div>
        </div>
      </div>
    );
  }


    export default News;
