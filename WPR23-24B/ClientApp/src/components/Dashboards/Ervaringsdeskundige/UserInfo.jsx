import React, { useState, useEffect } from "react";
import styled from "styled-components";
import { makeApiRequest } from "../../../Services/Utils/ApiHelper";
import DeskundigeNavbar from "./ErvaringsdeskundigeNavbar";

const UserInfo = ({ gebruiker, editMode }) => {
  const [selectedHulpmiddelen, setSelectedHulpmiddelen] = useState(
    gebruiker.hulpmiddelen || []
  );

  const [userInfo, setUserInfo] = useState({});
  const [editableUserInfo, setEditableUserInfo] = useState({});
  const [hulpmiddelenData, setHulpmiddelenData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const userInfoEndpoint = `User/userinfo`;
        const hulpmiddelenEndpoint = `Hulpmiddels/predefinedHulpmiddelen`;

        const userInfoResponse = await makeApiRequest(userInfoEndpoint, "GET");
        const hulpmiddelenResponse = await makeApiRequest(
          hulpmiddelenEndpoint,
          "GET"
        );

        setUserInfo(userInfoResponse);
        setEditableUserInfo(userInfoResponse);
        setHulpmiddelenData(hulpmiddelenResponse);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchData();
  }, [gebruiker.id, gebruiker.role]);

  const handleHulpmiddelChange = (hulpmiddel) => {
    const updatedHulpmiddelen = selectedHulpmiddelen.includes(hulpmiddel)
      ? selectedHulpmiddelen.filter((item) => item !== hulpmiddel)
      : [...selectedHulpmiddelen, hulpmiddel];

    setSelectedHulpmiddelen(updatedHulpmiddelen);
  };

  // Update editableUserInfo on input change
  const handleUserInfoChange = (key, value) => {
    setEditableUserInfo((prevUserInfo) => {
      return { ...prevUserInfo, [key]: value };
    });
  };

  return (
    <Container>
      <Header>
        <h3>Gebruiker Gegevens</h3>
      </Header>
      <Form>
        <h4>Mijn Gegevens</h4>
        <UserInfoSection>
          <UserInfoGrid>
            <UserInfoLabel>Volledige Naam</UserInfoLabel>
            <UserInfoValue>
              <Input
                type="text"
                value={editableUserInfo.naam || ""}
                onChange={(e) => handleUserInfoChange("naam", e.target.value)}
                disabled={!editMode}
              />
            </UserInfoValue>
            <UserInfoLabel>Emailadres:</UserInfoLabel>
            <UserInfoValue>
              <Input
                type="text"
                defaultValue={userInfo.emailadres}
                onChange={(e) =>
                  handleUserInfoChange("emailadres", e.target.value)
                }
                disabled={!editMode}
              />
            </UserInfoValue>
            <UserInfoLabel>Telefoonnummer:</UserInfoLabel>
            <UserInfoValue>
              <Input
                type="text"
                defaultValue={userInfo.telefoonNummer}
                onChange={(e) =>
                  setEditableUserInfo({
                    ...editableUserInfo,
                    telefoonNummer: e.target.value,
                  })
                }
                disabled={!editMode}
              />
            </UserInfoValue>
            <UserInfoLabel>Postcode:</UserInfoLabel>
            <UserInfoValue>
              <Input
                type="text"
                defaultValue={userInfo.postcode}
                onChange={(e) =>
                  setEditableUserInfo({
                    ...editableUserInfo,
                    postcode: e.target.value,
                  })
                }
                disabled={!editMode}
              />
            </UserInfoValue>

            <UserInfoLabel>Geboortedatum:</UserInfoLabel>
            <UserInfoValue>
              <Input
                type="date"
                defaultValue={
                  userInfo.geboorteDatum
                    ? userInfo.geboorteDatum.split("T")[0]
                    : ""
                }
                disabled={!editMode}
              />
            </UserInfoValue>

            {/* Add more user information fields as needed */}
          </UserInfoGrid>
        </UserInfoSection>

        <CheckboxSection>
          <h4>Mijn Communicatievoorkeur</h4>
          <CheckboxList>
            <CheckboxItem>
              <Checkbox
                type="checkbox"
                defaultChecked={userInfo.benaderingCommercieel}
                disabled={!editMode}
              />
              <CheckboxLabel>
                Commerciële benadering door bedrijven
              </CheckboxLabel>
            </CheckboxItem>
            <CheckboxItem>
              <Checkbox
                type="checkbox"
                defaultChecked={userInfo.benaderingTelefonisch}
                disabled={!editMode}
              />
              <CheckboxLabel>Telefonische benadering</CheckboxLabel>
            </CheckboxItem>
            <CheckboxItem>
              <Checkbox
                type="checkbox"
                defaultChecked={userInfo.benaderingPortal}
                disabled={!editMode}
              />
              <CheckboxLabel>Digitale benadering via het portaal</CheckboxLabel>
            </CheckboxItem>

            {/* Add more checkboxes for communication preferences */}
          </CheckboxList>
        </CheckboxSection>

        <CheckboxSection>
          <h4>Mijn Beperkingen</h4>
          <CheckboxList>
            <CheckboxItem>
              <Checkbox
                type="checkbox"
                defaultChecked={userInfo.fysiekeBeperking}
                disabled={!editMode}
              />
              <CheckboxLabel>Fysieke Beperking</CheckboxLabel>
            </CheckboxItem>
            <CheckboxItem>
              <Checkbox
                type="checkbox"
                defaultChecked={userInfo.auditieveBeperkin}
                disabled={!editMode}
              />
              <CheckboxLabel>Auditore Beperking</CheckboxLabel>
            </CheckboxItem>
            <CheckboxItem>
              <Checkbox
                type="checkbox"
                defaultChecked={userInfo.visueleBeperking}
                disabled={!editMode}
              />
              <CheckboxLabel>Visuele Beperking</CheckboxLabel>
            </CheckboxItem>

            {/* Add more checkboxes for physical limitations */}
          </CheckboxList>
        </CheckboxSection>

        {/* Hulpmiddelen Section */}
        <HulpmiddelenSection>
          <h4>Hulpmiddelen</h4>
          <HulpmiddelenList>
            {hulpmiddelenData.map((hulpmiddel) => (
              <HulpmiddelItem key={hulpmiddel.id}>
                <Checkbox
                  type="checkbox"
                  checked={selectedHulpmiddelen.includes(hulpmiddel.id)}
                  onChange={() => handleHulpmiddelChange(hulpmiddel.id)}
                  disabled={!editMode}
                />
                {hulpmiddel.name}
              </HulpmiddelItem>
            ))}
          </HulpmiddelenList>
        </HulpmiddelenSection>
      </Form>
    </Container>
  );
};

