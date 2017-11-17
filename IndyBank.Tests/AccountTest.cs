using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IndyBank.Models;

namespace IndyBank.Tests
{
    [TestClass]
    public class AccountTest
    {
        //Withdrawal Methods
        [TestMethod]
        public void Withdrawal_WithValidAmount_UpdatesBalance()
        {
            // arrange 
            var debitAmount = 4.55;
            var expected = 7.44;
            var account = new Checking
            {
                Balance = 11.99
            };

            // act  
            account.Withdraw(debitAmount);

            // assert  
            var actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");

        }

        [TestMethod]
        public void Withdrawal_WithInvalidAmount_ThrowsException()
        {
            // arrange 
            var debitAmount = 12.00;
            var account = new Checking
            {
                Balance = 11.99
            };

            // act  
            try
            {
                account.Withdraw(debitAmount);
            }
            catch (Exception e)
            {
                // assert  
                StringAssert.Contains(e.Message, "Insufficient Funds");
            }

        }

        [TestMethod]
        public void Withdrawal_WithNegativeAmount_ThrowsException()
        {
            // arrange 
            var account = new Checking
            {
                Balance = 11.99
            };

            // act  
            try
            {
                account.Withdraw(-9);
            }
            catch (Exception e)
            {
                // assert  
                StringAssert.Contains(e.Message, "Withdrawal amount must be greater than zero");
            }

        }

        [TestMethod]
        public void Withdrawal_WithZeroAmount_ThrowsException()
        {
            // arrange 
            var account = new Checking
            {
                Balance = 11.99
            };

            // act  
            try
            {
                account.Withdraw(0);
            }
            catch (Exception e)
            {
                // assert  
                StringAssert.Contains(e.Message, "Withdrawal amount must be greater than zero");
            }

        }

        [TestMethod] public void Withdrawal_WithBalanceZero_ThrowsException()
        {
            // arrange 
            var account = new CorporateInvestment();

            // act  
            try
            {
                account.Withdraw(9);
            }
            catch (Exception e)
            {
                // assert  
                StringAssert.Contains(e.Message, "Insufficient Funds");
            }

        }

        //Transfer Methods
        [TestMethod]
        public void Transfer_WithValidAmount_UpdatesBalance()
        {
            // arrange 
            var transferAmount = 4.00;
            var toExpected = 16.00;
            var fromExpected = 8.00;
            var toAccount = new Checking
            {
                Balance = 12.00
            };

            var fromAccount = new IndividualInvestment
            {
                Balance = 12.00
            };

            // act  
            fromAccount.Transfer(toAccount, transferAmount);

            // assert  
            var toActual = toAccount.Balance;
            var fromActual = fromAccount.Balance;
            Assert.AreEqual(toExpected, toActual);
            Assert.AreEqual(fromExpected, fromActual);


        }

        [TestMethod]
        public void Transfer_WithInvalidAmount_ThrowsException()
        {
            // arrange 
            var transferAmount = 12.00;
            var account = new Checking
            {
                Balance = 11.99
            };

            var toAccount = new Checking();

            // act  
            try
            {
                account.Transfer(toAccount, transferAmount);
            }
            catch (Exception e)
            {
                // assert  
                StringAssert.Contains(e.Message, "Insufficient Funds");
            }

        }

        [TestMethod]
        public void Transfer_WithNegativeAmount_ThrowsException()
        {
            // arrange 
            var account = new Checking
            {
                Balance = 11.99
            };

            var toAccount = new Checking();

            // act  
            try
            {
                account.Transfer(toAccount, -9);
            }
            catch (Exception e)
            {
                // assert  
                StringAssert.Contains(e.Message, "Transfer amount must be greater than zero");
            }

        }

        [TestMethod]
        public void Transfer_WithZeroAmount_ThrowsException()
        {
            // arrange 
            var account = new Checking
            {
                Balance = 11.99
            };

            var toAccount = new Checking();

            // act  
            try
            {
                account.Transfer(toAccount, 0);
            }
            catch (Exception e)
            {
                // assert  
                StringAssert.Contains(e.Message, "Transfer amount must be greater than zero");
            }

        }

