import React, { Component } from 'react';

import * as signalR from "@microsoft/signalr";

function Chat () {


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

export default Chat;