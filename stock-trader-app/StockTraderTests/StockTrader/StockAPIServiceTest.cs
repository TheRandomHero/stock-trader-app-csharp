using NUnit.Framework;
using NSubstitute;
using System;

namespace stockTrader
{
    public class StockAPIServiceTest
    {

        private readonly string apipath = "https://financialmodelingprep.com/api/v3/stock/real-time-price/{0}";
        private StockAPIService stockAPIService;
        private RemoteURLReader remoteURLReader;

        [SetUp]
        public void SetUp()
        {
            remoteURLReader = Substitute.For<RemoteURLReader>();
            stockAPIService = new StockAPIService(remoteURLReader);
        }

        [Test] // everything works
        public void TestGetPriceNormalValues()
        {
            remoteURLReader.ReadFromUrl(String.Format(apipath, "ibm")).Returns("{\n    \"symbol\": \"ibm\",\n    \"price\": 123\n}");
            Assert.AreEqual(123.0d, stockAPIService.GetPrice("ibm"));
        }

        [Test] // readFromURL threw an exception
        public void TestGetPriceServerDown()
        {
        }

        [Test] // readFromURL returned wrong JSON
        public void TestGetPriceMalformedResponse() 
        {
        }
    }
}