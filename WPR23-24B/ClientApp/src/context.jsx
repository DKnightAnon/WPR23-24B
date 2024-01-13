import React, { useContext, useReducer } from "react";
import reducer from "./reducer";

const AppContext = React.createContext();

const initialState = {
  name: "",
  image: "",
  services: [
    {
      id: 1,
      name: "Toegankelijke digitale omgeving",
      image:
        "/images/services/accessibilityVoorElkeGebruikerOngeachtBeperkingen.jpg",
      description:
        "De website of app voor jouw digitale product of dienst toegankelijk maken voor iedereen.",
    },
    {
      id: 2,
      name: "Toegankelijke fysieke omgeving",
      image: "/images/services/accessibilityInJouwOmgeving.jpg",
      description:
        "Alle ruimtes in en om het gebouw toegankelijk maken met drempels, geleidelijnen, verlichting en/of kleuren.",
    },
    {
      id: 3,
      name: "Gebruiksvriendelijke omgeving",
      image: "/images/services/accessibilitySamenMetErvaringdeskundigen.jpg",
      description:
        "Vergroot de toegankelijkheid, gebruiksvriendelijkheid en bruikbaarheid met ervaringdeskundigen.",
    },
  ],
};

const AppProvider = ({ children }) => {
  const [state, dispatch] = useReducer(reducer, initialState);

  const updateHomePage = () => {
    return dispatch({
      type: "HOME_UPDATE",
      payload: {
        name: "Stichting Accessibility",
        image: "./images/hero.svg",
      },
    });
  };

  const updateAboutPage = () => {
    return dispatch({
      type: "ABOUT_UPDATE",
      payload: {
        name: "Stichting Accessibility",
        image: "",
      },
    });
  };

  return (
    <AppContext.Provider value={{ ...state, updateHomePage, updateAboutPage }}>
      {children}
    </AppContext.Provider>
  );
};

const useGlobalContext = () => {
  return useContext(AppContext);
};

export { AppProvider, useGlobalContext };
