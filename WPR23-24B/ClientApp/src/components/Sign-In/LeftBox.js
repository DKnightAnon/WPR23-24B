import React from 'react';
import saLogo from '../Images/stichting_accessibility.png';

function LeftBox() {
  return (
    // JSX code for the LeftBox component
    <div className="col-md-6 rounded-4 d-flex justify-content-center align-items-center flex-column left-box" style={{ background: '#103cbe' }}>
      <div className="featured-image mb-3">
        <img src={saLogo} alt="Application Logo" className="img-fluid" style={{ width: '350px' }} />
      </div>
      <h1 className="text-white fs-2" style={{ fontFamily: 'Courier New, Courier, monospace', fontWeight: 600 }}>
        
      </h1>
      <p className="text-white text-wrap text-center" style={{ width: '17rem', fontFamily: 'Courier New, Courier, monospace' }}>
        
      </p>
    </div>
  );
}

export default LeftBox;