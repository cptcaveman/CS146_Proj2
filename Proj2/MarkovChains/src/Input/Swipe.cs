using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MarkovChains.Input
{
    public class Swipe : InputState
    {
        private Queue<Vector2> _mousePositions;

        private const float _mouseCaptureInterval = 0.0f;
        private float _mouseCurrCaptureTime = 0.0f;

        private const int _maxNumberOfPositions = 20;

        public Swipe()
            :base()
        {
            _mousePositions = new Queue<Vector2>();
        }

        public override void Update(GameTime gameTime)
        {
            _mState = Mouse.GetState();

            _mousePos.X = _mState.X;
            _mousePos.Y = _mState.Y;

            _mouseCurrCaptureTime += 1.0f;

            //if (LeftButtonJustPressed || LeftButtonJustReleased)
            //{
            //    _mouseCurrCaptureTime = 0;
            //    _mousePositions.Enqueue(_mousePos);
            //}
            //else 
            if (_mouseCurrCaptureTime > _mouseCaptureInterval)
            {
                if (LeftButtonDown)
                {
                    if (_mousePositions.Count > _maxNumberOfPositions / 3)
                        _mousePositions.Dequeue();

                    _mouseCurrCaptureTime = 0.0f;
                    _mousePositions.Enqueue(_mousePos);
                }
                else if(LeftButtonJustReleased)
                {
                    _mouseCurrCaptureTime = 0;
                }
                else
                {
                    if (_mousePositions.Count > 0)
                        _mousePositions.Dequeue();
                }
            }

            _pmState = _mState;
            _pmousePos = _mousePos;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (_mousePositions.Count > 0)
            {
                Vector2 prevPos = _mousePositions.ElementAt(0);

                float weight = 10.0f;
                float deltaWeight = weight / _mousePositions.Count;

                for (int i = 1; i < _mousePositions.Count; ++i)
                {
                    Vector2 currPos = _mousePositions.ElementAt(i);

                    //float weight = 1 / (1 + Math.Abs(i - _mousePositions.Count / 2)) * 3.0f;
                    //float weight = (i / _mousePositions.Count - 1.0f) * 10.0f;

                    Debug.Debug.DrawLine(spriteBatch, prevPos, currPos, Color.Red, weight);

                    weight -= deltaWeight;
                    prevPos = currPos;
                }
            }
        }
    }
}
