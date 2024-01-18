using Microsoft.AspNetCore.Identity;
using Moq;
using System.Collections.Generic;

namespace WPR.Tests
{
    public static class TestUtilities
    {
        // Helper method to mock UserManager<TUser>.
        // <typeparam name="TUser">Type of the user.</typeparam>
        // <returns>A Mock of UserManager<TUser>.</returns>
        public static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            // Mock IUserStore<TUser>
            var store = new Mock<IUserStore<TUser>>();

            // Mock UserManager<TUser> with the mocked user store and other necessary parameters
            var userManagerMock = new Mock<UserManager<TUser>>(
                store.Object, null, null, null, null, null, null, null, null);

            return userManagerMock;
        }

        // Helper method to mock RoleManager<IdentityRole>.
        // <returns> A Mock of RoleManager<IdentityRole>.
        public static Mock<RoleManager<IdentityRole>> MockRoleManager()
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
    }
}
