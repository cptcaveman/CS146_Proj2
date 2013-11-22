using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MarkovChains.Input;
using MarkovChains.src.Managers;

namespace MarkovChains.Managers
{
    public class InputManager : IManager
    {
        private static InputManager _instance;

        public static Texture2D Blank = Game1.Instance.Content.Load<Texture2D>(@"blank");

        private List<InputState> _inputStates;

        /// <summary>
        /// Accessor for singleton.
        /// </summary>
        public static InputManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InputManager();

                return _instance;
            }
        }

        private InputManager()
        {
            _inputStates = new List<InputState>();
        }

        public void Initialize()
        {

        }

        public void LoadContent()
        {

        }

        public void UnloadContent()
        {

        }

        public void AddInputState(InputState state)
        {
            if (!_inputStates.Contains(state))
                _inputStates.Add(state);
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < _inputStates.Count; ++i)
                _inputStates[i].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < _inputStates.Count; ++i)
                _inputStates[i].Draw(spriteBatch);
        }

        public bool KeyPressed(Keys key)
        {
            for (int i = 0; i < _inputStates.Count; ++i)
                if (_inputStates[i].KeysPressed != null)
                    if (_inputStates[i].KeysPressed.Contains(key))
                        return true;

            return false;
        }
    }
}
