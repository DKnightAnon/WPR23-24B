using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Moq;
using WPR23_24B.Models.Authenticatie;
using WPR23_24B.Services;
using Xunit;

namespace WPR.Tests
{
    // Test class for testing the functionality of the RolService class.
    public class RolServiceTest
    {
        // Test case for GetUserRole method when the user has roles.
        [Fact]
        public async Task GetUserRole_UserExists_ReturnsUserRole()
        {
            // Arrange
            var roleManagerMock = MockRoleManager();
            var userManagerMock = MockUserManager<Gebruiker>();

            var rolService = new RolService(roleManagerMock.Object, userManagerMock.Object);

            // Create a user with roles
            var user = new Gebruiker();
            userManagerMock.Setup(um => um.GetRolesAsync(user)).ReturnsAsync(new List<string> { "Admin" });

            // Act
            var result = await rolService.GetUserRole(user);

            // Assert
            // Ensure that the expected role is returned
            Assert.Equal("Admin", result);
        }

        // Test case for GetUserRole method when the user has no roles.
        [Fact]
        public async Task GetUserRole_UserHasNoRoles_ReturnsNull()
        {
            // Arrange
            var roleManagerMock = MockRoleManager();
            var userManagerMock = MockUserManager<Gebruiker>();

            var rolService = new RolService(roleManagerMock.Object, userManagerMock.Object);

            // Create a user with no roles
            var user = new Gebruiker();
            userManagerMock.Setup(um => um.GetRolesAsync(user)).ReturnsAsync(new List<string>());

            // Act
            var result = await rolService.GetUserRole(user);

            // Assert
            // Ensure that null is returned when the user has no roles
            Assert.Null(result);
        }

        // Helper method to mock RoleManager<IdentityRole>.
        // <returns> A Mock of RoleManager<IdentityRole>.
        private static Mock<RoleManager<IdentityRole>> MockRoleManager()
        {
            // Mock IRoleStore<IdentityRole>
            var roleStoreMock = new Mock<IRoleStore<IdentityRole>>();
            // Mock RoleManager<IdentityRole> with the mocked role store and other necessary parameters
            var roleManagerMock = new Mock<RoleManager<IdentityRole>>(roleStoreMock.Object, null, null, null, null);

            // Mock the RoleManager methods for role existence and creation
            foreach (var roleName in new List<string> { "Admin", "Ervaringsdeskundige", "Bedrijf" })
            {
                roleManagerMock.Setup(rm => rm.RoleExistsAsync(roleName)).ReturnsAsync(false);
                roleManagerMock.Setup(rm => rm.CreateAsync(It.IsAny<IdentityRole>())).ReturnsAsync(IdentityResult.Success);
            }

            return roleManagerMock;
        }

        // Helper method to mock UserManager<TUser>.
        // <typeparam name="TUser">Type of the user.</typeparam>
        // <returns>A Mock of UserManager<TUser>.</returns>
        private static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            // Mock IUserStore<TUser>
            var store = new Mock<IUserStore<TUser>>();

            // Mock UserManager<TUser> with the mocked user store and other necessary parameters
            var userManagerMock = new Mock<UserManager<TUser>>(
                store.Object, null, null, null, null, null, null, null, null);

            return userManagerMock;
        }
    }
}


// Test case for InitializeRoles method
// [Fact]
// public async Task InitializeRoles_RolesDoNotExist_CreatesRoles()
// {
//     // Arrange
//     var roleManagerMock = MockRoleManager();
//     var userManagerMock = MockUserManager<Gebruiker>();

//     var rolService = new RolService(roleManagerMock.Object, userManagerMock.Object);

//     // Act
//     await rolService.InitializeRoles();

//     // Assert
//     foreach (var roleName in new List<string> { "Admin", "Ervaringsdeskundige", "Bedrijf" })
//     {
//         roleManagerMock.Verify(rm => rm.RoleExistsAsync(roleName), Times.Once);
//         roleManagerMock.Verify(rm => rm.CreateAsync(It.IsAny<IdentityRole>()), Times.Exactly(1)); // Ensure exactly one call for each role
//     }
// }