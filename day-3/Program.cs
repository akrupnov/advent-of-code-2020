using System;
using System.IO;
using System.Linq;

namespace day_3
{
    class Program
    {
        public enum FieldCell 
        {
            Empty,
            Tree
        }
        static void Main(string[] args)
        {
            var slope = File.ReadAllLines("input").Select(row => 
            {
                return row.Select(ch => ch == '.' ? FieldCell.Empty : FieldCell.Tree).ToArray();
            }
            ).ToArray();

            var xInc = 3;
            var yInc = 1;
            var xRunner = 0;
            var treeCount = 0;

            for(var y = 0; y < slope.Length; y = y + yInc)
            {
                var x = xRunner % slope[y].Length;

                if(slope[y][x] == FieldCell.Tree)
                {
                    treeCount++;
                }

                Console.WriteLine($"{x}-{xRunner}-{y}{Environment.NewLine}");

                xRunner += xInc;
            }

            Console.WriteLine($"Trees {treeCount}");
        }
    }
}
