﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace DAN_XXXIV_Kristina_Garcia_Francisco
{
    /// <summary>
    /// Represents an atm bank machine functions
    /// </summary>
    class ATMMachine
    {
        #region Properties
        /// <summary>
        /// Fixed value in the bank
        /// </summary>
        public int money = 10000;
        /// <summary>
        /// The lock object
        /// </summary>
        private readonly object l = new object();
        /// <summary>
        /// List of all Users that are attempting to withdraw money from ATM
        /// </summary>
        public List<Thread> AllATMUsers = new List<Thread>();
        #endregion

        /// <summary>
        /// Withdraws the money from the bank using an atm, 
        /// the amount of withdraws equals the amount of people attempting it
        /// </summary>
        public void ATMWithdraw()
        {           
            int withdrawValue = 0;
            
            lock (l)
            {
                Random rnd = new Random();                
                withdrawValue = rnd.Next(100, 10001);

                // To make e sure its always a random number
                Thread.Sleep(15);

                // Amount of people qithdrawing money from atm
                for (int i = 0; i < AllATMUsers.Count; i++)
                {
                    // Checks if the amount is available in the bank
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
        
        /// <summary>
        /// Creates threads for the total amount of people withdrawing
        /// </summary>
        public void Bank()
        {
            Validations val = new Validations();

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

                AllATMUsers.Add(thread);
            }

            for (int i = 1; i < userNumTwo + 1; i++)
            {
                Thread thread = new Thread(() => ATMWithdraw())
                {
                    Name = "User " + i + " from ATM 2"
                };

                AllATMUsers.Add(thread);
            }

            // Start all threads at the same time from the list
            foreach (var item in AllATMUsers)
            {
                item.Start();
            }
        }
    }
}
