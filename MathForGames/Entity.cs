﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLib;
using Raylib_cs;

namespace MathForGames
{
    class Entity
    {
        protected char _icon = '-';
        protected Vector2 _position;
        protected Vector2 _velocity;
        protected ConsoleColor _color;
        protected Color _rayColor;

        public bool Started { get; private set; }

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
            _color = ConsoleColor.White;
            _rayColor = Color.WHITE;
        }

        public Entity(float x, float y, char icon = ' ', ConsoleColor color = ConsoleColor.White)
        {
            _rayColor = Color.WHITE;
            _icon = icon;
            _position = new Vector2(x,y);
            _velocity = new Vector2();
            _color = color;

        }
        public Entity(float x, float y, Color rayColor, char icon = ' ', ConsoleColor color = ConsoleColor.White)
            : this(x, y, icon, color)
        {
            _rayColor = rayColor;
        }

        public virtual void Start()
        {
            Started = true;
        }//start of entity

        public virtual void Update(float deltaTime)
        {
            _position += _velocity * (int)deltaTime;
            _position.X = Math.Clamp(_position.X, 0, Console.WindowWidth - 1);
            _position.Y = Math.Clamp(_position.Y, 0, Console.WindowHeight - 1);
        }//updates of entity

        public virtual void Draw()
        {
            int scale = 15;
            Raylib.DrawText(_icon.ToString(), (int)_position.X * scale, (int)_position.Y * scale,scale, Color.LIME);
            Raylib.DrawRectangle((int)_position.X * scale, (int)_position.Y * scale, scale, scale, _rayColor);
            Console.ForegroundColor = _color;
            Console.SetCursorPosition((int)_position.X, (int)_position.Y);
            Console.Write(_icon);
            Console.ForegroundColor = ConsoleColor.White;
        }//draws the entity

        public virtual void End()   
        {
            Started = false;
        }//ends the enitities
    }
}
