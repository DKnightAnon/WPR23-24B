import React from 'react';

import Message from './Message/Message';

export default function ChatWindow(props) {
    const chat = props.chat
        .map(m => <Message
            key={Date.now() * Math.random()}
            user={m.user}
            message={m.message}
            timestamp={m.timestamp}
        />);

    return (
        <div className="chat-window">
            {chat}
        </div>
    )
};

