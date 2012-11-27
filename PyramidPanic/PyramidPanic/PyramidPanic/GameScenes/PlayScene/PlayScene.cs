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
    public class PlayScene : IStateGame
    {
        //Fields
        private PyramidPanic game;
        private Level level;
        private int levelNumber = 2;

        //Constructor
        public PlayScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }

        //Initialize
        public void Initialize()
        {
            this.LoadContent();
        }

        //LoadContent
        public void LoadContent()
        {
            this.level = new Level(this.game, this.levelNumber);
        }

        //Update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Escape))
            {
                this.game.GameState = new StartScene(this.game);
            }

            if (Input.MouseEdgeDetectPressLeft())
            {
                this.game.Exit();
            }
            this.level.Update(gameTime);
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.White);
            this.level.Draw(gameTime);
        }
    }
}
