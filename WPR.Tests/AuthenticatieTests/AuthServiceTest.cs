using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPR23_24B.Controllers;
using WPR23_24B.DTO;
using WPR23_24B.Models.Authenticatie;
using WPR23_24B.Services;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WPR.Tests.AuthenticatieTests
{
    // Test class for testing the functionality of the AuthService class.
    public class AuthServiceTest
    {
        // Test case for SignInAsync method when user credentials are valid
        [Fact]
        public async Task SignInAsync_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            var userManagerMock = MockUserManager<Gebruiker>();
            var configurationMock = new Mock<IConfiguration>();
            var loggerMock = new Mock<ILogger<AuthService>>();
            var roleManagerMock = MockRoleManager();
            var rolServiceMock = new Mock<IRolService>();

            var authService = new AuthService(
                userManagerMock.Object,
                configurationMock.Object,
                loggerMock.Object,
                roleManagerMock.Object,
                rolServiceMock.Object);

            var signInDTO = new SignInDTO
            {
                Email = "test@example.com",
                Password = "ValidPassword123!"
            };

            userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(new Gebruiker());
            userManagerMock.Setup(um => um.CheckPasswordAsync(It.IsAny<Gebruiker>(), It.IsAny<string>())).ReturnsAsync(true);

            // Act
            var result = await authService.SignInAsync(signInDTO);

            // Assert
            Assert.True(result);
        }

        // Test case for SignInAsync method when user is not found
        [Fact]
        public async Task SignInAsync_UserNotFound_ReturnsFalse()
        {
            // Arrange
            var userManagerMock = MockUserManager<Gebruiker>();
            var configurationMock = new Mock<IConfiguration>();
            var loggerMock = new Mock<ILogger<AuthService>>();
            var roleManagerMock = MockRoleManager();
            var rolServiceMock = new Mock<IRolService>();

            var authService = new AuthService(
                userManagerMock.Object,
                configurationMock.Object,
                loggerMock.Object,
                roleManagerMock.Object,
                rolServiceMock.Object);

            var signInDTO = new SignInDTO
            {
                Email = "nonexistent@example.com",
                Password = "InvalidPassword123!"
            };

            userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync((Gebruiker)null);

            // Act
            var result = await authService.SignInAsync(signInDTO);

            // Assert
            Assert.False(result);
        }

        // Test case for SignInAsync method when password is invalid
        [Fact]
        public async Task SignInAsync_InvalidPassword_ReturnsFalse()
        {
            // Arrange
            var userManagerMock = MockUserManager<Gebruiker>();
            var configurationMock = new Mock<IConfiguration>();
            var loggerMock = new Mock<ILogger<AuthService>>();
            var roleManagerMock = MockRoleManager();
            var rolServiceMock = new Mock<IRolService>();

            var authService = new AuthService(
                userManagerMock.Object,
                configurationMock.Object,
                loggerMock.Object,
                roleManagerMock.Object,
                rolServiceMock.Object);

            var signInDTO = new SignInDTO
            {
                Email = "test@example.com",
                Password = "InvalidPassword123!"
            };

            userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(new Gebruiker());
            userManagerMock.Setup(um => um.CheckPasswordAsync(It.IsAny<Gebruiker>(), It.IsAny<string>())).ReturnsAsync(false);

            // Act
            var result = await authService.SignInAsync(signInDTO);

            // Assert
            Assert.False(result);
        }

        // Test case for GenerateJwtToken method
        [Fact]
        public async Task GenerateJwtToken_ReturnsValidToken()
        {
            // Arrange
            var userManagerMock = MockUserManager<Gebruiker>();
            var configurationMock = new Mock<IConfiguration>();
            var loggerMock = new Mock<ILogger<AuthService>>();
            var roleManagerMock = MockRoleManager();
            var rolServiceMock = new Mock<IRolService>();

            var authService = new AuthService(
                userManagerMock.Object,
                configurationMock.Object,
                loggerMock.Object,
                roleManagerMock.Object,
                rolServiceMock.Object);

            string userEmail = "test@example.com";

            // Set up FindByEmailAsync method
            userManagerMock.
                Setup(um => um.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(new Gebruiker 
                { 
                    Email = userEmail, 
                    UserName = "username",
                    Id = Guid.NewGuid().ToString(),
                
                });

            // Set up GetUserRole method
            rolServiceMock.Setup(service => service.GetUserRole(It.IsAny<Gebruiker>())).ReturnsAsync("UserRole");

            // Set up IConfiguration values
            configurationMock.SetupGet(c => c["Jwt:Key"]).Returns("mySecretKeyWithMinimum128Bits");
            configurationMock.SetupGet(c => c["Jwt:Issuer"]).Returns("myIssuer");
            configurationMock.SetupGet(c => c["Jwt:Audience"]).Returns("myAudience");

            // Act
            var token = await authService.GenerateJwtToken("test@example.com");
            Console.WriteLine($"token value = {token}");

            // Assert
            // Token decoding can be verified if needed
            Assert.NotNull(token);
        }

        // Helper method to mock UserManager<TUser>
        private static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var userManagerMock = new Mock<UserManager<TUser>>(
                store.Object, null, null, null, null, null, null, null, null);

            return userManagerMock;
        }

        // Helper method to mock RoleManager<IdentityRole>
        private static Mock<RoleManager<IdentityRole>> MockRoleManager()
        {
            var roleStoreMock = new Mock<IRoleStore<IdentityRole>>();
            var roleManagerMock = new Mock<RoleManager<IdentityRole>>(roleStoreMock.Object, null, null, null, null);

            return roleManagerMock;
        }
    }
}