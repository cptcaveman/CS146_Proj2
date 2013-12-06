using MarkovChains.src.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkovChains.src.Enemies
{
    public class Enemy : Entity
    {
        static Texture2D texture_idle = Game1.Instance.Content.Load<Texture2D>(@"Textures\enemy_idle");
        static Texture2D texture_chase = Game1.Instance.Content.Load<Texture2D>(@"Textures\enemy_chase");
        static Texture2D texture_damaged = Game1.Instance.Content.Load<Texture2D>(@"Textures\enemy_damaged");

        static Random rand = new Random();

        private Texture2D _texture;
        Vector2 _orig;
        float _scale = 1.0f;

        SpriteEffects dir = SpriteEffects.None;

        public static Vector2 _playerPos;
        public Boolean _transFlag;

        enum State
        {
            Idle = 0,
            Chase,
            Damaged,
        }

        State _state = State.Idle;

        public Enemy(Vector2 pos)
            :base()
        {
            GlobalPosition = pos;
            _orig = new Vector2();
        }

        float timer = 0.0f;
        float swapDirAt = 2.0f;
        int dirX = -1;
        int dirY = 1;

        public override void Update(GameTime gameTime)
        {

            if (Vector2.DistanceSquared(_playerPos, GlobalPosition + LocalPosition) < 60000.0f)
            {
                Vector2 disp = _playerPos - GlobalPosition - LocalPosition;
                disp.Normalize();

                if (disp.X < 0)
                    dir = SpriteEffects.FlipHorizontally;
                else
                    dir = SpriteEffects.None;

                GlobalPosition.X += disp.X * 3.75f;
                GlobalPosition.Y += disp.Y * 3.75f;

                _texture = texture_chase;

                _transFlag = true;

                timer = 0;
            }
            else
            {
                _texture = texture_idle;
                timer += gameTime.ElapsedGameTime.Milliseconds / 1000.0f;
                _transFlag = false;
                if (timer > swapDirAt)
                {
                    double test = rand.NextDouble();

                    timer = 0.0f;

                    if (test < .3)
                    {
                        dirX = -1;
                        dir = SpriteEffects.FlipHorizontally;
                    }
                    else if (test < .6)
                        dirX = 0;
                    else
                    {
                        dirX = 1;
                        dir = SpriteEffects.None;
                    }

                    test = rand.NextDouble();


                    if (test < .3)
                        dirY = -1;
                    else if (test < .6)
                        dirY = 0;
                    else
                        dirY = 1;
                }

                LocalPosition += Vector2.UnitX * dirX + Vector2.UnitY * dirY;

                float dist = LocalPosition.Length();

                if (dist > 150.0f)
                {
                    Vector2 unit = Vector2.Normalize(LocalPosition);

                    LocalPosition = unit * 150.0f;
                }
            }

            _orig.X = (float)_texture.Bounds.Center.X;
            _orig.Y = (float)_texture.Bounds.Center.Y;

            _scale = (256.0f / (float)_texture.Bounds.Width) * .4f;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(_texture, GlobalPosition + LocalPosition, null, Color.White, 0.0f, _orig, _scale, dir, 0.0f);
        }
    }
}
