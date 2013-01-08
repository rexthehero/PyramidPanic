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
    public class Treasure : Image
    {
        //Fields
        private Char name;

        public Char Name
        {
            get { return this.name; }
        }
        
        public Treasure(Char name, PyramidPanic game, string pathName, Vector2 position)
            : base(game, pathName, position)
        {
            this.name = name;
        }
    }
}
