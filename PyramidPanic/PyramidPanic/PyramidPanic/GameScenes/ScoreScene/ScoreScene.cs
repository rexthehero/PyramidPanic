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
    public class SaveGameData
    {
        public string name;
    }
    
    public class ScoreScene : IStateGame
    {
        //Fields
        private PyramidPanic game;
        //*********Serialize*data*to*a*save*game*file***********
        private IAsyncResult result;
        private StorageDevice device;
        //******************************************************
        string name = "";

        //Constructor
        public ScoreScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }

        //Initialize
        public void Initialize()
        {
            this.result = StorageDevice.BeginShowSelector(PlayerIndex.One, null, (object)"Hallo hier aarde");
            this.device = StorageDevice.EndShowSelector(result);
            this.LoadContent();
        }

        //LoadContent
        public void LoadContent()
        {

        }

        //Update
        public void Update(GameTime gameTime)
        {
            if ( Input.EdgeDetectKeyDown(Keys.Escape) )
            {
                this.game.GameState = new StartScene(this.game);   
            }

            if (Input.EdgeDetectKeyDown(Keys.F))
            {
                DoCreate(this.device);
            }

            if (Input.EdgeDetectKeyDown(Keys.G))
            {
                DoRead(this.device);
            }

            if (Input.EdgeDetectKeyDown(Keys.H))
            {
                DoWrite(this.device);
            }

            HandleInput();
        }

        private void HandleInput()
        {
            switch (Input.GetKey())
            {
                case Keys.Space:
                    this.name += " ";
                    break;
                case Keys.Back:
                    this.name = (this.name.Length > 0) ? this.name.Remove(this.name.Length - 1) : this.name;
                    break;
                default:
                    this.name += (Input.GetKey() != Keys.F12) ? Input.GetKey().ToString() : "";
                    break;
            }
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Black);
            this.game.SpriteBatch.DrawString(this.game.SpriteFont, this.name, new Vector2(100f, 200f), Color.Red);
        }

        private static void DoCreate(StorageDevice device)
        {
            // Open a storage container.
            IAsyncResult result =
                device.BeginOpenContainer("StorageDemo1", null, null);

            // Wait for the WaitHandle to become signaled.
            result.AsyncWaitHandle.WaitOne();

            StorageContainer container = device.EndOpenContainer(result);

            // Close the wait handle.
            result.AsyncWaitHandle.Close();

            // Add the container path to our file name.
            string filename = "demobinary.sav";

            // Create a new file.
            if (!container.FileExists(filename))
            {
                Stream file = container.CreateFile(filename);
                file.Close();
            }
            // Dispose the container, to commit the data.
            container.Dispose();
        }

        private static void DoOpen(StorageDevice device)
        {
            IAsyncResult result =
                device.BeginOpenContainer("StorageDemo1", null, null);

            // Wait for the WaitHandle to become signaled.
            result.AsyncWaitHandle.WaitOne();

            StorageContainer container = device.EndOpenContainer(result);

            // Close the wait handle.
            result.AsyncWaitHandle.Close();

            // Add the container path to our file name.
            string filename = "demobinary.sav";

            Stream file = container.OpenFile(filename, FileMode.Open);
            file.Close();

            // Dispose the container.
            container.Dispose();
        }

        private static void DoRead(StorageDevice device)
        {
            List<string> lines;
            lines = new List<string>();

            IAsyncResult result =
                device.BeginOpenContainer("StorageDemo1", null, null);

            // Wait for the WaitHandle to become signaled.
            result.AsyncWaitHandle.WaitOne();

            StorageContainer container = device.EndOpenContainer(result);

            // Close the wait handle.
            result.AsyncWaitHandle.Close();

            // Add the container path to our file name.
            string filename = "demobinary.sav";

            Stream file = container.OpenFile(filename, FileMode.Open);

            StreamReader reader = new StreamReader(file);
            string line = reader.ReadLine();
            int width = line.Length;
            while (line != null)
            {
                Console.WriteLine(line);
                lines.Add(line);
                line = reader.ReadLine();

            }
            reader.Close();

            file.Close();

            // Dispose the container.
            container.Dispose();
        }

        private static void DoWrite(StorageDevice device)
        {
            List<string> lines;
            lines = new List<string>();

            IAsyncResult result =
                device.BeginOpenContainer("StorageDemo1", null, null);

            // Wait for the WaitHandle to become signaled.
            result.AsyncWaitHandle.WaitOne();

            StorageContainer container = device.EndOpenContainer(result);

            // Close the wait handle.
            result.AsyncWaitHandle.Close();

            // Add the container path to our file name.
            string filename = "demobinary.sav";

            Stream file = container.OpenFile(filename, FileMode.Open);

            lines.Add("Eerste regel");
            lines.Add("tweede regel");
            lines.Add("derde regel");
            lines.Add("vierde regel");

            StreamWriter writer = new StreamWriter(file);

            foreach (String line in lines)
            {
                writer.WriteLine(line);
            }
            writer.WriteLine("Dit is een testerdetest\n");
            writer.WriteLine("Dit is een testerdetest1");
            writer.WriteLine("Dit is een testerdetest2");
            writer.WriteLine("Dit is een testerdetest3");
            writer.WriteLine("Dit is een testerdetest4");
            writer.WriteLine("Dit is een testerdetest5");
            writer.WriteLine("Dit is een testerdetest6");
            writer.WriteLine(DateTime.Now.ToLongTimeString());


            writer.Close();

            file.Close();

            // Dispose the container.
            container.Dispose();
        }
    }
}
