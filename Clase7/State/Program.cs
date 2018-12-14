using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuentas
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account("Jorge Sanchez");
            Console.WriteLine(account.GetState().GetType().Name);
            account.Deposit(100);
            account.Deposit(100);
            account.Deposit(100);
            account.Deposit(100);
            account.Deposit(100);
            account.Deposit(100);
            Console.WriteLine(account.GetState().GetType().Name);
        }
    }

    class Account
    {
        private State state;
        private string name;
        public Account(string name)
        {
            this.name = name;
            this.state = new SilverState(0.0, this);
        }

        public void Deposit(double amount)
        {
            this.state.Deposit(amount);
        }

        public void Withdraw(double amount)
        {
            this.state.Withdraw(amount);
        }

        public void SetState(State state)
        {
            this.state = state;
        }

        public State GetState()
        {
            return this.state;
        }

    }

    abstract class State
    {
        protected Account account;
        protected double balance;
        protected double lowerLimit;
        protected double upperLimit;

        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);

        public Account GetAccount()
        {
            return this.account;
        }

        public double GetBalance()
        {
            return this.balance;
        }

    }

    class RedState : State
    {
        private SilverState silverState;

        public RedState(SilverState silverState)
        {
            this.silverState = silverState;
        }

        public override void Deposit(double amount)
        {
            throw new NotImplementedException();
        }

        public override void Withdraw(double amount)
        {
            throw new NotImplementedException();
        }
    }

    class SilverState : State
    {
        public SilverState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
            Init();
        }

        public override void Deposit(double amount)
        {
            this.balance = this.balance + amount;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (balance < lowerLimit)
            {
                account.SetState(new RedState(this));
            }
            else if (balance > upperLimit)
            {
                account.SetState(new GoldState(this));
            }
        }

        public override void Withdraw(double amount)
        {
            this.balance = this.balance - amount;
            StateChangeCheck();
        }

        private void Init()
        {
            this.lowerLimit = 0.0;
            this.upperLimit = 500;
        }
    }

    class GoldState : State
    {
        private State state;

        public GoldState(State state) : this(state.GetBalance(), state.GetAccount())
        {

        }

        public GoldState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
            Init();
        }

        private void Init()
        {
            this.lowerLimit = 500;
            this.upperLimit = 100000;
        }

        public override void Deposit(double amount)
        {
            throw new NotImplementedException();
        }

        public override void Withdraw(double amount)
        {
            throw new NotImplementedException();
        }
    }
}