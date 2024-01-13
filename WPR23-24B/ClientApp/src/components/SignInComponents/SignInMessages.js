import React from "react";
import styled from "styled-components";

const MessageWrapper = styled.div`
  margin-bottom: 1.5rem;
  padding: 1rem;
  border-radius: 8px;
  font-size: 1.5rem;
  background-color: ${({ type }) => (type === "error" ? "#FFCCCC" : "#CCFFCC")};
  color: ${({ type }) => (type === "error" ? "#FF0000" : "#008000")};
`;

const SignInMessages = ({ type, message }) => {
  const role = type === "error" ? "alert" : "status";
  const ariaLive = type === "error" ? "assertive" : "polite";

  return (
    <MessageWrapper role={role} aria-live={ariaLive} type={type}>
      {message}
    </MessageWrapper>
  );
};

export default SignInMessages;
