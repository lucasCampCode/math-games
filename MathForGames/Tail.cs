using System;
using System.Collections.Generic;
using System.Text;
using MathLib;

namespace MathForGames
{
    class Tail : Entity
    {

        public Tail(float x, float y, ConsoleColor color = ConsoleColor.White, char icon = '■')
            : base(x, y, icon, color)
        {

        }
        public void follow(Entity entity,float deltaTime)
        {
                base.Update(deltaTime);
                if ((entity.Position.X > Position.X) && (entity.Position != Position))
                {
                    Velocity.X = 1;
                }
                else if ((entity.Position.X < Position.X) && (entity.Position != Position))
                {
                    Velocity.X = -1;
                }
                else
                {
                    Velocity.X = 0;
                }
                if ((entity.Position.Y > Position.Y) && (entity.Position != Position))
                {
                    Velocity.Y = 1;
                }
                else if ((entity.Position.Y < Position.Y) && (entity.Position != Position))
                {
                    Velocity.Y = -1;
                }
                else
                {
                    Velocity.Y = 0;
                }
            
        }
        public void follow(Vector2 position,float deltaTime)
        {
            if ((position.X > Position.X) && (position != Position))
            {
                Velocity.X = 1;
            }
            else if ((position.X < Position.X) && (position != Position))
            {
                Velocity.X = -1;
            }
            else
            {
                Velocity.X = 0;
            }
            if ((position.Y > Position.Y) && (position != Position))
            {
                Velocity.Y = 1;
            }
            else if ((position.Y < Position.Y) && (position != Position))
            {
                Velocity.Y = -1;
            }
            else
            {
                Velocity.Y = 0;
            }
            base.Update(deltaTime);
        }



        public override void Draw()
        {
            base.Draw();
        }

    }
}
