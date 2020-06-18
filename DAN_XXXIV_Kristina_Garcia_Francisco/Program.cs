using System;

namespace DAN_XXXIV_Kristina_Garcia_Francisco
{
    /// <summary>
    /// The main program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ATMMachine atm = new ATMMachine();
            atm.Bank();

            Console.ReadKey();
        }
    }
}
