import React, { useState } from 'react';
import styles from './InfoPage.module.css';
import { FaBuilding } from 'react-icons/fa';

    
const ProfilePage = () => {

    const userData = {
        name: 'Albert Heijn',
        address: '123 Main Street, City',
        telefoonnummer: '0619443227',
        email: 'placeholder@gmail.com',
        postcode: '2781CS',
        contactPersoon: 'John Donut',
        hulpmiddelen: 'Rolstoel',
        onderzoeken: ['Onderzoek A', 'Onderzoek B'],
    };

// State for managing user data
const [user, setUser] = useState(userData);

const handleSaveChanges = () => {
    console.log('Changes saved!');
};

return (
      <div className='body'>
 <div className={styles['white-container']}>
      {/* Container for basic information */}
      <div className={styles['basic-info-container']}>
        {/* Profile icon and heading */}
        <div className={styles['icon-heading-container']}>
          <FaBuilding className={styles.icon} />
          <h3>Bedrijfs Gegevens</h3>
        </div>

        
        <div className={styles['input-group']}>
        <label htmlFor='name'>Bedrijfsnaam: </label>
        <br />
        <input
            className={styles['input-fields']}
            type='text'
            id='name'
            placeholder='Wijzig je naam'
            value={user.name}
        />
    </div>

        <div className={styles['input-group']}>
        <label htmlFor='name'>Contactpersoon: </label>
        <br />
        <input
            className={styles['input-fields']}
            type='text'
            id='contactPersoon'
            placeholder='Wijzig je contactpersoon'
            value={user.contactPersoon}
        />
    </div>

      <div className={styles['input-group']}>
        <label htmlFor='name'>Email: </label>
        <br />
        <input
            className={styles['input-fields']}
            type='text'
            id='email'
            placeholder='Wijzig je email-adres'
            value={user.email}
        />
    </div>

      <div className={styles['input-group']}>
        <label htmlFor='address'>Telefoonnummer </label>
        <br />
        <input
            className={styles['input-fields']}
            type='text'
            id='phonenumber'
            placeholder='Wijzig je telefoonnummer'
            value={user.telefoonnummer}
        />
    </div>

    <div className={styles['input-group']}>
        <label htmlFor='address'>Adres: </label>
        <br />
        <input
            className={styles['input-fields']}
            type='text'
            id='adres'
            placeholder='Wijzig je adres'
            value={user.address}
        />
    </div>
</div>



    {/* Save Changes button */}
    <button className={styles['input-fields-save-button']} onClick={handleSaveChanges} >
        Wijzigingen opslaan
    </button>

    
    
    </div>
</div>

);
};

export default ProfilePage;
