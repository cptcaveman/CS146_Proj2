using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkovChains.src.Scene
{
    public class Entity :IEntity
    {
        public Entity Parent;
        public List<IEntity> Children;

        public Matrix Transform = Matrix.Identity;
        public Vector2 LocalPosition = Vector2.Zero;
        public Vector2 GlobalPosition = Vector2.Zero;
        protected float _rotation = 0.0f;

        public Entity()
        {
            Children = new List<IEntity>();
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (IEntity e in Children)
                e.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch batch)
        {
            foreach (IEntity e in Children)
                e.Draw(batch);
        }


        public void ParentToEntity(Entity e)
        {
            if (Parent != null)
            {
                if (Parent.Children.Contains(this))
                    Parent.Children.Remove(this);
            }

            Parent = e;
        }
    }
}
