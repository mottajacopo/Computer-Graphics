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

  public partial class Game1 : Game
  {
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;

    public List<Player> _player;
    public List<Map> _map = new List<Map>();

    public Game1()
    {
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
    }

  
    protected override void Initialize()
    {
            
      graphics.PreferredBackBufferWidth = C.MAINWINDOW.X;  
      graphics.PreferredBackBufferHeight = C.MAINWINDOW.Y;

      graphics.ApplyChanges();


      base.Initialize();
    }

    protected override void LoadContent()
    {
     
      spriteBatch = new SpriteBatch(GraphicsDevice);

      C.brickWall = Content.Load<Texture2D>("mossy");
      C.brickGrass = Content.Load<Texture2D>("grass");
      C.brickLava = Content.Load<Texture2D>("lava");
      C.brickDiamond = Content.Load<Texture2D>("diamante2");
      C.brickStart = Content.Load<Texture2D>("grass");
      C.brickEnd = Content.Load<Texture2D>("door");
      C.brickEnd2 = Content.Load<Texture2D>("door2");


      ReadLabyrinthSpec(V.labyrinthMatrix, C.LabyrinthPathName);
      _map = FillLabyrinth(spriteBatch, _map);
      V.currentHeroPosition = V.labEnter[0];

    V.animationDown = "WalkDown";
    V.animationUp = "WalkUp";
    V.animationLeft = "WalkLeft";
    V.animationRight = "WalkRight";

            var animations = new Dictionary<string, Animation>()
      {
            { "WalkRight", new Animation(Content.Load<Texture2D>("Player/ZeldaRight"), 3) },
            { "WalkUp", new Animation(Content.Load<Texture2D>("Player/ZeldaUp"), 3) },
            { "WalkDown", new Animation(Content.Load<Texture2D>("Player/ZeldaDown"), 3) },
            { "WalkLeft", new Animation(Content.Load<Texture2D>("Player/ZeldaLeft"), 3) },
            { "WalkRightRed", new Animation(Content.Load<Texture2D>("Player/ZeldaRightRed"), 3) },
            { "WalkUpRed", new Animation(Content.Load<Texture2D>("Player/ZeldaUpRed"), 3) },
            { "WalkDownRed", new Animation(Content.Load<Texture2D>("Player/ZeldaDownRed"), 3) },
            { "WalkLeftRed", new Animation(Content.Load<Texture2D>("Player/ZeldaLeftRed"), 3) },
      };

       _player = new List<Player>()
      {
        new Player(animations)
        {
          Position = H.ToVector2(H.HeroPosition()),   
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
        
    protected override void UnloadContent()
    {

    }
        
    protected override void Update(GameTime gameTime)
    {
        foreach (var sprite in _player)
        {
            sprite.Update(gameTime, _player, _map);
        }

      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.CornflowerBlue);

      spriteBatch.Begin();

      //ReadLabyrinthSpec(V.labyrinthMatrix, C.LabyrinthPathName);
      //FillLabyrinth(spriteBatch , _map);

      foreach (var map in _map)
        map.Draw(spriteBatch);

      foreach (var sprite in _player)
        sprite.Draw(spriteBatch);

            spriteBatch.End();

      base.Draw(gameTime);
    }
  }
}
