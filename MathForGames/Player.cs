using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Player : Entity
    {
        private Scene _tail = new Scene();
        public Player(float x,float y, char icon = '■',ConsoleColor color = ConsoleColor.White)
            : base(x,y,icon,color)
        {
        }

        public void AddTail()
        {
            Entity block;
            Entity[] entities = _tail.List;
            int lastTail = entities.Length-1;
            if (entities.Length > 0)
            {
                if (entities[lastTail].Velocity.X > 0)
                {
                    block = new Entity(entities[lastTail].Position.X - 1, entities[lastTail].Position.Y);
                    _tail.AddEntity(block);
                }
                else if (entities[lastTail].Velocity.X < 0)
                {
                    block = new Entity(entities[lastTail].Position.X + 1, entities[lastTail].Position.Y);
                    _tail.AddEntity(block);
                }
                if (entities[lastTail].Velocity.Y > 0)
                {
                    block = new Entity(entities[lastTail].Position.X, entities[lastTail].Position.Y - 1);
                    _tail.AddEntity(block);
                }
                else if (entities[lastTail].Velocity.Y < 0)
                {
                    block = new Entity(entities[lastTail].Position.X, entities[lastTail].Position.Y + 1);
                    _tail.AddEntity(block);
                }
            }
            else
            {
                block = new Entity(Position.X, Position.Y);
                _tail.AddEntity(block);
            }
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
            for (int i = 0; i < _tail.List.Length; i++)
            {
                _tail.List[i].Position += _velocity;
            }

            base.Update();
        }
        public override void Draw()
        {
            for (int i = 0; i < _tail.List.Length; i++)
            {
                _tail.Draw();
            }
            base.Draw();
        }
    }
}
