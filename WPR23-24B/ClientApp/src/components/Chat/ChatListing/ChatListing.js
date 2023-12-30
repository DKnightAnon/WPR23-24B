
import React from 'react';



//Component that represents a single user conversation. 
//This component should be represented as a tile in a list.
export default function ChatListing(props)

{






    return (

        <div className="chat-listing">

            <h3 className="conversation-title"> {props.title}  </h3>
            <p className="participant-name">Participant goes here</p>
            <p className="">Time last message was sent goes here</p>




        </div>


)

}