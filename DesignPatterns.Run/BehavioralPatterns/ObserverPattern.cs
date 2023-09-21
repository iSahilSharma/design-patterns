using System;
using System.Collections.Generic;

namespace DesignPatterns.BehavioralPatterns.ObserverPattern
{
    // Step 1: Define the observer interface.
    public interface IInvestor
    {
        void Update(Stock stock);
    }

    // Step 2: Implement the concrete observer.
    public class Investor : IInvestor
    {
        private readonly string _name;

        public Investor(string name)
        {
            _name = name;
        }

        // Step 4: Update method is called when the stock price changes.
        public void Update(Stock stock)
        {
            Console.WriteLine($"Notified {_name} of price change in {stock.Symbol}: New price is {stock.Price}");
        }
    }

    // Step 3: Define the subject (observable).
    public class Stock
    {
        private readonly string _symbol;
        private double _price;
        private readonly List<IInvestor> _investors = new List<IInvestor>();

        public string Symbol => _symbol;
        public double Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    NotifyObservers(); // Step 5: Notify observers when the price changes.
                }
            }
        }

        public Stock(string symbol, double price)
        {
            _symbol = symbol;
            _price = price;
        }

        // Register an investor as an observer.
        public void RegisterInvestor(IInvestor investor)
        {
            _investors.Add(investor);
        }

        // Deregister an investor.
        public void DeregisterInvestor(IInvestor investor)
        {
            _investors.Remove(investor);
        }

        // Notify all observers (investors).
        private void NotifyObservers()
        {
            foreach (var investor in _investors)
            {
                investor.Update(this);
            }
        }
    }

    public class TestStock
    {
        public void EntryPoint()
        {
            // Create a stock instance.
            Stock appleStock = new Stock("AAPL", 3000.0);

            // Create and register investors.
            IInvestor investor1 = new Investor("John");
            appleStock.RegisterInvestor(investor1);

            IInvestor investor2 = new Investor("Bob");
            appleStock.RegisterInvestor(investor2);

            // Simulate price changes.
            appleStock.Price = 3001.25;
            appleStock.Price = 3005.12;
        }
    }
}
