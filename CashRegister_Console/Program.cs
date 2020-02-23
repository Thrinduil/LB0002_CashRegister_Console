using System;
using System.Collections.Generic;
using System.Linq;

namespace CashRegister_Console
{

    class CashRegister
    {
        private readonly int[] drawer = new int[] { 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };

        public Tuple<int, int> GetPriceAndPayed()
        {
            Console.Write("Ange pris: ");
            int price = Convert.ToInt32(Console.ReadLine());

            Console.Write("Betalt: ");
            int payed = Convert.ToInt32(Console.ReadLine());

            var priceAndPayed = new Tuple<int, int>(price, payed);
            return priceAndPayed;
        }

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
            Console.WriteLine("Växel tillbaka:");
            PrintDenominator("tusen", change.Where(item => item == 1000).Count(), false);
            PrintDenominator("femhundra", change.Where(item => item == 500).Count(), false);
            PrintDenominator("tvåhundra", change.Where(item => item == 200).Count(), false);
            PrintDenominator("hundra", change.Where(item => item == 100).Count(), false);
            PrintDenominator("femtio", change.Where(item => item == 50).Count(), false);
            PrintDenominator("tjugo", change.Where(item => item == 20).Count(), false);
            PrintDenominator("tio", change.Where(item => item == 10).Count(), true);
            PrintDenominator("fem", change.Where(item => item == 5).Count(), true);
            PrintDenominator("två", change.Where(item => item == 2).Count(), true);
            PrintDenominator("en", change.Where(item => item == 1).Count(), true);
        }

        private void PrintDenominator(string value, int quantity, bool coin)
        {
            string moneyTypeSingular;
            string moneyTypePlural;

            if (coin)
            {
                moneyTypeSingular = "krona";
                moneyTypePlural = "kronor";
            }
            else
            {
                moneyTypeSingular = "lapp";
                moneyTypePlural = "lappar";
            }

            if (quantity == 1)
            {
                Console.WriteLine("{0} {1}{2}", quantity, value, moneyTypeSingular);
            }
            else if (quantity > 1)
            {
                Console.WriteLine("{0} {1}{2}", quantity, value, moneyTypePlural);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CashRegister cashRegister = new CashRegister();

            Tuple<int, int> priceAndPayed = cashRegister.GetPriceAndPayed();

            List<int> change = cashRegister.MakeChange(priceAndPayed.Item1, priceAndPayed.Item2);

            cashRegister.PrintChange(change);

            Console.ReadLine();
        }
    }
}
