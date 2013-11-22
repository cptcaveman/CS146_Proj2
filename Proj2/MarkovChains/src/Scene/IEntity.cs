using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkovChains.src.Scene
{
    public interface IEntity
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch batch);
        void ParentToEntity(Entity e);
    }
}
