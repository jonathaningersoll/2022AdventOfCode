using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampCleanup
{
    class Program
    {        
        static void Main(string[] args)
        {
            var c = new SupplyStacks();
            c.PartOne();
        }        
    }

    class SupplyStacks
    {
        public void PartOne()
        {
            var i = File.ReadAllLines(@"input.txt").ToList();
            var testBoat = new List<List<string>>() {
                new List<string>() {"Z","N"},
                new List<string>() {"M","C","D"},
                new List<string>() {"P"}
            };
            var boat = new List<List<string>>() {
                new List<string>() {"F","D","B","Z","T","J","R","N"},
                new List<string>() {"R","S","N","J","H"},
                new List<string>() {"C","R","N","J","G","Z","F","Q"},
                new List<string>() {"F","V","N","G","R","T","Q"},
                new List<string>() {"L","T","Q","F"},
                new List<string>() {"Q","C","W","Z","B","R","G","N"},
                new List<string>() {"F","C","L","S","N","H","M"},
                new List<string>() {"D","N","Q","M","T","J"},
                new List<string>() {"P","G","S"},
            };

            PrintStacks(boat);

            var crane = new List<string>();

            var origin = new List<string>();
            var destination = new List<string>();
            //skip the first 12 lines (or so)
            i.ForEach(instruction => {
                instruction = instruction.Replace("move ", "");
                instruction = instruction.Replace(" from ", ".");
                instruction = instruction.Replace(" to ", ",");

                var splitInstructions = instruction.Split('.').ToList();
                var q = int.Parse(splitInstructions[0]);
                var o = int.Parse(splitInstructions[1].Split(',')[0])-1;
                var d = int.Parse(splitInstructions[1].Split(',')[1])-1;

                for(int m = 1; m <= q; m++)
                {
                    var crate = testBoat[o].Last().ToString(); // does it have to be ToString()?
                    testBoat[d].Add(crate);                    
                    testBoat[o].Remove(crate);
                }
                //Console.Clear();
                //PrintStacks(boat);
            });
            /*testBoat.ForEach(stack => {
                Console.Write(stack.Last());
            });*/
            testBoat.ForEach(stack => {
                Console.WriteLine(stack.Last());
            });
        }

        public void PrintStacks(List<List<string>> boat)
        {
            for(int z = 0; z < boat.Count(); z++)
                {
                    //System.Console.Clear();
                    Console.Write($"Stack {z+1}");
                    boat[z].ForEach(crate => Console.Write("["+crate+"]"));
                    Console.WriteLine();
                }
        }
    }
}