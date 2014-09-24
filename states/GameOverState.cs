using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Practicum1.gameobjects;
namespace Practicum1.states
{
    class GameOverState : State
    {
        Paddle winPaddle;
        TextObject winText;

        public override void Update(GameTime gameTime)
        {
            winPaddle = Practicum1.WinPaddle;
            if(winText == null)
            {
<<<<<<< HEAD
                winText = new TextObject(" ", new Vector2(Practicum1.Screen.X / 2 - 200, Practicum1.Screen.Y - 150), Color.Black, null, "winText");
=======
                winText = new TextObject(winPaddle.Name + " has won! Press space to return to main menu", new Vector2(Practicum1.Screen.X / 2 - 200, Practicum1.Screen.Y - 150), Color.Black, null, "winText");
>>>>>>> 629ab9ea4cde38d1d723a1b4ac52f4d08dc938e6
                this.Add(winText);
            }
            else
            {
<<<<<<< HEAD
<<<<<<< HEAD
                winText.Text = winPaddle.Name + " has won!\nPress space to return to main menu\nor press Escape to exit";
=======
                winText.Text = winPaddle.Name + " has won!\nPress space to return to main menu\nor press R to have a rematch";
>>>>>>> origin/master
=======
                winText.Text = winPaddle.Name + " has won!\nPress space to return to main menu";
>>>>>>> 629ab9ea4cde38d1d723a1b4ac52f4d08dc938e6
            }
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.IsKeyPressed(Keys.Space))
            {
                Practicum1.WinPaddle = null;
                Practicum1.GameStateManager.SwitchTo("mainMenuState");
            }
            else if (inputHelper.IsKeyPressed(Keys.Escape))
            {
                Practicum1.WinPaddle = null;
                Program.Game.Exit();
            }
            base.HandleInput(inputHelper);
        }
    }
}
