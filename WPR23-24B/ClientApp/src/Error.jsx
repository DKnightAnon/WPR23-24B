import React from "react";
import styled from "styled-components";
import { Button } from "./components/WebsiteComponents/Styles/Button";
import { NavLink } from "react-router-dom";

const Error = () => {
  return (
    <Wrapper>
      {/* <img src="../public/images/error.png" alt="error" /> */}
      <h1>Sorry, er ging iets mis...</h1>
      <p>
        De pagina die je zocht, kon niet worden gevonden. Deze is mogelijk
        verwijderd, hernoemd of bestaat helemaal niet.
      </p>
      <NavLink to="/" aria-label="Ga terug naar home">
        <Button className="btn">Ga terug</Button>
      </NavLink>
    </Wrapper>
  );
};

const Wrapper = styled.section`
  padding: 9rem 0;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;

  .btn {
    font-size: 1.8rem;
    margin-top: 3rem;
    background-color: #2b50ec;
  }
`;

export default Error;
