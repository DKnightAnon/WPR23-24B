import React, { useEffect, useState } from 'react';
import axios from 'axios';
import Card from './Card';

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
                                <Card title={article.title} img={article.urlToImage} text={article.description} />
                            </div>
                        ))}
                    </div>
                </div>
            </div>
        </div>
    );
}
export default News;