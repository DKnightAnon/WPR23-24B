import React from 'react';
import { useState, useEffect } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import Stack from 'react-bootstrap/Stack'
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';

import InputGroup from 'react-bootstrap/InputGroup';


import { useSelector, useDispatch } from 'react-redux';
import { clearChat, addConversationContent, printTest } from '../../../../store/slices/chatSlice';
import { setCurrentRoom } from '../../../../store/slices/chatroomSlice';


export default function ChatConstructionButton() 
{


    const [show, setShow] = useState(false);

    const handleClose = () =>
    {
        setShow(false);
        //if (gesprektitel && bedrijf === !null) {submitFunction() }
        setGesprektitle(""); setBedrijf("");
        
    }
    const handleShow = () => setShow(true);


    const [gesprektitel, setGesprektitle] = useState('');
    const [bedrijf, setBedrijf] = useState('');

    const [validated, setValidated] = useState(false);

    function submitFunction(event) {
        const form = event.currentTarget;
        if (form.checkValidity() === false) {
            event.preventDefault();
            event.stopPropagation();
        }

        setValidated(true);

        console.log('ModalForm Submitted : ' + gesprektitel + '|' + bedrijf);
        PostNewRoom();
        handleClose();
    }


    const newConversationDetails =
    {
        RoomName: gesprektitel,
        Ervaringsdeskundige: { Id:'11185a46-ae89-4003-87d0-7461c8901cd6', UserName:'TestgebruikerVoornaam'},
        Bedrijf: { Id: bedrijf, UserName:'' }
    }

    const handleChange = (e) => { setGesprektitle(e.target.value) }
    const handleSelectChange = (e) => { setBedrijf(e.target.value) }
    //------------------------------ POST REQUEST ------------------------------// 

    const POSTurl = process.env.REACT_APP_API_BASE_URL + "ChatRooms/nieuwgesprek";
    const data = {
        "title": gesprektitel
    }
    const requestOptions = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(newConversationDetails),
    };

    const dispatch = useDispatch();

    const PostNewRoom = () => {
        console.log(newConversationDetails);
        fetch(POSTurl, requestOptions).then(response => response.json()).then(data =>
        {
            dispatch(clearChat()); dispatch(setCurrentRoom(data))
            console.log(data)
        })
            //  .then() method goes here
    }

    //------------------------------ GET REQUEST ------------------------------//
    const GETurl = process.env.REACT_APP_API_BASE_URL + 'Bedrijf/names';
    const [bedrijflijst, setBedrijflijst] = useState([]);

    const GETBedrijven = () => {

        fetch(GETurl)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                console.log(data);
                setBedrijflijst(data)
            })
            .catch(error => {
                console.error('Error:', error);
            });



    }


    useEffect(() => { GETBedrijven() }, [])









    return (
        <>

            <Button onClick={
                //() => alert('Dit werkt nog niet !')
                handleShow

            } aria-label="Gesprek aanmaken" style={{ fontSize: "14px" }}> Nieuw gesprek</Button>




            <Modal show={show} onHide={handleClose} aria-label="Gesprek aanmaken formulier" centered>
                <Modal.Header closeButton>
                    <Modal.Title>Nieuw gesprek starten</Modal.Title>
                </Modal.Header>
                <Modal.Body>




                    <Form noValidate validated={validated} form-id="NieuwGesprekForm" onSubmit={() => submitFunction()}>
                        <Form.Group controlId="validationBedrijfSelect" >
                            <Form.Label style={{ fontSize: "14px" }}>Selecteer een bedrijf om een gesprek mee te starten.</Form.Label>
                            <InputGroup hasValidation>

                                <Form.Select placeholder="selecteer een bedrijf" aria-label="Selecteer een bedrijf" onChange={event => { console.log(event.target.value); setBedrijf(event.target.value) } } value={bedrijf}>
                                    <option className="d-none" value={-1} style={{ fontSize: "18px" }} >selecteer een bedrijf</option>
                                    {bedrijflijst.map(bedrijf =>
                                        <option key={bedrijf.id} value={bedrijf.id}>{bedrijf.userName} </option>)}
                                </Form.Select>
                            </InputGroup>
                        </Form.Group>
                        <br />
                        <Form.Group controlId="validationInputGesprekTitel" >
                            <Form.Label >Titel gesprek</Form.Label>
                            <InputGroup hasValidation>

                                <Form.Control
                                    type="text"

                                    aria-describedby="Gesprek titel invul blok"
                                    onChange={handleChange}
                                    required
                                />
                                <Form.Control.Feedback type="invalid">Voer een titel in voor het gesprek.</Form.Control.Feedback>
                            </InputGroup>
                        </Form.Group>

                    </Form>

                    
                        
                       
                    
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose} aria-label="Wijzigingen weggooien">
                            Close
                        </Button>
                    <Button
                        form="NieuwGesprekForm"
                        variant="primary"
                        onClick={submitFunction}
                        aria-label="Gesprek met bedrijf aanmaken knop"
                    >
                        Save Changes
                    </Button>
                </Modal.Footer>
            </Modal>













        </>
    )


}