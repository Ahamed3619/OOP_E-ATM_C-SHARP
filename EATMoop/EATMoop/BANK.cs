using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EATMoop
{
    class BANK
    {
        public List<Account> _accountList ;

        
        public void Start()
        {
             var CardCheck = CheckingCard();
             var PinCheck = PinVerify(CardCheck);

        }

        public void BankingDetails()
        {
            Console.WriteLine("***************** WELCOME TO ATM BANKING-DEVELOPED BY TANVIR *****************\n");
            _accountList = new List<Account>()
            {
                new Account() {AccountNumber = 111, AccountPassword = 444, AccountBalance=10000, count=0, AccountName = "Bill"},
                new Account() {AccountNumber = 222, AccountPassword = 555, AccountBalance=60000, count=0,  AccountName = "Bill"},
                new Account() {AccountNumber = 333, AccountPassword = 666, AccountBalance=30000, count=0, AccountName = "Bill"}
            };

            
        }

        


        public Account CheckingCard()
        {
            Console.Write("Please Enter your Account Number: ");

            int CardInput = Convert.ToInt32(Console.ReadLine());

            foreach (var myaccount in _accountList)
            {
                
                if (CardInput == myaccount.AccountNumber)
                {

                    var UserCard = myaccount;

                    return UserCard;

                }


            }
            Console.WriteLine("Account Number Wrong");
            return CheckingCard();
        }

        public Account PinVerify( Account CardCheck)
        {
            Console.Write("Please Enter your Pin Number: ");

            var PinInput = Convert.ToInt32(Console.ReadLine());


            if (CardCheck.AccountPassword == PinInput)
            {
                ChooseTransaction(CardCheck);
            }


            Console.WriteLine("PIN Wrong");
            return CheckingCard();
        }

        public void ChooseTransaction(Account CardCheck)
        {

            Console.WriteLine("Please Choose Your Transaction: ");

            Console.WriteLine("\t1. Withdraw Money\n\t2. Balance Check\n\t3. Exit");

            Console.Write("Enter Your Choice Now: ");

            var choice = int.Parse(Console.ReadLine());

            // ***************WITHDRW MONEY CODE***********

            if (choice == 1)
            {
                CardCheck.count++;



                if (CardCheck.count > 3)
                {
                    Console.WriteLine("You tried for 3 times.Try another ");
                    ChooseTransaction(CardCheck);

                }

                else
                {

                    WithDraw(CardCheck);


                }





            }
            else if (choice == 2)
            {
                BalanceCheck(CardCheck);

            }
            else if (choice == 3)
            {
                Exit();

            }
            else
            {
                Console.WriteLine("Sorry Wrong Choice.Try Again");
                ChooseTransaction(CardCheck);
            }
        }

        public void WithDraw(Account CardCheck)
        {
            Console.Write("Enter Your amount:");

            var withdraw = int.Parse(Console.ReadLine());


            //var Balance1 = Balance[CardIndex];


            var CurrentBalance1 = CardCheck.AccountBalance - withdraw;

            CardCheck.AccountBalance = CurrentBalance1;

            if (CurrentBalance1 > 20)
            {


                Console.WriteLine("Success Withdraw. New Balance is: " + CurrentBalance1);

                Console.Write("Do you Want to Quit? Yes OR No: ");

                var quit1 = Console.ReadLine();

                if (quit1 == "yes")
                {
                    Environment.Exit(0);
                }
                else if (quit1 == "no")
                {
                    Console.WriteLine("OK.Try Again From Scratch");
                    ChooseTransaction(CardCheck);
                }
            }


        }

        public void BalanceCheck(Account CardCheck)
        {
            Console.WriteLine("Your Balance is: " + CardCheck.AccountBalance);
            ChooseTransaction(CardCheck);
        }

        public void Exit()
        {
            //Environment.Exit(0);
            Start();




        }



        
    }
}

