using System;
using System.Collections.Generic;
using System.Threading;

namespace DAN_XXXIV_Kristina_Garcia_Francisco
{
    class Program
    {
        public static List<Thread> AllATMUsers = new List<Thread>();

        static void Main(string[] args)
        {
            ATMMachine atm = new ATMMachine();
            atm.Bank();

            Console.ReadKey();
        }
    }
}
