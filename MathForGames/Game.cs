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
        private readonly Random rng = new Random();
        private Entity _entity = new Entity(20,20, '■', ConsoleColor.Green);
        private Player _player = new Player(5, 5, '■', ConsoleColor.Red);

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
            _scene.AddEntity(_entity);
            _scene.AddEntity(_player);
        }
        
        //Called every frame.
        public void Update()
        {

            _scene.Update();
            if (_player.Position.X == _entity.Position.X && _player.Position.Y == _entity.Position.Y)
            {
                _entity.Position.X = rng.Next(0, Console.WindowWidth);
                _entity.Position.Y = rng.Next(0, Console.WindowHeight);
            }
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Console.Clear();
            _scene.Draw();
            _player.Draw();
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
                Thread.Sleep(250);
            }

            End();
        }
    }
}
