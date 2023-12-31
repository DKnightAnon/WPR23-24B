import React from 'react';
import { useState, useEffect } from "react";

import ChatListing from './ChatListing';


//Component to represent the list of conversations a user has. 
export default function ChatList(props) {

    const testListObjects = [
        {
            id: 1,
            title: "first conversation"
        },
        {
            id: 2,
            title: "second conversation"
        }





    ];

    const MappedList = (argument) =>
    
        //console.log(argument)
        argument.map(
            m => <ChatListing key={m.id} id={m.id} title={m.title} loadChatFunction={props.chatloadfunction } />

        )


    

    const url = "https://localhost:7180/api/ChatRooms";

    const [conversationList, setConversationList] = useState([]);

    const fetchInfo = async () => {
        fetch(url)
            .then((result) => result.json())
            .then((data) => setConversationList(data))
            console.log(conversationList)
    };


    useEffect(() => {
        fetchInfo();
    }, [])


    return (
        <div className="chat-list">

            <h1>Conversations <br/>(Not clickable yet)</h1>
            {MappedList(conversationList)}




        </div>
    );

}