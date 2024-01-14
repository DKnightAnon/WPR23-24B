import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import GeneralInfo from "./GeneralInfo";
import DisabilityType from "./DisabilityType";
import CommercialApproach from "./CommercialApproach";
import CompanyInfo from "./CompanyInfo"; // Import the CompanyInfo component
import UserOrCompanyChoice from "./UserOrCompanyChoice"; // Import the UserOrCompanyChoice component
import { handleSignUp } from "../../Services/Authentication/RegistrationService";

const SignupForm = () => {
  const [step, setStep] = useState(0); // Start with step 0 for the choice
  const navigate = useNavigate(); // Initialize the useNavigate hook
  const [submitMessage, setSubmitMessage] = useState(null);

  const [userFormValues, setUserFormValues] = useState({
    Email: "",
    Wachtwoord: "",
    HerhaalWachtwoord: "",
    Naam: "",
    Postcode: "",
    Geboortedatum: "",
    TelefoonNummer: "",
    isJongerDan18: null,
    FysiekeBeperking: false,
    AuditieveBeperking: false,
    VisueleBeperking: false,
    andereBeperking: "",
    BenaderingTelefonisch: false,
    BenaderingPortal: false,
    BenaderingCommercieel: false,
    userType: "", // Add userType to store the user's choice
    voogdNaam: "", // Add voogdNaam
    voogdEmail: "", // Add voogdEmail
    voogdTelNummer: "", // Add voogdTelNummer
  });

  const [companyFormValues, setCompanyFormValues] = useState({
    Email: "",
    Wachtwoord: "",
    Naam: "",
    Postcode: "",
    TelefoonNummer: "",
    TrackingId: "",
    Website: "",
    Contactpersoon: "",
  });

  const handleChange = (e, userType) => {
    const { name, value, type, checked } = e.target;

    if (userType === "user") {
      setUserFormValues((prevValues) => ({
        ...prevValues,
        [name]: type === "checkbox" ? checked : value,
      }));
    } else if (userType === "company") {
      setCompanyFormValues((prevValues) => ({
        ...prevValues,
        [name]: type === "checkbox" ? checked : value,
      }));
    }
  };

  const handleNext = () => setStep(step + 1);
  const handlePrev = () => setStep(step - 1);

  const handleSubmit = async () => {
    try {
      if (userFormValues.userType === "user") {
        const success = await handleSignUp(
          userFormValues.userType,
          userFormValues,
          userFormValues.isJongerDan18 === false
        );

        if (success) {
        } else {
          // Handle registration error for users
        }
      } else if (userFormValues.userType === "company") {
        const success = await handleSignUp(
          userFormValues.userType,
          companyFormValues, // Use companyFormValues for company registration
          false // Assuming isUnder18 is always false for companies
        );
        if (success) {
          navigate("/signin");
        } else {
          // Handle registration error for companies
        }
      }
    } catch (error) {
      // Handle other errors
    }
  };

  const handleUserSelect = (userType) => {
    setUserFormValues((prevValues) => ({
      ...prevValues,
      userType,
    }));
    handleNext();
  };

  const renderStep = () => {
    switch (step) {
      case 0:
        return (
          <UserOrCompanyChoice
            onSelectUser={() => handleUserSelect("user")}
            onSelectCompany={() => handleUserSelect("company")}
          />
        );
      case 1:
        return userFormValues.userType === "user" ? (
          <GeneralInfo
            onNext={handleNext}
            values={userFormValues}
            handleChange={(e) => handleChange(e, "user")}
          />
        ) : (
          <CompanyInfo
            onNext={handleNext}
            onSubmit={handleSubmit} // Pass the handleSubmit function as prop
            values={companyFormValues}
            handleChange={(e) => handleChange(e, "company")}
          />
        );
      case 2:
        return userFormValues.userType === "user" ? (
          <DisabilityType
            onPrev={handlePrev}
            onNext={handleNext}
            values={userFormValues}
            handleChange={(e) => handleChange(e, "user")}
          />
        ) : (
          handleNext()
        );
      case 3:
        return userFormValues.userType === "user" ? (
          <CommercialApproach
            onPrev={handlePrev}
            onSubmit={handleSubmit}
            values={userFormValues}
            handleChange={(e) => handleChange(e, "user")}
          />
        ) : (
          handleNext()
        );
      default:
        return null;
    }
  };

  return (
    <div>
      {" "}
      {submitMessage && <p>{submitMessage}</p>}
      {renderStep()}
    </div>
  );
};

export default SignupForm;
