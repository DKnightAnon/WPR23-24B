
import React, { useState } from 'react';
//import { Offcanvas, OffcanvasBody, OffcanvasHeader, Button } from 'reactstrap';

import Alert from 'react-bootstrap/Alert';
import Button from 'react-bootstrap/Button';
import Offcanvas from 'react-bootstrap/Offcanvas';
import ChatList from '../Chat/ChatListing/ChatList'



const Example = () => {


    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);




    function alertButton() {alert('This is a React Bootstrap button!') }

    return (
        <div>


            <Button onClick={handleShow}>Testing</Button>
         

            <Alert variant="info" className="d-none d-lg-block">
                Resize your browser to show the responsive offcanvas toggle.
            </Alert>



            <Offcanvas show={show} onHide={handleClose} responsive="lg">
                <Offcanvas.Header closeButton>
                    <Offcanvas.Title>Responsive offcanvas</Offcanvas.Title>
                </Offcanvas.Header>
                <Offcanvas.Body>
                    <p className="mb-0">
                        This is content within an <code>.offcanvas-lg</code>.
                    </p>
                    <ChatList/>
                </Offcanvas.Body>
            </Offcanvas>



        </div>

    );

}



export default Example