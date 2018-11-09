using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprobadoresDeCreditos
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount = 500;

            Approver employee = new Employee();
            Approver supervisor = new Supervisor();
            Approver manager = new Manager();
            Approver director = new Director();

            employee.SetNext(supervisor);
            supervisor.SetNext(manager);
            manager.SetNext(director);

            employee.HandleRequest(amount);
        }
    }

    abstract class Approver
    {
        protected Approver next;

        public void SetNext(Approver next)
        {
            this.next = next;
        }

        public abstract void HandleRequest(double amount);
    }

    class Employee : Approver
    {
        public override void HandleRequest(double amount)
        {
            if ((amount > 0) && (amount < 1000))
            {
                Console.WriteLine($"Approve by {this.GetType().Name}");
            }
            else
            {
                this.next.HandleRequest(amount);
            }
        }
    }

    class Supervisor : Approver
    {
        public override void HandleRequest(double amount)
        {
            if ((amount > 1000) && (amount < 10000))
            {
                Console.WriteLine($"Approve by {this.GetType().Name}");
            }
            else
            {
                this.next.HandleRequest(amount);
            }
        }
    }

    class Manager : Approver
    {
        public override void HandleRequest(double amount)
        {
            if ((amount > 10000) && (amount < 500000))
            {
                Console.WriteLine($"Approve by {this.GetType().Name}");
            }
            else
            {
                this.next.HandleRequest(amount);
            }
        }
    }

    class Director : Approver
    {
        public override void HandleRequest(double amount)
        {
            if (amount > 500000)
            {
                Console.WriteLine($"Approve by {this.GetType().Name}");
            }
        }
    }

}
