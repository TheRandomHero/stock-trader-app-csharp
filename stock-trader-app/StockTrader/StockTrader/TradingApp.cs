using System;
using System.Net;

namespace stockTrader
{

  internal class TradingApp
  {
        public StockAPIService stockAPIService;
        public Trader trader;
        public Logger logger;
        public RemoteURLReader remoteReader;
        
        public void setUp()
        {
            logger = new Logger();
            remoteReader = new RemoteURLReader(new WebClient());
            stockAPIService = new StockAPIService("https://financialmodelingprep.com/api/v3/stock/real-time-price/{0}", remoteReader);
            trader = new Trader(stockAPIService, logger);

        }
    public static void Main(string[] args)
    {
	    TradingApp app = new TradingApp();
            app.setUp();
            app.Start();
    }

    public void Start()
    {
	    Console.WriteLine("Enter a stock symbol (for example aapl):");
	    string symbol = Console.ReadLine();
	    Console.WriteLine("Enter the maximum price you are willing to pay: ");
	    double price;
	    while (!double.TryParse(Console.ReadLine(), out price))
	    {
		    Console.WriteLine("Please enter a number.");
	    }
	    
	    try {
		    bool purchased = trader.Buy(symbol, price);
		    if (purchased) {
			    logger.Log("Purchased stock!");
		    }
		    else {
			    logger.Log("Couldn't buy the stock at that price.");
		    }
	    } catch (Exception e) {
		    logger.Log("There was an error while attempting to buy the stock: " + e.Message);
	    }
        Console.ReadLine();
    }
  }
}