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
    public class MenuStartScene
    {
        //Fields
        private PyramidPanic game;
        private Image start, load, help, scores, quit, leveleditor;
        private int top, left, space;

        //Constructor
        public MenuStartScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }

        //Initialize
        private void Initialize()
        {
            this.top = 430;
            this.left = 4;
            this.space = 107;
            this.LoadContent();
        }

        //LoadContent 
        private void LoadContent()
        {
            this.start = new Image(this.game,
                @"StartSceneAssets\Button_start", new Vector2(this.left, this.top));
            this.load = new Image(this.game, 
                @"StartSceneAssets\Button_load", new Vector2(this.left + this.space, this.top));
            this.help = new Image(this.game, 
                @"StartSceneAssets\Button_help", new Vector2(this.left + 2 * this.space, this.top));
            this.scores = new Image(this.game, 
                @"StartSceneAssets\Button_scores", new Vector2(this.left + 3 * this.space, this.top));
            this.quit = new Image(this.game, 
                @"StartSceneAssets\Button_quit", new Vector2(this.left + 4 * this.space, this.top));
            this.leveleditor = new Image(this.game, 
                @"StartSceneAssets\Button_leveleditor", new Vector2(this.left + 5 * this.space, this.top));
        }
        //Update
        //Draw
        public void Draw(GameTime gameTime)
        {
            this.start.Draw(this.game.SpriteBatch);
            this.load.Draw(this.game.SpriteBatch);
            this.help.Draw(this.game.SpriteBatch);
            this.scores.Draw(this.game.SpriteBatch);
            this.quit.Draw(this.game.SpriteBatch);
            this.leveleditor.Draw(this.game.SpriteBatch);
        }
    }
}
