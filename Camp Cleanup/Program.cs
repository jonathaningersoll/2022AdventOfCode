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
            var c = new CampCleanup();
            c.PartOne();
        }        
    }

    class CampCleanup
    {
        public void PartOne()
        {
            var containedSections = 0;

            var i = File.ReadAllLines(@"input.txt").ToList();

            i.ForEach(pair => {
                var e = pair.Split(',');

                int oneStart = int.Parse(e[0].Split('-').First());
                int oneEnd = int.Parse(e[0].Split('-').Last());
                int twoStart = int.Parse(e[1].Split('-').First());
                int twoEnd = int.Parse(e[1].Split('-').Last());

                if(((oneStart >= twoStart) && (oneEnd <= twoEnd)) || ((twoStart >= oneStart) && (twoEnd <= oneEnd)))
                {
                    containedSections++;
                }
            });

            Console.WriteLine(containedSections);

            PartTwo(i);
        }

        public void PartTwo(List<string> input)
        {
            int containedSections = 0;
            input.ForEach(pair => {
                var e = pair.Split(',');

                int oneStart = int.Parse(e[0].Split('-').First());
                int oneEnd = int.Parse(e[0].Split('-').Last());
                int twoStart = int.Parse(e[1].Split('-').First());
                int twoEnd = int.Parse(e[1].Split('-').Last());

                var e1 = new List<int>();
                var e2 = new List<int>();
                
                for(int i = oneStart; i <= oneEnd; i++)
                {
                    e1.Add(i);
                }

                for(int t = twoStart; t <= twoEnd; t++)
                {
                    e2.Add(t);
                }

                if(e1.Intersect(e2).Count() > 0)
                {
                    containedSections += 1;
                }
            });
            Console.WriteLine(containedSections);
        }
    }
}