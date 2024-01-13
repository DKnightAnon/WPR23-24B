import React from 'react';
import { useState } from 'react';





export default function Message(props)  {



    //function getTime() {
    //    var time = new Date();
    //    var year = time.getFullYear();
    //    var month = (time.getMonth() + 1);
    //    var day = time.getDate()
    //    var hour = time.getHours()
    //    var minute = time.getMinutes();
    //    var format = year + "-" + month + "-" + day + " - " + hour + ":" + minute;
    //    var date = format.toString();
    //    return date;
    //}

    function convertTime(dateTime)
    {
        // Step 1:
        const utcDateString = dateTime; // UTC date string (example)
        const utcDateWithoutMillis = utcDateString.slice(0, -5) + "Z";
        const utcDate = new Date(utcDateWithoutMillis);
                console.log("UTC Date:", utcDate.toISOString());

        // Step 2:
        const offsetMinutes = utcDate.getTimezoneOffset();
                console.log("Time Zone Offset (minutes):", offsetMinutes);

        // Step 3:
        const localTime = new Date(utcDate.getTime() - offsetMinutes * 60 * 1000);
                console.log("Local Time:", localTime.toISOString());

        // Display Local Time
        const localTimeString = localTime.toLocaleString();
        console.log('current time : ' + localTimeString)
        return localTimeString;
    }
    

    //function parseDate(date) {
    //    return new Date(parseInt(/-?\d+/.exec(date)[0]))
    //}

    return(
        <div className="chat-message-box">
            <p><strong>{props.user}</strong> - {convertTime(props.timestamp)}</p>
            <p>{props.message}</p>
        </div>
    );
}

