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
using PyramidPanic;

namespace PyramidPanic
{
    public class Idle : AnimatedSprite
    {
        private Explorer explorer;

        public Idle(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.i = 1;
        }

        public override void Update(GameTime gameTime)
        {
            if ( Input.DetectKeyDown(Keys.Right))
            {
                this.explorer.State = new Right(explorer);
            }
            else if (Input.DetectKeyDown(Keys.Up))
            {
                this.explorer.State = new Up(explorer);
            }
            //base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
