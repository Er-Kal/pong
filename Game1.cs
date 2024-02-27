using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Net;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Sprite> _playerSprites;
        private List<Sprite> _wallSprites;
        private Ball _ball;
        private Texture2D _paddleTexture;
        private Texture2D _ballTexture;
        private Texture2D _rightleftTexture;
        private Texture2D _topbottomTexture;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _paddleTexture = Content.Load<Texture2D>("Sprites/Paddle");
            _ballTexture = Content.Load<Texture2D>("Sprites/Ball");
            _rightleftTexture = Content.Load<Texture2D>("Sprites/rightleft");
            _topbottomTexture = Content.Load<Texture2D>("Sprites/topbottom");
            _playerSprites = new List<Sprite>()
            {
                new Player(_paddleTexture)
                {
                    Input = new Input()
                    {
                        Up=Keys.Up,
                        Down = Keys.Down,
                        Right=Keys.Right,
                        Left=Keys.Left,
                    },
                    position = new Vector2(50,50),
                    color=Color.White,
                    speed=5f,
                },
                new Player(_paddleTexture)
                {
                    Input = new Input()
                    {
                        Up=Keys.W,
                        Down = Keys.S,
                        Right=Keys.D,
                        Left=Keys.A,
                    },
                    position = new Vector2(700,50),
                    color=Color.Blue,
                    speed=5f,
                }
            };
            _wallSprites = new List<Sprite>()
            {
                new Sprite(_topbottomTexture)
                {
                    position=new Vector2(0,0),
                    color=Color.White,
                },
                new Sprite(_topbottomTexture)
                {
                    position=new Vector2(0,460),
                    color=Color.White,
                },
                new PointColliders(_rightleftTexture)
                {
                    position=new Vector2(0,0),
                    color=Color.White,
                },
                new PointColliders(_rightleftTexture)
                {
                    position=new Vector2(780,0),
                    color=Color.White,
                }
            };
            _ball = new Ball(_ballTexture)
            {
                position = new Vector2(390, 230),
                speed = 5f,
                color = Color.White,
                ballAngle = 1f,
                velocity = new Vector2(2, 2),
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (var sprite in _playerSprites)
            {
                sprite.Update(gameTime, _playerSprites);
            }
            _ball.Update(gameTime, _playerSprites, _wallSprites);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach(var sprite in _playerSprites)
            {
                sprite.Draw(_spriteBatch);
            }
            foreach (var sprite in _wallSprites)
            {
                sprite.Draw(_spriteBatch);
            }
            _ball.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
