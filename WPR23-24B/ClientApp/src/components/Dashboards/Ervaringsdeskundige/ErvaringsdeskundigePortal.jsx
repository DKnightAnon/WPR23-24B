// ErvaringsdeskundigePortal.jsx
import { makeApiRequest } from "../../../Services/Utils/ApiHelper";
import React, { useState, useEffect } from "react";
import styled from "styled-components";
import { Link } from "react-router-dom";
import UserInfo from "./UserInfo";

const ErvaringsdeskundigePortal = () => {
  const [editMode, setEditMode] = useState(false);
  const [userData, setUserData] = useState({});
  const [editableUserInfo, setEditableUserInfo] = useState({});

  const handleEditClick = () => {
    setEditMode(true);
  };

  const handleSaveClick = async () => {
    console.log("Saving user information:", editableUserInfo);
    try {
      // Validate required fields before saving

      const endpoint = `User/updateuserinfo`;
      const method = "PUT";

      // Sending only the necessary data to the server
      const { Naam, Emailadres, ...userInfo } = editableUserInfo;
      const response = await makeApiRequest(endpoint, method, {
        Naam,
        Emailadres,
        userInfo,
      });

      setUserData(response);
      setEditMode(false);
    } catch (error) {
      console.error("Error saving user information:", error);
    }
  };

  return (
    <Container>
      <Navbar>
        <NavLinks>
          <NavLink to="/dashboard">Gebruiker Gegevens</NavLink>
          <NavLink to="/onderzoeken">Onderzoeken</NavLink>
          {/* Add more navigation links */}
        </NavLinks>
      </Navbar>
      <ContentContainer>
        <MainContent>
          <UserInfoContainer>
            <UserInfo gebruiker={userData} editMode={editMode} />
          </UserInfoContainer>
          <ButtonContainer>
            {!editMode ? (
              <Button onClick={handleEditClick}>Edit</Button>
            ) : (
              <>
                <Button onClick={handleSaveClick}>Save</Button>
                <Button onClick={() => setEditMode(false)}>Cancel</Button>
              </>
            )}
          </ButtonContainer>
        </MainContent>
      </ContentContainer>
    </Container>
  );
};

const Container = styled.div`
  display: flex;
  flex-direction: column;
  min-height: 100vh;
`;

const Navbar = styled.nav`
  background-color: #2b50ec;
  color: ${({ theme }) => theme.colors.white};
  padding: 10px 0;
`;

const NavLinks = styled.div`
  display: flex;
  justify-content: space-around;
`;

const NavLink = styled(Link)`
  font-size: 1.8rem;
  color: ${({ theme }) => theme.colors.white};
  text-decoration: none;
  border-radius: 5px;
  padding: 10px;
  cursor: pointer;

  &:hover {
    background-color: #1ca883;
  }
`;

const ContentContainer = styled.div`
  display: flex;
  flex: 1;
  padding: 20px;
`;

const MainContent = styled.div`
  display: flex;
  flex-direction: column;
  flex: 1;
`;

const UserInfoContainer = styled.div`
  background-color: ${({ theme }) => theme.colors.white};
  padding: 20px;
  border-radius: 10px;
  box-shadow: ${({ theme }) => theme.colors.shadow};
  margin-bottom: 20px;
`;

const ButtonContainer = styled.div`
  display: flex;
  justify-content: flex-end;
`;

const Button = styled.button`
  background-color: ${({ theme }) => theme.colors.btn};
  color: ${({ theme }) => theme.colors.white};
  padding: 0.8rem 1.2rem;
  border: none;
  cursor: pointer;
  border-radius: 5px;

  &:hover {
    background-color: ${({ theme }) => theme.colors.shadow};
  }
`;

export default ErvaringsdeskundigePortal;
