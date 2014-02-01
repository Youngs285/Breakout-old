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

namespace Breakout
{
   
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D paddle;
        Vector2 paddleposition = Vector2.Zero;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

       
        protected override void Initialize()
        {
          

            base.Initialize();
        }

      
        protected override void LoadContent()
        {
           
            spriteBatch = new SpriteBatch(GraphicsDevice);

            paddle = Content.Load < Texture2D > ("paddle");
            paddleposition = new Vector2((graphics.GraphicsDevice.Viewport.Width / 2) - 
                                        (paddle.Width / 2), graphics.GraphicsDevice.Viewport.Height - 100);
          
        }

      
        protected override void UnloadContent()
        {
         
        }

      
        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Left) && paddleposition.X >= 0)
            {
                paddleposition.X -= 4;
            }

            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Right) && paddleposition.X <= (graphics.GraphicsDevice.Viewport.Width) 
                                                                                              - (paddle.Width))
            {
                paddleposition.X += 4;
            }




            base.Update(gameTime);
        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(paddle, paddleposition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
