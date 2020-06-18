using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAN_XXXIV_Kristina_Garcia_Francisco
{
    class Program
    {
        public static List<Thread> ATMOneThreads = new List<Thread>();
        public static List<Thread> ATMTwoThreads = new List<Thread>();

        static void Main(string[] args)
        {
            ATMMachine atm = new ATMMachine();
            atm.CreateThreads();

            Console.ReadKey();
        }
    }
}
