using System;
using NUnit.Framework;
using NSubstitute;
using stock_trader_app_DI_csharp.StockTrader;

namespace stockTrader
{
    [TestFixture]
    public class TraderTests
    {
        private StockAPIService stockAPIService;
        private Logger logger;
        private Trader trader;

        [SetUp]
        public void Setup()
        {
            stockAPIService = Substitute.For<StockAPIService>(new RemoteURLReader());
            stockAPIService.GetPrice(Arg.Any<string>()).Returns(150);
            logger = Substitute.For<Logger>();
            trader = new Trader(stockAPIService, logger);
        }
        [Test] // Bid was lower than price, Buy() should return false.
        public void TestBidLowerThanPrice()
        {
            var result = trader.Buy("aapl", 50);
            Assert.IsFalse(result);
        }

        [Test] // bid was equal or higher than price, Buy() should return true.
        public void TestBidHigherThanPrice()
        {
            var result = trader.Buy("ibm", 355);
            Assert.IsTrue(result);
        }
    }
}