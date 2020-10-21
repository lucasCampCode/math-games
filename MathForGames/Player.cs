using MathLib;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Player : Entity
    {
        private Tail[] _tails;
        public Player(float x,float y,Color rayColor, char icon = '■',ConsoleColor color = ConsoleColor.White)
            : base(x,y,rayColor,icon,color)
        {
            Tail firstTail = new Tail(x, y);
            _tails = new Tail[] {firstTail};
        }
        public override void Start()
        {
            base.Start();
        }
        public void addTail()
        {
            Tail[] newEntities = new Tail[_tails.Length + 1];
            //copy values from old array to the old array
            for (int i = 0; i < _tails.Length; i++)
            {
                newEntities[i] = _tails[i];
            }
            //sets the new entity at the end of the new array
            newEntities[_tails.Length] = new Tail(_tails[_tails.Length-1].Position.X, _tails[_tails.Length - 1].Position.Y);
            //set old array to the new array with the new entity
            _tails = newEntities;
        }
        public override void Update()
        {
            for (int i = 0; i < _tails.Length; i++)
            {
                if (i == 0)
                {
                    _tails[i].follow(Position);
                }
                else
                {
                    _tails[i].follow(_tails[i - 1]);
                }
            }
            int xVelocity = -Convert.ToInt32(Game.GetKeyPressed((int)KeyboardKey.KEY_A))
                + Convert.ToInt32(Game.GetKeyPressed((int)KeyboardKey.KEY_D));

            int yVelocity = -Convert.ToInt32(Game.GetKeyPressed((int)KeyboardKey.KEY_W))
                + Convert.ToInt32(Game.GetKeyPressed((int)KeyboardKey.KEY_S));
            switch (xVelocity)
            {
                case 1:
                    Velocity = new Vector2(1, 0);
                    break;
                case -1:
                    Velocity = new Vector2(-1, 0);
                    break;
            }
            switch (yVelocity)
            {
                case 1:
                    Velocity = new Vector2(0, 1);
                    break;
                case -1:
                    Velocity = new Vector2(0, -1);
                    break;
            }

            //if (Velocity.GetMagnitude() != 0)
            //{
            //    Velocity.X /= Velocity.GetMagnitude();
            //    Velocity.Y /= Velocity.GetMagnitude();
            //}
            base.Update();
            
        }
        public override void Draw()
        {
            for (int i = 0; i< _tails.Length; i++ )
            {
                _tails[i].Draw();
            }

            base.Draw();
        }
    }
}
