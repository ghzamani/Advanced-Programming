using System;

namespace A11
{
    public class Account
    {
        public double Balance;

        public Account(double balance)
        {
            if (balance >= 0)
                this.Balance = balance;

            else
            {
                this.Balance = 0;
                Console.WriteLine(ToString());
            }
        }

        public override string ToString()
        {
            if (Balance == 0)
            {
                string str = $"Initial balance is invalid. Setting balance to 0.";
                return str;
            }
            else return base.ToString();
        }

        public virtual void Credit(double amount)
        {
            if(amount < 0)
                throw new ArgumentException("Credit amount must be positive");

            this.Balance += amount;           
        }

        public virtual bool Debit(double amount)
        {
            if (amount <= this.Balance)
            {
                Balance -= amount;
                return true;
            }

            Console.WriteLine("Debit amount exceeded account balance.");
            return false;
        }
    }
}
