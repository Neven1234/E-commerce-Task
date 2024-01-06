using DomainLayer.Dto;
using DomainLayer.Models;
using E_CommerceAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using RepositoryLayer;
using ServiceLayer.Implementation;
using ServiceLayer.Interface;
using ServiceLayer.Options;

namespace ASPUnitTest
{
    public class UserServiceTest
    {

        [Fact]
        public async void LogIn_WithWrongUsername_ShouldReturnNull()
        {
            //Arrange
            DbContextOptionsBuilder<DbContext> optionsBuilder = new DbContextOptionsBuilder<DbContext>();
            optionsBuilder.UseInMemoryDatabase("TestDb");
            AppDbContext dbContext = new AppDbContext(optionsBuilder.Options);
            Repository<User, int> repository = new Repository<User, int>(dbContext);
            Mock<IOptions<JWTOptions>> mock = new Mock<IOptions<JWTOptions>>();
            JWTOptions jWTOptions = new JWTOptions
            {
                SecretKey = "JWTAuthericationHIGHsecuredPasswordVVVVp10H",
                ValidIssuer = "http://localhost:5107",
                ValidAudience = "http://localhost:4200"
            };
            mock.Setup(o => o.Value).Returns(jWTOptions);

            UserServices sut = new UserServices(repository, mock.Object);


            UserLoginDTO userLoginDTO = new UserLoginDTO
            {
                Username = "Test",
                Password = "Test"
            };

            //Act
            var result = await sut.LoginAsync(userLoginDTO.Username, userLoginDTO.Password);
            //Assert
            Assert.Null(result);

        }

    }
}