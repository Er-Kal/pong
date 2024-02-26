using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Player : Sprite
    {
        public Player(Texture2D texture)
            : base(texture)
        {

        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();
            foreach(var sprite in sprites)
            {
                if (sprite == this)
                    continue;
                if (this.velocity.Y > 0 && this.CollidingTop(sprite) ||
                    this.velocity.Y < 0 && this.CollidingBottom(sprite))
                    this.velocity.Y = 0;
                if (this.velocity.X > 0 && this.CollidingLeft(sprite) ||
                    this.velocity.X < 0 && this.CollidingRight(sprite))
                    this.velocity.X = 0;
            }
            position += velocity;
            velocity = Vector2.Zero;
        }
        private void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                velocity.Y+=speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                velocity.Y -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Input.Right)){
                velocity.X += speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                velocity.X -= speed;
            }
        }
    }
}
