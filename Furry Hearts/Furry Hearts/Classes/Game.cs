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
    }

    public class Game
    {
        private GameState currentState;
        private Chapter currentChapter;
        public int loveMeter;
        public List<Ending> endings;


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
                    CenterText.CenterTextHorizontally("Invalid choice. Please choose a number.");
                    Thread.Sleep(800);
                    break;
            }
        }

        private void StartGame()
        {

            var choices = new List<Choice>
            {
                new Choice("Continue", 10, () =>
                {
                    CenterText.CenterTextHorizontally("You chose to continue.");
                    loveMeter += 100;
                    currentChapter.NextScene();
                })
            };

            var choices2 = new List<Choice>
            {
                new Choice("Pet the puppy", 100, () =>
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

            currentChapter = new Chapter(scenes, this)
            {
                Title = "Intro",
                Description = "This is the introduction chapter.",
                Scenes = scenes
            };

            currentChapter.Start();
        }

        private void ShowHowToPlay()
        {
            string[] instructions = new string[]
            {
                "Furry Hearts is a text-based game where you make choices to progress through the story.",
                "You will be presented with a scenario and a list of choices.",
                "To make a choice, type the number of the choice and press 'Enter'.",
                "Your choices will affect the outcome of the story and your lovemeter.",
                "The goal is to reach the highest lovemeter possible to romance Jasper, who is your crush.",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "Press Enter to return to the main menu..."
            };
            CenterText.CenterTextBoth(instructions);
            Console.ReadLine();
            currentState = GameState.MainMenu;
        }

        public void SetState(GameState newState)
        {
            currentState = newState;
        }
    }
}