using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkovChains.src.Camera
{
    public class Camera2D : MarkovChains.src.Scene.Entity
    {
        protected float _zoom;

        public float Zoom
        {
            get { return _zoom; }
            set
            {
                _zoom = value;
                if (_zoom < .1f) _zoom = .1f;
            }
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        public Camera2D()
        {
            _zoom = 1.0f;
            _rotation = 0.0f;
            LocalPosition = Vector2.Zero;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Parent != null)
            {
                Vector2 disp = Parent.GlobalPosition - GlobalPosition;

                //clamp the position of the camera within a radius
                //of 10.0f from it's parent
                if (disp.Length() > 100.0f)
                {
                    Vector2 unit = Vector2.Normalize(disp);

                    GlobalPosition = Parent.GlobalPosition - unit * 100.0f;
                }

                if (GlobalPosition.X < Game1.Instance.GraphicsDevice.Viewport.Width / 2 - 256 / 2)
                    GlobalPosition.X = Game1.Instance.GraphicsDevice.Viewport.Width / 2 - 256 / 2;
                if (GlobalPosition.X > 20 * 256 - Game1.Instance.GraphicsDevice.Viewport.Width / 2 - 256 / 2)
                    GlobalPosition.X = 20 * 256 - Game1.Instance.GraphicsDevice.Viewport.Width / 2 - 256 / 2;

                if (GlobalPosition.Y < Game1.Instance.GraphicsDevice.Viewport.Height / 2 - 256 / 2)
                    GlobalPosition.Y = Game1.Instance.GraphicsDevice.Viewport.Height / 2 - 256 / 2;
                if (GlobalPosition.Y > 20 * 256 - Game1.Instance.GraphicsDevice.Viewport.Height / 2 - 256 / 2)
                    GlobalPosition.Y = 20 * 256 - Game1.Instance.GraphicsDevice.Viewport.Height / 2 - 256 / 2;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }

        public Matrix GetTransformation(GraphicsDevice g)
        {
            Transform = Matrix.CreateTranslation(
                new Vector3(-GlobalPosition.X, -GlobalPosition.Y, 0)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(new Vector3(Zoom, Zoom, 1.0f)) *
                Matrix.CreateTranslation(new Vector3(g.Viewport.Width / 2, g.Viewport.Height / 2, 0));

            return Transform;
        }
    }
}
