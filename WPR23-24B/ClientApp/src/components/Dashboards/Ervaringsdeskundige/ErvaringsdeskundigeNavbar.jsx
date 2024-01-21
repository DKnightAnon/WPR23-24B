// Navbar.jsx
import React from "react";
import { Link } from "react-router-dom";
import styled from "styled-components";
import { FaUser, FaClipboardList, FaTasks, FaHome } from "react-icons/fa";

const DeskundigeNavbar = () => {
  return (
    <Nav className="navbar navbar-expand-lg navbar-dark bg-primary">
      <NavContainer className="container">
        <NavLink as={Link} to="/dashboard" className="navbar-brand">
          <IconContainer>
            <FaUser className="icon" />
          </IconContainer>
          Gebruiker Gegevens
        </NavLink>
        <NavLink as={Link} to="/dashboard/onderzoeken">
          <IconContainer>
            <FaClipboardList className="icon" />
          </IconContainer>
          Onderzoeken
        </NavLink>
        <NavLink as={Link} to="/dashboard/claimedresearches">
          <IconContainer>
            <FaTasks className="icon" />
          </IconContainer>
          Mijn Onderzoeken
        </NavLink>
        <NavLink as={Link} to="/dashboard/portaal">
          <IconContainer>
            <FaHome className="icon" />
          </IconContainer>
          Portaal
        </NavLink>
        {/* Add more navigation links */}
      </NavContainer>
    </Nav>
  );
};

const Nav = styled.nav`
  padding: 10px 0;
`;

const NavContainer = styled.div`
  display: flex;
  align-items: center;
`;

const NavLink = styled(Link)`
  display: flex;
  align-items: center;
  font-size: 1.8rem;
  color: ${({ theme }) => theme.colors.white};
  text-decoration: none;
  border-radius: 5px;
  padding: 10px;
  margin-right: 15px;
  cursor: pointer;
  transition: background-color 0.3s ease, color 0.3s ease;

  &:hover {
    background-color: #1ca883;
    color: ${({ theme }) => theme.colors.white};
    text-decoration: underline;
  }
`;

const IconContainer = styled.span`
  margin-right: 10px;
`;

export default DeskundigeNavbar;
