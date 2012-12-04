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
    public class AnimatedSprite
    {
        //Field
        private Beetle beetle;
        private int[] xValue = { 0, 32, 64, 96 };
        private int i = 0;
        private float timer;
        protected float angle = 0f;
        
        //Constructor
        public AnimatedSprite(Beetle beetle)
        {
            this.beetle = beetle;
        }

        public void Update(GameTime gameTime)
        {
            //Dit is de code voor de animatie van de sprite
            this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timer > 1f / 8f)
            {
                this.timer = 0;
                this.i++;
                if (this.i > 2)
                {
                    this.i = 0;
                }
            }
        }

        public void Draw(GameTime gameTime)
        {
            this.beetle.Game.SpriteBatch.Draw(this.beetle.Texture,
                                              this.beetle.Rectangle,
                                              new Rectangle(this.xValue[this.i], 0, 32, 32),
                                              Color.White,
                                              this.angle,
                                              new Vector2(16f, 16f),
                                              SpriteEffects.None,
                                              0f);
        }
    }
}
