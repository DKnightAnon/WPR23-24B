import React, { useState } from 'react';
import { useSelector, useDispatch } from 'react-redux'

//props are a catch-all for passed in paramteres. Think of it as a list. You can call props.[paramater] to retrieve something.
export default function ChatInput(props) {
    const [user, setUser] = useState(

        {
            id: "10418506-072b-42f4-ba37-4148b234952e",
            userName: "Anthony Delgado"

        }


    );
    const [message, setMessage] = useState('');

    const room = useSelector((state) => state.chatroom.currentroom);

    const onSubmit = (e) => {
        e.preventDefault();

        console.log("Submit button in TestgroupChatInput pressed!")
     
       
        const isUserProvided = user && user !== '';
        const isMessageProvided = message && message !== '';

        if (isUserProvided && isMessageProvided) {
            console.log('Message contents : ')
            console.log(JSON.stringify(user) + message + JSON.stringify(room))
            props.messageToBeSent(user, message, room);
        }
        else {
            alert('Please insert an user and a message.');
        }
    }

    const onMessageUpdate = (e) => {
        setMessage(e.target.value);
    }

    return (
        <form className="testgroup-input"
        
            //this is called automatically by the button tag because it is in a form? research this.
            onSubmit={onSubmit}>
            <label>TestGroup</label>
          
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
