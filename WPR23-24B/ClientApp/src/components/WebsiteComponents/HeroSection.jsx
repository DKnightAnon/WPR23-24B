import React from "react";
import { NavLink } from "react-router-dom";
import styled from "styled-components";
import { useGlobalContext } from "../../context";
import { Button } from "./Styles/Button";

const HeroSection = () => {
  const { name, image } = useGlobalContext();

  return (
    <Wrapper>
      <div className="container grid grid-two-column">
        <div className="section-hero-data">
          <h1 className="hero-heading">{name}</h1>
          <p className="hero-para">
            Samen met onze{" "}
            <span className="hero-span">partners en klanten</span> werken we aan
            een <span className="hero-span">inclusieve samenleving</span> die
            toegankelijk is voor <span className="hero-span">iedereen.</span>
          </p>
          <Button className="btn hireme-btn">
            <NavLink to="/contact" aria-label="Meer over Accessibility">
              Meer over ons
            </NavLink>
          </Button>
        </div>

        {/* for image  */}
        <div className="section-hero-image">
          <picture>
            <img src={image} alt="Afbeelding van een mevrouw die werkt op haar laptop" className="hero-img " />
          </picture>
        </div>
      </div>
    </Wrapper>
  );
};

const Wrapper = styled.section`
  padding: 9rem 0;

  .section-hero-data {
    display: flex;
    flex-direction: column;
    justify-content: center;
  }

  .btn {
    max-width: 16rem;
    background-color: darkblue;
  }

  .hero-top-data {
    text-transform: uppercase;
    font-weight: 500;
    font-size: 1.5rem;
    color: ${({ theme }) => theme.colors.helper};
  }

  .hero-heading {
    text-transform: uppercase;
    font-size: 6.4rem;
  }

  .hero-para {
    margin-top: 1.5rem;
    margin-bottom: 3.4rem;
    max-width: 60rem;
    font-size: 2.3rem;
  }

  .hero-span {
    font-weight: 700;
  }

  .section-hero-image {
    display: flex;
    justify-content: center;
    align-items: center;
  }

  picture {
    text-align: center;
  }

  .hero-img {
    max-width: 80%;
  }

  @media (max-width: ${({ theme }) => theme.media.mobile}) {
    .grid {
      gap: 7.2rem;
    }

    .hero-heading {
      font-size: 5rem;
    }

    .hero-para {
      font-size: 2.3rem;
    }

    .hero-img {
      max-width: 50%;
    }
  }
`;

export default HeroSection;
