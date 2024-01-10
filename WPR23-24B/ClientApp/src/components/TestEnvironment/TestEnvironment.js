import React from 'react';

import { useState } from 'react';


import Example from './offcanvas_React_Bootstrap'



function TestEnvironment() {

    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);






    return (
    
        <Example/>

    )


}

export default TestEnvironment