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
    public class Explorer : IAnimatedSprite
    {
        //Fields
        private PyramidPanic game;
        private Texture2D texture;
        private Rectangle rectangle;
        private Vector2 position;
        private float speed;

        //State variable is de parentclass van de toestandsklassen
        AnimatedSprite state;

        //Properties
        public AnimatedSprite State
        {
            set { this.state = value; }
        }

        public PyramidPanic Game
        {
            get { return this.game; }
        }

        public Rectangle Rectangle
        {
            get { return this.rectangle; }
        }

        public Texture2D Texture
        {
            get { return this.texture; }
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

        public float Speed
        {
            get { return this.speed; }
        }

        //Constructor
        public Explorer(PyramidPanic game, Vector2 position, float speed)
        {
            this.game = game;
            this.position = position;
            this.speed = speed;
            this.texture = game.Content.Load<Texture2D>(@"PlaySceneAssets\Explorer\Explorer");
            this.rectangle = new Rectangle((int)position.X + 16,
                                           (int)position.Y + 16,
                                           this.texture.Width/4,
                                           this.texture.Height);
            this.state = new Idle(this);
        }

        public void Update(GameTime gameTime)
        {
            this.state.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);
        }
    }
}
