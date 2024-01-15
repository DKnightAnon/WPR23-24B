import React, { useState } from 'react';

import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Stack from 'react-bootstrap/Stack';

                                   //props are a catch-all for passed in paramteres. Think of it as a list. You can call props.[paramater] to retrieve something.
export default function ChatInput (props)  {
    const [user, setUser] = useState('');
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

    const onUserUpdate = (e) => {
        setUser(e.target.value);
    }

    const onMessageUpdate = (e) => {
        setMessage(e.target.value);
    }

    return (

        <div>
<Form onSubmit={onSubmit}>
            <Stack direction="horizontal" gap={3}>
                
                    <Form.Control type="text" className="me-auto" placeholder="Type your username..." value={user} onChange={onUserUpdate} aria-describedby="Invoerveld voor gebruikernaam" />
                    <Form.Control type="text" className="me-auto" placeholder="type your message..." value={message} onChange={onMessageUpdate} aria-describedby="Invoerveld voor bericht" />
                    <Button variant="secondary" type="submit">Submit</Button>    
           
        </Stack>
 </Form>




        {/*<div className="chat-input-form-container">*/}
        {/*    <form className="chat-input"*/}
        {/*        //this is called automatically by the button tag because it is in a form? research this.*/}
        {/*        onSubmit={onSubmit}>*/}
        {/*        <label htmlFor="user">User:</label>*/}
        {/*        <br />*/}
        {/*        <input*/}
        {/*            id="user"*/}
        {/*            name="user"*/}
        {/*            value={user}*/}
        {/*            onChange={onUserUpdate} />*/}
        {/*        <br />*/}
        {/*        <label htmlFor="message">Message:</label>*/}
        {/*        <br />*/}
        {/*        <input*/}
        {/*            type="text"*/}
        {/*            id="message"*/}
        {/*            name="message"*/}
        {/*            value={message}*/}
        {/*            onChange={onMessageUpdate} />*/}
        {/*        <br /><br />*/}
        {/*        <button>Submit</button>*/}

        {/*    </form>*/}
          
        {/*</div>*/}



        </div>
    )
};

