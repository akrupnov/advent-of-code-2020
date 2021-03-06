﻿using System;
using System.IO;
using System.Linq;

namespace day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var rawInput = File.ReadAllLines("input");

            var passwords = rawInput.Select(row => {
                var rowSplit = row.Split(':', StringSplitOptions.RemoveEmptyEntries);
                var policySplit = rowSplit[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var rangeSplit = policySplit[0].Split('-', StringSplitOptions.RemoveEmptyEntries);

                return new {Password = rowSplit[1].Trim(), PolicyLetter = policySplit[1][0], PolicyMinimal = Convert.ToInt32(rangeSplit[0]), PolicyMaximum = Convert.ToInt32(rangeSplit[1])};
            }).ToList();

            var validCount = passwords.Count(pd => {
                var letterCount = pd.Password.Count(x => x == pd.PolicyLetter);
                return letterCount >= pd.PolicyMinimal && letterCount <= pd.PolicyMaximum;
            });

            var superValidCount = passwords.Count(pd => pd.Password[pd.PolicyMinimal -1] == pd.PolicyLetter ^ pd.Password[pd.PolicyMaximum - 1] == pd.PolicyLetter);

            Console.WriteLine($"Day 2, Task 1: {validCount}");
            Console.WriteLine($"Day 2, Task 2: {superValidCount}");

        }
    }
}
