import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import AuthService from "../Authentication/AuthService";

// PrivateRoute is a higher-order component for handling private routes
const PrivateRoute = ({ element: Element, roles }) => {
  const navigate = useNavigate();
  const isAuthenticated = AuthService.isUserAuthenticated();
  const userRole = AuthService.getUserRole();

  useEffect(() => {
    // Redirect to login if not authenticated or user role doesn't match
    if (!isAuthenticated || (roles.length > 0 && !roles.includes(userRole))) {
      console.log("Redirecting to /login");
      navigate("/login");
    }
  }, [navigate, isAuthenticated, roles, userRole]);

  return isAuthenticated ? <Element /> : null;
};

export default PrivateRoute;
