using MathLib;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Player : Entity
    {
        public Tail[] tails { get; private set; }
        
        public Player(float x,float y,Color rayColor, char icon = '■',ConsoleColor color = ConsoleColor.White)
            : base(x,y,rayColor,icon,color)
        {
            Tail firstTail = new Tail(x, y);
            tails = new Tail[] {firstTail};
        }
        public override void Start()
        {
            base.Start();
        }
        public void addTail()
        {
            Tail[] newEntities = new Tail[tails.Length + 1];
            //copy values from old array to the old array
            for (int i = 0; i < tails.Length; i++)
            {
                newEntities[i] = tails[i];
            }
            //sets the new entity at the end of the new array
            newEntities[tails.Length] = new Tail(tails[tails.Length-1].Position.X, tails[tails.Length - 1].Position.Y);
            //set old array to the new array with the new entity
            tails = newEntities;
        }
        public override void Update(float deltaTime)
        {
            for (int i = 0; i < tails.Length; i++)
            {
                if (i == 0)
                {
                    tails[i].follow(Position,deltaTime);
                }
                else
                {
                    tails[i].follow(tails[i - 1],deltaTime);
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

            //Velocity = Velocity.Normalized
            base.Update(deltaTime);
            for(int i = 1; i < tails.Length; i++)
            {
                if(Position.X == tails[i].Position.X && Position.Y == tails[i].Position.Y)
                {
                    Game.SetGameOver(true);
                }
            }
            
        }
        public override void Draw()
        {
            for (int i = 0; i< tails.Length; i++ )
            {
                tails[i].Draw();
            }

            base.Draw();
        }
    }
}
