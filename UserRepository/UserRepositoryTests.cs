using System.Threading.Tasks;
using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using CRUD_Operation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CRUD.Tests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private UsersController _usersController;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IEmailSender> _emailSenderMock;

        [SetUp]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _emailSenderMock = new Mock<IEmailSender>();
            _usersController = new UsersController(_userRepositoryMock.Object, _emailSenderMock.Object);
        }

        [Test]
        public async Task CreateCustomer_ValidUser_ReturnsOk()
        {
            // Arrange
            var validUser = new Users
            {
                UserId = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Password = "password123",
                IsActive = false,
                AddressLine1 = "123 Main St",
                AddressLine2 = "Apt 4B",
                Country = "USA",
                County = "Some County",
                CreatedBy = "Admin",
                PhoneNumber = "555-1234",
                UpdatedBy = "Admin"
            };

            _userRepositoryMock.Setup(r => r.UserAdd(validUser));
            _emailSenderMock.Setup(e => e.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            // Act
            var result = _usersController.CreateCustomer(validUser);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task GetById_ValidId_ReturnsUser()
        {
            // Arrange
            var userId = 1;
            var user = new Users
            {
                UserId = userId,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Password = "password123",
                IsActive = false,
                AddressLine1 = "123 Main St",
                AddressLine2 = "Apt 4B",
                Country = "USA",
                County = "Some County",
                CreatedBy = "Admin",
                PhoneNumber = "555-1234",
                UpdatedBy = "Admin"
            };

            _userRepositoryMock.Setup(r => r.GetById(userId)).Returns(user);

            // Act
            var result = _usersController.GetById(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = (OkObjectResult)result;
            var resultUser = (Users)okResult.Value;

            Assert.AreEqual(userId, resultUser.UserId);
            Assert.AreEqual(user.Name, resultUser.Name);
            Assert.AreEqual(user.Email, resultUser.Email);
            Assert.AreEqual(user.Password, resultUser.Password);
            Assert.AreEqual(user.IsActive, resultUser.IsActive);
            Assert.AreEqual(user.AddressLine1, resultUser.AddressLine1);
            Assert.AreEqual(user.AddressLine2, resultUser.AddressLine2);
            Assert.AreEqual(user.Country, resultUser.Country);
            Assert.AreEqual(user.County, resultUser.County);
            Assert.AreEqual(user.CreatedBy, resultUser.CreatedBy);
            Assert.AreEqual(user.PhoneNumber, resultUser.PhoneNumber);
            Assert.AreEqual(user.UpdatedBy, resultUser.UpdatedBy);
            Assert.AreEqual(user.CreatedDate, resultUser.CreatedDate);
            Assert.AreEqual(user.UpdatedDate, resultUser.UpdatedDate);

        }

        [Test]
        public async Task ActivateAccount_ExistingEmail_ReturnsOk()
        {
            // Arrange
            var userEmail = "john.doe@example.com";
            var existingUser = new Users
            {
                UserId = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Password = "password123",
                IsActive = false,
                AddressLine1 = "123 Main St",
                AddressLine2 = "Apt 4B",
                Country = "USA",
                County = "Some County",
                CreatedBy = "Admin",
                PhoneNumber = "555-1234",
                UpdatedBy = "Admin"
            };

            _userRepositoryMock.Setup(r => r.GetUserByEmail(userEmail)).Returns(existingUser);
            _userRepositoryMock.Setup(r => r.UpdateUser(existingUser));

            // Act
            var result = await _usersController.ActivateAccount(userEmail);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = (OkObjectResult)result;
            var resultData = okResult.Value;



        }


    }
}
