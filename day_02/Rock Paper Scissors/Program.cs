using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {        
        static void Main(string[] args)
        {
            var RockPaperScissors = new RockPaperScissors();
            RockPaperScissors.Run();
        }
    }

    class RockPaperScissors
    {
        int score = 0;
        public void Run()
        {
            var i = File.ReadAllLines(@"input.txt").ToList();
            //.ToList().Select(round => EvaluateGame(round));
            //i.ForEach(round => PartOne(round));
            i.ForEach(round => PartTwo(round));
        }

        public int PartOne(string round)
        {
            round = round.Replace('A','1');
            round = round.Replace('B','2');
            round = round.Replace('C','3');
            round = round.Replace('X','1');
            round = round.Replace('Y','2');
            round = round.Replace('Z','3');

            var elf = int.Parse(round.Split(' ')[0]);
            var me = int.Parse(round.Split(' ')[1]);

            int final = elf + me;

            if(elf == me)
            {
                score += 3 + me;
            } else if((elf == 1 && me == 3) || (elf == 2 && me == 1) || (elf == 3 && me == 2))
            {
                score += 0 + me;
            } else
            {
                score += 6 + me;
            }

            Console.WriteLine($"My choice: {me}, Elf choice: {elf}, my score: {score}.");
            return 0;
        }

        public void PartTwo(string round){
            // A = Rock
            // B = Paper
            // C = Scissors

            // X = Lose
            // Y = Draw
            // Z = Win

            if(round.Split(' ')[1] == "Y")
            {
                round = round.Replace(round.ToList().Last(), round.ToList().First());
            } else if(round.Split(' ')[1] == "X")
            {
                if(round.Split(' ')[0] == "A")
                {
                    round = round.Replace(round.ToList().Last(), 'Z');
                }else if(round.Split(' ')[0] == "C")
                {
                    round = round.Replace(round.ToList().Last(), 'Y');
                }
            } else if(round.Split(' ')[1] == "Z")
            {
                if(round.Split(' ')[0] == "A")
                {
                    round = round.Replace(round.ToList().Last(), 'Y');
                } else if(round.Split(' ')[0] == "C")
                {
                    round = round.Replace(round.ToList().Last(), 'X');
                }
            }

            PartOne(round);
        }
    }
}