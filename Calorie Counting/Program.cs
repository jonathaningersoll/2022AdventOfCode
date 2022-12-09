using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounting
{
    class Program
    {        
        static void Main(string[] args)
        {
            var CalorieCounting = new CalorieCounting();
            CalorieCounting.Run();
        }
    }

    class CalorieCounting
    {
        public void Run()
        {
            // Part 1 Solution:
            Console.WriteLine(
                File.ReadAllText(@"./input.txt")
                    .Split("\r\n\r\n")
                    .ToList()
                    .Select(y => y
                        .Split("\r\n")
                        .ToList()
                        .Select(int.Parse)
                        .Sum())
                    .Max());

            // Part 2 Solution:
            Console.WriteLine(
                File.ReadAllText(@"./input.txt")
                    .Split("\r\n\r\n")
                    .ToList()
                    .Select(y => y
                        .Split("\r\n")
                        .ToList()
                        .Select(int.Parse)
                        .Sum())
                    .ToList()
                    .OrderByDescending(n => n)
                    .Take(3)
                    .Sum());
        }
    }
}