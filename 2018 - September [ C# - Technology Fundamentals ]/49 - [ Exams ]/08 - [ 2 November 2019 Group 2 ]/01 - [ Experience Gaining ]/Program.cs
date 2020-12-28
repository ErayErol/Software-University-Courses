using System;

namespace ExperienceGaining
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int battlesCount = int.Parse(Console.ReadLine());

            double totalCollectedExperience = 0;
            for (int i = 1; i <= battlesCount; i++)
            {
                double experienceFromBattle = double.Parse(Console.ReadLine());
                if (i % 3 == 0)
                {
                    experienceFromBattle += experienceFromBattle * 0.15;
                }

                if (i % 5 == 0)
                {
                    experienceFromBattle -= experienceFromBattle * 0.10;
                }

                totalCollectedExperience += experienceFromBattle;

                if (totalCollectedExperience >= neededExperience)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {i} battles.");

                    break;
                }
            }

            if (neededExperience > totalCollectedExperience)
            {
                double neededExperienceMore = neededExperience - totalCollectedExperience;
                Console.WriteLine($"Player was not able to collect the needed experience, {neededExperienceMore:f2} more needed.");
            }
        }
    }
}
