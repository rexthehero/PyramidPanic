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
    public class Down : AnimatedSprite 
    {
        //Fields
        private Explorer explorer;

        //Constructor
        public Down(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.angle = (float)Math.PI / 2;
            this.i = 0;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.explorer.Position += new Vector2(0f, this.explorer.Speed);
            if (Input.DetectKeyUp(Keys.Down))
            {
                this.explorer.State = new Idle(this.explorer, (float)Math.PI/2);
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
