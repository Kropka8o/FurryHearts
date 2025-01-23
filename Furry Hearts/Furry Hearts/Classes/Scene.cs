using Furry_Hearts.Classes;
using Furry_Hearts.Methods;
using System;
using System.Collections.Generic;

namespace Furry_Hearts
{
    public class Scene
    {
        private string description;
        private List<Choice> choices;

        public Scene(string description, List<Choice> choices)
        {
            this.description = description;
            this.choices = choices;
        }

        public void Play()
        {
            Console.Clear();
            List<string> lines = new List<string> { description };

            for (int i = 0; i < choices.Count; i++)
            {
                lines.Add($"{i + 1}. {choices[i].Description}");
            }

            CenterText.CenterTextBoth(lines.ToArray());

            string input = CenterText.CenteredReadLine("Enter your choice: ");
            int choiceIndex = int.Parse(input) - 1;
            if (choiceIndex >= 0 && choiceIndex < choices.Count)
            {
                choices[choiceIndex].OnSelect.Invoke();
            }
            else
            {
                string error = "Invalid choice. Please try again.";
                CenterText.CenterTextHorizontally(error);
                Play();
            }
        }
    }
}