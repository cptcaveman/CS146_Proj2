using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarkovChains.Input
{
    public class InputState
    {
        public InputState()
        {
            _mousePos = new Vector2();

            _mState = Mouse.GetState();
        }

        #region Mouse Properties

        /// <summary>
        /// Current mouse state.
        /// </summary>
        protected MouseState _mState;

        /// <summary>
        /// Previous mouse state.
        /// </summary>
        protected MouseState _pmState;

        protected Vector2 _mousePos;
        protected Vector2 _pmousePos;

        public bool LeftButtonJustPressed
        {
            get
            {
                return _pmState.LeftButton != ButtonState.Pressed 
                       && _mState.LeftButton == ButtonState.Pressed;
            }
        }

        public bool LeftButtonJustReleased
        {
            get
            {
                return _pmState.LeftButton == ButtonState.Pressed
                       && _mState.LeftButton != ButtonState.Pressed;
            }
        }

        public bool LeftButtonDown
        {
            get { return _mState.LeftButton == ButtonState.Pressed; }
        }

        public bool LeftButtonUp
        {
            get { return _mState.LeftButton == ButtonState.Released; }
        }

        public Vector2 MousePosition
        {
            get
            {
                return _mousePos;
            }
        }

        #endregion

        #region Keyboard Properties

        private KeyboardState _kState;
        private KeyboardState _pkState;
        private Keys[] _keysPressed;
        private Keys[] _pkeysPressed;

        public Keys[] KeysPressed
        {
            get { return _keysPressed; }
        }

        #endregion

        public void Update(GameTime gameTime)
        {
            PreUpdate(gameTime);

            OnUpdate(gameTime);

            PostUpdate(gameTime);
        }

        protected virtual void PreUpdate(GameTime gameTime)
        {
            //udpate the current mouse state
            _mState = Mouse.GetState();
            _mousePos.X = _mState.X;
            _mousePos.Y = _mState.Y;

            //update the current keyboard state
            _kState = Keyboard.GetState();
            _keysPressed = _kState.GetPressedKeys();
        }

        protected virtual void OnUpdate(GameTime gameTime)
        {

        }

        protected virtual void PostUpdate(GameTime gameTime)
        {
            //save the previous mouse state
            _pmState = _mState;
            _pmousePos = _mousePos;

            //save the previous keyboard state
            _pkState = _kState;
            _pkeysPressed = _keysPressed;
        }

        protected virtual void UpdateMouse()
        {

        }

        protected virtual void UpdateKeyboard()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            OnDraw(spriteBatch);
        }

        protected virtual void OnDraw(SpriteBatch spritebatch)
        {

        }
    }
}
