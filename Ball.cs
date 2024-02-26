using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Ball : Sprite
    {
        public float ballAngle;
        

        public Ball(Texture2D texture)
            :base(texture)
        {
            this._texture = texture;
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {

            position += velocity;
            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;
                if (this.CollidingTop(sprite) || this.CollidingBottom(sprite))
                {
                    ballAngle = (float)Math.PI * 2 - ballAngle;
                    velocity.Y = (float)Math.Sin(ballAngle) * speed;
                    velocity.X = (float)Math.Cos(ballAngle) * speed;
                }
                if (this.CollidingLeft(sprite) || this.CollidingRight(sprite))
                {
                    ballAngle += (float)Math.PI / 2;
                    velocity.Y = (float)Math.Sin(ballAngle) * speed;
                    velocity.X = (float)Math.Cos(ballAngle) * speed;
                    speed += 0.1f;
                }
            }
        }
    }
}
