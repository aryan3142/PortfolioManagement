using Microsoft.AspNetCore.Mvc;
using Moq;
using MutualFund.Loggers;
using MutualFund.Models;
using MutualFund.Repository;
using MutualFundNav.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace TestMutualFundServie
{
    public class Tests
    {
        List<MutualFundDetails> mutualFunds = new List<MutualFundDetails>();
        private readonly MutualFundNavController mutualFundNavController;
        private readonly Mock<ILoggerManager> mockLogger = new Mock<ILoggerManager>();
        private readonly Mock<IMutualFundRepository> mockRepository = new Mock<IMutualFundRepository>();
        public Tests()
        {
            mutualFundNavController = new MutualFundNavController(mockRepository.Object, mockLogger.Object);
        }


        [SetUp]
        public void Setup()
        {
            mutualFunds = new List<MutualFundDetails>
            {
                new MutualFundDetails{ MutualFundId = 1,MutualFundName="HDFC", MutualFundValue = 10},
                new MutualFundDetails{ MutualFundId= 2, MutualFundName="ICICI" , MutualFundValue = 20}
            };
            mockRepository.Setup(x => x.GetMutualFund(It.IsAny<string>())).Returns((string s) => mutualFunds.FirstOrDefault(x => x.MutualFundName.Equals(s)));
        }

        [Test]
        public void GetDailyStockDetail_ValidStockName_returns_Ok()
        {
            var mutualFund = mutualFundNavController.GetMutualFundDetail("HDFC");
            ObjectResult result = mutualFund as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void GetDailyStockDetail_InValidStockName_returns_BadRequest()
        {
            var mutualFund = mutualFundNavController.GetMutualFundDetail("");
            Assert.IsInstanceOf<BadRequestResult>(mutualFund);
        }

        [Test]
        public void GetDailyStockDetail_InValidStockName_returns_NoContent()
        {
            var mutualFund = mutualFundNavController.GetMutualFundDetail("Nerolac");
            Assert.IsInstanceOf<NoContentResult>(mutualFund);
        }
    }
}