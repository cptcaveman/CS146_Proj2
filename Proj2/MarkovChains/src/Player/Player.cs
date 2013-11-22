using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkovChains.src.Player
{
    public class Player : MarkovChains.src.Scene.Entity
    {
        Texture2D texture = Game1.Instance.Content.Load<Texture2D>(@"Textures\player");
        Vector2 _orig;
        float _scale = 1.0f;

        public Player(Vector2 position)
            :base()
        {
            LocalPosition = position;
            //This is the case just for this demo. So, LocalPos serves no purpose as of now
            GlobalPosition = LocalPosition;
            _orig = new Vector2(texture.Bounds.Center.X, texture.Bounds.Center.Y);

            _scale = (256.0f / (float)texture.Bounds.Width) * .4f;
        }

        SpriteEffects dir = SpriteEffects.None;

        public void HandleInput(Input.InputState input)
        {
            if (input.KeysPressed.Contains(Microsoft.Xna.Framework.Input.Keys.A))
            {
                GlobalPosition.X += -4;
                dir = SpriteEffects.None;
            }
            if (input.KeysPressed.Contains(Microsoft.Xna.Framework.Input.Keys.D))
            {
                GlobalPosition.X += 4;
                dir = SpriteEffects.FlipHorizontally;
            }
            if (input.KeysPressed.Contains(Microsoft.Xna.Framework.Input.Keys.W))
                GlobalPosition.Y -= 4;
            if (input.KeysPressed.Contains(Microsoft.Xna.Framework.Input.Keys.S))
                GlobalPosition.Y += 4;

            if (GlobalPosition.X < 0)
                GlobalPosition.X = 0;
            if (GlobalPosition.X > 19 * 256)
                GlobalPosition.X = 19 * 256;

            if (GlobalPosition.Y < 0)
                GlobalPosition.Y = 0;
            if (GlobalPosition.Y > 19 * 256)
                GlobalPosition.Y = 19 * 256;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            batch.Draw(texture, GlobalPosition, null, Color.White, _rotation, _orig, _scale, dir, 0.0f);
        }
    }
}
