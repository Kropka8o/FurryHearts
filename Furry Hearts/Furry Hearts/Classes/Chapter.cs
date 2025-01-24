using Furry_Hearts.Classes;
using Furry_Hearts.Methods;
using System;
using System.Collections.Generic;

namespace Furry_Hearts
{
    public class Chapter
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Scene> Scenes;
        public int currentSceneIndex;
        private Game gameInstance;

        public Chapter(List<Scene> scenes, Game game)
        {
            this.Scenes = scenes;
            currentSceneIndex = 0;
            this.gameInstance = game;
        }

        public void Start()
        {
            if (Scenes.Count > 0)
            {
                Scenes[currentSceneIndex].Play();
            }
        }

        public void NextScene()
        {
            if (currentSceneIndex < Scenes.Count - 1)
            {
                currentSceneIndex++;
                Scenes[currentSceneIndex].Play();
            }
            else
            {
                Console.ReadLine();
                Console.Clear(); 
                bool endingDisplayed = Ending.DisplayEnding(gameInstance.endings, gameInstance.loveMeter);
                if (endingDisplayed)
                {
                    gameInstance.SetState(GameState.MainMenu);
                }
            }

        }
    }
}