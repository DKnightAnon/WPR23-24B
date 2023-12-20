import React from 'react';
import { useState } from 'react';




export default function Message(props)  {




    return(
        <div className="chat-message-box" style={{ background: "#eee", borderRadius: '5px', padding: '0 10px' }}>
            <p><strong>{props.user}</strong> Time Goes Here</p>
            <p>{props.message}</p>
        </div>
    );
}

