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
    public class Scorpion
    {
        //Fields
        private Texture2D texture;
        private Rectangle rectangle;
        private Vector2 position;
        private PyramidPanic game;
        private int[] number = { 0, 32, 64, 96};
        private int i = 0;

        //Properties
        public Rectangle Rectangle
        {
            get { return this.rectangle; }
        }

        //Constructor
        public Scorpion(PyramidPanic game, string pathName, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.texture = game.Content.Load<Texture2D>(pathName);
            this.rectangle = new Rectangle((int)position.X,
                                           (int)position.Y,
                                           this.texture.Width/4,
                                           this.texture.Height);
        }

        public void Update(GameTime gameTime)
        {
            
           if (Input.EdgeDetectKeyDown(Keys.N))
           {
                if (this.i < 3)
                    this.i++;
                else
                    this.i = 0;
           }
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            //this.game.SpriteBatch.Draw(this.texture, this.rectangle, Color.White);
            this.game.SpriteBatch.Draw(this.texture, this.rectangle, new Rectangle(this.number[i], 0, 32, 32), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0f);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(this.texture, this.rectangle, color);
        }
    }
}
