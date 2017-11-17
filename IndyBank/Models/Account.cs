using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBank.Models
{
    public abstract class Account
    {
        protected Account(double initialAMount)
        {
            this.Balance = initialAMount;
        }
        protected Account() { }
        public string AccountNumber { get; set; }
        public AccountOwner Member { get; set; }
        public double Balance { get; set; }

        public virtual void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Deposit amount must be greater than zero");
            }

            this.Balance += amount;
        }

        public virtual void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Withdrawal amount must be greater than zero");
            }
            if (amount > Balance)
            {
                throw new Exception("Insufficient Funds");
            }

            Balance -= amount;
        }

        public virtual void Transfer(Account toAccount, double amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Transfer amount must be greater than zero");
            }
            if (toAccount == null)
            {
                throw new Exception("Invalid Account");
            }
            if (this.Balance < amount)
            {
                throw new Exception("Insufficient Funds.");
            }
            Balance -= amount;
            toAccount.Deposit(amount);

        }
    }
}
