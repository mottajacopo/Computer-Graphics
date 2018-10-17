using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Labyrinth.Models;
using Labyrinth.Sprites;
using Labyrinth.Manager;

namespace Labyrinth
{
  /// <summary>
  /// This is the main type for your game.
  /// </summary>
  public partial class Game1 : Game
  {
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;

    public List<Sprite> _sprites;

    public Game1()
    {
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
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
            graphics.PreferredBackBufferWidth = C.MAINWINDOW.X;   /// definisco la larghezza della finestra esterna
            graphics.PreferredBackBufferHeight = C.MAINWINDOW.Y;

            graphics.ApplyChanges();


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

      C.brickWall = Content.Load<Texture2D>("mossy");
      C.brickGrass = Content.Load<Texture2D>("grass");
      C.brickLava = Content.Load<Texture2D>("lava");
      C.brickDiamond = Content.Load<Texture2D>("diamante2");
      C.brickStart = Content.Load<Texture2D>("grass");
      C.brickEnd = Content.Load<Texture2D>("door");
      C.brickEnd2 = Content.Load<Texture2D>("door2");


      ReadLabyrinthSpec(V.labyrinthMatrix, C.LabyrinthPathName);
      V.currentHeroPosition = V.labEnter[0];

      var playerTexture = Content.Load<Texture2D>("Hero");
            var animations = new Dictionary<string, Animation>()
      {
            { "WalkRight", new Animation(Content.Load<Texture2D>("Player/ZeldaRight"), 3) },
            { "WalkUp", new Animation(Content.Load<Texture2D>("Player/ZeldaUp"), 3) },
            { "WalkDown", new Animation(Content.Load<Texture2D>("Player/ZeldaDown"), 3) },
            { "WalkLeft", new Animation(Content.Load<Texture2D>("Player/ZeldaLeft"), 3) },
      };

            _sprites = new List<Sprite>()
      {
        new Sprite(new Dictionary<string, Animation>()
        {
            { "WalkRight", new Animation(Content.Load<Texture2D>("Player/ZeldaRight"), 3) },
            { "WalkUp", new Animation(Content.Load<Texture2D>("Player/ZeldaUp"), 3) },
            { "WalkDown", new Animation(Content.Load<Texture2D>("Player/ZeldaDown"), 3) },
            { "WalkLeft", new Animation(Content.Load<Texture2D>("Player/ZeldaLeft"), 3) },
          
        })
        {
          Position = H.ToVector2(H.heroPosition()),
          Input = new Input()
          {
            Up = Keys.W,
            Down = Keys.S,
            Left = Keys.A,
            Right = Keys.D,
          },
        },
        
      };
        }

    /// <summary>
    /// UnloadContent will be called once per game and is the place to unload
    /// game-specific content.
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
      foreach (var sprite in _sprites)
        sprite.Update(gameTime, _sprites);

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

      ReadLabyrinthSpec(V.labyrinthMatrix, C.LabyrinthPathName);
      FillLabyrinth(spriteBatch , _sprites);

      foreach (var sprite in _sprites)
        sprite.Draw(spriteBatch);
       

      spriteBatch.End();

      base.Draw(gameTime);
    }
  }
}
