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
    public class Up : AnimatedSprite
    {
        //Fields
        private Explorer explorer;

        //Constructor
        public Up(Explorer explorer)
            : base(explorer)
        {
            this.explorer = explorer;
            this.angle = -(float)Math.PI / 2;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.explorer.Position -= new Vector2(0f, this.explorer.Speed);
            if (Input.DetectKeyUp(Keys.Up))
            {
                this.explorer.State = new Idle(this.explorer);
            }
            base.Update(gameTime);
        }

        //Draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}

