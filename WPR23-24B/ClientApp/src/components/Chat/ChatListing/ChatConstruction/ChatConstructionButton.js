import React from 'react';
import { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import Stack from 'react-bootstrap/Stack'


export default function ChatConstructionButton() 
{



    //------------------------------ POST REQUEST ------------------------------// 

    const url = process.env.REACT_APP_API_BASE_URL + "";
    const data = {}
    const requestOptions = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    };


    const PostNewRoom = () => {

        fetch(url, requestOptions)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            //  .then() method goes here
    }

    //------------------------------ POST REQUEST ------------------------------//
    const GETurl = process.env.REACT_APP_API_BASE_URL + 'ChatRooms';
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







    const [show, setShow] = useState(false);

    const handleClose = () => { setShow(false); submitFunction() }
    const handleShow = () => setShow(true);


    const [gesprektitel, setGesprektitle] = useState('');


    function submitFunction() {
        console.log('ModalForm Submitted : ' + gesprektitel);
        setGesprektitle('');
    }

    const handleChange = (e) => { setGesprektitle(e.target.value) }



    return (
        <>

            <Button onClick={
                //() => alert('Dit werkt nog niet !')
                handleShow

            } aria-label="Gesprek aanmaken" > Nieuw gesprek</Button>




            <Modal show={show} onHide={handleClose} aria-label="Gesprek aanmaken formulier" centered>
                <Modal.Header closeButton>
                    <Modal.Title>Modal heading</Modal.Title>
                </Modal.Header>
                <Modal.Body>

                    <Form form-id="NieuwGesprekForm" onSubmit={() => submitFunction()}>
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
                            type="text"
                            id="inputPassword5"
                            aria-describedby="Gesprek titel helpblok"
                            onChange={ handleChange }
                        />

                        </Form>

                    
                        
                       
                    
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose} aria-label="Wijzigingen weggooien">
                            Close
                        </Button>
                    <Button
                        form="NieuwGesprekForm"
                        variant="primary"
                        onClick=
                        {
                            handleClose
                        }
                        aria-label="Gesprek met bedrijf aanmaken knop"
                    >
                        Save Changes
                    </Button>
                </Modal.Footer>
            </Modal>













        </>
    )


}