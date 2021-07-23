using AuthorizationPortfolioManagement.Controllers;
using AuthorizationPortfolioManagement.Models;
using AuthorizationPortfolioManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AuthorizationPortfolioManagementTest
{
    public class Tests
    {
        List<Customer> loginDetails;
        Mock<IAuthorizationRepository> mockSet;
        Mock<IConfiguration> config;

        [SetUp]
        public void Setup()
        {
            loginDetails = new List<Customer>()
            {
               new Customer { CustomerId = 1,
                CustomerAddress1 = "Gaur Atulyam",
                CustomerAddress2 = "Pari Chowk",
                CustomerCity = "Noida",
                CustomerName = "Aryan Khandelwal",
                Age = 22,
                Username = "ryan3142",
                Password = "Aryan@3142"
               }
            };
            mockSet = new Mock<IAuthorizationRepository>();
            config = new Mock<IConfiguration>();
            mockSet.Setup(p => p.CheckCredentials(new LoginModel { Username="ryan3142", Password="Aryan@3142"})).Returns(loginDetails[0]);  
            config.Setup(p => p["Jwt:Key"]).Returns("SecretAuthenticationKey");
            config.Setup(p => p["Jwt:Issuer"]).Returns("https://localhost:44316");
        }

        #region Repository Functions Testing
        [Test]
        public void GenerateJSONWebToken_ValidCustomer_ReturnsToken()
        {
            AuthorizationRepository repo = new AuthorizationRepository();
            config.Setup(p => p["Jwt:Key"]).Returns("SecretAuthenticationKey");
            config.Setup(p => p["Jwr:Issuer"]).Returns("https://localhost:44316");
            mockSet.Setup(m => m.GenerateToken(config.Object, loginDetails[0]));

            var data = repo.GenerateToken(config.Object, loginDetails[0]);

            Assert.IsNotNull(data);
            Assert.AreEqual("string".GetType(), data.GetType());
        
        }

        [Test]
        public void GenerateJSONWebToken_InvalidCustomer_ThrowsException()
        {
            AuthorizationRepository repo = new AuthorizationRepository();
            config.Setup(p => p["Jwt:Key"]).Returns("SecretAuthenticationKey");
            config.Setup(p => p["Jwr:Issuer"]).Returns("https://localhost:44316");
            mockSet.Setup(m => m.GenerateToken(config.Object, loginDetails[0]));

            var exceptionMessage = Assert.Throws<NullReferenceException>(() => repo.GenerateToken(config.Object, null));

            Assert.AreEqual("Object reference not set to an instance of an object.", exceptionMessage.Message);
        }

        #endregion

        #region Auth Controller Testing

        [Test]
        public void AuthControllerLogin_ValidData_ReturnsOk()
        {           
            mockSet.Setup(m => m.GenerateToken(config.Object, loginDetails[0]));
            AuthController auth = new AuthController(config.Object, mockSet.Object);
            var data = auth.Login(new LoginModel { Username = "ryan3142", Password = "Aryan@3142" });        
            Assert.IsNotNull(data);
            Assert.IsInstanceOf<OkObjectResult>(data);
        }

        [Test]
        public void AuthControllerLogin_InvalidInput_ReturnsUnAuthorized()
        {
            config.Setup(p => p["Jwt:Key"]).Returns("SecretAuthenticationKey");
            config.Setup(p => p["Jwr:Issuer"]).Returns("https://localhost:44316");
            mockSet.Setup(m => m.GenerateToken(config.Object, loginDetails[0]));

            AuthController auth = new AuthController(config.Object, mockSet.Object);
            var data = auth.Login(new LoginModel { Username = "abctestUsername", Password = "abctestPassword" });
            Assert.IsInstanceOf<UnauthorizedObjectResult>(data);
        }

        [Test]
        public void AuthControllerLogin_InvalidInput_ReturnsBadRequest()
        {
            config.Setup(p => p["Jwt:Key"]).Returns("SecretAuthenticationKey");
            config.Setup(p => p["Jwr:Issuer"]).Returns("https://localhost:44316");
            mockSet.Setup(m => m.GenerateToken(config.Object, loginDetails[0]));

            AuthController auth = new AuthController(config.Object, mockSet.Object);
            var data = auth.Login(null);
            Assert.IsInstanceOf<BadRequestResult>(data);
        }

        #endregion
    }
}