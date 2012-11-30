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
        private RenderTarget2D renderTarget2D;

        //Properties
        public IStateGame GameState
        {
            get { return this.gameState; }
            set { this.gameState = value; }
        }

        public SpriteBatch SpriteBatch
        {
            get { return this.spriteBatch; }
        }

        //Constructor
        public PyramidPanic()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            Mouse.SetPosition
            this.Window.Title = "Pyramid Panic";
            this.graphics.PreferredBackBufferWidth = 640;
            this.graphics.PreferredBackBufferHeight = 480;
            this.graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            this.gameState = new StartScene(this);
            this.renderTarget2D = new RenderTarget2D(GraphicsDevice,
                                                     GraphicsDevice.PresentationParameters.BackBufferWidth,
                                                     GraphicsDevice.PresentationParameters.BackBufferHeight,
                                                     false,
                                                     SurfaceFormat.Color,
                                                     DepthFormat.None);
        }

        protected override void UnloadContent()
        {
           
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            
            this.gameState.Update(gameTime);
            Input.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.SetRenderTarget(this.renderTarget2D);

            this.GraphicsDevice.Clear(Color.CornflowerBlue);
            this.spriteBatch.Begin();
            this.gameState.Draw(gameTime);
            this.spriteBatch.End();

            this.GraphicsDevice.SetRenderTarget(null);
            this.GraphicsDevice.Clear(Color.Black);

            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.renderTarget2D,
                                  new Vector2(GraphicsDevice.PresentationParameters.BackBufferWidth/2, GraphicsDevice.PresentationParameters.BackBufferHeight/2),
                                  null,
                                  Color.White,
                                  0f,
                                  new Vector2(this.renderTarget2D.Width/2, this.renderTarget2D.Height/2),
                                  0.8f,
                                  SpriteEffects.None,
                                  0f);                                      
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
