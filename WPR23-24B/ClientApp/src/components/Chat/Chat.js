import React, { Component } from 'react';

//import * as signalR from '@microsoft/signalr';
const signalR = require("@microsoft/signalr");

export default function Chat () {

    //Make connection
    const connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/chatHub").build();

    //Define methods
    connectionUserCount.on("updateTotalViews", (value) => {
        var newCountSpan = document.getElementById("totalViewsCounter")
        newCountSpan.innerText = value.toString();
    }
    );

    //Notify hub
    function newUserAccess()
    {
        connectionUserCount.send("newUserAccess");
    }

    //Start connection
    function fulfilled()
    {
        //Do something on start
        console.log("Connection to hub succeeded!");
    }

    function rejected()
    {
        //Do something on failure
        console.log("Connection to hub failed!");
    }

    connectionUserCount.start().then(fulfilled, rejected);


    return(
        <div>Here goes chat

            <div class="Container">
                <div class="col-3">Total Views: </div>
                <div class="col-4">
                    <span id="totalViewsCounter"></span>
                </div>
            </div>
        </div>
       

    )
}

