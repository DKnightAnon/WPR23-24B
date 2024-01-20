import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import ReactDOM from "react-dom";
import "./custom.css";
import { ThemeProvider } from "styled-components";
import { GlobalStyle } from "./GlobalStyle";
import GoToTop from "./components/WebsiteComponents/GoToTop";
import 'bootstrap/dist/css/bootstrap.min.css';

// Pages
import About from "./About";
import Contact from "./Contact";
import Home from "./Home";
import Services from "./Services";
import News from "./News";
import Header from "./components/WebsiteComponents/Header";
import Footer from "./components/WebsiteComponents/Footer";
import Error from "./Error";
import SignInForm from "./components/SignInComponents/SignInForm";
import SignupForm from "./components/SignUpComponents/SignUpForm";
import SignInComponent from "./components/SignInComponents/SignInComponent";
import UserOrCompanyChoice from "./components/SignUpComponents/UserOrCompanyChoice";

import BeheerHome from './components/Beheer/BeheerHome';


// import ProfilePage from "./components/Dashboards/Bedrijf/InfoPage";

import Chat from "./components/Chat/Chat";
import './ChatStyling.css'
import ErvaringsdeskundigePortal from "./components/Dashboards/ErvaringsdeskundigePortal";
import PrivateRoute from "./Services/Autorisation/PrivateRoute";


import NavBar from "./components/Dashboards/Bedrijf/NavBar";
import ResearchList from "./components/Dashboards/Bedrijf/ResearchList";
import NieuwOnderzoekButton from "./components/Dashboards/Bedrijf/NieuwOnderzoekButton"
import InfoPage from "./components/Dashboards/Bedrijf/InfoPage";
import { useState, useEffect } from "react";
import { makeApiRequest } from "./Services/Utils/ApiHelper";

const App = () => {

  const [researches, setResearches] = useState([]);

  const [researchListVisible, setResearchListVisible] = useState(true); 
  const [newResearchButtonVisible, setNewResearchButtonVisible] = useState(true);
  const [newComponentVisible, setNewComponentVisible] = useState(false); 

  
  const showDetails = (index) => {
    alert(`Details for research: ${researches[index].details}`);
  };

  const createNewResearch = (newResearch) => {
    setResearches([...researches, newResearch]);
  };

  const toggleVisibility = () => {
    setResearchListVisible(!researchListVisible);
    setNewResearchButtonVisible(!newResearchButtonVisible);
    // Update the text inside the 'Gegevens' button based on the current visibility state
    setNewComponentVisible(!newComponentVisible);
  };

  const closeComponent = () => {
    setNewComponentVisible(false);
  };

  return (
    <div>
      <NavBar toggleResearchListVisibility={toggleVisibility} />
      <div className="main-content">
        {researchListVisible && (
          <ResearchList researches={researches} showDetails={showDetails}/>
        )}
        {newResearchButtonVisible && (
          <NieuwOnderzoekButton createNewResearch={createNewResearch} />
        )}
        {newComponentVisible && <InfoPage closeComponent={closeComponent} />}
      </div>
    </div>
  );
}




//   const theme = {
//     colors: {
//       heading: "rgb(24 24 29)",
//       text: "rgb(24 24 29)",
//       white: "#fff",
//       black: " #212529",
//       helper: "#8490ff",
//       bg: "#D9EBF7",
//       footer_bg: "#0a1435",
//       btn: "#2B50EC",
//       border: "rgba(98, 84, 243, 0.5)",
//       hr: "#ffffff",
//       gradient:
//         "linear-gradient(0deg, rgb(132 144 255) 0%, rgb(98 189 252) 100%)",
//       shadow:
//         "rgba(0, 0, 0, 0.02) 0px 1px 3px 0px,rgba(27, 31, 35, 0.15) 0px 0px 0px 1px;",
//       shadowSupport: " rgba(0, 0, 0, 0.16) 0px 1px 4px",
//     },
//     media: { mobile: "768px", tab: "998px" },
//   };


//   return (
//     <ThemeProvider theme={theme}>
//       <GlobalStyle />
//       <GoToTop />
//       <Header />
//       <Routes>
//         <Route path="/" element={<Home />} />
//         <Route path="/about" element={<About />} />
//         <Route path="/service" element={<Services />} />
//         <Route path="/news" element={<News />} />
//         <Route path="/contact" element={<Contact />} />
//         <Route path="/login" element={<SignInComponent />} />
//         <Route path="/register" element={<SignupForm />} />
//         <Route path="*" element={<Error />} />
//         <Route path="/chat" element={<Chat />} />
//         <Route path="/beheer" element={<BeheerHome />} />
//         <Route
//           path="/dashboard"
//           element={
//             <PrivateRoute
//               element={ErvaringsdeskundigePortal}
//               roles={["Admin", "Ervaringsdeskundige"]}
//             />
//           }
//         />
//         {/* Voeg hieronder extra privaterouting elementen toe voor andere rollen! */}
//       </Routes>
//       <Footer />
//     </ThemeProvider>
//   );

// };

export default App;
