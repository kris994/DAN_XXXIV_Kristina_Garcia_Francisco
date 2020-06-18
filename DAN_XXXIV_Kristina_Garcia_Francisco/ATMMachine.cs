using System;
using System.Threading;

namespace DAN_XXXIV_Kristina_Garcia_Francisco
{
    class ATMMachine
    {
        public static int money = 10000;
        private readonly object l = new object();

        public void ATMWithdraw()
        {           
            int withdrawValue = 0;
            
            lock (l)
            {
                Random rnd = new Random();                
                withdrawValue = rnd.Next(100, 10001);

                // To make e sure its always a random number
                Thread.Sleep(15);

                for (int i = 0; i < Program.AllATMUsers.Count; i++)
                {
                    if (withdrawValue <= money)
                    {
                        money = money - withdrawValue;
                        Console.WriteLine("{0} withdraw {1} RSD. Current money state in bank: {2}",
                           Thread.CurrentThread.Name, withdrawValue, money);
                        break;
                    }
                    else if (withdrawValue > money)
                    {
                        Console.WriteLine("{0} tried to withdraw {1} RSD." +
                            " Transaction failed due to lack of money in Bank.", Thread.CurrentThread.Name, withdrawValue);
                        break;
                    }
                }

            }
        }

        public void Bank()
        {
            Validations val = new Validations();
            Random rnd = new Random();

            Console.Write("Please enter the number of users for ATM 1: ");
            int userNumOne = val.ValidPositiveNumber();

            Console.Write("Please enter the number of users for ATM 2: ");
            int userNumTwo = val.ValidPositiveNumber();
            Console.WriteLine();

            for (int i = 1; i < userNumOne + 1; i++)
            {
                Thread thread = new Thread(() => ATMWithdraw())
                {
                    Name = "User " + i + " from ATM 1"
                };

                Program.AllATMUsers.Add(thread);
            }

            for (int i = 1; i < userNumTwo + 1; i++)
            {
                Thread thread = new Thread(() => ATMWithdraw())
                {
                    Name = "User " + i + " from ATM 2"
                };

                Program.AllATMUsers.Add(thread);
            }

            foreach (var item in Program.AllATMUsers)
            {
                item.Start();
            }
        }
    }
}