        [TestMethod]
        public void Transfer_WithBalanceZero_ThrowsException()
        {
            // arrange 
            var account = new CorporateInvestment();
            var toAccount = new Checking();

            // act  
            try
            {
                account.Transfer(toAccount, 9);
            }
            catch (Exception e)
            {
                // assert  
                StringAssert.Contains(e.Message, "Insufficient Funds");
            }

        }

        [TestMethod]
        public void Transfer_NoTransferToAccount_ThrowsException()
        {
            // arrange 
            var account = new CorporateInvestment();

            // act  
            try
            {
                account.Transfer(null, 10);
            }
            catch (Exception e)
            {
                // assert  
                StringAssert.Contains(e.Message, "Invalid Account");
            }

        }

        //Deposit Methods
        [TestMethod]
        public void Deposit_WithValidAmount_UpdatesBalance()
        {
            // arrange 
            var depositAmount = 4.00;
            var expected = 16.00;
            var account = new Checking
            {
                Balance = 12.00
            };

            // act  
            account.Deposit(depositAmount);

            // assert  
            var actual = account.Balance;
            Assert.AreEqual(expected, actual);
            
        }

        [TestMethod]
        public void Deposit_WithInvalidAmount_ThrowsException()
        {
            // arrange 
            var depositAmount = -9;
            var account = new Checking
            {
                Balance = 12.00
            };

            // act  
            try
            {
                account.Deposit(depositAmount);
            }
            catch (Exception e)
            {
                // assert  
                StringAssert.Contains(e.Message, "Deposit amount must be greater than zero");
            }

        }

        [TestMethod]
        public void Deposit_WithZeroAmount_ThrowsException()
        {
            // arrange 
            var depositAmount = 0;
            var account = new Checking
            {
                Balance = 12.00
            };

            // act  
            try
            {
                account.Deposit(depositAmount);
            }
            catch (Exception e)
            {
                // assert  
                StringAssert.Contains(e.Message, "Deposit amount must be greater than zero");
            }

        }

        //Individual Investment Withdrawal Methods
        [TestMethod]
        public void IndividualInvestment_Withdrawal_WithValidAmount_UpdatesBalance()
        {
            // arrange 
            var debitAmount = 4.55;
            var expected = 7.44;
            var account = new IndividualInvestment
            {
                Balance = 11.99
            };

            // act  
            account.Withdraw(debitAmount);

            // assert  
            var actual = account.Balance;
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void IndividualInvestment_Withdrawal_WithInvalidAmount_ThrowsException()
        {
            // arrange 
            var debitAmount = 12.00;
            var account = new IndividualInvestment
            {
                Balance = 11.99
            };

            // act  
            try
            {
                account.Withdraw(debitAmount);
            }
            catch (Exception e)
            {
                // assert  
                StringAssert.Contains(e.Message, "Insufficient Funds");
            }

        }

        [TestMethod]
        public void IndividualInvestment_Withdrawal_WithNegativeAmount_ThrowsException()
        {
            // arrange 
            var account = new IndividualInvestment
            {
                Balance = 11.99
            };

            // act  
            try
            {
                account.Withdraw(-9);
            }
            catch (Exception e)
            {
                // assert  
                StringAssert.Contains(e.Message, "Withdrawal amount must be greater than zero");
            }

        }

        [TestMethod]
        public void IndividualInvestment_Withdrawal_WithZeroAmount_ThrowsException()
        {
            // arrange 
            var account = new IndividualInvestment
            {
                Balance = 11.99
            };

            // act  
            try
            {
                account.Withdraw(0);
            }
            catch (Exception e)
            {
                // assert  
                StringAssert.Contains(e.Message, "Withdrawal amount must be greater than zero");
            }

        }

        [TestMethod]
        public void IndividualInvestment_Withdrawal_WithBalanceZero_ThrowsException()
        {
            // arrange 
            var account = new IndividualInvestment();

            // act  
            try
            {
                account.Withdraw(9);
            }
            catch (Exception e)
            {
                // assert  
                StringAssert.Contains(e.Message, "Insufficient Funds");
            }

        }

        [TestMethod]
        public void IndividualInvestment_Withdrawal_Over1000_ThrowsException()
        {
            // arrange 
            var account = new IndividualInvestment();

            // act  
            try
            {
                account.Withdraw(1001);
            }
            catch (Exception e)
            {
                // assert  
                StringAssert.Contains(e.Message, "Max withdrawal is $1000");
            }

        }

    }
}
