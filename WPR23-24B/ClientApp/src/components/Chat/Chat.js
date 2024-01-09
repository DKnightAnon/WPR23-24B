
/*"use strict";*/
import React, { useState, useEffect, useRef } from 'react';
import { HubConnectionBuilder } from '@microsoft/signalr';

import * as SignalR from '@microsoft/signalr'; 

//Chat modules
import ChatWindow from './ChatWindow/ChatWindow';
import ChatInput from './ChatInput/ChatInput';
import TestgroupChatInput from './ChatInput/TestgroupChatInput';


//Custom chat modules
import ChatList from './ChatListing/ChatList';


//Styling
import { useSelector, useDispatch } from 'react-redux'
import { addNewMessage } from '../../store/slices/chatSlice';

//import { useSelector, useDispatch } from 'react-redux'
//import { addNewMessage, clearChat, addConversationContent } from './chatSlice'


export default function Chat() {
    const [connection, setConnection] = useState(null);
    const [chat, setChat] = useState([]);
    const latestChat = useRef(null);
    const [userCount, setUserCount] = useState(0);
    const [currentChatGroep, setCurrentChatGroup] = useState("");

    const currentConnectedRoom = useSelector ((state) => state.chatroom.currentroom)

    const dispatch = useDispatch();

    //const chatContent = useSelector((state) => state.chatContent.content)
    //const dispatch = useDispatch()

    latestChat.current = chat;

    useEffect(() => {
        const newConnection = new HubConnectionBuilder()
            //url has to be a http://localhost 
            .withUrl(process.env.REACT_APP_HUB_URL)
            .withAutomaticReconnect()
            //.configureLogging()
            .build();

        setConnection(newConnection);
    }, []);


    const groupChatFunction = (content) => {
        const updatedChat = [...latestChat.current];
                        updatedChat.push(content);

                        setChat(updatedChat); }


    useEffect(() => {
        //console.log('Connected to a room!');
        //console.log('Current room : ' + JSON.stringify(currentConnectedRoom));
        joinTestGroup()

    }, [currentConnectedRoom])

    useEffect(() => {
        if (connection) {
            connection.start(  /*this doesnt print for some reason*/ function () { console.log('Starting Connection...') })
                .then(result => {
                    console.log('Connected!');
                    connection.on('ReceiveMessage', message => {

                        /*
                        const updatedChat = [...latestChat.current];
                        updatedChat.push(message);

                        setChat(updatedChat);
                        */


                        console.log('Message received!')
                        console.log('message contents : ' + JSON.stringify(message))
                        dispatch(addNewMessage(message))
                        
                    });
                    connection.on('ReceiveGroupMessage', message => {
                        console.log("ReceiveGroupMessage triggered!")
                        console.log(message)
                        dispatch(addNewMessage(message))
                        //console.log(room) 

                        groupChatFunction(message)
                        
                    });
                    connection.on("UserJoinMessage", content => {
                        console.log(content);
                       
                    });
                    connection.on("UserLeftMessage", content => {
                        console.log("A user left!");
                    });
                    connection.on("UserChange", content => { setUserCount(content); })

                    connection.on("RoomNotification", content => {console.log(content) })

                })
                .catch(e => console.log('Connection failed: ', e));
        }
    }, [connection]);

    //This method is called by the submit button in ChatInput.js. 
    //As it is a constant, you can pass down the entire function.
    const sendMessage = async (user, message, timestamp) => {
        //props received from ChatInput is converted into an object
        const chatMessage = {
            User:
                { userName: user } ,
            Message: message,
            postedAt: timestamp


        };

        //for some reason the if statement here was preventing the connection.

        //At this point the hub is not in the 'Disconnected' state. Maybe like in postman details about the connection has to be sent?
        //connection.start();

        //if (connection.connectionStarted) {
        try {
            console.log('Sending message!')
                //trigger the SendMessage() method in ChatHub.cs with the const chatMessage as parameter. 
            await connection.invoke('SendMessage', chatMessage);
                
            }
            catch (e) {
                console.log(e);
            }
     //   }
        //else {
        //    console.log("If you see this, something went wrong with the connection.");
        //    //alert('No connection to server yet.');
        //}
    }

    const sendTestgroupMessage = async (user, message, room) => {
        const chatMessage = {
            user: user,
            message: message,
 
        };
   
        try {
            //trigger the SendMessage() method in ChatHub.cs with the const chatMessage as parameter.
                //This should be SendGroupMessage, or else it will just send a mesaage to everyone.
            await connection.invoke('SendGroupMessage', chatMessage, room);
        }
        catch (e) {
            console.log(e);
        } }

    const joinTestGroup = async () => {

        const room = {
            Id: currentConnectedRoom.id,
            Title: currentConnectedRoom.Title
        }
        try {
            console.log('trying to connect to room : ' + JSON.stringify(currentConnectedRoom))
            await connection.invoke("JoinRoom", room);
            
        }
        catch (e) {console.log(e) }
    }
    const leaveTestGroup = async () => {
        try { await connection.invoke("LeaveRoom", "testgroup") }
        catch (e) { console.log(e) }
    }


    const lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. "
        + "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur."
        + "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";






    return (


        <div className="chat-component-main">

            <div className="chat-list-container">
                <ChatList />
            </div>

            <div className="chat-window">

                <div className="chat-window-container">
                    <ChatWindow chat={chat} />
                </div>


                <div className="chat-component-inputs">
                    <ChatInput sendMessage={sendMessage} />

                    <div className="chat-input-box">
                        <p><strong>TestGroupChat</strong></p>

                        <p>Amount of connected users : {userCount}</p>
                        <TestgroupChatInput messageToBeSent={sendTestgroupMessage} />

                    </div>


                    {/*            <button id="send-join-to-test-group" onClick={joinTestGroup}>Connect to test group</button> <button id="send-leave-to-test-group" onClick={leaveTestGroup}>leave the test group</button>*/}
                    <br></br>

                    

                        <button id="chat-message-lorem-ipsum" onClick={() => sendMessage("ipsum generator", lorem)} />
                    



                </div>

            </div>
        </div>

       
    );
};

