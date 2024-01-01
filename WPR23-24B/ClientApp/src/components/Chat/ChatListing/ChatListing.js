
import React from 'react';
import { useState, useEffect } from "react";


//Component that represents a single user conversation. 
//This component should be represented as a tile in a list.
export default function ChatListing(props)

{

    const [LastMessageTimestamp, setLastMessageTimestamp] = useState(props.timestamp);


    //This should go in the button. It will be responsible for calling a function in the parent component to load the correct chat functions
//, props.chatloadfunction(props.id)
    return (

        <div className="chat-listing">
            <button className="load-conversation-button" onClick={() => console.log("button was pressed! caller : " + props.id)}>
                <h3 className="conversation-title"> {props.title}  </h3>
                <p className="conversation-id">conversation id : {props.id}</p>
                <p className="participant-name">Participant goes here</p>
                <p className="">Time last message was sent goes here : {LastMessageTimestamp} </p>
            </button>



        </div>


)

}