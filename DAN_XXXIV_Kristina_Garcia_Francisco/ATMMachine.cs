using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXIV_Kristina_Garcia_Francisco
{
    class ATMMachine
    {
        public static int money = 10000;

        public void ATMOne(int userNum)
        {
            
        }

        public void ATMTwo(int userNum)
        {

        }

        public void CreateThreads()
        {
            Validations val = new Validations();

            Console.Write("Please enter the number of users for ATM 1: ");
            int userNumOne = val.ValidPositiveNumber();

            Console.Write("Please enter the number of users for ATM 2: ");
            int userNumTwo = val.ValidPositiveNumber();

            for (int i = 0; i < userNumOne; i++)
            {
                Thread thread = new Thread(() => ATMOne(userNumOne));
                Program.ATMOneThreads.Add(thread);
            }

            for (int i = 0; i < userNumTwo; i++)
            {
                Thread thread = new Thread(() => ATMOne(userNumTwo));
                Program.ATMTwoThreads.Add(thread);
            }

            foreach (var item in Program.ATMOneThreads)
            {
                item.Start();
            }

            foreach (var item in Program.ATMTwoThreads)
            {
                item.Start();
            }
        }
    }
}
