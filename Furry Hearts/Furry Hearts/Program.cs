using System;
using System.Text;
using Furry_Hearts;
using Furry_Hearts.Methods;

class Program
{
    static void Main()
    {
        // Set console encoding to UTF-8
        Console.OutputEncoding = Encoding.UTF8;

        // Clear the console
        Console.Clear();

        Game game = new Game();
        game.Run();
    }
}