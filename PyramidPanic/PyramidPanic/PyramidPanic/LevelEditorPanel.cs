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
    public class LevelEditorPanel
    {
        //Fields
        private LevelEditorScene levelEditorScene;
        private Vector2 position;
        private Image background;
        private List<Image> levelEditorButtons, levelEditorAssets;
        private int levelEditorAssetsIndex = 0;
        private SpriteFont Arial;

        //Properties
        public List<Image> LevelEditorAssets
        {
            get { return this.levelEditorAssets; }
        }

        //Constructor
        public LevelEditorPanel(LevelEditorScene levelEditorScene, Vector2 position)
        {
            this.levelEditorScene = levelEditorScene;
            this.position = position;
            this.Initialize();
        }

        //Initialize
        private void Initialize()
        {
            this.LoadContent();
        }

        //LoadContent
        private void LoadContent()
        {
            this.Arial = this.levelEditorScene.Game.Content.Load<SpriteFont>(@"PlaySceneAssets\Fonts\Arial");
            this.levelEditorButtons = new List<Image>();
            this.levelEditorAssets = new List<Image>();
            //levelnumber verlagen
            this.levelEditorButtons.Add(
                new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Left",
                    this.position + new Vector2(2.5f * 32f, 0f)));
            //levelnumber verhogen
            this.levelEditorButtons.Add(
                new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Right",
                    this.position + new Vector2(4.5f * 32f, 0f)));
            //plaatje wisselen naar beneden in list
            this.levelEditorButtons.Add(
                new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Left",
                    this.position + new Vector2(9f * 32f, 0f)));
            //plaatje wisselen naar omhoog in list
            this.levelEditorButtons.Add(
                new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Right",
                    this.position + new Vector2(11f * 32f, 0f)));

            //Assets toevoegen aan de list levelEditorAssets
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"PlaySceneAssets\Blocks\Block",
                                                    this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"PlaySceneAssets\Blocks\Door",
                                                    this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"PlaySceneAssets\Blocks\Wall1",
                                                    this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"PlaySceneAssets\Blocks\Wall2",
                                                    this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Beetle",
                                                    this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Scorpion",
                                                    this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorAssets\mummy",
                                                    this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Potion",
                                                   this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Scarab",
                                                   this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Treasure1",
                                                   this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Treasure2",
                                                   this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"PlaySceneAssets\Panel\Lives",
                                                   this.position + new Vector2(10f * 32f, 0f)));
            this.background = new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Panel", this.position);
        }

        //Update
        public void Update(GameTime gameTime)
        {
            foreach (Image image in this.levelEditorButtons)
            {
                if (image.Rectangle.Intersects(Input.MouseRectangle()))
                {
                    //Bepaal om welk image het gaat in list en geef het indexnummer
                    int indexOfImage = this.levelEditorButtons.IndexOf(image);
                    
                    //Detecteer of er linksgeklikt wordt op muisknop
                    if (Input.MouseEdgeDetectPressLeft())
                    {
                        switch (indexOfImage)
                        {
                            case 0:
                                //ternary
                                this.levelEditorScene.LevelIndex = (this.levelEditorScene.LevelIndex > 0) ?
                                    this.levelEditorScene.LevelIndex-1 : 0;
                                this.levelEditorScene.LoadLevel();
                                break;
                            case 1:
                                //ternary
                                this.levelEditorScene.LevelIndex = (this.levelEditorScene.LevelIndex < 10) ?
                                    this.levelEditorScene.LevelIndex + 1 : 10;
                                this.levelEditorScene.LoadLevel();
                                break;
                            case 2:
                                this.levelEditorAssetsIndex = (this.levelEditorAssetsIndex > 0) ?
                                    this.levelEditorAssetsIndex - 1 : 0;
                                Console.WriteLine(this.levelEditorAssetsIndex);
                                break;
                            case 3:
                                this.levelEditorAssetsIndex = (this.levelEditorAssetsIndex < this.levelEditorAssets.Count - 1) ?
                                    this.levelEditorAssetsIndex + 1 : this.levelEditorAssets.Count - 1;
                                Console.WriteLine(this.levelEditorAssetsIndex);
                                break;
                            default:
                                break;
                        }                        
                    }
                }
            }
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.background.Draw(gameTime);
            foreach (Image image in this.levelEditorButtons)
            {
                image.Draw(gameTime);
            }
            this.levelEditorAssets[this.levelEditorAssetsIndex].Draw(gameTime);
            //Ternary
            float levelIndexOffset = (levelEditorScene.LevelIndex > 9) ? 3.4f : 3.7f;
            this.levelEditorScene.Game.SpriteBatch.DrawString(this.Arial, 
                this.levelEditorScene.LevelIndex.ToString(), this.position +
                    new Vector2(levelIndexOffset * 32f, -3f), Color.Yellow);
        }
    }
}
