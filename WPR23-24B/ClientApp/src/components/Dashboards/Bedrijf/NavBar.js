import React from 'react';
import logo from './Logo.png';
import styles from './navBar.module.css';

const NavBar = ({ toggleResearchListVisibility }) => {
  return (
    <div>
      {/* Topbar */}
      <div className={styles['top-bar']}>
        {/* Add buttons for navigation */}
        <img src={logo} alt="Logo van Stichting Accessibility" className={styles.logo} />

        <div className={styles['other-top-buttons']}>
          <button className={styles['info-button']} onClick={toggleResearchListVisibility}>
            Gegevens
          </button>
        </div>

        <div className={styles['other-top-buttons']}>
          <button className={styles['chat-button']}>Berichten</button>
        </div>

        {/* Buttons */}
        <div className={styles['top-buttons']}>
          <button className={styles['about-button']}>Over ons</button>
        </div>
      </div>
    </div>
  );
};

export default NavBar;
