using System;

namespace Furry_Hearts.Classes
{
    public class Choice
    {
        public string Description { get; set; }
        public int Points { get; set; }
        public Action OnSelect { get; set; }

        public Choice(string description, int points, Action onSelect)
        {
            Description = description;
            Points = points;
            OnSelect = onSelect;
        }
    }
}