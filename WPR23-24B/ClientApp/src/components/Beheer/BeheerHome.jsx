import React, { useEffect, useState } from "react";

function BeheerHome() {
    // Declaratie van de BeheerderPortal-component binnen de BeheerHome-functie
    const BeheerderPortal = () => {
      return (
        <div>
          <h2>Welkom op het portaal voor beheerders van de stichting Accesibillity</h2>
          {}
        </div>
      );
    };
  
    return (
      <div>
        <h1>Beheer Home</h1>
        {}
        <BeheerderPortal /> {}
      </div>
    );
  }
  
  export default BeheerHome;
