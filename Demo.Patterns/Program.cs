using System;

namespace Demo.Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleSample();

            PlayRockPaperScissors();

            PropertyPattern();
        }

        private static void SimpleSample()
        {
            Systembolaget_Sergel.IsOpen(DayOfWeek.Monday);
            Systembolaget_Sergel.IsOpen(DayOfWeek.Sunday);
        }

        private static void PlayRockPaperScissors()
        {
            const string rock = "rock";
            const string paper = "paper";
            const string scissors = "scissors";

            Console.WriteLine(RockPaperScissors.Play(rock, paper));
            Console.WriteLine(RockPaperScissors.Play(scissors, paper));
            Console.WriteLine(RockPaperScissors.Play(rock, scissors));

            Console.WriteLine(RockPaperScissors.Play(rock, rock));
        }

        private static void PropertyPattern()
        {
            var saturday_1530 = new DateTime(2019, 10, 11, 15, 30, 0);

            bool is_Open_When_I_Run_Out_Of_Booze = Systembolaget_Sergel.IsOpen(saturday_1530);
            bool is_Open_On_Christmas_Eve = Systembolaget_Sergel.IsOpen(DateTime.Parse("2019-12-24"));
        }
    }
}
