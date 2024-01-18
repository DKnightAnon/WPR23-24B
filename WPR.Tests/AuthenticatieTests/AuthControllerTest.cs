using WPR23_24B.Controllers;
using WPR23_24B.DTO;
using WPR23_24B.Models.Authenticatie;
using WPR23_24B.Services;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace WPR.Tests.AuthenticatieTests
{
    // Test class for testing the functionality of the AuthController class.
    public class AuthControllerTest
    {
        // This test method verifies the behavior of the SignIn action
        // when a valid model is provided.
        [Fact]
        public async Task SignIn_ValidModel_ReturnsOkResult()
        {
            // Arrange
            // Mock dependencies: AuthService, RolService, UserManager, and Logger
            var authServiceMock = new Mock<IAuthService>();
            var rolServiceMock = new Mock<IRolService>();
            var userManagerMock = MockUserManager<Gebruiker>();
            var loggerMock = new Mock<ILogger<AuthController>>();

            // Create an instance of AuthController with mocked dependencies
            var controller = new AuthController(authServiceMock.Object, rolServiceMock.Object, userManagerMock, loggerMock.Object);

            // Create a valid SignInDTO
            var signInDTO = new SignInDTO
            {
                Email = "test@example.com",
                Password = "Password2024/"
            };

            // Set up expected behavior for AuthService methods
            authServiceMock.Setup(service => service.SignInAsync(signInDTO)).ReturnsAsync(true);
            authServiceMock.Setup(service => service.GenerateJwtToken(It.IsAny<string>())).ReturnsAsync("fakeToken");

            // Set up expected behavior for RolService method
            rolServiceMock.Setup(service => service.GetUserRole(It.IsAny<Gebruiker>())).ReturnsAsync("UserRole");

            // Act
            // Call the SignIn action with the valid model
            var result = await controller.SignIn(signInDTO);

            // Assert
            // Verify that the action returns the expected OkObjectResult with correct properties
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Login Succesfull", okResult.Value.GetType().GetProperty("Message").GetValue(okResult.Value));
            Assert.Equal("fakeToken", okResult.Value.GetType().GetProperty("Token").GetValue(okResult.Value));
            Assert.Equal("UserRole", okResult.Value.GetType().GetProperty("UserRole").GetValue(okResult.Value));
        }

        // This test method checks the behavior of the SignIn action
        // when an invalid model is provided.
        [Fact]
        public async Task SignIn_InvalidModel_ReturnsBadRequest()
        {
            // Arrange
            // Mock dependencies: AuthService, RolService, UserManager, and Logger
            var authServiceMock = new Mock<IAuthService>();
            var rolServiceMock = new Mock<IRolService>();
            var userManagerMock = MockUserManager<Gebruiker>();
            var loggerMock = new Mock<ILogger<AuthController>>();

            // Create an instance of AuthController with mocked dependencies
            var controller = new AuthController(authServiceMock.Object, rolServiceMock.Object, userManagerMock, loggerMock.Object);

            // Simulate ModelState error by adding an error for the "Email" field
            controller.ModelState.AddModelError("Email", "Email is required");

            // Act
            // Call the SignIn action with an invalid model
            var result = await controller.SignIn(new SignInDTO());

            // Assert
            // Verify that the action returns a BadRequestObjectResult
            Assert.IsType<BadRequestObjectResult>(result);
        }

        // This test method examines the behavior of the SignIn action
        // when invalid credentials are provided.
        [Fact]
        public async Task SignIn_InvalidCredentials_ReturnsBadRequest()
        {
            // Arrange
            // Mock dependencies: AuthService, RolService, UserManager, and Logger
            var authServiceMock = new Mock<IAuthService>();
            var rolServiceMock = new Mock<IRolService>();
            var userManagerMock = MockUserManager<Gebruiker>();
            var loggerMock = new Mock<ILogger<AuthController>>();

            // Create an instance of AuthController with mocked dependencies
            var controller = new AuthController(authServiceMock.Object, rolServiceMock.Object, userManagerMock, loggerMock.Object);

            // Create a SignInDTO with incorrect password
            var signInDTO = new SignInDTO
            {
                Email = "test@example.com",
                Password = "incorrectpassword"
            };

            // Set up expected behavior for SignInAsync method
            authServiceMock.Setup(service => service.SignInAsync(signInDTO)).ReturnsAsync(false);

            // Act
            // Call the SignIn action with invalid credentials
            var result = await controller.SignIn(signInDTO);

            // Assert
            // Verify that the action returns a BadRequestObjectResult
            Assert.IsType<BadRequestObjectResult>(result);
        }

        // This test method validates the CheckRole action's behavior
        // when the userEmail is null or empty.
        [Fact]
        public async Task CheckRole_InvalidUserEmail_ReturnsBadRequest()
        {
            // Arrange
            // Mock dependencies: AuthService, RolService, UserManager, and Logger
            var authServiceMock = new Mock<IAuthService>();
            var rolServiceMock = new Mock<IRolService>();
            var userManagerMock = MockUserManager<Gebruiker>();
            var loggerMock = new Mock<ILogger<AuthController>>();

            // Create an instance of AuthController with mocked dependencies
            var controller = new AuthController(authServiceMock.Object, rolServiceMock.Object, userManagerMock, loggerMock.Object);

            // Act
            // Call the CheckRole action with userEmail as null
            var result = await controller.CheckRole(userEmail: null);

            // Assert
            // Verify that the action returns a BadRequestObjectResult
            Assert.IsType<BadRequestObjectResult>(result);
        }

        // This test method tests the CheckRole action's behavior
        // when the specified user is not found.
        [Fact]
        public async Task CheckRole_UserNotFound_ReturnsNotFound()
        {
            // Arrange
            // Mock dependencies: AuthService, RolService, UserManager, and Logger
            var authServiceMock = new Mock<IAuthService>();
            var rolServiceMock = new Mock<IRolService>();
            var userManagerMock = MockUserManager<Gebruiker>();
            var loggerMock = new Mock<ILogger<AuthController>>();

            // Create an instance of AuthController with mocked dependencies
            var controller = new AuthController(authServiceMock.Object, rolServiceMock.Object, userManagerMock, loggerMock.Object);

            // Act
            // Call the CheckRole action with a non-existent user
            var result = await controller.CheckRole(userEmail: "nonexistent@example.com");

            // Assert
            // Verify that the action returns a NotFoundObjectResult
            Assert.IsType<NotFoundObjectResult>(result);
        }

        // CheckRole action returns Ok with correct user role
        [Fact]
        public async Task CheckRole_ValidUser_ReturnsOkWithUserRole()
        {
            // Arrange
            // Mock dependencies: AuthService, RolService, UserManager, and Logger
            var authServiceMock = new Mock<IAuthService>();
            var rolServiceMock = new Mock<IRolService>();

            var userManagerMock = MockUserManager<Gebruiker>();
            var loggerMock = new Mock<ILogger<AuthController>>();

            // Create an instance of AuthController with mocked dependencies
            var controller = new AuthController(authServiceMock.Object, rolServiceMock.Object, userManagerMock, loggerMock.Object);

            // Define a user email for testing
            var userEmail = "existing@example.com";

            // Get the mock for UserManager<Gebruiker>
            var userManagerMockObject = Mock.Get(userManagerMock);

            // Set up FindByEmailAsync method to return a Gebruiker object with the specified email
            userManagerMockObject.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync((string email) =>
            {
                if (email == userEmail)
                {
                    return new Gebruiker { Email = userEmail };
                }
                return null;
            });

            // Set up GetUserRole method to return a role string
            rolServiceMock.Setup(service => service.GetUserRole(It.IsAny<Gebruiker>())).ReturnsAsync("UserRole");

            // Act
            // Call the CheckRole action with a valid user email
            var result = await controller.CheckRole(userEmail);

            // Assert
            // Verify that the action returns an OkObjectResult with correct properties
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(userEmail, okResult.Value.GetType().GetProperty("Email").GetValue(okResult.Value));
            Assert.Equal("UserRole", okResult.Value.GetType().GetProperty("Role").GetValue(okResult.Value));
        }

        // Helper method to mock UserManager<TUser>
        private static UserManager<TUser> MockUserManager<TUser>() where TUser : class
        {
            return TestUtilities.MockUserManager<TUser>().Object;
        }
    }
}