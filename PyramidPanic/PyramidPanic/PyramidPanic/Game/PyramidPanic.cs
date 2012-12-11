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

namespace PyramidPanic
{
    public class PyramidPanic : Microsoft.Xna.Framework.Game
    {
        //Fields
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private IStateGame gameState;

        //*******RenderTarget2D****************

        public RenderTarget2D renderTarget2D;

        //*************************************
        
        //*******Bloom *******************
        private BloomComponent bloom;
        int bloomSettingsIndex = 5;
        SpriteFont spriteFont;
        
        KeyboardState lastKeyboardState = new KeyboardState();
        GamePadState lastGamePadState = new GamePadState();
        KeyboardState currentKeyboardState = new KeyboardState();
        GamePadState currentGamePadState = new GamePadState();
        //*****************************

        //Properties
        public SpriteFont SpriteFont
        {
            get { return this.spriteFont; }
        }

        public IStateGame GameState
        {
            get { return this.gameState; }
            set { this.gameState = value; }
        }

        public SpriteBatch SpriteBatch
        {
            get { return this.spriteBatch; }
        }

        public GraphicsDevice Graphics
        {
            get { return this.GraphicsDevice; }
        }

        //Constructor
        public PyramidPanic()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
            this.IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1.0f/60.0f);

           
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            this.Window.Title = "Pyramid Panic";
            this.graphics.PreferredBackBufferWidth = 640;
            this.graphics.PreferredBackBufferHeight = 480;
            this.graphics.ApplyChanges();
            base.Initialize();

        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);

            //********Bloom*************************************************************
            this.bloom = new BloomComponent(this);
            this.bloom.Settings = BloomSettings.PresetSettings[this.bloomSettingsIndex];
            //**************************************************************************
            
            spriteFont = Content.Load<SpriteFont>(@"Effects\hudFont");

            //************RenderTarget2D********************************************************************
            this.renderTarget2D = new RenderTarget2D(GraphicsDevice,
                                                     GraphicsDevice.PresentationParameters.BackBufferWidth,
                                                     GraphicsDevice.PresentationParameters.BackBufferHeight,
                                                     false,
                                                     SurfaceFormat.Color,
                                                     DepthFormat.None);
            //***********************************************************************************************
            this.gameState = new StartScene(this);
            
        }

        protected override void UnloadContent()
        {
            this.bloom.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //********Bloom****************************
            HandleInput();
            //*****************************************

            this.gameState.Update(gameTime);
            Input.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {     

            //************renderTarget2D********************************
            this.GraphicsDevice.SetRenderTarget(this.renderTarget2D);
            this.GraphicsDevice.Clear(Color.CornflowerBlue);
            this.spriteBatch.Begin();
            this.gameState.Draw(gameTime);
            this.spriteBatch.End();
            this.GraphicsDevice.SetRenderTarget(null);
            this.GraphicsDevice.Clear(Color.Black);
            //***********************************************************

            //********Bloom**********************************************
            bloom.BeginDraw();

            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.renderTarget2D,
                                  new Vector2(GraphicsDevice.PresentationParameters.BackBufferWidth / 2, GraphicsDevice.PresentationParameters.BackBufferHeight / 2),
                                  null,
                                  Color.White,
                                  0f,
                                  new Vector2(this.renderTarget2D.Width / 2, this.renderTarget2D.Height / 2),
                                  0.98f,
                                  SpriteEffects.None,
                                  0f);
            this.spriteBatch.End();

            //Has own spriteBatch.Begin() and spriteBatch.End()
            this.bloom.Draw(gameTime);

            base.Draw(gameTime);            
            //**********************************************************

            //DrawOverlayText(); 
        }

        private void HandleInput()
        {
            lastKeyboardState = currentKeyboardState;
            lastGamePadState = currentGamePadState;

            currentKeyboardState = Keyboard.GetState();
            currentGamePadState = GamePad.GetState(PlayerIndex.One);

            
            // Switch to the next bloom settings preset?
            if ((currentGamePadState.Buttons.A == ButtonState.Pressed &&
                 lastGamePadState.Buttons.A != ButtonState.Pressed) ||
                (currentKeyboardState.IsKeyDown(Keys.A) &&
                 lastKeyboardState.IsKeyUp(Keys.A)))
            {
                bloomSettingsIndex = (bloomSettingsIndex + 1) %
                                     BloomSettings.PresetSettings.Length;

                bloom.Settings = BloomSettings.PresetSettings[bloomSettingsIndex];
                bloom.Visible = true;
            }

            // Toggle bloom on or off?
            if ((currentGamePadState.Buttons.B == ButtonState.Pressed &&
                 lastGamePadState.Buttons.B != ButtonState.Pressed) ||
                (currentKeyboardState.IsKeyDown(Keys.B) &&
                 lastKeyboardState.IsKeyUp(Keys.B)))
            {
                 this.bloom.Visible = !this.bloom.Visible;
            }

            // Cycle through the intermediate buffer debug display modes?
            if ((currentGamePadState.Buttons.X == ButtonState.Pressed &&
                 lastGamePadState.Buttons.X != ButtonState.Pressed) ||
                (currentKeyboardState.IsKeyDown(Keys.X) &&
                 lastKeyboardState.IsKeyUp(Keys.X)))
            {
                bloom.Visible = true;
                bloom.ShowBuffer++;

                if (bloom.ShowBuffer > BloomComponent.IntermediateBuffer.FinalResult)
                    bloom.ShowBuffer = 0;
            }
        }

        void DrawOverlayText()
        {
            string text = "A = settings (" + bloom.Settings.Name + ")\n" +
                          "B = toggle bloom (" + (this.bloom.Visible ? "on" : "off") + ")\n" +
                          "X = show buffer (" + bloom.ShowBuffer.ToString() + ")";

            this.spriteBatch.Begin();

            // Draw the string twice to create a drop shadow, first colored black
            // and offset one pixel to the bottom right, then again in white at the
            // intended position. This makes text easier to read over the background.
            this.spriteBatch.DrawString(spriteFont, text, new Vector2(65, 65), Color.Black);
            this.spriteBatch.DrawString(spriteFont, text, new Vector2(64, 64), Color.White);

            this.spriteBatch.End();
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (PyramidPanic game = new PyramidPanic())
            {
                game.Run();
            }
        }
    }
}
