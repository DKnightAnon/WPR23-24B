import React from "react";
import styled from "styled-components";
import { Link } from "react-router-dom";
import ErvaringsdeskundigePortal from "./ErvaringsdeskundigePortal";
const LandingPage = () => {
  return (
    <Container>
      <MainContent>
        <WelcomeSection>
          <WelcomeMessage>
            Welkom bij het Ervaringsdeskundige Portaal
          </WelcomeMessage>
          <SubMessage>
            Uw centrale hub voor gepersonaliseerde ervaringen en informatie.
          </SubMessage>
        </WelcomeSection>
        <FeaturesSection>
          <Feature>
            <FeatureIcon>👤</FeatureIcon>
            <FeatureTitle>Bekijk en Bewerk Profiel</FeatureTitle>
            <FeatureDescription>
              Personaliseer uw profielinformatie en voorkeuren.
            </FeatureDescription>
          </Feature>
          <Feature>
            <FeatureIcon>📋</FeatureIcon>
            <FeatureTitle>Inschrijven voor Onderzoeken</FeatureTitle>
            <FeatureDescription>
              Verken en schrijf u in voor onderzoeksmogelijkheden die bij u
              passen.
            </FeatureDescription>
          </Feature>
          <Feature>
            <FeatureIcon>💬</FeatureIcon>
            <FeatureTitle>Chat met Bedrijven</FeatureTitle>
            <FeatureDescription>
              Ga in gesprek met bedrijven om feedback en ervaringen te delen.
            </FeatureDescription>
          </Feature>
          <Feature>
            <FeatureIcon>🤝</FeatureIcon>
            <FeatureTitle>Samenwerken met Stichting Accessibility</FeatureTitle>
            <FeatureDescription>
              Neem deel aan samenwerkingen met Stichting Accessibility voor
              inclusieve ervaringen.
            </FeatureDescription>
          </Feature>
          {/* Voeg meer functies toe indien nodig */}
        </FeaturesSection>
        <ActionButtons>
          <ActionButton to="/dashboard">Ga naar Dashboard</ActionButton>
          <ActionButton to="/dashboard/claimedresearches">
            Bekijk uw Onderzoeken
          </ActionButton>
        </ActionButtons>
      </MainContent>
    </Container>
  );
};

const Container = styled.div`
  display: flex;
  flex-direction: column;
  min-height: 100vh;
`;

const Header = styled.div`
  background-color: #2b50ec; /* Uw achtergrondkleur voor de koptekst */
  color: #fff;
  padding: 20px;
  display: flex;
  justify-content: space-between;
  align-items: center;
`;

const Logo = styled.div`
  font-size: 24px;
  font-weight: bold;
`;

const Navigation = styled.nav`
  display: flex;
`;

const NavLink = styled(Link)`
  color: #fff;
  text-decoration: none;
  margin-left: 20px;
  font-weight: bold;
  font-size: 16px;

  &:hover {
    text-decoration: underline;
  }
`;

const MainContent = styled.div`
  flex: 1;
  padding: 20px;
  text-align: center;
`;

const WelcomeSection = styled.div`
  margin-bottom: 40px;
`;

const WelcomeMessage = styled.h1`
  font-size: 36px;
  margin-bottom: 20px;
  margin-top: 40px;
`;

const SubMessage = styled.p`
  font-size: 18px;
  color: #6c757d;
`;

const FeaturesSection = styled.div`
  display: flex;
  justify-content: space-around;
  flex-wrap: wrap;
  margin-bottom: 40px;
`;

const Feature = styled.div`
  max-width: 300px;
  padding: 20px;
  border: 1px solid #dee2e6; /* Uw randkleur (placeholder) */
  border-radius: 10px;
  margin: 20px;
`;

const FeatureIcon = styled.span`
  font-size: 36px;
`;

const FeatureTitle = styled.h2`
  font-size: 24px;
  margin-bottom: 10px;
`;

const FeatureDescription = styled.p`
  font-size: 16px;
  color: #6c757d;
`;

const ActionButtons = styled.div`
  display: flex;
  justify-content: center;
`;

const ActionButton = styled(Link)`
  background-color: #28a745; /* Uw knopkleur */
  color: #fff;
  padding: 15px 30px;
  border: none;
  text-decoration: none;
  font-weight: bold;
  font-size: 18px;
  border-radius: 5px;
  margin: 0 10px;
  cursor: pointer;

  &:hover {
    background-color: #218838; /* Donkerder groen voor hover */
  }
`;

export default LandingPage;
