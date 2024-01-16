import React from 'react';
import { useState, useEffect } from "react";

import ListGroup from 'react-bootstrap/ListGroup';


import { useSelector, useDispatch } from 'react-redux'
import { clearChat, addConversationContent, printTest } from '../../../store/slices/chatSlice'
import { setCurrentRoom } from '../../../store/slices/chatroomSlice'
//Component to represent the list of conversations a user has.

import AuthUtils from '../../../Services/Authentication/AuthUtils';

export default function ChatList(props) {



    /*----------------------------------------- MAP DATA TO LISTGROUP.ITEM---------------------------------*/

    const MappedList = (argument) =>

        //console.log(argument)
        argument.map(
            m => <ListGroup.Item key={m.id} action onClick={() => loadChat(m)} style={{ fontSize: "14px" }} > {m.title} </ListGroup.Item>

        )

    



    const url = process.env.REACT_APP_API_BASE_URL + "ChatRooms";

    const [conversationList, setConversationList] = useState([]);

    const fetchInfo = async () => {
        fetch(url)
            .then((result) => result.json())
            .then((data) => setConversationList(data))
        //console.log(conversationList)
    };

    const roomChange = useSelector((state) => state.chatroom.currentroom);

    useEffect(() => {
        fetchInfo();
    }, [roomChange])


    /*---------------------------------------- CHAT LISTING (SINGULAR) ------------------------------*/
    const chatConversation =
    {
        id: props.id,
        title: props.title

    }


    const [conversationContent, setConversationContent] = useState([])
    


    //const conversationContent = useSelector((state) => state.conversationContent.content)

    const dispatch = useDispatch();
    const encodedToken = AuthUtils.getToken();
    const urlBase = process.env.REACT_APP_API_BASE_URL + "ChatRooms/berichten/";
 
    const bearerToken = ""

    async function fetchListingInfo(prop) {
        try {
            const response =  await fetch(`${urlBase}${prop.id}`,
                {
                    method: 'GET',
                    mode: 'cors',
                    headers:
                    {
                        "Content-Type": "application/json",
                        Authorization: `Bearer ${encodedToken}`
                    }
                })
                //.then((result) => result.json())
                //.then(
                //    (data) => {
                //        //console.log(data)
                //        setConversationContent(data)
                //        //console.log(conversationList)

                //    }
                //)
            // console.log(conversationList)
            console.log(response.status)
            if (!response.ok) {
                throw new Error(`${response.status} ${response.statusText}`);
                
            }
            const data = await response.json();
            
            console.log(data)
             setConversationContent(data);
        } catch (error)
        {
            console.log(error)
        }
    };



    //test to see if conversationList is properly changed.
    useEffect(() => {
        console.log('UseEffect triggered!')
        console.log(conversationContent)
        dispatch(clearChat())
        dispatch(
            addConversationContent(
                conversationContent))
        



    }, [conversationContent])


    const [LastMessageTimestamp, setLastMessageTimestamp] = useState(props.timestamp);

    const loadChat = (prop) => {
        console.log("button was pressed! caller : " + prop.id);
        //console.log(prop)

        //clearChet method functions as intended and clears the chatbox of the client that triggered it.
        dispatch(clearChat())
        fetchListingInfo(prop)
        dispatch(
            setCurrentRoom(
                prop))

    }

    return (

        <div className="chat-list">
            <ListGroup>
                {MappedList(conversationList)}
            </ListGroup>
        </div>

    );

}