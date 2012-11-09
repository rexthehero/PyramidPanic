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
    public class StartScene
    {
        //Fields
        private PyramidPanic game;
        private Image background, title;
        private MenuStartScene menu;

        //Constructor
        public StartScene(PyramidPanic game)
        {
            this.game = game;
            this.background = new Image(game, @"StartSceneAssets\Background", Vector2.Zero);
            this.title = new Image(game, @"StartSceneAssets\Title", new Vector2(100f, 30f));
            this.menu = new MenuStartScene(game);
        }

        //Update


        //Draw
        public void Draw(GameTime gameTime)
        {
            this.background.Draw(this.game.SpriteBatch);
            this.title.Draw(this.game.SpriteBatch);
            this.menu.Draw(gameTime);
        }
    }
}
