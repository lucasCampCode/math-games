using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
        private Scene _scene;
        public Random rng;

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.DarkCyan;

        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        //return weather or not the specified consoleKey is pressed
        public static ConsoleKey GetNextKey()
        {
            if (!Console.KeyAvailable)
            {
                return 0;
            }

            return Console.ReadKey(true).Key;
        }

        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            Console.CursorVisible = false;
            _scene = new Scene();
            Entity entity = new Entity(Console.WindowWidth/2,Console.WindowHeight/2,'■',ConsoleColor.Green);
            Player player = new Player(5, 5, '■', ConsoleColor.Red);
            _scene.AddEntity(entity);
            _scene.AddEntity(player);
        }
        
        //Called every frame.
        public void Update()
        {
            _scene.Update();
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Console.Clear();
            _scene.Draw();
        }


        //Called when the game ends.
        public void End()
        {

        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while(!_gameOver)
            {
                Update();
                Draw();
                while (Console.KeyAvailable) 
                    Console.ReadKey(true);
                Thread.Sleep(30);
            }

            End();
        }
    }
}
