using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Player : Entity
    {
        private Scene _tail;

        public Player(float x,float y,char icon = ' ',ConsoleColor color = ConsoleColor.White)
            : base(x,y,icon,color)
        {
            _tail = new Scene();
            Entity firstBlock = new Entity(_position.X, _position.Y, '■', Game.DefaultColor);
            _tail.AddEntity(firstBlock);
        }

        public void AddTail()
        {
            Entity block = new Entity(_position.X, _position.Y, '■', Game.DefaultColor);
            _tail.AddEntity(block);
        }
        public override void Start()
        {

        }
        public override void Update()
        {
            switch (Game.GetNextKey())
            {
                case ConsoleKey.D:
                    _velocity.X = 1;
                    _velocity.Y = 0;
                    break;
                case ConsoleKey.A:
                    _velocity.X = -1;
                    _velocity.Y = 0;
                    break;
                case ConsoleKey.S:
                    _velocity.X = 0;
                    _velocity.Y = 1;
                    break;
                case ConsoleKey.W:
                    _velocity.X = 0;
                    _velocity.Y = -1;
                    break;
            }

            base.Update();
        }
    }
}
