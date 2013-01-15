﻿using System;
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
        private static int levelNumber = 0;

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

        public static int LevelNumber
        {
            set { levelNumber = value; }
            get { return levelNumber; }
        }

        //LoadContent
        public void LoadContent()
        {
            this.level = new Level(this.game, levelNumber);
        }

        //Update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Escape) || Input.EdgeDetectButtonDown(Buttons.B))
            {
                this.game.GameState = new StartScene(this.game);
            }
            if (Score.isDead())
            {
                this.level.LevelState = level.LevelGameOver;
            }
            if (ExplorerManager.WalkOutOfLevel())
            {
                this.level.LevelState = level.LevelNextLevel;
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
