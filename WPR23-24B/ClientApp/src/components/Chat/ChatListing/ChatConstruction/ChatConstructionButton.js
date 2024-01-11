import React from 'react';
import { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';


export default function ChatConstructionButton() 
{


    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);








    return (
        <div>

            <Button onClick={
                //() => alert('Dit werkt nog niet !')
                handleShow

            } aria-label="Gesprek aanmaken" > Nieuw gesprek</Button>




            <Modal show={show} onHide={handleClose} aria-label="Gesprek aanmaken formulier">
                <Modal.Header closeButton>
                    <Modal.Title>Modal heading</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                   

                    <Form.Label htmlFor="bedrijfSelect">Selecteer een bedrijf om een gesprek mee te starten.</Form.Label>
                    <Form.Select id="bedrijfSelect" aria-label="Default select example">
                        <option>Open this select menu</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                    </Form.Select>
                    <br/>
                    <Form.Label htmlFor="inputPassword5">Titel gesprek</Form.Label>
                    <Form.Control
                        type="password"
                        id="inputPassword5"
                        aria-describedby="Gesprek titel helpblok"
                    />

                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose} aria-label="Wijzigingen weggooien">
                        Close
                    </Button>
                    <Button variant="primary" onClick={handleClose} aria-label="Gesprek met bedrijf aanmaken knop">
                        Save Changes
                    </Button>
                </Modal.Footer>
            </Modal>













        </div>
    )


}