using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarkovChains.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarkovChains.Managers
{
    public class ScreenManager
    {
        private static ScreenManager _instance;
        private Stack<IScreen> _screenStack;

        /// <summary>
        /// Accessor to singleton.
        /// </summary>
        public static ScreenManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ScreenManager();

                return _instance;
            }
        }

        /// <summary>
        /// Constructor for singleton.
        /// </summary>
        private ScreenManager()
        {
            _screenStack = new Stack<IScreen>();
        }

        public void Update(GameTime gameTime)
        {
            //handle input for only the top most screen
            _screenStack.Peek().HandleInput(gameTime);

            //update only the top most screen
            _screenStack.Peek().Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(IScreen screen in _screenStack)
            {
                screen.Draw(spriteBatch);
            }
        }

        public void PopScreen()
        {
            IScreen screen = null;

            if (_screenStack.Count > 0)
                screen = _screenStack.Pop();

            if (screen != null)
                screen.Deactivate();
        }

        public void PushScreen(IScreen screen)
        {
            _screenStack.Push(screen);
        }
    }
}
