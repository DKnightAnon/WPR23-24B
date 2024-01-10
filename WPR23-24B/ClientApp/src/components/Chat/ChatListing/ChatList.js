import React from 'react';
import { useState, useEffect } from "react";

import ChatListing from './ChatListing';


import { Spinner } from 'reactstrap';

//Component to represent the list of conversations a user has. 
export default function ChatList(props) {





    const MappedList = (argument) =>
    
        //console.log(argument)
        argument.map(
            m => <ChatListing key={m.id} id={m.id} title={m.title} /> 

        )


    

    const url = process.env.REACT_APP_API_BASE_URL + "ChatRooms";

    const [conversationList, setConversationList] = useState([]);

    const fetchInfo = async () => {
        fetch(url)
            .then((result) => result.json())
            .then((data) => setConversationList(data))
            //console.log(conversationList)
    };


    useEffect(() => {
        fetchInfo();
    }, [])


    return (
        
            <div className="chat-list">
                <h1>Conversations </h1>
                {MappedList(conversationList)}
            </div>

    );

}