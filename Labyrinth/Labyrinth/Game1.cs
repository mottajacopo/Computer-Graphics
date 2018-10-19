using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Labyrinth.Models;
using Labyrinth.Sprites;
using Labyrinth.Manager;
using System.Threading.Tasks;
using System.IO;

namespace Labyrinth
{
    public partial class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private List<Player> _player;
        private List<Map> _map = new List<Map>();
        public List<Sprite> _sprite = new List<Sprite>(); // list for sprite (es . grave)
        public List<Cannon> _cannon = new List<Cannon>();

        private Dictionary<string, Animation> animations;
        private float timer;
        private SpriteFont font;
        bool check = false; // need for death count check

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
            C.Grave = Content.Load<Texture2D>("Rip");

            C.cannon2_30 = Content.Load<Texture2D>("Cannon/cannon2.30");
            C.cannon3 = Content.Load<Texture2D>("Cannon/cannon3");
            C.cannon4_30 = Content.Load<Texture2D>("Cannon/cannon4.30");
            C.cannon6 = Content.Load<Texture2D>("Cannon/cannon6");
            C.cannon7_30 = Content.Load<Texture2D>("Cannon/cannon7.30");
            C.cannon9 = Content.Load<Texture2D>("Cannon/cannon9");
            C.cannon10_30 = Content.Load<Texture2D>("Cannon/cannon10.30");
            C.cannon12 = Content.Load<Texture2D>("Cannon/cannon12");

            V.cannonTexture = C.cannon3;
            ReadLabyrinthSpec(V.labyrinthMatrix, C.LabyrinthPathName);
            _map = FillLabyrinth(spriteBatch, _map , _cannon);
            V.currentHeroPosition = V.labEnter[0];

            V.animationDown = "WalkDown";
            V.animationUp = "WalkUp";
            V.animationLeft = "WalkLeft";
            V.animationRight = "WalkRight";
            V.animationDied = "HasDied";
 
            V.deathCount = 0;
            V.playerHealth = 100;

            animations = new Dictionary<string, Animation>()
            {
                { "WalkRight", new Animation(Content.Load<Texture2D>("Player/ZeldaRight"), 3) },
                { "WalkUp", new Animation(Content.Load<Texture2D>("Player/ZeldaUp"), 3) },
                { "WalkDown", new Animation(Content.Load<Texture2D>("Player/ZeldaDown"), 3) },
                { "WalkLeft", new Animation(Content.Load<Texture2D>("Player/ZeldaLeft"), 3) },
                { "WalkRightRed", new Animation(Content.Load<Texture2D>("Player/ZeldaRightRed"), 3) },
                { "WalkUpRed", new Animation(Content.Load<Texture2D>("Player/ZeldaUpRed"), 3) },
                { "WalkDownRed", new Animation(Content.Load<Texture2D>("Player/ZeldaDownRed"), 3) },
                { "WalkLeftRed", new Animation(Content.Load<Texture2D>("Player/ZeldaLeftRed"), 3) },
                { "HasDied", new Animation(Content.Load<Texture2D>("Player/ZeldaHasDied"), 1) },
            };

            _player = new List<Player>()
            {
                new Player(animations)
                {
                    Position = H.ToVector2(H.HeroPosition()),
                    Health = 5,
                    Input = new Input()
                    {
                    Up = Keys.W,
                    Down = Keys.S,
                    Left = Keys.A,
                    Right = Keys.D,
                    },
                },
            };

            font = Content.Load<SpriteFont>("Fonts/Font");
        }

        protected override void UnloadContent()
        {
        }

        private void Restart()
        {
            V.deathCount++;
            V.playerHealth = 100;

            check = false;
            _player = new List<Player>()
            {
                new Player(animations)
                {
                    Position = H.ToVector2(H.HeroPosition()),
                    Health = 5,
                    Input = new Input()
                    {
                    Up = Keys.W,
                    Down = Keys.S,
                    Left = Keys.A,
                    Right = Keys.D,
                    },
                },
            };

            _sprite.Add(  // add new grave every time player dies
                new Sprite(C.Grave)
                {
                    Position = V.deathHeroPoisition,

                }
            );
            
        }

        protected override void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var player in _player)
            {
                player.Update(gameTime, _player, _map);

                
                if(player.hasDied && !check)
                {
                    Task.Delay(500).ContinueWith(t => Restart());  //delay for death animation show
                    check = true;
                    
                }
                
            }

            foreach (var cannon in _cannon)
            {
                cannon.Update(gameTime, _cannon, _map);
            }

            if (timer > 1)
            {
                // do something
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (var map in _map)
                map.Draw(spriteBatch);

            foreach (var cannon in _cannon)
                cannon.Draw(spriteBatch);

            foreach (var player in _player)
                player.Draw(spriteBatch);

            if (_sprite.Count >0)  // draw sprite different from player ( es grave )
            {
                foreach (var sprite in _sprite)
                    sprite.Draw(spriteBatch);
            }

            spriteBatch.DrawString(font, string.Format("Time: {0}", timer.ToString("n2")), new Vector2(10, 5), Color.White);
            spriteBatch.DrawString(font, string.Format("Score: {0}", V.score), new Vector2(10, 30), Color.White);
            spriteBatch.DrawString(font, string.Format("Death count: {0}", V.deathCount), new Vector2(10, 55), Color.White);  // death counter
            spriteBatch.DrawString(font, string.Format("Health: {0}", V.playerHealth), new Vector2(10, 80), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
