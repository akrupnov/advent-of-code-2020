﻿using System;
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

            var allPairs = expenseReport.
                                SelectMany(x => expenseReport, (x, y) => Tuple.Create(x, y)).
                                Where(tuple => tuple.Item1 != tuple.Item2).ToList();
            
            var allTriplets = expenseReport.SelectMany(a => expenseReport.Where(b => (b > a)).
                                    SelectMany(b => expenseReport.Where(c => (c > b)).
                                    Select(c => Tuple.Create(a, b, c)))).ToList();


            var firstResult = allPairs.Where(t => t.Item1 + t.Item2 == 2020).Select(t => t.Item1 * t.Item2).First();

            Console.WriteLine($"{firstResult}");
            
            var secondResult = allTriplets.Where(t => t.Item1 + t.Item2 + t.Item3 == 2020).Select(t => t.Item1*t.Item2*t.Item3).First();

            Console.WriteLine($"{secondResult}");

            Console.ReadLine();
        }
    }
}
