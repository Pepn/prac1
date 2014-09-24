using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Practicum1.gameobjects
{
    class PaddleAI : Paddle
    {
        Random random = new Random();
        private Ball ball;
        float difference;


        public PaddleAI(Texture2D sprite, Texture2D livesSprite, Vector2 position, float newVelocity, Keys key1, Keys key2, String name)
            : base(sprite, livesSprite, position, newVelocity, Keys.None, Keys.None, name)
        {

        }

        public override void HandleInput(InputHelper inputHelper)
        {
            //no input cause AI object

        }

        public override void Update(GameTime gametime)
        {
            difference = ball.Position.Y - position.Y;

            checkMaxRange();
            if (ball.Position.X > 600)
            {
                if (difference >= 50 || difference <= -50)
                {
                    if (difference > 0)
                    {
                        velocity.Y += 50 + random.Next(0, 30);
                    }
                    else
                    {
                        velocity.Y -= 50 + random.Next(0, 30);
                    }
                }
            }
            else
            {
                if (difference > 0)
                    velocity.Y = 50;
                else
                    velocity.Y = -50;
            }

            base.Update(gametime);
        }

        public Ball Ball
        {
            get { return ball; }
            set { ball = value; }
        }

        
    }
}
