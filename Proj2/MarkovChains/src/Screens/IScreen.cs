using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarkovChains.Screens
{
    /// <summary>
    /// Interface for all screens.
    /// </summary>
    public interface IScreen
    {
        /// <summary>
        /// Handle input for this screen
        /// </summary>
        /// <param name="gameTime"></param>
        void HandleInput(GameTime gameTime);

        /// <summary>
        /// Update the screen
        /// </summary>
        /// <param name="gameTime"></param>
        void Update(GameTime gameTime);

        /// <summary>
        /// Draw the screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        void Draw(SpriteBatch spriteBatch);

        /// <summary>
        /// Activate the screen.
        /// </summary>
        void Activate();

        /// <summary>
        /// Deactivate the screen. Unload assets, etc.
        /// </summary>
        void Deactivate();
    }
}
