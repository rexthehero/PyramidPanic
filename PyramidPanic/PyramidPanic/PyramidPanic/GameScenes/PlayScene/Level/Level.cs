using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace PyramidPanic
{
    public class Level
    {
        //Fields
        private PyramidPanic game;
        private string levelPath;
        private List<string> lines;
        private Block[,] blocks;
        private const int GRIDWIDTH = 32;
        private const int GRIDHEIGHT = 32;
        private Scorpion scorpion;
        private Image background;
        private List<Image> treasures;
        private Panel panel;

        //Constructor
        public Level(PyramidPanic game, int levelIndex)
        {
            this.game = game;
            this.levelPath = @"Content\PlaySceneAssets\Levels\0.txt";
            this.LoadAssets();
        }

        private void LoadAssets()
        {
            this.treasures = new List<Image>();
            this.panel = new Panel(this.game, new Vector2(0f, 448f));
            this.lines = new List<string>();
            StreamReader reader = new StreamReader(this.levelPath);
            string line = reader.ReadLine();
            int width = line.Length;
            while ( line != null)
            {
                lines.Add(line);
                line = reader.ReadLine();
            }
            int height = lines.Count;
            this.blocks = new Block[width, height];
            reader.Close();

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    char blockElement = this.lines[row][column];
                    this.blocks[column, row] = LoadBlock(blockElement, column * GRIDWIDTH, row * GRIDHEIGHT);
                }
            }
        }

        private Block LoadBlock(char blockElement, int x, int y)
        {
            switch (blockElement)
            {
                case 'a':
                    this.treasures.Add(new Image(this.game, @"PlaySceneAssets\Treasures\Treasure1", new Vector2(x, y)));
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, 'a');
                case 'b':
                    this.treasures.Add(new Image(this.game, @"PlaySceneAssets\Treasures\Treasure2", new Vector2(x, y)));
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, 'b');
                case 'c':
                    this.treasures.Add(new Image(this.game, @"PlaySceneAssets\Treasures\Potion", new Vector2(x, y)));
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, 'c');
                case 'd':
                    this.treasures.Add(new Image(this.game, @"PlaySceneAssets\Treasures\Scarab", new Vector2(x, y)));
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, 'd');
                case 'w':
                    return new Block(this.game, @"Block", new Vector2(x, y), BlockCollision.NotPassable, 'w');
                case 'x':
                    return new Block(this.game, @"Wall1", new Vector2(x, y), BlockCollision.NotPassable, 'x');
                case 'y':
                    return new Block(this.game, @"Wall2", new Vector2(x, y), BlockCollision.NotPassable, 'y');
                case 'z':
                    return new Block(this.game, @"Door", new Vector2(x, y), BlockCollision.NotPassable, 'z');
                case '@':
                    this.background = new Image(this.game, @"PlaySceneAssets\Background\Background2", new Vector2(x, y));
                    return new Block(this.game, @"Block", new Vector2(x, y), BlockCollision.NotPassable, '@');
                case '.':
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, '.');
                case 's':
                    this.scorpion =  new Scorpion(this.game, @"PlaySceneAssets\Scorpion", new Vector2(x,y));
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, '.');
                default:
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, '.');
            }
        }

        public void Update(GameTime gameTime)
        {
            if ( this.scorpion != null)
            this.scorpion.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            this.background.Draw(gameTime);
            this.panel.Draw(gameTime);

            for ( int row = 0; row < this.blocks.GetLength(1); row++ )
            {
                for ( int column = 0; column < this.blocks.GetLength(0); column++ )
                {
                    this.blocks[column, row].Draw(gameTime);
                }
            }

            foreach (Image treasure in this.treasures)
            {
                treasure.Draw(gameTime);
            }

            if ( this.scorpion != null )
            this.scorpion.Draw(gameTime);
        }
    }
}
