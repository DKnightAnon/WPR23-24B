// Validation for general user information
export const validateGeneralInfo = (values) => {
  const errors = {};

  // Validate email
  if (!values.Email) {
    errors.Email = "Vul alstublieft uw email-adres in.";
  } else if (!isValidEmail(values.Email)) {
    errors.Email =
      "Het ingevoerde email-adres lijkt ongeldig te zijn. Controleer het opnieuw.";
  }

  if (!values.Naam) {
    errors.Naam = "Vul alstublieft uw naam in.";
  }
  // Validate isJongerDan18
  if (values.isJongerDan18 === null) {
    errors.isJongerDan18 = "Geef alsjeblieft aan of u jonger dan 18 jaar bent.";
  }

  // Validate password
  if (!values.Wachtwoord) {
    errors.Wachtwoord = "Vul alstublieft uw wachtwoord in.";
  } else if (!isValidPassword(values.Wachtwoord)) {
    errors.Wachtwoord =
      "Het wachtwoord moet minimaal 8 tekens bevatten, waaronder ten minste één cijfer, één hoofdletter en één speciaal teken.";
  }

  // Validate postcode
  if (!values.Postcode) {
    errors.Postcode = "Vul alstublieft uw postcode in.";
  } else if (!isValidPostcode(values.Postcode)) {
    errors.Postcode = "Ongeldige postcode. Voer een postcode in zoals 1234AB.";
  }

  // Validate TelefoonNummer
  if (!values.TelefoonNummer) {
    errors.TelefoonNummer = "Vul alstublieft een telefoonnummer in.";
  } else if (!isValidPhoneNumber(values.TelefoonNummer)) {
    errors.TelefoonNummer =
      "Ongeldig telefoonnummer. Voer een geldig telefoonnummer in (vb 0612345678).";
  }

  // Validate geboortedatum
  //   if (!values.Geboortedatum) {
  //     errors.Geboortedatum = "Vul alstublieft uw geboortedatum in.";
  //   } else if (!isValidDate(values.Geboortedatum)) {
  //     errors.Geboortedatum =
  //       "Ongeldige geboortedatum. Voer een geldige datum in in het formaat dd/MM/yyyy.";
  //   }

  return errors;
};

const isValidEmail = (email) => {
  // Regular expression for a more comprehensive email validation
  const emailRegex = /^[^\s@]+@[^\s@]+\.[a-zA-Z]{2,}$/;
  return emailRegex.test(email);
};

const isValidPassword = (password) => {
  // Check if the password length is at least 8
  const isLengthValid = password.length >= 8;
  console.log("Is Length Valid:", isLengthValid);

  // Check if the password contains at least one letter, one digit, and one special character
  const hasLetter = /[A-Za-z]/.test(password);
  const hasDigit = /\d/.test(password);
  const hasSpecialCharacter = /[@$!%*#?&/]/.test(password);

  // Combine the checks
  const isValid = isLengthValid && hasLetter && hasDigit && hasSpecialCharacter;

  return isValid;
};

const isValidPhoneNumber = (phoneNumber) => {
  const phoneRegex = /^06[0-9]{8}$/;
  return phoneRegex.test(phoneNumber);
};

const isValidPostcode = (postcode) => {
  // Regular expression for a valid Dutch postcode format
  const postcodeRegex = /^[1-9][0-9]{3} ?[A-Za-z]{2}$/;
  return postcodeRegex.test(postcode);
};

// const isValidDate = (dateString) => {
//   const regex = /^(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[0-2])\/\d{4}$/; // Format: dd/MM/yyyy

//   if (!regex.test(dateString)) {
//     console.log("Invalid date format");
//     return false; // Invalid date format
//   }

//   const inputDate = new Date(dateString);
//   const currentDate = new Date();

//   //   console.log("Input Date:", inputDate);
//   //   console.log("Current Date:", currentDate);

//   // Compare only the dates, ignoring the time component
//   inputDate.setHours(0, 0, 0, 0);
//   currentDate.setHours(0, 0, 0, 0);

//   return inputDate <= currentDate;
// };

// Validation for disabilitytypes
export const validateDisabilityType = (values) => {
  const errors = {};

  // Validate checkboxes
  if (
    values.FysiekeBeperking !== true &&
    values.VisueleBeperking !== true &&
    values.AuditieveBeperking !== true
  ) {
    errors.DisabilityType = "Selecteer ten minste één type beperking.";
  }

  return errors;
};

// Validation for disabilitytypes
export const validateApproach = (values) => {
  const errors = {};

  // Validate checkboxes
  if (
    values.BenaderingCommericeel !== true &&
    values.BenaderingPortal !== true &&
    values.BenaderingTelefonisch !== true
  ) {
    errors.DisabilityType = "Selecteer ten minste één type benadering.";
  }

  return errors;
};
