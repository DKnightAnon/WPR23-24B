import React, { useState, useEffect } from 'react'
import { useSelector, useDispatch } from 'react-redux'
import { addNewMessage, clearChat, addConversationContent } from '../../../store/slices/chatSlice'

import Message from './Message/Message';

export default function ChatWindow(props) {

    const chatWindowContent = useSelector( (state) => state.chatcontent.content);
    const [isEmpty, setIsEmpty] = useState(true);
   
    
    //const chat = chatWindowContent
    //    .map(m => <Message
    //        key={m.timestamp}
    //        user={m.user}
    //        message={m.message}
    //        timestamp={m.timestamp}
    //    />);

    const chatUnorderedList = chatWindowContent.map(    (chat) =>
        <ul key={chat.postedAt}>
            {/*{JSON.stringify(chat)}*/}
            <Message
                user={chat.verzender.userName}
                message={chat.content}
                timestamp={chat.postedAt}
                className="chat-message-box"

            />
        </ul>)



    useEffect(() => {
         console.group("ChatWindow useEffect() methode")
         console.log('useEffect in ChatWindow.js was triggered by a change in chatWindowContent(state.chatcontent.content)')
         console.log('chatWindowContent : ');
        console.log(chatWindowContent);
        console.groupEnd();

         if (chatWindowContent.length === 0) {
             setIsEmpty(true)
             console.log( "ChatWindow Content is leeg!")
         } else {
             setIsEmpty(false)
             console.log("ChatWindow Content heeft berichten!")
         }


    }, [chatWindowContent]
    )




    return (
        <div className="chat-message-list">
            {/*<p>current state of chatwindowcontent: {chatWindowContent}</p>*/}
            {/*{chat}*/}


            {isEmpty ? <Message user="System" message="Deze chatgroep heeft nog geen berichten!" timestamp={new Date() } />  : chatUnorderedList}

        </div>
    )
};

