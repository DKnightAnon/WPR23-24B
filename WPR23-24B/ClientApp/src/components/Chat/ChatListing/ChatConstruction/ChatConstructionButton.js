import React from 'react';
import { useState, useEffect } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import Stack from 'react-bootstrap/Stack'

import CompanyName from './CompanyNameSelectionOption';


export default function ChatConstructionButton() 
{


    const [show, setShow] = useState(false);

    const handleClose = () => { setShow(false); submitFunction() }
    const handleShow = () => setShow(true);


    const [gesprektitel, setGesprektitle] = useState('');
    const [bedrijf, setBedrijf] = useState('');


    function submitFunction() {
        console.log('ModalForm Submitted : ' + gesprektitel + '|' + bedrijf);
        PostNewRoom();
    }


    const newConversationDetails =
    {
        RoomName: gesprektitel,
        Ervaringsdeskundige: { Id:'a601420e-1fde-460f-88b8-74f20cf72d91', UserName:'TestgebruikerVoornaam'},
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


    const PostNewRoom = () => {
        console.log(newConversationDetails);
        fetch(POSTurl, requestOptions).then( response => response.json()).then(data => console.log(data))
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

            } aria-label="Gesprek aanmaken" > Nieuw gesprek</Button>




            <Modal show={show} onHide={handleClose} aria-label="Gesprek aanmaken formulier" centered>
                <Modal.Header closeButton>
                    <Modal.Title>Modal heading</Modal.Title>
                </Modal.Header>
                <Modal.Body>

                    <Form form-id="NieuwGesprekForm" onSubmit={() => submitFunction()}>
                        <Form.Label htmlFor="bedrijfSelect">Selecteer een bedrijf om een gesprek mee te starten.</Form.Label>
                        <Form.Select id="bedrijfSelect" aria-label="Default select example" onChange={handleSelectChange} value={bedrijf }>
                            <option>Open this select menu</option>
                            {bedrijflijst.map(bedrijf =>
                                <option key={bedrijf.id} value={bedrijf.id}>{bedrijf.userName } </option> )}
                    </Form.Select>
                    <br/>
                    <Form.Label htmlFor="inputGesprekTitel">Titel gesprek</Form.Label>
                    <Form.Control
                            type="text"
                            id="inputGesprekTitel"
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