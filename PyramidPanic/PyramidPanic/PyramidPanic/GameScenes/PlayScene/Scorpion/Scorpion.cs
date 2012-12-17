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
    public class Scorpion : IAnimatedSprite
    {
        //Field
        private PyramidPanic game;
        private Texture2D texture;
        private Vector2 position;
        private Rectangle rectangle;
        private IScorpion state;
        private float speed;
        private float right, left;
        private WalkLeft walkLeft;
        private WalkRight walkRight;

        //Properties
        public WalkLeft WalkLeft
        {
            get { return this.walkLeft; }
        }

        public WalkRight WalkRight
        {
            get { return this.walkRight; }
        }

        public float Left
        {
            set { this.left = value; }
            get { return this.left; }
        }

        public float Right
        {
            set { this.right = value; }
            get { return this.right; }
        }

        public float Speed
        {
            get { return this.speed; }
        }

        public Vector2 Position
        {
            get { return this.position; }
            set 
            { 
                this.position = value;
                this.rectangle.X = (int)this.position.X + 16;
                this.rectangle.Y = (int)this.position.Y + 16;
            }
        }

        public PyramidPanic Game
        {
            get { return this.game; }
        }

        public Texture2D Texture
        {
            get { return this.texture; }
        }

        public Rectangle Rectangle
        {
            get { return this.rectangle; }
        }

        public IScorpion State
        {
            get { return this.state; }
            set { this.state = value; }
        }
        
        
        //De constructor
        public Scorpion(PyramidPanic game, Vector2 position, float speed)
        {
            this.game = game;
            this.texture = game.Content.Load<Texture2D>(@"PlaySceneAssets\Scorpion\Scorpion");
            this.position = position;
            this.speed = speed;
            this.rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.texture.Width/4, this.texture.Height);
            this.walkLeft = new WalkLeft(this);
            this.walkRight = new WalkRight(this);
            this.state = this.walkRight;
        }

        //Update
        public void Update(GameTime gameTime)
        {
            this.state.Update(gameTime);
        }

        //Draw methode
        public void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);
        }
    }
}
