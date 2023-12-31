
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
import './ChatStyling.css'



export default function Chat() {
    const [connection, setConnection] = useState(null);
    const [chat, setChat] = useState([]);
    const latestChat = useRef(null);
    const [userCount, setUserCount] = useState(0);

    latestChat.current = chat;

    useEffect(() => {
        const newConnection = new HubConnectionBuilder()
                      //url has to be a http://localhost 
            .withUrl("http://localhost:5057/hubs/chathub")
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
        if (connection) {
            connection.start(  /*this doesnt print for some reason*/ function () { console.log('Starting Connection...') })
                .then(result => {
                    console.log('Connected!');
                    connection.on('ReceiveMessage', message => {
                        const updatedChat = [...latestChat.current];
                        updatedChat.push(message);

                        setChat(updatedChat);
                    });
                    connection.on('ReceiveGroupMessage', message => {
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

    //This method is called by the submit button in ChatInput.js
    const sendMessage = async (user, message, timestamp) => {
        //props received from ChatInput is converted into an object
        const chatMessage = {
            user: user,
            message: message,
            timestamp: timestamp


        };

        //for some reason the if statement here was preventing the connection.

        //At this point the hub is not in the 'Disconnected' state. Maybe like in postman details about the connection has to be sent?
        //connection.start();

        //if (connection.connectionStarted) {
        try {
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

    const sendTestgroupMessage = async (user, message) => {
        const chatMessage = {
            user: user,
            message: message
        };
        try {
            //trigger the SendMessage() method in ChatHub.cs with the const chatMessage as parameter.
                //This should be SendGroupMessage, or else it will just send a mesaage to everyone.
            await connection.invoke('SendGroupMessage', chatMessage, "testgroup");
        }
        catch (e) {
            console.log(e);
        } }

    const joinTestGroup = async () => {
        try { await connection.invoke("JoinRoom","testgroup")}
        catch (e) {console.log(e) }
    }
    const leaveTestGroup = async () => {
        try { await connection.invoke("LeaveRoom", "testgroup") }
        catch (e) { console.log(e) }
    }

    const loadChat = async (props) =>
    {
        const url = "https://localhost:7180/api/ChatRooms";

        const fetchInfo = async () => {
            fetch(url)
                .then((result) => result.json())
                .then((data) => console.log)
            console.log(props)
        };


    }

    return (
        <div className="chat-component-main">
            <ChatList chatloadfunction={loadChat} />
            <ChatInput sendMessage={sendMessage} />
            <hr />
            <p><strong>TestGroupChat</strong></p>
            <TestgroupChatInput messageToBeSent={sendTestgroupMessage} />
            <hr />
            <button id="send-join-to-test-group" onClick={joinTestGroup}>Connect to test group</button> <button id="send-leave-to-test-group" onClick={leaveTestGroup}>leave the test group</button>
            <p>Amount of connected users : {userCount}</p>
            <ChatWindow chat={chat} />

        </div>
    );
};

