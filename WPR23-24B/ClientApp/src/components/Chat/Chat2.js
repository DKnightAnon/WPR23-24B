import React, { useEffect, useState } from 'react';
//import './App.css';
import Connector from './signalr-connection'
const Chat2 = () => {
    const { newMessage, events } = Connector();
    const [message, setMessage] = useState("initial value");
    useEffect(() => {
        events((_, message) => setMessage(message));
    });
    return (
        <div className="Chat2">
            <span>message from signalR: <span style={{ color: "green" }}>{message}</span> </span>
            <br />
            <button onClick={() => newMessage((new Date()).toISOString())}>send date </button>
        </div>
    );
}
export default Chat2;