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
    public static class Input
    {
        //Fields
        private static KeyboardState ks, oks;
        private static MouseState ms, oms;
        private static Rectangle mouseRectangle;
        private static GamePadState gps, ogps;
        private static Keys[] alphabet = { Keys.A, Keys.B, Keys.C, Keys.D, Keys.D, Keys.D, Keys.D, Keys.E, Keys.F, Keys.G,
                                           Keys.H, Keys.I, Keys.J , Keys.K, Keys.L, Keys.M, Keys.N, Keys.O, Keys.P, Keys.Q, Keys.R,
                                           Keys.S, Keys.T, Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y, Keys.Z, Keys.Back, Keys.Space};

        //Constructor wordt eenmaal aangeroepen.
        static Input()
        {
            mouseRectangle = new Rectangle(0, 0, 1, 1);
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
            gps = GamePad.GetState(PlayerIndex.One);
            oks = ks;
            oms = ms;
            ogps = gps;
        }

        //Update methode
        public static void Update()
        {
            oks = ks;
            oms = ms;
            ogps = gps;
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
            gps = GamePad.GetState(PlayerIndex.One);
        }

        public static Keys GetKey()
        {
            foreach (Keys key in alphabet)
            {
                if (EdgeDetectKeyDown(key))
                {
                    return key;
                }
            }
            return Keys.F12;
        }

        
        //EdgeDetector  gamepad
        public static bool EdgeDetectButtonDown(Buttons button)
        {
            return ogps.IsButtonUp(button) && gps.IsButtonDown(button);
        }
        
        //LevelDetecter voor het indrukken van de toetsenknoppen
        public static bool DetectKeyDown(Keys key)
        {
            return ks.IsKeyDown(key);
        }

        //LevelDetecter voor het loslaten van de toetsenknoppen
        public static bool DetectKeyUp(Keys key)
        {
            return ks.IsKeyUp(key);
        }

        //Edgedetector voor de toetsenbordknoppen
        public static bool EdgeDetectKeyDown(Keys key)
        {
            return (ks.IsKeyDown(key) && oks.IsKeyUp(key));
        }

        //Edgedetector voor een linksklik van de muis
        public static bool MouseEdgeDetectPressLeft()
        {
            return ( ms.LeftButton == ButtonState.Pressed && oms.LeftButton == ButtonState.Released );
        }

        //Edgedetector voor een rechtklik van de muis
        public static bool MouseEdgeDetectPressRight()
        {
            return (ms.RightButton == ButtonState.Pressed && oms.RightButton == ButtonState.Released);
        }

        //Positie van de muis
        public static Vector2 MousePosition()
        {
            return new Vector2(ms.X, ms.Y);
        }

        //Positie van de rectangle
        public static Rectangle MouseRectangle()
        {
            mouseRectangle.X = ms.X;
            mouseRectangle.Y = ms.Y;
            return mouseRectangle;
        }
    }
}
