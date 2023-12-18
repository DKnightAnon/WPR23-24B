import React from 'react';

import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
/*const signalR = require("@microsoft/signalr");*/

const Chat = () => {

    //Make connection
    //https://localhost:44443
    const connectionUserCount = new HubConnectionBuilder().withUrl("https://localhost:5057/hubs/chathub").build();
    const userCount = 0;

    //Define methods
    connectionUserCount.on("updateTotalViews", (value) => {
        userCount = value;
        //var newCountSpan = document.getElementById("totalViewsCounter")
        //newCountSpan.innerText = value.toString();
    }
    );

    //Notify hub
    function newUserAccess() {
        connectionUserCount.send("newUserAccess");
    }

    //Start connection
    function fulfilled() {
        //Do something on start
        console.log("Connection to hub succeeded!");
        newUserAccess();
    }

    function rejected() {
        //Do something on failure
        console.log("Connection to hub failed!");
    }

    connectionUserCount.start().then(fulfilled, rejected);


    return (
        <div>Here goes chat

            <p>testing</p>
            <div class="Container">
                <div class="col-3">Total Views: </div>
                <div class="col-4">
                    <span id="totalViewsCounter">{userCount}</span>
                </div>
            </div>
        </div>


    )
}

export default Chat;