using System;
using System.Text;
using Furry_Hearts.Classes;
using Furry_Hearts.Methods;

namespace Furry_Hearts
{
    public enum GameState
    {
        MainMenu,
        StartGame,
        HowToPlay,
        ExitGame
        // Add more states as needed
    }

    public class Game
    {
        private GameState currentState;
        private Chapter currentChapter;
        private int loveMeter;
        private List<Ending> endings;


        public Game()
        {
            currentState = GameState.MainMenu;
            loveMeter = 0;
            InitializeEndings();
        }
        private void InitializeEndings()
        {
            endings = new List<Ending>
            {
                new Ending("You lived happily ever after.", 100),
                new Ending("You had a decent life.", 50),
                new Ending("You struggled but survived.", 0)
            };
        }

        public void Run()
        {
            while (currentState != GameState.ExitGame)
            {
                switch (currentState)
                {
                    case GameState.MainMenu:
                        ShowMainMenu();
                        break;
                    case GameState.StartGame:
                        StartGame();
                        break;
                    case GameState.HowToPlay:
                        ShowHowToPlay();
                        break;
                        // Add more cases as needed
                }
            }
        }

        private void ShowMainMenu()
        {
            Console.Clear();
            string[] title = new string[]
            {
                ".----. .-. .-. .---.  .---.  .-.  .-.     .-. .-. .----.   .--.   .---.  .-----.  .----. ",
                "} |__} | } { | } }}_} } }}_}  \\ \\/ /      { {_} | } |__}  / {} \\  } }}_} `-' '-' { {__-` ",
                "} '_}  \\ `-' / | } \\  | } \\    `-\\ }      | { } } } '__} /  /\\  \\ | } \\    } {   .-._} } ",
                "  `--'    `---'  `-'-'  `-'-'      `-'      `-' `-' `----' `-'  `-' `-'-'    `-'   `----'   "
            };

            foreach (var line in title)
            {
                CenterText.CenterTextHorizontally(line);
            }
            string[] menuOptions = new string[]
            {
                "1. Start Game",
                "2. How To Play",
                "3. Exit Game"
            };

            CenterText.CenterTextBoth(menuOptions);
            string choice = CenterText.CenteredReadLine("Enter your choice: ");

            switch (choice)
            {
                case "1":
                    currentState = GameState.StartGame;
                    break;
                case "2":
                    currentState = GameState.HowToPlay;
                    break;
                case "3":
                    currentState = GameState.ExitGame;
                    break;
                default:
                    Console.Clear();
                    CenterText.CenterTextHorizontally("Invalid choice. Please try again.");
                    break;
            }
        }

        private void StartGame()
        {
            Console.Clear();
            CenterText.CenterTextHorizontally("Starting game...");

            var choices = new List<Choice>
    {
        new Choice("Continue", 10, () =>
        {
            CenterText.CenterTextHorizontally("You chose to continue.");
            loveMeter += 10;
            currentChapter.NextScene();
        })
    };

            var choices2 = new List<Choice>
    {
        new Choice("Pet the puppy", 10, () =>
        {
            Console.Clear();
            string[] description = {
                "The puppy wags its tail happily and licks your hand.",
                "You feel a warm fuzzy feeling in your heart."
            };
            CenterText.CenterTextBoth(description);
            loveMeter += 10;
            currentChapter.NextScene();
        }),
        new Choice("Ignore the puppy", 0, () =>
        {
            CenterText.CenterTextHorizontally("You chose to ignore the puppy.");
            currentChapter.NextScene();
        })
    };

            var scenes = new List<Scene>
    {
        new Scene("This is the start of your story.", choices),
        new Scene("You are walking in the park and you see a lost puppy. What do you do?", choices2)
    };

            currentChapter = new Chapter(scenes)
            {
                Title = "Intro",
                Description = "This is the introduction chapter.",
                Scenes = scenes
            };

            currentChapter.Start(); // Start the chapter to display the scenes
        }

        private void ShowHowToPlay()
        {
            Console.Clear();
            Console.WriteLine("How to play...");
            // Add instructions here
            Console.ReadLine();
            currentState = GameState.MainMenu;
        }
    }
}