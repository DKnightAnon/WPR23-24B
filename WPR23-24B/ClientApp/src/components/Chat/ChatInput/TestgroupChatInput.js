import React, { useState } from 'react';

//props are a catch-all for passed in paramteres. Think of it as a list. You can call props.[paramater] to retrieve something.
export default function ChatInput(props) {
    const [user, setUser] = useState('');
    const [message, setMessage] = useState('');

    const onSubmit = (e) => {
        e.preventDefault();

        const isUserProvided = user && user !== '';
        const isMessageProvided = message && message !== '';

        if (isUserProvided && isMessageProvided) {
            props.messageToBeSent(user, message);
        }
        else {
            alert('Please insert an user and a message.');
        }
    }

    const onUserUpdate = (e) => {
        setUser(e.target.value);
    }

    const onMessageUpdate = (e) => {
        setMessage(e.target.value);
    }

    return (
        <form
        
            //this is called automatically by the button tag because it is in a form? research this.
            onSubmit={onSubmit}>
            <label>TestGroup</label>
            <label htmlFor="user">User:</label>
            <br />
            <input
                id="user"
                name="user"
                value={user}
                onChange={onUserUpdate} />
            <br />
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

