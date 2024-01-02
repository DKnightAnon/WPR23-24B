import React, { useState, useEffect } from 'react'
import { useSelector, useDispatch } from 'react-redux'
import { addNewMessage, clearChat, addConversationContent } from '../../../store/slices/chatSlice'

import Message from './Message/Message';

export default function ChatWindow(props) {

    const chatWindowContent = useSelector( (state) => state.chatcontent.content);

   

    //const chatArray = []

    //for (var x in chatWindowContent) {

     

    //    chatArray.push(JSON.parse(JSON.stringify(x)))
    //}


   

    const chat = chatWindowContent
        .map(m => <Message
            key={m.timestamp}
            user={m.user}
            message={m.message}
            timestamp={m.timestamp}
        />);



     useEffect(() => {
         console.log('useEffect in ChatWindow.js was triggered by a change in chatWindowContent(state.chatcontent.content)')
         console.log('chatWindowContent : '); console.log(chatWindowContent)
         //console.log('chatarray: '); console.log(chatArray)




    }, [chatWindowContent]
    )




    return (
        <div className="chat-window">
            {/*<p>current state of chatwindowcontent: {chatWindowContent}</p>*/}
            {chat}
            {/*<p>{chatArray}</p>*/}
        </div>
    )
};

