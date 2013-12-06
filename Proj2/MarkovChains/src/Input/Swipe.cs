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

        protected override void OnUpdate(GameTime gameTime)
        {
            base.OnUpdate(gameTime);

            _mouseCurrCaptureTime += 1.0f;

            if (_mouseCurrCaptureTime > _mouseCaptureInterval)
            {
                if (LeftButtonDown)
                {
                    CaptureMousePos();

                    CreateSwipeSound();
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
        }

        private void CaptureMousePos()
        {
            if (_mousePositions.Count > _maxNumberOfPositions / 3)
                _mousePositions.Dequeue();

            _mouseCurrCaptureTime = 0.0f;
            _mousePositions.Enqueue(_mousePos);
        }

        private static void CreateSwipeSound()
        {
            double random = (new Random()).NextDouble();
            string name = "A";

            if (0 <= random && random <= .25)
                name = "D";
            else if (.33 < random && random <= .5)
                name = "G";
            else if (.5 < random && random <= .75)
                name = "Bb";

            MarkovChains.Managers.AudioManager.Instance.PlaySound(name);
        }

        protected override void OnDraw(SpriteBatch spriteBatch)
        {
            base.OnDraw(spriteBatch);

            if (_mousePositions.Count > 0)
            {
                Vector2 prevPos = _mousePositions.ElementAt(0);

                float weight = 10.0f;
                float deltaWeight = weight / _mousePositions.Count;

                for (int i = 1; i < _mousePositions.Count; ++i)
                {
                    Vector2 currPos = _mousePositions.ElementAt(i);

                    Debug.Debug.DrawLine(spriteBatch, prevPos, currPos, Color.Red, weight);

                    weight -= deltaWeight;
                    prevPos = currPos;
                }
            }
        }
    }
}
