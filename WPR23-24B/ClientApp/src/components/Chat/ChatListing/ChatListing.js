
import React from 'react';
import { useState, useEffect } from "react";
import { useSelector, useDispatch } from 'react-redux'
import { clearChat, addConversationContent, printTest } from '../../../store/slices/chatSlice'
import { setCurrentRoom } from '../../../store/slices/chatroomSlice'


//Component that represents a single user conversation. 
//This component should be represented as a tile in a list.
export default function ChatListing(props)

{


    const chatConversation =
    {
        id: props.id,
        title: props.title

    }


    const [conversationList, setConversationList] = useState([])


    //const conversationContent = useSelector((state) => state.conversationContent.content)

    const dispatch = useDispatch();

    const urlBase = "https://localhost:7180/api/ChatRooms/berichten/";
    const urlParam = chatConversation.id;
    const url = urlBase + urlParam;

    async function fetchInfo() {
        fetch(url)
            .then((result) => result.json())
            .then(
                (data) => {
                    //console.log(data)
                    setConversationList(data)
                    //console.log(conversationList)
                   
                }
            )
       // console.log(conversationList)
    };



    //test to see if conversationList is properly changed.
    useEffect(() => {
        console.log('UseEffect triggered!')
        console.log(conversationList)
        dispatch(clearChat())
        dispatch(
            addConversationContent(
                conversationList))
        dispatch(
            setCurrentRoom(
                chatConversation))



    }, [conversationList])


    const [LastMessageTimestamp, setLastMessageTimestamp] = useState(props.timestamp);

    const loadChat = () => {
        console.log("button was pressed! caller : " + props.id);

        //clearChet method functions as intended and clears the chatbox of the client that triggered it.
        //dispatch(clearChat())
        fetchInfo()

        
    }

    //This should go in the button. It will be responsible for calling a function in the parent component to load the correct chat functions
//, props.chatloadfunction(props.id)
    return (

        <div className="chat-listing">
            <button className="load-conversation-button" onClick={() => { loadChat() } }>
                <h3 className="conversation-title"> {chatConversation.title}  </h3>
                <p className="conversation-id">conversation id : {chatConversation.id}</p>
                <p className="participant-name">Participant goes here</p>
                <p className="">Time last message was sent goes here : {LastMessageTimestamp} </p>
            </button>



        </div>


)

}