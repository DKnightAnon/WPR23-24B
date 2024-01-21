import React from "react";
import { useEffect } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import ReactDOM from "react-dom";
import "./custom.css";
import { ThemeProvider } from "styled-components";
import { GlobalStyle } from "./GlobalStyle";
import GoToTop from "./components/WebsiteComponents/GoToTop";
import "bootstrap/dist/css/bootstrap.min.css";

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

// BEHEERDERS PORTAAL
import BeheerHome from "./components/Beheer/BeheerHome";

// ERVARINGSDESKUNDIGE PORTAAL
import ResearchPage from "./components/Onderzoek/ResearchPage";
import ResearchDetailPage from "./components/Onderzoek/ResearchDetailPage";
import UserInfo from "./components/Dashboards/Ervaringsdeskundige/UserInfo";
import ClaimedResearchesPage from "./components/Dashboards/Ervaringsdeskundige/ClaimedResearchesPage";
import LandingPage from "./components/Dashboards/Ervaringsdeskundige/LandingPage";
import ErvaringsdeskundigePortal from "./components/Dashboards/Ervaringsdeskundige/ErvaringsdeskundigePortal";

// AUTHENTICATIE
import AuthService from "./Services/Authentication/AuthService";
import AuthUtils from "./Services/Authentication/AuthUtils";

// CHAT
import Chat from "./components/Chat/Chat";
import "./ChatStyling.css";

// AUTORISATIE
import PrivateRoute from "./Services/Autorisation/PrivateRoute";

const App = () => {
  const theme = {
    colors: {
      heading: "rgb(24 24 29)",
      text: "rgb(24 24 29)",
      white: "#fff",
      black: " #212529",
      helper: "#8490ff",
      bg: "#D9EBF7",
      footer_bg: "#0a1435",
      btn: "#2B50EC",
      border: "rgba(98, 84, 243, 0.5)",
      hr: "#ffffff",
      gradient:
        "linear-gradient(0deg, rgb(132 144 255) 0%, rgb(98 189 252) 100%)",
      shadow:
        "rgba(0, 0, 0, 0.02) 0px 1px 3px 0px,rgba(27, 31, 35, 0.15) 0px 0px 0px 1px;",
      shadowSupport: " rgba(0, 0, 0, 0.16) 0px 1px 4px",
    },
    media: { mobile: "768px", tab: "998px" },
  };

  //useEffect(

  //    () => {
  //        const interval = setInterval(
  //            () => {
  //                if (AuthUtils.tokenExpired()) {
  //                    //AuthService.signOut()
  //                    console.log("token expired")
  //                }
  //                console.log("intervaltest")
  //            }, 5000);
  //        return () => clearInterval(interval);
  //    }, []

  //)

  return (
    <ThemeProvider theme={theme}>
      <GlobalStyle />
      <GoToTop />
      <Header />

      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/service" element={<Services />} />
        <Route path="/news" element={<News />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="/login" element={<SignInComponent />} />
        <Route path="/register" element={<SignupForm />} />
        <Route path="/Onderzoeken" element={<ResearchPage />} />
        <Route path="/research/:id" element={<ResearchDetailPage />} />
        <Route path="*" element={<Error />} />
        <Route
          path="/chat"
          element={
            <PrivateRoute
              element={Chat}
              roles={"Bedrijf, Ervaringsdeskundige"}
            />
          }
        />
        <Route path="/beheer" element={<BeheerHome />} />
        <Route path="/dashboard" element={<ErvaringsdeskundigePortal />} />
        <Route path="/dashboard/userinfo" element={<UserInfo />} />
        <Route path="/dashboard/onderzoeken" element={<ResearchPage />} />
        <Route path="/research/:id" element={<ResearchDetailPage />} />
        <Route
          path="/dashboard/claimedresearches"
          element={<ClaimedResearchesPage />}
        />
        <Route
          path="/dashboard/portaal"
          element={
            <PrivateRoute
              element={LandingPage}
              roles={["Admin", "Ervaringsdeskundige"]}
            />
          }
        />
        {/* Voeg hieronder extra privaterouting elementen toe voor andere rollen! */}
      </Routes>
      <Footer />
    </ThemeProvider>
  );
};

export default App;