using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MathForGames
{
    class Entity
    {
        private char _icon = '-';
        private int _x = 0;
        private int _y = 0;
        public void Start()
        {

        }//start of entity

        public void Update()
        {
            if (Game.CheckKey(ConsoleKey.A)) 
                _x--;
            if (Game.CheckKey(ConsoleKey.D))
                _x++;
        }//updates of entity

        public void Draw()
        {
            Console.SetCursorPosition(_x,_y);
            Console.Write(_icon);
        }//draws the entity

        public void End()
        {      

        }//ends the enitities
    }
}
