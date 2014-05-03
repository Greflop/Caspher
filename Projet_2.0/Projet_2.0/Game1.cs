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

namespace Projet_2._0
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Casper casper;
        Decors decors;
        SpriteFont fontdebug;
        ScreenManager screenmanager;
        GameType gameState;
        static Game1 game;
        MouseState mouseState;

        internal bool IsFullScreen
        {
            get { return graphics.IsFullScreen; }
            set
            {
                graphics.IsFullScreen = value;
                graphics.ApplyChanges();
            }
        }

        public static Game1 GetGame()
        {
            if (game == null)
                game = new Game1();
            return game;
        }

        private Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            double ScreenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            double ScreenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.PreferredBackBufferWidth = Convert.ToInt32(ScreenWidth);
            graphics.PreferredBackBufferHeight = Convert.ToInt32(ScreenHeight);
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //gametime = new GameTime();
            IsMouseVisible = true;
            gameState = GameType.Menu_Base_Type;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Content_Manager.getInstance().LoadTextures(Content);
            fontdebug = Content.Load<SpriteFont>("Fontdebug");
            //decors = new Decors(Content_Manager.getInstance().Textures["Level1"], new Rectangle(0, 0, 1680, 1050));
            screenmanager = new ScreenManager(gameState, this);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            // Allows the game to exit
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            //casper.update(gameTime);
            screenmanager.update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            screenmanager.Draw(spriteBatch);
            if (IsMouseVisible == true)
            {
                spriteBatch.DrawString(fontdebug, Convert.ToString(mouseState.X), new Vector2(100, 10), Color.White);
                spriteBatch.DrawString(fontdebug, Convert.ToString(mouseState.Y), new Vector2(100, 40), Color.White);
            }
            //decors.Draw(spriteBatch);
            spriteBatch.DrawString(fontdebug, Convert.ToString(casper.getVelocity().X), new Vector2(10, 10), Color.Red);
            spriteBatch.DrawString(fontdebug, Convert.ToString(casper.getVelocity().Y), new Vector2(10, 25), Color.Red);
            spriteBatch.DrawString(fontdebug, Convert.ToString(casper.getPosition().X), new Vector2(10, 40), Color.Red);
            spriteBatch.DrawString(fontdebug, Convert.ToString(casper.getPosition().Y), new Vector2(10, 55), Color.Red);
            //casper.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
