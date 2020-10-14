using System;
using System.Collections.Generic;
using System.Text;
using MathLib;

namespace MathForGames
{
    class Entity
    {
        protected char _icon = '-';
        protected Vector2 _position;
        protected Vector2 _velocity;
        protected ConsoleColor _color;

        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        public Vector2 Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }

        public Entity()
        {
            _position = new Vector2();
            _velocity = new Vector2();
        }

        public Entity(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {

            _icon = icon;
            _position = new Vector2(x,y);
            _velocity = new Vector2();
            _color = color;
        }

        public virtual void Start()
        {

        }//start of entity

        public virtual void Update()
        {
            _position.X += _velocity.X;
            _position.Y += _velocity.Y;

            _position.X = Math.Clamp(_position.X, 0, Console.WindowWidth - 1);
            _position.Y = Math.Clamp(_position.Y, 0, Console.WindowHeight - 1);
        }//updates of entity

        public virtual void Draw()
        {
            Console.ForegroundColor = _color;
            Console.SetCursorPosition((int)_position.X, (int)_position.Y);
            Console.Write(_icon);
            Console.ForegroundColor = ConsoleColor.White;
        }//draws the entity

        public virtual void End()   
        {      

        }//ends the enitities
    }
}
