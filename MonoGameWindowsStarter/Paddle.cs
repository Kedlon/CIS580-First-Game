﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace MonoGameWindowsStarter
{
    public class Paddle
    {
        Game1 game;

        BoundingRectangle bounds;

        Texture2D texture;

        /// <summary>
        /// Creates a paddle
        /// </summary>
        /// <param name="game">The game the paddle belongs to.</param>
        public Paddle(Game1 game)
        {
            this.game = game;
            bounds.Width = 50;
            bounds.Height = 200;
            bounds.X = 0;
            bounds.Y = game.GraphicsDevice.Viewport.Height/2 - bounds.Height/2 ;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("pixel");
        }

        public void Update()
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                //move up
                bounds.Y -= 1;
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                //move down
                bounds.Y += 1;
            }

            if (bounds.Y < 0)
            {
                bounds.Y = 0;
            }
            if (bounds.Y > game.GraphicsDevice.Viewport.Height - bounds.Height)
            {
                bounds.Y = game.GraphicsDevice.Viewport.Height - bounds.Height;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.Green);
        }
    }
}
