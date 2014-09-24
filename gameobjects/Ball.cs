﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Practicum1.gameobjects;
using Practicum1.states;
using System.Diagnostics;

namespace Practicum1.gameobjects
{
    public class Ball : GameObject
    {
        Random random = new Random();
        double direction, speed, startSpeed;
        List<Paddle> paddleList = new List<Paddle>();
        Paddle lastBouncePaddle = null;

        public Ball(Texture2D sprite, Vector2 position, double speed, List<Paddle> paddleList, string name)
            : base(sprite, position, name)
        {
            direction = random.NextDouble() * 2 * Math.PI;
            this.speed = speed;
            startSpeed = speed;
            this.paddleList = paddleList;
        }

        public override void Update(GameTime gameTime)
        {
            velocity.X = (float)(speed * Math.Cos(direction));
            velocity.Y = (float)(speed * Math.Sin(direction));
            
            if((position.Y < 0 && velocity.Y < 0)
                || (position.Y > Practicum1.Screen.Y-sprite.Height && velocity.Y > 0))
            {
                Bounce();
            }
            foreach(Paddle paddle in paddleList)
            {
                if (CheckCollision(paddle))
                    Bounce(paddle);
            }

            if (position.X < 0 - sprite.Width)
                foreach (Paddle paddle in paddleList)
                    if (paddle.Name.Equals("Player 1"))
                    {
                        paddle.Lives = paddle.Lives - 1;
                        Reset(paddle);
                    }
                        

            if (position.X > Practicum1.Screen.X)
                foreach (Paddle paddle in paddleList)
                    if (paddle.Name.Equals("Player 2"))
                    {
                        paddle.Lives = paddle.Lives - 1;
                        Reset(paddle);
                    }
            foreach (PowerUp pwrUp in TwoPlayerState.PowerUpList)
            {
                if(CheckCollision(pwrUp) && pwrUp.Visible)
                {
                    Debug.Print("collision between ball and " + pwrUp.Name);
                    if (lastBouncePaddle != null)
                    {
                        foreach (Paddle paddle in paddleList)
                        {
                            if ((pwrUp.ChosenType == PowerUpType.OPSmaller || pwrUp.ChosenType == PowerUpType.OPSlower) && !paddle.Name.Equals(lastBouncePaddle.Name))
                            {
                                paddle.HandlePowerup(pwrUp.ChosenType);
                                Debug.Print("poweruptype is " + pwrUp.ChosenType + " and is for " + paddle.Name);
                            }
                            else if ((pwrUp.ChosenType == PowerUpType.TPBigger || pwrUp.ChosenType == PowerUpType.TPFaster) && paddle.Name.Equals(lastBouncePaddle.Name))
                            {
                                paddle.HandlePowerup(pwrUp.ChosenType);
                                Debug.Print("poweruptype is " + pwrUp.ChosenType + " and is for " + paddle.Name);
                            }
                        }
                    }
                    pwrUp.Reset();
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
<<<<<<< HEAD
            // debugging
            /*
=======
            /* debugging
>>>>>>> origin/master
            int i = 0;
            foreach(Paddle paddle in paddleList)
            {
                spriteBatch.DrawString(Practicum1.GameFont, "" + paddle.Name + "  " + paddle.BoundingBox + "  " + CheckCollision(paddle), new Vector2(50, 0+i*20), Color.Black);
                i++;
            }
            spriteBatch.DrawString(Practicum1.GameFont, "velocity: " + velocity, new Vector2(100, 60), Color.Black);
            spriteBatch.DrawString(Practicum1.GameFont, "position: " + BoundingBox, new Vector2(100, 80), Color.Black);
<<<<<<< HEAD
            spriteBatch.DrawString(Practicum1.GameFont, "direction: " + direction, new Vector2(100, 100), Color.Black);
            */
=======
            spriteBatch.DrawString(Practicum1.GameFont, "direction: " + direction, new Vector2(100, 100), Color.Black);*/
>>>>>>> origin/master
            base.Draw(gameTime, spriteBatch);
        }

        public bool CheckCollision(GameObject obj)
        {
            Rectangle otherBounds = obj.BoundingBox;
            return BoundingBox.Intersects(otherBounds);
        }

        public void Bounce()
        {            
            direction = 2 * Math.PI - direction;
        }

        public void Bounce(Paddle paddle)
        {
            if(paddle.Name.Equals("Player 1"))
            {
                float relativeIntersectY = (paddle.Position.Y + ((paddle.Sprite.Height * paddle.SpriteScale) / 2) - position.Y);
                float normalizedIntersectY = (relativeIntersectY / ((paddle.Sprite.Height * paddle.SpriteScale) / 2));
                direction = normalizedIntersectY * (-1 * Math.PI / 3);
                
            }
            else if(paddle.Name.Equals("Player 2"))
            {
                float relativeIntersectY = (paddle.Position.Y + ((paddle.Sprite.Height * paddle.SpriteScale) / 2) - position.Y);
                float normalizedIntersectY = (relativeIntersectY / ((paddle.Sprite.Height * paddle.SpriteScale) / 2)); 
                direction = Math.PI - normalizedIntersectY * (-1 * Math.PI / 3);
            }
<<<<<<< HEAD
            lastBounce = paddle;
            speed *= 1.05;
            if (speed > 1000)
                speed = 1000;
=======
            lastBouncePaddle = paddle;
            speed *= 1.04;
>>>>>>> 629ab9ea4cde38d1d723a1b4ac52f4d08dc938e6
        }


        public void Reset(Paddle paddle)
        {
            position = new Vector2(Practicum1.Screen.X / 2, Practicum1.Screen.Y / 2);
            
            if (paddle.Name.Equals("Player 1"))
                direction = 0.75 * Math.PI + random.NextDouble() * 0.5 * Math.PI;
            else if (paddle.Name.Equals("Player 2"))
                direction = 0.25 * Math.PI - random.NextDouble() * 0.5 * Math.PI;
            lastBouncePaddle = null;
            speed = startSpeed;
        }
    }
}