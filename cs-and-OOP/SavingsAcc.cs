/* 
* Filename: SavingsAcc.cs
* Project: C# and OOP assignment "WP"
* Author: Bakr Jasim
* Date: Sept 18, 2022
* Description:This is a savings acount that inherits from the account class 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_and_OOP
{
    //Name: SavingsAcc
    //Purpose:This is the child class of Account class, and lets the user to deposit withdraw and calculate interest on the balance
    public class SavingsAcc :Account 
    {
        private decimal InterestRate;


        /*
        * Function: pInterestRate 
        * Description:The property for the interestRate field to read and write
        * Parameter: no parameter
        * Return Values: InterestRate
        */
        public decimal pInterestRate
        {
            get { return InterestRate; }
            set
            {
                if ((value > 0) && (value < 30)) //I made an assumption/role for not letting the interest rate be higher than 30%
                {
                    InterestRate = value;
                }
            }
        }

     /*
     * Function: pBalance
     * Description:This is the overriden property for the balance field to make it read and write, it is overriden so this subclass can make changes to it
     * Parameter: no parameter
     * Return Values: Balance
     */
        public override decimal pBalance
        {
            get => base.pBalance;
            set
            {
                if (value >= 0)
                {
                    base.pBalance = value;
                }
            }
        }

        /*
        * Function: SavingsAcc (constructor)
        * Description:This is the default constructor for the SavingsAcc class 
        * Parameter: no parameter
        * Return Values: no return
        */
        public SavingsAcc() : base()
        { }

        /*
        * Function: SavingsAcc (constructor)
        * Description:This is the constructor for the SavingsAcc class and used when instantiating the object
        * Parameter: cAccountNumber: AccountNumber
        *            cBalance: balance in the savings account
        *            cInterestRate: The interestRate for savings
        * Return Values: no return
        */
        public SavingsAcc(int cAccountNumber, decimal cBalance, decimal cInterestRate):base(cAccountNumber , cBalance)
        {
            pInterestRate = cInterestRate; 
        }

     /*
     * Function: pBalance
     * Description:This method calculates the applied interest on the saving balance of this account
     * Parameter: no parameter
     * Return Values: the interest amount applies on the balance
     */
        public decimal CalculateAppliedInterest()
        {
            return pBalance + (pBalance * (InterestRate/100));//divide it by 100 to get the decimal value of the interest rate
        }

        /*
        * Function: ToString()
        * Description:This method is displaying the required info about the bank account for the user to see
        * Parameter: no parameter
        * Return Values: the account info
        */
        public override string ToString()
        {
            return String.Format($"\nAccount Type: Savings Account" +
                $"\nAccount Number: {pAccountNumber}" +
                $"\nBalance: {pBalance}" +
                $"\nAnnual Interest Rate: {pInterestRate}" +
                $"\nApply Interest: {CalculateAppliedInterest().ToString("f")}\n");
        }

    }
}
