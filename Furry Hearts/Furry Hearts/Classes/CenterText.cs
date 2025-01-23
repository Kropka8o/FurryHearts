using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furry_Hearts.Methods
{
    internal class CenterText
    {
        private static int CalculateHorizontalPosition(string text)
        {
            int screenWidth = Console.WindowWidth;
            int stringWidth = text.Length;
            return (screenWidth / 2) - (stringWidth / 2);
        }

        private static int CalculateVerticalPosition(int totalLines)
        {
            int screenHeight = Console.WindowHeight;
            return (screenHeight / 2) - (totalLines / 2);
        }

        public static void CenterTextHorizontally(string text)
        {
            int horizontalPosition = CalculateHorizontalPosition(text);
            Console.WriteLine(text.PadLeft(horizontalPosition + text.Length));
        }

        public static void CenterTextBoth(string[] texts)
        {
            int startingVerticalPosition = CalculateVerticalPosition(texts.Length);
            for (int i = 0; i < texts.Length; i++)
            {
                int horizontalPosition = CalculateHorizontalPosition(texts[i]);
                Console.SetCursorPosition(horizontalPosition, startingVerticalPosition + i);
                Console.WriteLine(texts[i]);
            }
        }

        public static string CenteredReadLine(string prompt)
        {
            int horizontalPosition = CalculateHorizontalPosition(prompt);
            Console.SetCursorPosition(horizontalPosition, Console.CursorTop);
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}