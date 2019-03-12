using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


// my project import 
using GravityChallenger.Global;
using GravityChallenger.Menu;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using Android.Media;
using Microsoft.Xna.Framework.Media;

namespace GravityChallenger
{
    public enum MenuState
    {
        MAIN,
        GAME,
        SETTINGS,
        SCORE,
        GAMEOVER
    }
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Input touchStateCollection;

        MenuBase menu;

        public object ContentManager { get; private set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            /*// Width = 800; Height = 480 is the default value
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = Settings.SCREEN_WIDTH;
            graphics.PreferredBackBufferHeight = Settings.SCREEN_HEIGHT;
            graphics.IsFullScreen = false;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
            graphics.ApplyChanges();*/

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
            graphics.ApplyChanges();

            this.IsFixedTimeStep = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {           
            base.Initialize();

            // Initialize the Menu
            this.menu = new MenuMain();

            // Initialize the touch collection manager
            this.touchStateCollection = new Input();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load Image and Sounds
            Resources.LoadImages(this.Content, this.GraphicsDevice);
            Resources.LoadSounds(this.Content, this.GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }


        /// <summary>
        /// ChangMenu is used to switch between each menu state
        /// </summary>
        public void ChangeMenu(MenuState menu)
        {
            switch (menu)
            {
                case MenuState.MAIN:
                    this.menu = new MenuMain();
                    Console.WriteLine("\nSTATE: Menu Main\n");
                    break;
                case MenuState.GAME:
                    this.menu = new MenuGame();
                    Console.WriteLine("\nSTATE: Menu Game\n");
                    break;
                case MenuState.SETTINGS:
                    this.menu = new MenuSettings();
                    Console.WriteLine("\nSTATE: Menu Settings\n");
                    break;
                case MenuState.SCORE:
                    this.menu = new MenuScore();
                    Console.WriteLine("\nSTATE: Menu Score\n");
                    break;
                default:
                    break;
            }        
        }



        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();


            // Update the menu
            this.menu.Update(gameTime, touchStateCollection, this);

            // Update touch panel state
            this.touchStateCollection.Update();
            this.touchStateCollection.IsPressed();
            this.touchStateCollection.GetPosition();
            

            base.Update(gameTime);
                        
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);

            // Draw the menu
            this.menu.Draw(this.spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
