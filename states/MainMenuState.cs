using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Practicum1;
using Practicum1.gameobjects;

namespace Practicum1.states
{
    class MainMenuState : State
    {
        TextObject pressStartText, pressPText, powerUpsToggleText, powerUpsToggleText2;
        string powerUpText;
        Color powerUpColor;
        public MainMenuState()
        {
<<<<<<< HEAD
            pressStartText = new TextObject("Press to Play :\n<1> Two Players\n<2> player vs AI\n<3> Trololol??", new Vector2(Practicum1.Screen.X/2-110, Practicum1.Screen.Y/2-50), Color.Black, null, "Main Menu Text");
=======
            pressPText = new TextObject("Press <P> to\ntoggle powerups", new Vector2(Practicum1.Screen.X - 250, 25), Color.Black, null, "Press P Text");
            powerUpsToggleText = new TextObject("Powerups: ", new Vector2(Practicum1.Screen.X - 250, 90), Color.Black, null, "PowerUps Toggle Text");
            powerUpsToggleText2 = new TextObject("On", new Vector2(Practicum1.Screen.X - 100, 90), Color.Green, null, "PowerUps Toggle Text 2");
            pressStartText = new TextObject("Press <1> to begin\na game with two players", new Vector2(Practicum1.Screen.X/2-180, Practicum1.Screen.Y/2-50), Color.Black, null, "Main Menu Text");

            this.Add(pressPText);
            this.Add(powerUpsToggleText);
            this.Add(powerUpsToggleText2);
>>>>>>> 629ab9ea4cde38d1d723a1b4ac52f4d08dc938e6
            this.Add(pressStartText);
        }
        
        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.IsKeyPressed(Keys.D1))
            {
                Practicum1.GameStateManager.SwitchTo("twoPlayerState");
            }
<<<<<<< HEAD
            else if (inputHelper.IsKeyPressed(Keys.D2))
            {
                Practicum1.GameStateManager.SwitchTo("PlayerAIState");
            }
            else if (inputHelper.IsKeyPressed(Keys.D3))
            {
                Practicum1.GameStateManager.SwitchTo("TrolState");
=======

            if (inputHelper.IsKeyPressed(Keys.P))
            {
                Practicum1.PowerUpsOn = !Practicum1.PowerUpsOn;
                if (Practicum1.PowerUpsOn)
                {
                    powerUpText = "On";
                    powerUpColor = Color.Green;
                }
                else
                {
                    powerUpText = "Off";
                    powerUpColor = Color.Red;
                }

                powerUpsToggleText2.Text = "" + powerUpText;
                powerUpsToggleText2.Color = powerUpColor;

>>>>>>> 629ab9ea4cde38d1d723a1b4ac52f4d08dc938e6
            }
        }
    }
}
