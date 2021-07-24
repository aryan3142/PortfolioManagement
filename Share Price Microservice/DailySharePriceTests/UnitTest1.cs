using DailySharePriceMS.Models;
using NUnit.Framework;
using System.Collections.Generic;
using DailySharePriceMS.Repository;
using DailySharePriceMS.Controllers;
using DailySharePriceMS.Loggers;
using Moq;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DailySharePriceTests
{
    public class Tests
    {
        List<DailyStockDetails> stocks = new List<DailyStockDetails>();
        private readonly DailySharePriceController dailySharePriceController;
        private readonly Mock<ILoggerManager> mockLogger = new Mock<ILoggerManager>();
        private readonly Mock<IStockRepository> mockRepository = new Mock<IStockRepository>();
        public Tests()
        {
            dailySharePriceController = new DailySharePriceController(mockRepository.Object,mockLogger.Object);
        }


        [SetUp]
        public void Setup()
        {
            stocks = new List<DailyStockDetails>()
            {
                new DailyStockDetails{ StockId=1, StockName="ABC", StockValue=1},
                new DailyStockDetails{ StockId=2, StockName="APP", StockValue=2}
            };
            mockRepository.Setup(x => x.GetDailyShare(It.IsAny<string>())).Returns((string s) => stocks.FirstOrDefault(x => x.StockName.Equals(s)));           
        }
        
        [Test]
        public void GetDailyStockDetail_ValidStockName_returns_Ok()
        {
            var stock = dailySharePriceController.GetStockDetail("ABC");
            ObjectResult result = stock as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void GetDailyStockDetail_InValidStockName_returns_BadRequest()
        {
            var stock = dailySharePriceController.GetStockDetail("");
            Assert.IsInstanceOf<BadRequestResult>(stock);
        }

        [Test]
        public void GetDailyStockDetail_InValidStockName_returns_NoContent()
        {
            var stock = dailySharePriceController.GetStockDetail("BitCoin");
            Assert.IsInstanceOf<NoContentResult>(stock);
        }

    }
}