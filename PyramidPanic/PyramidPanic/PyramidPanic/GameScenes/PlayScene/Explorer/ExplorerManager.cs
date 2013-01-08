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
    public class ExplorerManager
    {
        //Fields
        private static Level level;
        private static Explorer explorer;

        //Properties
        public static Level Level
        {
            set { level = value; }
        }

        public static Explorer Explorer
        {
            set { explorer = value; }
        }

        public static bool CollisionDetectionWalls()
        {
            for ( int i = 0; i < level.Blocks.GetLength(0); i++)
            {
                for (int j = 0; j < level.Blocks.GetLength(1); j++)
                {
                    if (level.Blocks[i, j].BlockCollision == BlockCollision.NotPassable)
                    {
                        if (explorer.CollisionRectangle.Intersects(level.Blocks[i, j].Rectangle))
                        {
                            return true;
                        }
                    }
                }
            }            
            return false;
        }

        public static void CollisionDetectTreasures()
        {
            foreach (Treasure treasure in level.Treasures)
            {
                if (explorer.CollisionRectangle.Intersects(treasure.Rectangle))
                {
                    switch (treasure.Character)
                    {
                        case 'a':
                            Score.Points += 10;
                            break;
                        case 'b':
                            Score.Points += 100;
                            break;
                        case 'c':
                            Score.Lives++;
                            break;
                        case 'd':
                            Score.Scarabs++;
                            Score.Points += 50;
                            break;
                    }                  
                    level.Treasures.Remove(treasure);
                    break;
                }

            }
        }

        public static void CollisionDetectScorpions()
        {
            foreach (Scorpion scorpion in level.Scorpions)
            {
                if (explorer.CollisionRectangle.Intersects(scorpion.CollisionRectangle))
                {
                    Score.Lives--;
                    level.Scorpions.Remove(scorpion);
                    break;
                }
            }
        }

        public static void CollisionDetectBeetles()
        {
            foreach (Beetle beetle in level.Beetles)
            {
                if (explorer.CollisionRectangle.Intersects(beetle.CollisionRectangle))
                {
                    Score.Lives--;
                    level.Beetles.Remove(beetle);
                    break;
                }
            }
        }
    }
}
