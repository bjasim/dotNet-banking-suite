/* 
* Filename: Programs.cs
* Project: C# and OOP assignment "WP"
* Author: Bakr Jasim
* Date: Sept 18, 2022
* Description: This is a test harness for the bank account that I created using OOPs best practices
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cs_and_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //-----------------------------Test Harness For The Savings Account Class --------------------------------
            Console.WriteLine("--------------------------------Testing Savings Account-------------------------------------------------"); //Note: I displayed this just for testing purposes only

            SavingsAcc mySavingsAccount1 = new SavingsAcc(34214, 1000, 12.7m);
            Console.WriteLine(mySavingsAccount1);

            //This is the same account but we're just making deposit to demonstrate that the method works
            mySavingsAccount1.MakeDeposit(255.65m);
            Console.WriteLine(mySavingsAccount1);

            //Now with the same savings account we're withdrawing instead of making deposit and will see how the balance will change
            mySavingsAccount1.Withdraw(359.99m);
            Console.WriteLine(mySavingsAccount1);

            Console.WriteLine($"Balance before deposit:{mySavingsAccount1.pBalance}");//Here we're reading the balance property
            //Now will test the MakeDeposit method
            mySavingsAccount1.MakeDeposit(100);
            Console.WriteLine($"Balance after deposit:{mySavingsAccount1.pBalance}\n"); //demonstrate that we can access the fields and the balance will change since we're depositing

            Console.WriteLine($"Balance before withdraw:{mySavingsAccount1.pBalance}");
            mySavingsAccount1.Withdraw(203.47m);
            Console.WriteLine($"Balance after withdraw:{mySavingsAccount1.pBalance}\n");
            mySavingsAccount1.CalculateAppliedInterest();
            //Console.WriteLine($"This is after calling function for calculating interest: )

            Console.WriteLine("Now we will be calling the CalculateAppliedInterest Method to apply interest to the balance we got above after making a withdraw\n");
            Console.WriteLine($"The balance after applying the interest: {mySavingsAccount1.CalculateAppliedInterest().ToString("f")}\n");

            //Uncomment the following two lines demonstrate the exception handling for the Withdraw method when trying to withdraw more than what's available in the balance
            //mySavingsAccount1.Withdraw(12000);
            //Console.WriteLine(mySavingsAccount1.pBalance);

            //----------------------------- Test Harness For The Chequing Account Class ---------------------------------
            Console.WriteLine("--------------------------------Testing Chequing Account-------------------------------------------------"); //Note: I displayed this just for testing purposes only

            ChequingAcc myChequingAcc1 = new ChequingAcc(263824, 5000);
            Console.WriteLine(myChequingAcc1); //only when we create the object, the account gets charged the annual fee

            //Now we're making deposit to the Chequing account 
            myChequingAcc1.MakeDeposit(1200);   //Notice how the annual fee was not charged again since it got
            Console.WriteLine(myChequingAcc1);  //charged the time the object created

            //This time we're going to withdraw from the Chequing account
            myChequingAcc1.Withdraw(420.49m);
            Console.WriteLine(myChequingAcc1);

            //Note: I will be applying the annual fee now just to demonstrate the function works, but in reality, I have already applied the annual fee when creatin ghte object
            Console.WriteLine($"The balance right now:{myChequingAcc1.pBalance}"); //demonstrate that we can access the fields and the balance will change since we're depositing
            myChequingAcc1.ApplyAnnulaFee();
            Console.WriteLine($"The balance after applying the annual fee:{myChequingAcc1.pBalance}\n"); //demonstrate that we can access the fields and the balance will change since we're depositing

            Console.WriteLine($"The balance before deposit:{myChequingAcc1.pBalance}"); //demonstrate that we can access the fields 
            myChequingAcc1.MakeDeposit(150.54m);
            Console.WriteLine($"The balance before deposit:{myChequingAcc1.pBalance}\n"); //demonstrate that we can access the fields and the balance will change since we're depositing

            Console.WriteLine($"The balance before withdraw:{myChequingAcc1.pBalance}"); //demonstrate that we can access the fields 
            myChequingAcc1.Withdraw(321.54m);
            Console.WriteLine($"The balance after withdraw:{myChequingAcc1.pBalance}\n"); //demonstrate that we can access the fields and the balance will change since we're withdrawing

            //Uncomment the following two lines demonstrate the exception handling for the MakeDeposit method when trying to deposit a negative value
            //myChequingAcc1.MakeDeposit(-264);
            //Console.WriteLine(myChequingAcc1.pBalance);

            ////------------------------------ Test Harness For The Loan Account --------------------------------------------

            Console.WriteLine("--------------------------------Testing Loan Account-------------------------------------------------"); //Note: I displayed this just for testing purposes only
            //Here we're just creating the Loan Account
            LoanAcc myLoanAcc1 = new LoanAcc(84923, 1000m);
            Console.WriteLine(myLoanAcc1);

            //Here we're making deposit to the account to reduce the loan 
            myLoanAcc1.MakeDeposit(320.46m);//some of it goes to the accrued interest and the rest to loan balance
            Console.WriteLine(myLoanAcc1);

            //We're paying off more money to reduce the loan balance
            myLoanAcc1.MakeDeposit(200);//some of it goes to the accrued interest and the rest to loan balance 
            Console.WriteLine(myLoanAcc1);

            myLoanAcc1.Withdraw(300);     //Here we're giving loan to the user "first loan" 
            Console.WriteLine(myLoanAcc1);//They only allowed to have one loan

            myLoanAcc1.Withdraw(300);        //Notice that we this amount was not added to the loan balance 
            Console.WriteLine(myLoanAcc1);   //since it only allowed to make only one withdrawl

            //Demonstrate that we can read/access the fields:
            Console.WriteLine($"Here's the Account Number:{myLoanAcc1.pAccountNumber}");
            Console.WriteLine($"This is the balance before depositing any money: {myLoanAcc1.pBalance.ToString("f")}");
            myLoanAcc1.MakeDeposit(221.43m);   //Calling the overriden method
            Console.WriteLine($"The loan balance after depositing money: {myLoanAcc1.pBalance.ToString("f")}");
            Console.WriteLine($"This is the accrued interest right now: {myLoanAcc1.pAccruedInterest.ToString("f")}\n");


            Console.WriteLine("Now we will be depositing more than loan balance amount to demonstrate the balance field can be negative in the Loan Account");
            myLoanAcc1.MakeDeposit(800);
            Console.WriteLine($"After calling the deposit method to deposit $800, this is the balance: {myLoanAcc1.pBalance.ToString("f")}");


            //Here creating a new object and trying the withdraw method again but accessing the field differently than with last object
            LoanAcc myLoanAccount = new LoanAcc(4254, 1500);
            Console.WriteLine(myLoanAccount);
            Console.WriteLine($"This is the loan balance before making a withdraw: {myLoanAccount.pBalance}");
            myLoanAccount.Withdraw(560.43m);  //Calling the overriden method
            Console.WriteLine($"This is the loan balance after making a withdraw: {myLoanAccount.pBalance}\n");

            //Interest Calculation
            Console.WriteLine($"Showing the balance to caculate the Accrued Interest on it: {myLoanAccount.pBalance}");
            myLoanAccount.InterestCalculation();
            Console.WriteLine($"This is the Accrued Interest based on the Interest Rate and the balance above: {myLoanAccount.pAccruedInterest.ToString("f")}\n"); 
        }
    }
}
