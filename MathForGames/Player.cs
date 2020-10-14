﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Player : Entity
    {
        public Player(float x,float y,char icon = ' ',ConsoleColor color = ConsoleColor.White)
            : base(x,y,icon,color)
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