const Header = styled.div`
  h3 {
    font-size: 24px;
    color: ${({ theme }) =>
      theme.colors.primary}; /* You can use your desired color */
    margin-bottom: 15px;
  }
`;

const UserInfoSection = styled.div`
  margin-bottom: 20px;
`;

const UserInfoGrid = styled.div`
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
  gap: 20px;
`;

const UserInfoLabel = styled.div`
  font-weight: bold;
  font-size: 1.2rem;
`;

const UserInfoValue = styled.div``;

const CheckboxSection = styled.div`
  margin-bottom: 20px;
`;

const CheckboxList = styled.div`
  display: grid;
  gap: 8px;
  grid-template-columns: repeat(auto-fill, minmax(200px, 1fr));
`;

const CheckboxItem = styled.div`
  display: flex;
  align-items: center;
`;

const Container = styled.div`
  background-color: ${({ theme }) => theme.colors.white};
  padding: 20px;
  border-radius: 10px;
  box-shadow: ${({ theme }) => theme.colors.shadow};
  position: relative;
  max-width: 600px;
  margin: 0 auto;
`;

const Form = styled.form`
  display: grid;
  gap: 20px;
`;

const FormGroup = styled.div`
  display: grid;
  gap: 10px;
`;

const Label = styled.label`
  font-weight: bold;
`;

const Input = styled.input`
  width: 100%;
  padding: 8px;
  border: 1px solid ${({ theme }) => theme.colors.border};
  border-radius: 5px;
  text-transform: initial;
`;

const CheckboxContainer = styled.div`
  display: flex;
  align-items: center;
`;

const Checkbox = styled.input`
  margin-right: 8px;
`;

const CheckboxLabel = styled.span`
  font-weight: bold;
  font-size: 1.2rem;
`;

const HulpmiddelenSection = styled.div`
  margin-top: 20px;
`;

const HulpmiddelItem = styled.div`
  display: flex;
  align-items: center;
  padding: 12px;
  border: 1px solid ${({ theme }) => theme.colors.border};
  border-radius: 5px;
  margin-bottom: 8px;
  transition: background-color 0.3s;

  &:hover {
    background-color: ${({ theme }) => theme.colors.hover};
  }

  ${Checkbox} {
    margin-right: 8px;
  }
`;

const AddHulpmiddelInput = styled.input`
  width: 100%;
  padding: 8px;
  border: 1px solid ${({ theme }) => theme.colors.border};
  border-radius: 5px;
  margin-top: 8px;
`;

const HulpmiddelenList = styled.div`
  display: grid;
  gap: 8px;
  grid-template-columns: repeat(auto-fit, minmax(120px, 1fr));
`;

const SaveButton = styled.button`
  background-color: ${({ theme }) => theme.colors.btn};
  color: ${({ theme }) => theme.colors.white};
  padding: 8px 16px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  position: absolute;
  bottom: 20px;
  right: 20px;

  &:hover {
    background-color: ${({ theme }) => theme.colors.shadow};
  }
`;

export default UserInfo;
