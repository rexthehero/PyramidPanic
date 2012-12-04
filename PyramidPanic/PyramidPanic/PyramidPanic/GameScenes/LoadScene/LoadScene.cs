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
//*********Serialize*data*to*a*save*game*file***********
using Microsoft.Xna.Framework.Storage;
//******************************************************

namespace PyramidPanic
{   
    public class LoadScene : IStateGame
    {
        //Fields
        private PyramidPanic game;

        

        //Constructor
        public LoadScene(PyramidPanic game)
        {
            this.game = game;
            //this.game.Components.Add(new GamerServicesComponent(this.game));
            this.Initialize();
        }

        //Initialize
        public void Initialize()
        {
            this.LoadContent();
        }

        //LoadContent
        public void LoadContent()
        {

        }

        //Update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Escape))
            {
                this.game.GameState = new StartScene(this.game);
            }
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Red);
        }

        
    }
}
