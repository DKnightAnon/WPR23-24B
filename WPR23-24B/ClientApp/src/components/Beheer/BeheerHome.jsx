import React, { useEffect, useState } from "react";
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import Stack from 'react-bootstrap/Stack'
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import styled from "styled-components";
import { Link } from 'react-router-dom';

function BeheerHome() {
    
    const BeheerderPortal = () => {
      return (
        <div>
          <h2>Welkom op het portaal voor beheerders van de stichting Accesibillity</h2>
            {<h2 className="main-title text-center">Beheer</h2>}
        </div>
      );
    };
  
    return (
      <div>
      <h1>Beheer Home</h1>
      <h2 className="main-title text-center">Beheer</h2>
      {/* Voeg de drie knoppen toe met links naar de lijsten */}
      <Button as={Link} to="/ervaringsdeskundigen" variant="primary" className="m-2">
        Lijst van Ervaringsdeskundigen
      </Button>
      <Button as={Link} to="/onderzoeken" variant="primary" className="m-2">
        Lijst van Onderzoeken
      </Button>
      <Button as={Link} to="/bedrijven" variant="primary" className="m-2">
        Lijst van Bedrijven
      </Button>
    </div>
    );
  }
  
  export default BeheerHome;
