using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labyrinth.Models;
using Labyrinth.Sprites;
using Labyrinth.Manager;

namespace Labyrinth.Sprites
{
    public class Player : Sprite
    {
        #region Fields

        protected AnimationManager _animationManager;
        protected Dictionary<string, Animation> _animations;
        protected int offset = 8;
        public bool hasDied = false;
        protected float _health;
        

        #endregion

        #region Properties

        public Input Input;

        public override Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;

                if (_animationManager != null)
                    _animationManager.Position = _position;
            }
        }

        public float Health
        {
            get { return _health; }
            set
            {
                _health = value;
            }
        }

        public float Speed = 1f;
        public Vector2 Velocity;

        #endregion

        #region Methods

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
                spriteBatch.Draw(_texture, new Rectangle((int)Position.X, (int)Position.Y, 30, 30), Color.White);
            else if (_animationManager != null)
                _animationManager.Draw(spriteBatch);
            else throw new Exception("This ain't right..!");
        }

        public virtual void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Velocity.Y = -Speed;
                V.score++;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Velocity.Y = Speed;
                V.score++;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                Velocity.X = -Speed;
                V.score++;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                Velocity.X = Speed;
                V.score ++;
            }
        }

        protected virtual void SetAnimations(string up, string down, string left, string right, string died)
        {
            if (hasDied)
                _animationManager.Play(_animations[died]);
            else if (Velocity.X > 0)
                _animationManager.Play(_animations[right]);
            else if (Velocity.X < 0)
                _animationManager.Play(_animations[left]);
            else if (Velocity.Y > 0)
                _animationManager.Play(_animations[down]);
            else if (Velocity.Y < 0)
                _animationManager.Play(_animations[up]);
            else _animationManager.Stop();
        }

        public Player(Texture2D texture)
            : base(texture)
        {
        }

        public Player(Dictionary<string, Animation> animations)
            : base(animations)
        {
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
        }

        public void Update(GameTime gameTime, List<Player> player, List<Map> _map)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Move();

            foreach (var map in _map)
            {
                if (map.ID == '1' || map.ID == 'C')
                {
                    if (this.Velocity.X >= 0 && IsTouchingLeft(map) ||
                       (this.Velocity.X <= 0 && IsTouchingRight(map)))
                        this.Velocity.X = 0;

                    if (this.Velocity.Y >= 0 && IsTouchingTop(map) ||
                       (this.Velocity.Y <= 0 && IsTouchingBottom(map)))
                        this.Velocity.Y = 0;
                }

                if (map.ID == 'L')
                {
                    if (IsTouchingLeft(map) || IsTouchingRight(map) || IsTouchingTop(map) || IsTouchingBottom(map))
                    {
                        V.animationDown = "WalkDownRed";
                        V.animationUp = "WalkUpRed";
                        V.animationLeft = "WalkLeftRed";
                        V.animationRight = "WalkRightRed";

                        if(Health > 0)
                        {
                            Health = Math.Max(0f,Health-deltaTime);
                            V.score += 15;
                            V.playerHealth = (int)Health * 20;
                        }
                        else
                        {
                            this.hasDied = true;
                            deltaTime = 0;
                            V.score += 50;
                            V.deathHeroPoisition = this.Position;  // save death position
                            this.Velocity.X = 0;
                            this.Velocity.Y = 0;
                        }
                    }
                }



                if (map.ID == '0')
                {
                    if (IsTouchingLeft(map) || IsTouchingRight(map) || IsTouchingTop(map) || IsTouchingBottom(map))
                    {
                        V.animationDown = "WalkDown";
                        V.animationUp = "WalkUp";
                        V.animationLeft = "WalkLeft";
                        V.animationRight = "WalkRight";
                    }
                }
            }

            SetAnimations(V.animationUp, V.animationDown, V.animationLeft, V.animationRight, V.animationDied);

            _animationManager.Update(gameTime);

            Position += 2 * Velocity;

            // keep the player in the map limitation
            _position.X = MathHelper.Clamp(Position.X, 0, C.MAINWINDOW.X - Rectangle.Width);
            _position.Y = MathHelper.Clamp(Position.Y, 0, C.MAINWINDOW.Y - Rectangle.Height);

            Velocity = Vector2.Zero;
            
        }

        public bool IsTouchingLeft(Map map)
        {
            return this.Rectangle.Right + this.Velocity.X > map.Rectangle.Left &&
              this.Rectangle.Left < map.Rectangle.Left &&
              this.Rectangle.Bottom > map.Rectangle.Top &&
              this.Rectangle.Top < map.Rectangle.Bottom;
        }

        public bool IsTouchingRight(Map map)
        {
            return this.Rectangle.Left + this.Velocity.X < map.Rectangle.Right  &&
              this.Rectangle.Right > map.Rectangle.Right &&
              this.Rectangle.Bottom > map.Rectangle.Top &&
              this.Rectangle.Top < map.Rectangle.Bottom;
        }

        public bool IsTouchingTop(Map map)
        {
            return this.Rectangle.Bottom + this.Velocity.Y > map.Rectangle.Top &&
              this.Rectangle.Top < map.Rectangle.Top &&
              this.Rectangle.Right > map.Rectangle.Left &&
              this.Rectangle.Left < map.Rectangle.Right;
        }

        public bool IsTouchingBottom(Map map)
        {
            return this.Rectangle.Top + this.Velocity.Y < map.Rectangle.Bottom  &&
              this.Rectangle.Bottom > map.Rectangle.Bottom &&
              this.Rectangle.Right > map.Rectangle.Left &&
              this.Rectangle.Left < map.Rectangle.Right;
        }

        #endregion
    }
}

