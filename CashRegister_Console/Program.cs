using System;
using System.Collections.Generic;

namespace CashRegister_Console
{

    class CashRegister
    {
        private readonly int[] drawer = new int[] { 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };

        public List<int> MakeChange(int price, int payed)
        {
            int difference = payed - price;

            List<int> change = new List<int> { };
            int i = 0;
            int denomination = drawer[i];

            while (difference > 0)
            {
                if (difference < denomination)
                {
                    i += 1;
                    denomination = drawer[i];
                    continue;
                }

                change.Add(denomination);
                difference -= denomination;
            }

            return change;
        }

        public void PrintChange(List<int> change)
        {
            Console.WriteLine("Change:");

            for (int i = 0; i < change.Count; i++)
            {
                Console.WriteLine(change[i]);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CashRegister cashRegister = new CashRegister();

            int price = 123;
            int payed = 500;

            List<int> change = cashRegister.MakeChange(price, payed);

            cashRegister.PrintChange(change);

            Console.ReadLine();
        }
    }
}
