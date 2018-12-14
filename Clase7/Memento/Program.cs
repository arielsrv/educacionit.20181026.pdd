using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historia
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            customer.Name = "Juan";

            History history = customer.Save();
            customer.Name = "Maria";

            customer.Restore(history);
        }
    }

    class Customer
    {
        public string Name { get; set; }  

        public History Save()
        {
            return new History(Name);
        }

        public void Restore(History history)
        {
            this.Name = history.Name;
        }
    }

    class History
    {
        string name;

        public History(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }
    }
}