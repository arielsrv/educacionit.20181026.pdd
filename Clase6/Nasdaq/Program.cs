using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasdaq
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock goog = new Stock("GOOG");
            goog.SetPrice(100.0);

            Investor Juan = new Investor(nameof(Juan));
            Investor Maria = new Investor(nameof(Maria));

            goog.Add(Juan);
            goog.Add(Maria);

            goog.SetPrice(100.0);
            goog.SetPrice(101.0);
            goog.SetPrice(101.5);
            goog.SetPrice(90.0);
            goog.SetPrice(89.9);

        }
    }

    class Stock
    {
        private string name;
        private double price;
        private List<Investor> investors = new List<Investor>();

        public void Add(Investor investor)
        {
            this.investors.Add(investor);
        }

        public void Remove(Investor investor)
        {
            this.investors.Remove(investor);
        }

        public Stock(string name)
        {
            this.name = name;
        }

        public void SetPrice(double price)
        {
            this.price = price;
            Notify();
        }

        private void Notify()
        {
            foreach (Investor investor in investors)
            {
                investor.Update(this.price);
            }
        }
    }

    interface IInvestor
    {
        void Update(double price);
    }

    class Investor : IInvestor
    {
        private string name;
        private double price;

        public Investor(string name)
        {
            this.name = name;
        }

        public void Update(double price)
        {
            this.price = price;
            Console.WriteLine($"Current price is: {this.price}");
        }
    }
}
