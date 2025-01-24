using System;
using Furry_Hearts.Classes;
using Furry_Hearts.Methods;

namespace Furry_Hearts.Classes
{
    public class Ending
    {
        public string Description { get; set; }
        public int MinLovePoints { get; set; }

        public Ending(string description, int minLovePoints)
        {
            Description = description;
            MinLovePoints = minLovePoints;
        }

        public bool IsAchievable(int lovePoints)
        {
            return lovePoints >= MinLovePoints;
        }

        public static bool DisplayEnding(List<Ending> endings, int lovePoints)
        {
            Ending ending = endings.FindLast(e => e.IsAchievable(lovePoints));
            if (ending != null)
            {
                string[] description = {ending.Description };
                CenterText.CenterTextBoth(description);
            }
            else
            {
                string[] error = { "No ending found." };
                CenterText.CenterTextBoth(error);
            }
            string[] text = { 
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "Thank you for playing Furry Hearts!",
                "Press Enter to return to the main menu..."
            };
            CenterText.CenterTextBoth(text);
            Console.ReadLine();
            return true;
        }
    }
}

    