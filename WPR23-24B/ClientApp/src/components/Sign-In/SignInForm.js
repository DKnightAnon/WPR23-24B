import React from 'react';
import './SignInStyle.css';
import LeftBox from './LeftBox';
import RightBox from './RightBox';

function SignInForm() {
  return (
    <div className="container d-flex justify-content-center align-items-center min-vh-100">
      <div className="row border rounded-5 p-3 bg-white shadow box-area">
        <LeftBox />
        <RightBox />
      </div>
    </div>
  );
}

export default SignInForm;
