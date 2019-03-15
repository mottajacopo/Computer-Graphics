using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Labyrinth.Models;
using Labyrinth.Sprites;
using Labyrinth.Controls;
using System.Threading.Tasks;
using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Labyrinth
{
    enum State { menu, game };

    public partial class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private List<Component> _gameComponents;

        State currentState = State.menu;

        private Dictionary<string, Animation> animations;
        
        private SpriteFont font;
        bool check = false; // need for death count check


        private float timer = 1.5f;         //timer for bullets
        private float timer2;
        const float TIMER = 1.5f;

        private Random r = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        

        protected override void Initialize()
        {

            graphics.PreferredBackBufferWidth = C.MAINWINDOW.X;
            graphics.PreferredBackBufferHeight = C.MAINWINDOW.Y;
            this.IsMouseVisible = true;

            graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            var startButton = new Button(Content.Load<Texture2D>("Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(400, 300),
                Text = "Play",
            };

            startButton.Click += StartButton_Click;

            var quitButton = new Button(Content.Load<Texture2D>("Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(400, 350),
                Text = "Quit",
            };

            quitButton.Click += QuitButton_Click;

            _gameComponents = new List<Component>()
      {
        startButton,
        quitButton,
      };

            C.brickWall = Content.Load<Texture2D>("mossy");
            C.brickGrass = Content.Load<Texture2D>("grass");
            C.brickLava = Content.Load<Texture2D>("lava");
            C.brickDiamond = Content.Load<Texture2D>("diamante2");
            C.brickStart = Content.Load<Texture2D>("grass");
            C.brickEnd = Content.Load<Texture2D>("door");
            C.brickEnd2 = Content.Load<Texture2D>("door2");
            C.Grave = Content.Load<Texture2D>("Player/Rip");

            C.cannonRightUp = Content.Load<Texture2D>("Cannon/cannonRightUp");
            C.cannonRight = Content.Load<Texture2D>("Cannon/cannonRight");
            C.cannonRightDown = Content.Load<Texture2D>("Cannon/cannonRightDown");
            C.cannonDown = Content.Load<Texture2D>("Cannon/cannonDown");
            C.cannonLeftDown = Content.Load<Texture2D>("Cannon/cannonLeftDown");
            C.cannonLeft = Content.Load<Texture2D>("Cannon/cannonLeft");
            C.cannonLeftUp = Content.Load<Texture2D>("Cannon/cannonLeftUp");
            C.cannonUp = Content.Load<Texture2D>("Cannon/cannonUp");
            C.win = Content.Load<Texture2D>("win");
            C.cover = Content.Load<Texture2D>("Cover");

            C.bulletTexture = Content.Load<Texture2D>("Bullet");     
            C.explosion = Content.Load<SoundEffect>("Prof/explosion");     
            C.newBullet = Content.Load<SoundEffect>("Prof/newBullet");    
            C.backMusic = Content.Load<Song>("Prof/background");       
            
           
            //MediaPlayer.Play(C.backMusic);
            //MediaPlayer.IsRepeating = true;

            V.cannonTexture = C.cannonRightUp;  // default texture for cannon

           ReadLabyrinthSpec(V.labyrinthMatrix, C.LabyrinthPathName);
           FillLabyrinth(spriteBatch);

            V.currentHeroPosition = V.labEnter[0];

            V.animationDown = "WalkDown";
            V.animationUp = "WalkUp";
            V.animationLeft = "WalkLeft";
            V.animationRight = "WalkRight";
            V.animationDied = "HasDied";

            V.deathCount = 0;
            V.playerHealth = 100;
            V.win = false;

            animations = new Dictionary<string, Animation>()
            {
                { "WalkRight", new Animation(Content.Load<Texture2D>("Link blue/LinkRight2"), 5) },
                { "WalkUp", new Animation(Content.Load<Texture2D>("Link blue/LinkUp2"), 5) },
                { "WalkDown", new Animation(Content.Load<Texture2D>("Link blue/LinkDown2"), 5) },
                { "WalkLeft", new Animation(Content.Load<Texture2D>("Link blue/LinkLeft2"), 5) },
                { "WalkRightRed", new Animation(Content.Load<Texture2D>("Link blue/LinkRightRed2"), 5) },
                { "WalkUpRed", new Animation(Content.Load<Texture2D>("Link blue/LinkUpRed2"), 5) },
                { "WalkDownRed", new Animation(Content.Load<Texture2D>("Link blue/LinkDownRed2"), 5) },
                { "WalkLeftRed", new Animation(Content.Load<Texture2D>("Link blue/LinkLeftRed2"), 5) },
                { "HasDied", new Animation(Content.Load<Texture2D>("Link blue/LinkHasDied"), 1) },
            };

            V.playerList = new List<Player>()
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

        private void QuitButton_Click(object sender, System.EventArgs e)
        {
            Exit();
        }

        private void StartButton_Click(object sender, System.EventArgs e)
        {
            currentState = State.game;
        }

        protected override void UnloadContent()
        {
        }

        private void Restart()
        {
            
            V.playerList = new List<Player>()
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

            if (check)
            {
                V.deathCount++;
                V.spriteList.Add(  // add new grave every time player dies
               new Sprite(C.Grave)
               {
                   Position = V.deathHeroPoisition,

               }
           );
            }
         
            V.playerHealth = 100;
            check = false;
            V.win = false;

        }

        protected override void Update(GameTime gameTime)
        {
            if (currentState == State.menu)
            {
                foreach (var component in _gameComponents)
                    component.Update(gameTime);
            }
                if (currentState == State.game)
            {
                float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                timer -= elapsed;
                timer2 += elapsed;
                if (timer < 0)
                {
                    DoGameLogic();
                    C.explosion.Play(volume: 0.1f, pitch: 0.0f, pan: 0.0f);
                    timer = TIMER;
                }

                foreach (var player in V.playerList)
                {
                    player.Update(gameTime);

                    if (player.hasDied && !check)
                    {
                        Task.Delay(500).ContinueWith(t => Restart());  //delay for death animation show
                        check = true;
                    }
                    if (V.win == true)
                    {
                        Task.Delay(2000).ContinueWith(t => Restart());  //delay for death animation show
                        V.deathCount = 0;
                        V.score = 0;
                        timer2 = 0;
                    }
                }


                foreach (var cannon in V.cannonList)
                {
                    cannon.Update(gameTime);
                }


                foreach (var bullet in V.bulletsList)
                {
                    bullet.Update(gameTime);
                }


                // remove bullet when wall collision
                for (int i = V.bulletsList.Count - 1; i >= 0; --i)
                {
                    if (!V.bulletsList[i].isVisible)
                        V.bulletsList.RemoveAt(i);
                    //C.explosion.Play();
                }

                base.Update(gameTime);
            }
        }

        private void DoGameLogic()
        {
            foreach (var cannon in V.cannonList)
            {
                V.bulletsList.Add(new Bullet(C.bulletTexture, cannon));
                //C.newBullet.Play();
            }
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            spriteBatch.Begin();

            if(currentState == State.menu)
            {
                spriteBatch.Draw(C.cover, new Rectangle(0, 0, 960, 720), Color.White);
                foreach (var component in _gameComponents)
                    component.Draw(gameTime, spriteBatch);
            }

            if (currentState == State.game)
            {
                foreach (var map in V.mapList)
                    map.Draw(spriteBatch);

                foreach (var cannon in V.cannonList)
                    cannon.Draw(spriteBatch);

                foreach (var player in V.playerList)
                    player.Draw(spriteBatch);

                foreach (var bullet in V.bulletsList)
                    bullet.Draw(spriteBatch);

                if (V.spriteList.Count > 0)  // draw sprite different from player ( es grave )
                {
                    foreach (var sprite in V.spriteList)
                        sprite.Draw(spriteBatch);
                }
                if (V.win)
                {
                    
                    spriteBatch.Draw(C.win, new Rectangle(300, 300, 400, 200), Color.White);
                }

                spriteBatch.DrawString(font, string.Format("Time: {0}", timer2.ToString("n2")), new Vector2(10, 5), Color.White);
                spriteBatch.DrawString(font, string.Format("Score: {0}", V.score), new Vector2(10, 30), Color.White);
                spriteBatch.DrawString(font, string.Format("Death count: {0}", V.deathCount), new Vector2(10, 55), Color.White);  // death counter
                spriteBatch.DrawString(font, string.Format("Health: {0}", V.playerHealth), new Vector2(10, 80), Color.White);

            }


            spriteBatch.End();


            base.Draw(gameTime);

        }
    }
}
