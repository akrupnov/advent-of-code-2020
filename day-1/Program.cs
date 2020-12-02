using System;
using System.IO;
using System.Linq;

namespace day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input");
            var expenseReport = input.Select(x => Convert.ToInt32(x)).ToList();

            var allPairs = expenseReport.SelectMany(x => expenseReport, (x, y) => Tuple.Create(x, y)).Where(tuple => tuple.Item1 != tuple.Item2).ToList();

            var result = allPairs.Where(t => t.Item1 + t.Item2 == 2020).Select(t => t.Item1 * t.Item2).First();

            Console.WriteLine($"{result}");

            Console.ReadLine();
        }
    }
}
