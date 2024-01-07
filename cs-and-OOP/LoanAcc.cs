/* 
* Filename: LoanAcc.cs
* Project: C# and OOP assignment "WP"
* Author: Bakr Jasim
* Date: Sept 18, 2022
* Description: This is the Loan account class that inherits from the Account class
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_and_OOP
{
    //Name: LoanAcc
    //Purpose: This class inherits from the Account class, and it is a loan account that shows the user their
    //balance, interest rate, and lets the to deposit/pay off their balance as well as withdraw the one time money.
    public class LoanAcc:Account
    {
        private static decimal lInterestRate = 0.15m;
        private decimal AccruedInterest;
        private int WithdrawOnce;

        public decimal pAccruedInterest
        {
            get { return AccruedInterest; }
            set { AccruedInterest = value; }
        }

        /*
        * Function: LoanAcc (constructor)
        * Description:This is the default constructor for the LoanAcc class 
        * Parameter: no parameter
        * Return Values: no return
        */
        public LoanAcc() : base()
        { }

        /*
        * Function: LoanAcc (constructor)
        * Description:This is the constructor for the LoanAcc class and used when instantiating the object
        * Parameter: cAccountNumber: AccountNumber
        *            cBalance: balance in the loan account
        * Return Values: no return
        */
        public LoanAcc(int cAccountNumber, decimal cBalance) : base(cAccountNumber, cBalance)
        {
            WithdrawOnce = 0;
        }

        /*
        * Function: MakeDeposit
        * Description:This method is used to deposit money to the loan account,but for this account, it actually
        * pays off the owing balance, it is overriden from the base class so we can make changes to it
        * Parameter: amount: the amount specified for deposit
        * Return Values: returns the balance after the deposit is done
        */
        public override decimal MakeDeposit(decimal amount)
        {
            InterestCalculation();

            amount = amount - pAccruedInterest;
            pBalance = pBalance - amount;
            return pBalance;
        }

        /*
       * Function: Withdraw
       * Description:This method is used to send money from the loan account to the user (loan), it is overriden so we can make changes to it in this class
       * Parameter: amount: the amount specified for withdraw
       * Return Values: returns the loan balance after the withdraw is done
       */
        public override void Withdraw(decimal amount)
        {
            if (WithdrawOnce == 0)
            {
                pBalance = pBalance + amount;
            }
            WithdrawOnce++;
        }

        /*
       * Function: InterestCalculation
       * Description:This method calculates the amount that need to go to pay off the interest when making a deposit
       * Parameter: no parameter
       * Return Values: no return
       */
        public void InterestCalculation()
        {
            pAccruedInterest = pBalance * (lInterestRate / 12);//12 months in a year
            
        }

        /*
        * Function: ToString()
        * Description:This method is displaying the required info about the bank account for the user to see
        * Parameter: no parameter
        * Return Values: the account info
        */
        public override string ToString()
        {
            return String.Format($"\nAccount Type: Loan Account\n" +
                $"Account Number: {pAccountNumber}\n" +
                $"Current/Remaining Balance: {pBalance.ToString("f")}\n" +
                $"Interest Rate: {lInterestRate}\n");
        }
    }
}
