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
    public class Score
    {
        private static int scorePoints = 0;
        private static int lives = 3;
        private static int scarab = 0;

        public static int ScorePoints
        {
            get { return scorePoints; }
            set { scorePoints = value; }
        }

        public static int Lives
        {
            get { return lives; }
            set { lives = value; }
        }

        public static int Scarab
        {
            get { return scarab; }
            set { scarab = value; }
        }
    }
}
