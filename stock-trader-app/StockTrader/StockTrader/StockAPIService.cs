using System;
using Newtonsoft.Json.Linq;

namespace stockTrader
{
    /// <summary>
    /// Stock price service that gets prices from a remote API
    /// </summary>
    public class StockAPIService {

        private string apiPath;
        private RemoteURLReader _remoteURLReader;

        public StockAPIService(string path, RemoteURLReader remoteURLReader)
        {
            apiPath = path;
            _remoteURLReader = remoteURLReader;
        }
	
        /// <summary>
        /// Get stock price from iex
        /// </summary>
        /// <param name="symbol">symbol Stock symbol, for example "aapl"</param>
        /// <returns>the stock price</returns>
        public double GetPrice(string symbol) {
            string url = String.Format(apiPath, symbol);
            string result = _remoteURLReader.ReadFromUrl(url);
            var json = JObject.Parse(result);
            string price = json.GetValue("price").ToString();
            return double.Parse(price);
    }
	
    /// <summary>
    /// Buys a share of the given stock at the current price. Returns false if the purchase fails 
    /// </summary>
    public bool Buy(string symbol) {
        // Stub. No need to implement this.
        return true;
    }
}
}