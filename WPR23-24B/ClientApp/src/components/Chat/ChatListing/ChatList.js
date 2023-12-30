import React from 'react';
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

    const MappedList = testListObjects.map(
        m => <ChatListing key={m.id} title={m.title}/>

    )







    return (
        <div className="chat-listing-section">

        <h1>Not clickable yet</h1>
            {MappedList }




        </div>
    );

}