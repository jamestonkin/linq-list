using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqlist
{
    // Define a bank
    public class Bank
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }

    // Define a customer
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            IEnumerable<string> LFruits = from fruit in fruits
            where fruit.StartsWith("L")
            select fruit;

            foreach(string fruit in LFruits)
            {
                Console.WriteLine($"\n{fruit}");
            }

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> fourSixMultiples = numbers.Where(number => number % 4 == 0 || number % 6 == 0);
            
            foreach(int number in fourSixMultiples)
            {
                Console.WriteLine($"\n {number}");
            }

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
                {
                    "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                    "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                    "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                    "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                    "Francisco", "Tre"
                };

            IEnumerable<string> reverseAlphaNames = from name in names
                                                    orderby name descending
                                                    select name;

            foreach(string name in reverseAlphaNames)
            {
                Console.WriteLine(name);
            }

            // Build a collection of these numbers sorted in ascending order
            List<int> moreNumbers = new List<int>()
                {
                    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
                };

            IEnumerable<int> ascendNum = from num in moreNumbers
                                         orderby num ascending
                                         select num;

            foreach(int num in ascendNum)
            {
                Console.WriteLine(num);
            }

            // Output how many numbers are in this list
            List<int> evenMoreNumbers = new List<int>()
                {
                    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
                };

            int howManyNums = evenMoreNumbers.Count();
            Console.WriteLine("Number of evenMoreNumbers: " + howManyNums);

            // How much money have we made?
            List<double> purchases = new List<double>()
                {
                    2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
                };

            double totalMoney = purchases.Sum();
            Console.WriteLine("Total Money: " + totalMoney);

            // What is our most expensive product?
            List<double> prices = new List<double>()
                {
                    879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
                };

            double highPriced = prices.Max();
            Console.WriteLine("Highest Priced: " + highPriced);

            /*
                Store each number in the following List until a perfect square
                is detected.

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> wheresSquaredo = new List<int>()
                {
                    66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
                };

            IEnumerable<int> squaredNums = wheresSquaredo.TakeWhile(num => Math.Sqrt(num) % 1 != 0);

            foreach(int num in squaredNums)
            {
                Console.WriteLine($"{num} is not a squared number");
            }

            // Create some banks and store in a List
            List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };

            // Create some customers and store in a List
            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            /* 
                Given the same customer set, display how many millionaires per bank.
                Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

                Example Output:
                WF 2
                BOA 1
                FTB 1
                CITI 1
            */

            var millionaires = customers.Where(millionaire => millionaire.Balance >= 1000000)
;
            foreach(var person in millionaires)
            {
                Console.WriteLine($"Millionaires: {person.Name}");
            }

            var millionaireByBank = millionaires.GroupBy(groupedMillionaires => groupedMillionaires.Bank);

            foreach(var groupedMillionaires in millionaireByBank)
            {
                Console.WriteLine($"{groupedMillionaires.Key} {groupedMillionaires.Count()}");
            }

            var millionaireReport = from m in millionaires
                                    orderby m.Name[m.Name.IndexOf(" ") + 1] ascending
                                    join bank in banks on m.Bank equals bank.Symbol
                                    select new { BankName = bank.Name, Customer = m.Name };

            foreach(var milly in millionaireReport)
            {
                Console.WriteLine($"{milly.Customer} at {milly.BankName}");
            }

            Console.Read();
        }
    }
}
