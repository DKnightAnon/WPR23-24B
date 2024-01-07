import React, { useState } from 'react';

//props are a catch-all for passed in paramteres. Think of it as a list. You can call props.[paramater] to retrieve something.
export default function ChatInput(props) {
    const user = "10418506-072b-42f4-ba37-4148b234952e";
    const [message, setMessage] = useState('');

    const onSubmit = (e) => {
        e.preventDefault();

        const isUserProvided = user && user !== '';
        const isMessageProvided = message && message !== '';

        if (isUserProvided && isMessageProvided) {
            props.sendMessage(user, message);
        }
        else {
            alert('Please insert an user and a message.');
        }
    }



    const onMessageUpdate = (e) => {
        setMessage(e.target.value);
    }

    return (
        <form className="chat-input"
            //this is called automatically by the button tag because it is in a form? research this.
            onSubmit={onSubmit}>
            <label htmlFor="message">Message:</label>
            <br />
            <input
                type="text"
                id="message"
                name="message"
                value={message}
                onChange={onMessageUpdate} />
            <br /><br />
            <button>Submit</button>
        </form>
    )
};

