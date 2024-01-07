/* 
* Filename: ChequingAcc.cs
* Project: C# and OOP assignment "WP"
* Author: Bakr Jasim
* Date: Sept 18, 2022
* Description: This is the Subclass for the Account class and inherits some methods and properties and it is a chequing account
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace cs_and_OOP
{
    //Name: ChequingAcc
    //Purpose: This class will have fields and methods that lets the user have a balance, depoist and withdraw money
    public class ChequingAcc : Account
    {
        private static decimal AnnualFee = 97.99m;
        private int ChargeOnce;

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
                if(value >= 0)
                {
                    base.pBalance = value;
                }
            }
        }

        /*
        * Function: ChequingAcc (constructor)
        * Description:This is the default constructor for the ChequingAcc class 
        * Parameter: no parameter
        * Return Values: no return
        */
        public ChequingAcc() : base()
        { }

        /*
        * Function: ChequingAcc (constructor)
        * Description:This is the constructor for the ChequingAcc class and used when creating a new object for the class
        * Parameter: cAccountNumber: AccountNumber
        *            cBalance: balance in the chequing account
        * Return Values: no return
        */
        public ChequingAcc(int cAccountNumber, decimal cBalance):base(cAccountNumber, cBalance)
        {
            ChargeOnce = 1;//This value will let us know to charge the annual fee and help us charge only once since it is an annual fee
        }

        /*
        * Function: ApplyAnnualFee
        * Description:This method calculates and applies the annual fee on the chequing account when it gets created
        * Parameter: no parameter
        * Return Values: no return
        */
        public void ApplyAnnulaFee()
        {
            pBalance = pBalance - AnnualFee;
        }

        /*
        * Function: ToString()
        * Description:This method is displaying the required info about the bank account for the user to see
        * Parameter: no parameter
        * Return Values: the account info
        */
        public override string ToString()
        {
            if (ChargeOnce == 1)//Only charge when the account gets created"Annual"
            {
                ApplyAnnulaFee();
                ChargeOnce++;
            }
            return String.Format($"\nAccount Type: Chequing Account" +
                $"\nAccount Number: {pAccountNumber}" +
                $"\nCurrent Balance: {pBalance}" +
                $"\nAnnual Fee: {AnnualFee}\n");
        }

    }
}
