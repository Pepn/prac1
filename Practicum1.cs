using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Practicum1.states;
using Practicum1.gameobjects;

namespace Practicum1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Practicum1 : Game
    {
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;
        protected static Point screen;
        protected static SpriteFont gameFont;
        protected static GameStateManager gameStateManager;
        protected static InputHelper inputHelper;
        protected static Random random;
        protected static TimerManager timerManager;
        protected static Paddle winPaddle;
        protected static bool powerUpsOn = true;

        public Practicum1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            random = new Random();
            gameStateManager = new GameStateManager();
            inputHelper = new InputHelper();
            timerManager = new TimerManager();
            graphics.IsFullScreen = false;
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Point(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            gameFont = Content.Load<SpriteFont>("GameFont");
            gameStateManager.AddGameState("mainMenuState", new MainMenuState());
            gameStateManager.AddGameState("gameOverState", new GameOverState());
            gameStateManager.AddGameState("twoPlayerState", new TwoPlayerState(Content));
            gameStateManager.AddGameState("PlayerAIState", new PlayerAIState(Content));
            gameStateManager.AddGameState("TrolState", new TrolState(Content));
            gameStateManager.SwitchTo("mainMenuState");
        }

        public void ExitGame()
        {
            Exit();
        }
        
        protected override void Update(GameTime gameTime)
        {
            inputHelper.Update();
            gameStateManager.Update(gameTime);
            gameStateManager.HandleInput(inputHelper);
            timerManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.White);
            gameStateManager.Draw(gameTime, spriteBatch);
            spriteBatch.End();
        }

        public void setFullscreen()
        {
            graphics.IsFullScreen = !graphics.IsFullScreen;
        }
        public static Point Screen
        {
            get { return screen; }
        }

        public static SpriteFont GameFont
        {
            get { return gameFont; }
        }

        public static GameStateManager GameStateManager
        {
            get { return gameStateManager; }
        }

        public static InputHelper InputHelper
        {
            get { return inputHelper; }
        }

        public static Random Random
        {
            get { return random; }
        }

        public static TimerManager TimerManager
        {
            get { return timerManager; }
        }

        public static Paddle WinPaddle
        {
            get { return winPaddle; }
            set { winPaddle = value; }
        }

        public static bool PowerUpsOn
        {
            get { return powerUpsOn; }
            set { powerUpsOn = value; }
        }
    }
}