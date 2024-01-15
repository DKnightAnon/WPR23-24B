import React, { useEffect } from "react";
import { useGlobalContext } from "./context";
import styled from "styled-components";

const StyledSection = styled.section`
  margin-top: 2rem;
`;

const StyledContainerBox = styled.div`
  background-color: #a7b5f0;
  padding: 2rem;
  margin-top: 2rem;
  border-radius: 8px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
`;

const StyledH2 = styled.h2`
  font-weight: 600;
  color: #2b50ec;
  font-size: 2rem;
  margin-bottom: 1rem;
  padding-top: 1rem;
`;

const StyledP = styled.p`
  color: #000;
  font-size: 1.6rem;
  line-height: 1.5;
  margin-bottom: 1.5rem; /* Add margin bottom for spacing */
`;

const StyledLink = styled.a`
  color: #131b56;
  text-decoration: underline;
  font-weight: 600;
`;

const About = () => {
  const { updateAboutPage } = useGlobalContext();

  useEffect(() => updateAboutPage(), []);

  return (
    <div>
      <StyledSection className="container">
        <StyledContainerBox>
          <StyledH2 aria-label="Missie van Stichting Accessibility">Onze missie</StyledH2>
          <StyledP>
            Bij Accessibility werken we aan een inclusieve samenleving waarin
            iedereen kan meedoen en tot zijn recht komt. Steeds meer
            organisaties sluiten zich aan bij onze ambities. Al zoeken ze nog
            naar hoe ze dit voor elkaar kunnen krijgen.
          </StyledP>
          <StyledP>
            Samen met onze klanten en partners bouwen we iedere dag aan een
            toegankelijker Nederland. We zetten onze kennis en expertise in om
            fysieke, sociale én digitale omgevingen toegankelijk te maken; in
            het bijzonder voor mensen met een (visuele) beperking.
          </StyledP>
          <StyledP>
            Onze experts denken graag met hen mee en bieden begeleiding op maat.
            Dit doen zij in nauwe samenwerking met ervaringsdeskundigen. Met
            onze trainingen, producten en diensten kan iedere organisatie morgen
            nog aan de slag met toegankelijkheid. Zo vertalen we onze kennis
            naar joúw praktijk.
          </StyledP>
          <StyledP>
            Wij denken in mogelijkheden – iedere dag opnieuw – binnen jouw
            doelen en budget. Zodat jouw organisatie doet waar jullie voor
            staan; voor collega’s, klanten en/of burgers.
          </StyledP>
          <StyledP>
            Jouw investering in toegankelijkheid is waardevol voor jouw bedrijf
            én voor de samenleving. Via Stichting Accessibility vloeit jouw
            investering terug naar projecten die bijdragen aan een toegankelijke
            en inclusieve samenleving. Sluit ook bij ons aan!
          </StyledP>
          <StyledP>
            <StyledLink href="#" aria-label="Link naar de website van Stichting Accessibility">
              Wij zijn Accessibility, expert in toegankelijkheid.
            </StyledLink>
          </StyledP>
          <StyledH2 aria-label="Achtergrond Informatie over Stichting Accessibility">Achtergrond</StyledH2>
          <StyledP>
            Begin deze eeuw digitaliseerde de samenleving in een rap tempo. Maar
            waren al die websites en digitale hulpmiddelen wel door iedereen te
            gebruiken? Toegankelijkheid stond nog in de kinderschoenen. Als
            eerste organisatie in Nederland begon Stichting Accessibility in
            2001 met het toegankelijk maken van ICT voor mensen met een visuele
            beperking.
          </StyledP>
          {/* Add more paragraphs as needed */}
          <StyledH2 aria-label="Vacactures">Nieuwsgierig naar onze vacatures?</StyledH2>
          <StyledP>
          Bekijk <StyledLink href="#" aria-label="Bekijk onze vacatures en stageplekken"> hier onze vacatures</StyledLink> die we momenteel open hebben staan. We bieden ook stageplekken!
          </StyledP>
        </StyledContainerBox>
      </StyledSection>
    </div>
  );
};

export default About;
