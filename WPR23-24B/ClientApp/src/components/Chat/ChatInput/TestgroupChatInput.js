import React, { useState } from 'react';
import { useSelector, useDispatch } from 'react-redux'


import AuthUtils from '../../../Services/Authentication/AuthUtils'


import InputGroup from 'react-bootstrap/InputGroup'
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Stack from 'react-bootstrap/Stack';



//props are a catch-all for passed in paramteres. Think of it as a list. You can call props.[paramater] to retrieve something.
export default function ChatInput(props) {

    const encodedToken = AuthUtils.getToken();
    const token = AuthUtils.decodeToken(encodedToken);
    const role = token["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    const [user, setUser] = useState(
        {
            id: token.Id,
            userName: token.UserName
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
            setMessage('');
        }

        else {
            alert('Please insert an user and a message.');
        }
    }
    const url = `${process.env.REACT_APP_API_BASE_URL}ChatBericht/AuthorizeTest`;
    const onMessageUpdate = (e) => {
        setMessage(e.target.value);
    }

    return (

        <div>

            <Form onSubmit={onSubmit}>
                <InputGroup>
                    <Form.Control type="text" name="berichtInhoud" className="me-auto" placeholder="Typ een bericht..." value={message} onChange={onMessageUpdate} aria-describedby="Invoerveld voor bericht" style={{ fontSize: "14px" }} />
                    {/*<Button variant="secondary" className="me-auto" onClick={() => {console.log(user) } } > Print user </Button>*/}
                    {/*<Button variant="secondary" className="me-auto" onClick={() => { console.log(token) }} >Test Decode JWT</Button>*/}
                    {/*<Button variant="secondary" className="me-auto" onClick={() => {console.log(role) } } > Print UserRole</Button>*/}
                  <Button variant="secondary" type="submit" size='lg' style={{ fontSize: "14px" }} >Submit</Button>
                    <Button variant="secondary" className="me-auto" onClick={() => { console.log(encodedToken) }} >Encoded Token</Button>
   {/*.             <Button variant="secondary" className="me-auto" onClick={() => {*/}

   {/*                  //this doesnt work yet*/}
   {/*                  fetch(url, {*/}
   {/*                     method: "GET",*/}
   {/*                     headers: { "Authorization" : `Bearer ${encodedToken}` }*/}
   {/*                 })*/}
   {/*                     .then(response => response.json())*/}
   {/*                      .then(data => console.log(data.stringify()))*/}



   {/*               }}*/}


                   

{/* <Button variant="secondary" className="me-auto" onClick={() => { console.log(AuthUtils.tokenExpired()) }} >Print JWT expired</Button> */}

   {/*                 >*/}
   {/*                     Test Authorize Fetch </Button>*/}

                </InputGroup>

            </Form>

            {/*<form className="testgroup-input"*/}

            {/*    //this is called automatically by the button tag because it is in a form? research this.*/}
            {/*    onSubmit={onSubmit}>*/}
            {/*    <label>TestGroup</label>*/}

            {/*    <label htmlFor="message">Message:</label>*/}
            {/*    <br />*/}
            {/*    <input*/}
            {/*        type="text"*/}
            {/*        id="message"*/}
            {/*        name="message"*/}
            {/*        value={message}*/}
            {/*        onChange={onMessageUpdate} />*/}
            {/*    <br /><br />*/}
            {/*    <button>Submit</button>*/}
            {/*</form>*/}

        </div>
    )
};

