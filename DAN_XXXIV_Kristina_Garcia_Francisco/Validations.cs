using System;

namespace DAN_XXXIV_Kristina_Garcia_Francisco
{
    /// <summary>
    /// Validates the user input
    /// </summary>
    class Validations
    {
        /// <summary>
        /// The user input has to be a positive unber above 0
        /// </summary>
        /// <returns>the integer value</returns>
        public int ValidPositiveNumber()
        {
            string s = Console.ReadLine();
            bool b = Int32.TryParse(s, out int num);
            while (!b || num < 0)
            {
                Console.Write("Invalid input. Try again: ");
                s = Console.ReadLine();
                b = Int32.TryParse(s, out num);
            }
            return num;
        }
    }
}
