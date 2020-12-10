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

            var treeCount = 
                CountTrees(1, 1, slope) * 
                CountTrees(3, 1, slope) * 
                CountTrees(5, 1, slope) * 
                CountTrees(7, 1, slope) *
                CountTrees(1, 2, slope) ;

            Console.WriteLine($"Trees {treeCount}");
        }

        private static Int32 CountTrees(int xInc, int yInc, FieldCell[][] slope)
        {
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

            return treeCount;
        }
    }
}
