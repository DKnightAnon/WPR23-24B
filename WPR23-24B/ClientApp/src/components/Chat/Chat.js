
/*"use strict";*/
import React, { useState, useEffect, useRef } from 'react';
import { HubConnectionBuilder } from '@microsoft/signalr';

import * as SignalR from '@microsoft/signalr'; 

import ChatWindow from './ChatWindow/ChatWindow';
import ChatInput from './ChatInput/ChatInput';

export default function Chat() {
    const [connection, setConnection] = useState(null);
    const [chat, setChat] = useState([]);
    const latestChat = useRef(null);

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

    function getTime() {
        var time = new Date();
        var year = time.getFullYear();
        var month = (time.getMonth() + 1);
        var day = time.getDate()
        var hour = time.getHours()
        var minute = time.getMinutes();
        var format = year + "-" + month + "-" + day + " - " + hour + ":" + minute;
        var date = format.toString();
        return date;
    }

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

                })
                .catch(e => console.log('Connection failed: ', e));
        }
    }, [connection]);

    //This method is called by the submit button in ChatInput.js
    const sendMessage = async (user, message) => {
        //props received from ChatInput is converted into an object
        const chatMessage = {
            user: user,
            message: message


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

    return (
        <div>
            <ChatInput sendMessage={sendMessage} />
            <hr />
            <ChatWindow chat={chat} />
        </div>
    );
};

