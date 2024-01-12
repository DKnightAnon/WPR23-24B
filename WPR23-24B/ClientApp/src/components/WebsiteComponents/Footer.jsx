import React from "react";
import styled from "styled-components";
import { Button } from "./Styles/Button";
import { NavLink } from "react-router-dom";
import { FaLinkedin, FaTwitter, FaYoutube } from "react-icons/fa";

const Footer = () => {
  return (
    <Wrapper>
      <section className="contact-short">
        <div className="grid grid-two-column">
          <div>
            <h3>Ook jouw organisatie voor iedereen toegankelijk?</h3>
            <p>
              Wij kunnen je helpen met digitale, fysieke en sociale
              toegankelijkheid.
            </p>
          </div>
          <div className="contact-short-btn">
            <NavLink to="/">
              <Button>Begin vandaag nog</Button>
            </NavLink>
          </div>
        </div>
      </section>

      {/* footer section  */}

      <footer>
        <div className="container grid grid-four-column">
          <div className="footer-about">
            <h3>Stichting Accessibility</h3>
            <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit.</p>
          </div>

          {/* 2nd column */}
          <div className="footer-subscribe">
            <h3>
              Ontvang maandelijks onze nieuwsbrief met de laatste updates rondom
              accessibility.
            </h3>
            <form action="#">
              <input
                type="email"
                required
                autoComplete="off"
                placeholder="Email"
              />
              <input type="submit" value="Inschrijven" />
            </form>
          </div>

          {/* 3rs column  */}
          <div className="footer-social">
            <h3>Volg ons op:</h3>
            <div className="footer-social--icons">
              <div>
                <FaTwitter className="icons" aria-label="Twitter" />
              </div>
              <div>
                <FaLinkedin className="icons" aria-label="LinkedIn" />
              </div>
              <div>
                <a href="" target="_blank">
                  <FaYoutube className="icons" aria-label="Youtube" />
                </a>
              </div>
            </div>
          </div>

          {/* 4th column  */}
          <div className="footer-contact">
            <h3>Accessibility</h3>
            <p aria-label="Email">info@accessibility.nl</p>
            <p>Telefoonnummer:030-2398270</p>
          </div>
        </div>

        {/* bottom section  */}
        <div className="footer-bottom--section">
          <hr />
          <div className="container grid grid-two-column">
            <p>© {new Date().getFullYear()} Stichting Accessibility</p>
            <div>
              <p href="" aria-label="Privacy Policy">
                PRIVACY POLICY
              </p>
              <p href="" aria-label="Terms & Conditions">
                TERMS & CONDITIONS
              </p>
            </div>
          </div>
        </div>
      </footer>
    </Wrapper>
  );
};

const Wrapper = styled.section`
  .contact-short {
    max-width: 60vw;
    margin: auto;
    padding: 5rem 10rem;
    background-color: ${({ theme }) => theme.colors.bg};
    border-radius: 1rem;
    box-shadow: ${({ theme }) => theme.colors.shadowSupport};
    transform: translateY(50%);
  }
  .contact-short-btn {
    justify-self: end;
    align-self: center;
    background-color: #2b50ec;
  }

  footer {
    padding: 14rem 0 9rem 0;
    background-color: ${({ theme }) => theme.colors.footer_bg};

    h3 {
      color: ${({ theme }) => theme.colors.hr};
      margin-bottom: 2.4rem;
    }
    p {
      color: ${({ theme }) => theme.colors.white};
    }
    .footer-social--icons {
      display: flex;
      gap: 2rem;

      div {
        padding: 1rem;
        border-radius: 50%;
        border: 2px solid ${({ theme }) => theme.colors.white};

        .icons {
          color: ${({ theme }) => theme.colors.white};
          font-size: 2.4rem;
          position: relative;
          cursor: pointer;
        }
      }
    }

    .footer-bottom--section {
      padding-top: 9rem;

      hr {
        margin-bottom: 2rem;
        color: ${({ theme }) => theme.colors.hr};
        height: 0.1px;
      }
    }
  }

  @media (max-width: ${({ theme }) => theme.media.mobile}) {
    .contact-short {
      max-width: 95vw;
      padding: 2rem 0rem;
      display: flex;
      justify-content: center;
      align-items: center;
      align-text: center;

      .contact-short-btn {
        text-align: center;
        justify-self: center;
      }
    }

    footer .footer-bottom--section {
      padding-top: 3.2rem;
    }

    .contact-short h3,
    p {
      text-align: left;
      margin-left: 1rem;
    }
  }
`;

export default Footer;
