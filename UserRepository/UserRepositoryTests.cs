using System;
using System.Threading.Tasks;
using CRUD.Domain.Models;
using CRUD.Services.Interfaces;
using CRUD.Services.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Moq;
using CRUD.Data.MySQL.Data;

namespace CRUD.Tests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        [Test]
        public async Task UserAdd_ValidModel_ShouldAddUserToDatabase()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ProductContext>()
       .UseInMemoryDatabase(databaseName: "UserAdd_ValidModel_ShouldAddUserToDatabase")
       .EnableSensitiveDataLogging()
       .Options;

            using (var context = new ProductContext(dbContextOptions))
            {
                var validatorMock = new Mock<IValidator<Users>>();
                validatorMock.Setup(v => v.Validate(It.IsAny<Users>())).Returns(new FluentValidation.Results.ValidationResult());

                var userRepository = new UserRepository(context, validatorMock.Object);

                // Act
                var userModel = new Users
                {
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

                await userRepository.UserAdd(userModel);

                // Assert
                var userFromDb = await context.Users.FirstOrDefaultAsync(u => u.Email == userModel.Email);
                Assert.IsNotNull(userFromDb);
                Assert.AreEqual(userModel.Name, userFromDb.Name);
                Assert.AreEqual(userModel.Email, userFromDb.Email);
            }
        }

        // Add more test methods as needed for other scenarios
    }
}
