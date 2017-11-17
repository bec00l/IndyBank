using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndyBank.Models
{
    public class IndividualInvestment : Account
    {
        
        public override void Withdraw(double amount)
        {
            if (amount > 1000)
            {
                throw new Exception("Max withdrawal is $1000");
            }
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
    }
}
