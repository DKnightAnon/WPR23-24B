// ErvaringsdeskundigePortal.jsx
import { makeApiRequest } from "../../../Services/Utils/ApiHelper";
import React, { useState, useEffect } from "react";
import styled from "styled-components";
import { useNavigate, Link } from "react-router-dom";
import UserInfo from "./UserInfo";
import DeskundigeNavbar from "./ErvaringsdeskundigeNavbar";

const ErvaringsdeskundigePortal = () => {
  const [editMode, setEditMode] = useState(false);
  const [userData, setUserData] = useState({});
  const [editableUserInfo, setEditableUserInfo] = useState({});
  const navigate = useNavigate();

  const handleEditClick = () => {
    setEditMode(true);
  };

  const handleGoBack = () => {
    // Navigeer terug naar het dashboard
    navigate("/dashboard");
  };

  const handleSaveClick = async () => {
    try {
      // const endpoint = `User/updateuserinfo`;
      // const method = "PUT";

      // // Sending only the necessary data to the server
      // const { naam, emailadres, ...userInfo } = editableUserInfo;
      // const response = await makeApiRequest(endpoint, method, {
      //   ...userInfo, // Include other user information properties
      // });

      // // Update state with the response from the server
      // setUserData(response);

      // Exit edit mode after successfully saving
      setEditMode(false);
    } catch (error) {
      console.error("Error saving user information:", error);
      // You can handle errors and display error messages if needed
    }
  };

  return (
    <Container>
      <DeskundigeNavbar />
      <ContentContainer>
        <MainContent>
          <UserInfoContainer>
            <UserInfo gebruiker={userData} editMode={editMode} />
          </UserInfoContainer>
          <ButtonContainer>
            {!editMode ? (
              <Button onClick={handleEditClick}>Wijzig Gegevens</Button>
            ) : (
              <>
                <Button onClick={handleSaveClick}>Opslaan</Button>
                <CancelButton
                  className="cancel"
                  onClick={() => setEditMode(false)}
                >
                  Cancel
                </CancelButton>
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
  background-color: green;
  color: ${({ theme }) => theme.colors.white};
  padding: 0.8rem 1.2rem;
  border: none;
  cursor: pointer;
  border-radius: 5px;

  &:hover {
    background-color: ${({ theme }) => theme.colors.shadow};
  }
`;

const CancelButton = styled.button`
  background-color: red;
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
