using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RucksackReorganization
{
    class Program
    {        
        static void Main(string[] args)
        {
            var r = new RucksackReorganization();
            r.PartOne();
        }        
    }

    class RucksackReorganization
    {
        public void PartOne()
        {
            int priorities = 0;
            var i = File.ReadAllLines(@"input.txt").ToList();

            i.ForEach(sack => {
                var lowerList = sack.ToList().GetRange(0, (sack.Count()/2));
                var upperList = sack.ToList().GetRange((sack.Count()/2) ,(sack.Count()/2));
                var item = lowerList.Intersect(upperList).First();

                priorities += PrioritySum(item);
            });
            Console.WriteLine(priorities);

            PartTwo(i);
        }

        public void PartTwo(List<string> input)
        {
            int priorities = 0;
            for(int i = 0; i < (input.Count - 2); i += 3)
            {
                var intersect = input[i].Intersect(input[i + 1].Intersect(input[i + 2]));
                intersect.ToList().ForEach(x => System.Console.WriteLine(x));
                priorities += PrioritySum(intersect.First());
            }
            Console.WriteLine(priorities);
        }

        public int PrioritySum(char ascii)
        {
            return (ascii > 96 && ascii < 123) ? ascii - 96 : ascii - 38;
        }
    }
}