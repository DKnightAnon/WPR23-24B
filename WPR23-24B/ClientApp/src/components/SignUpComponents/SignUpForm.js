import React, { useState } from "react";
import GeneralInfo from "./GeneralInfo";
import DisabilityType from "./DisabilityType";
import CommercialApproach from "./CommercialApproach";
import CompanyInfo from "./CompanyInfo"; // Import the CompanyInfo component
import UserOrCompanyChoice from "./UserOrCompanyChoice"; // Import the UserOrCompanyChoice component

import { makeApiRequest } from '../../Services/Utils/ApiHelper'

const SignupForm = () => {
  const [step, setStep] = useState(0); // Start with step 0 for the choice
  const [formValues, setFormValues] = useState({
    name: "",
    email: "",
    disability: "",
    includePhysical: false,
    includeVisual: false,
    includeAudio: false,
    allowCommercialApproach: false,
    allowPortalApproach: false,
    allowPhoneApproach: false,
    userType: "", // Add userType to store the user's choice
  });

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setFormValues((prevValues) => ({
      ...prevValues,
      [name]: type === "checkbox" ? checked : value,
    }));
  };

  const handleNext = () => setStep(step + 1);
  const handlePrev = () => setStep(step - 1);

  const handleSubmit = () => {
    // Perform submission logic here
      console.log("Form submitted:", formValues);

      makeApiRequest("Registratie/ervaringsdeskundige/registerOver18", 'POST', formValues)
  };

  const handleUserSelect = (userType) => {
    setFormValues((prevValues) => ({
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
        return formValues.userType === "user" ? (
          <GeneralInfo
            onNext={handleNext}
            values={formValues}
            handleChange={handleChange}
          />
        ) : (
          <CompanyInfo
            onNext={handleNext}
            values={formValues}
            handleChange={handleChange}
          />
        );
      case 2:
        return formValues.userType === "user" ? (
          <DisabilityType
            onPrev={handlePrev}
            onNext={handleNext}
            values={formValues}
            handleChange={handleChange}
          />
        ) : (
          handleNext() // Skip DisabilityType for companies and proceed to the next step
        );
      case 3:
        return formValues.userType === "user" ? (
          <CommercialApproach
            onPrev={handlePrev}
            onSubmit={handleSubmit}
            values={formValues}
            handleChange={handleChange}
          />
        ) : (
          handleNext() // Skip CommercialApproach for companies and proceed to the next step
        );
      default:
        return null;
    }
  };

  return <div>{renderStep()}</div>;
};

export default SignupForm;
