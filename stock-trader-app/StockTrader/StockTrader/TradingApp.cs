using System;
using System.Net;

namespace stockTrader
{

  internal class TradingApp
  {
        private readonly Trader _trader;
        private readonly Logger _logger;
        
    public static void Main(string[] args)
    {


        Logger logger = new Logger();
        RemoteURLReader remoteURLReader = new RemoteURLReader();
        StockAPIService stockAPIService = new StockAPIService(remoteURLReader);
        Trader trader = new Trader(stockAPIService, logger);

        TradingApp app = new TradingApp(trader, logger);
        app.Start();
    }

    public TradingApp(Trader trader, Logger logger)
    {
        _trader = trader;
        _logger = logger;
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
		    bool purchased = _trader.Buy(symbol, price);
		    if (purchased) {
			    _logger.Log("Purchased stock!");
		    }
		    else {
			    _logger.Log("Couldn't buy the stock at that price.");
		    }
	    } catch (Exception e) {
		    _logger.Log("There was an error while attempting to buy the stock: " + e.Message);
	    }
        Console.ReadLine();
    }
  }
}