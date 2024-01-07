/* 
* Filename: Account.cs
* Project: C# and OOP assignment "WP"
* Author: Bakr Jasim
* Date: Sept 18, 2022
* Description: This is the parent class for the bank program that I'm creating
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace cs_and_OOP
{
    //Name: Account
    //Purpose: This is the base class for the bank program that we're creating, it is abstract so it can't ba an object without specifiying the derived class
    public abstract class Account
    {
       
        private int AccountNumber;
        private decimal Balance;

        /*
        * Function: pBalance
        * Description:This is the property for the balance field to make it read and write, it is virtual so other derived classes can override it
        * Parameter: no parameter
        * Return Values: Balance
        */
        public virtual decimal pBalance
        {
            get { return Balance; }
            set { Balance = value; }
        }

        /*
        * Function: pAccountNumber
        * Description:This is the property for the accountNumber field to make it read and write 
        * Parameter: no parameter
        * Return Values: AccountNumber
        */
        public int pAccountNumber
        {
            get { return AccountNumber; }
            set
            {
                if(value > 0)
                {
                    AccountNumber = value;
                }
            }
        }

        /*
        * Function: Account (constructor)
        * Description:This is the default constructor for the Account class 
        * Parameter: no parameter
        * Return Values: no return
        */
        public Account()
        { }

        /*
        * Function: Account (constructor)
        * Description:This is the constructor for the Account class and used when instantiating the object
        * Parameter: cAccountNumber: AccountNumber
        *            cBalance: balance in the specified account
        * Return Values: no return
        */
        public Account(int cAccountNumber, decimal cBalance)
        {
            pAccountNumber = cAccountNumber;
            pBalance = cBalance;
        }

        /*
        * Function: MakeDeposit
        * Description:This method is used to deposit money to the specified account, it is virtual so derived classes can override it
        * Parameter: amount: the amount specified for deposit
        * Return Values: returns the balance after the deposit is done
        */
        public virtual decimal  MakeDeposit(decimal amount)
        {
            if(amount > 0)
            {
                pBalance = amount + pBalance;
                return Balance;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Can't deposit a number that's less than 0$\n");
            }
        }

        /*
       * Function: Withdraw
       * Description:This method is used to withdraw money from the specified account, it is virtual so derived classes can override it
       * Parameter: amount: the amount specified for withdraw
       * Return Values: returns the balance after the withdraw is done
       */

        public virtual void Withdraw(decimal amount)
        {
            if (amount < pBalance)
            {
                pBalance = pBalance - amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Can't withdraw more than what you have in balance\n");
            }
        }

    }
}
