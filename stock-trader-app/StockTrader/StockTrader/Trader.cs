namespace stockTrader
{
    public class Trader
    {

        private readonly StockAPIService _stockApiService;
        private Logger _logger;

        public Trader(StockAPIService stockApiService, Logger logger)
        {
            _stockApiService = stockApiService;
            _logger = logger;
        }
        
        /// <summary>
        /// Checks the price of a stock, and buys it if the price is not greater than the bid amount.
        /// </summary>
        /// <param name="symbol">the symbol to buy, e.g. aapl</param>
        /// <param name="bid">the bid amount</param>
        /// <returns>whether any stock was bought</returns>
        public bool Buy(string symbol, double bid) 
        {
            double price = _stockApiService.GetPrice(symbol);
            bool result;
            if (price <= bid) {
                result = true;
                _stockApiService.Buy(symbol);
                _logger.Log("Purchased " + symbol + " stock at $" + bid + ", since its higher that the current price ($" + price + ")");
            }
            else {
                _logger.Log("Bid for " + symbol + " was $" + bid + " but the stock price is $" + price + ", no purchase was made.");
                result = false;
            }
            return result;
    }
        
    }
}