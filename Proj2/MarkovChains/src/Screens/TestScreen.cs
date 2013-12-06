using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MarkovChains.src.Player;
using MarkovChains.src.Camera;
using MarkovChains.Input;
using MarkovChains.Managers;
using MarkovChains.src.Environment;
using MarkovChains.src.Enemies;

namespace MarkovChains.Screens
{
    public class TestScreen : IScreen
    {
        Player _player;
        Camera2D _cam;
        Swipe _playerInput;
        Level _level;

        int numEnemies = 20;
        public static List<Enemy> _enemyList = new List<Enemy>();

        /// <summary>
        /// Constructor.
        /// </summary>
        public TestScreen()
        {
            Game1.Instance.IsMouseVisible = true;
            _level = new Level(20, 20);

            _playerInput = new Swipe();
            InputManager.Instance.AddInputState(_playerInput);

            _player = new Player(_level.GetCenter());
            _cam = new Camera2D();
            _cam.ParentToEntity(_player);

            Random rand = new Random();

            for (int i = 0; i < numEnemies; ++i)
            {
                _enemyList.Add(new Enemy(new Vector2((float)rand.NextDouble() * 20.0f * 256.0f, (float)rand.NextDouble() * 20.0f * 256.0f)));
            }
        }

        public void HandleInput(GameTime gameTime)
        {
            _player.HandleInput(_playerInput);
        }

        public void Update(GameTime gameTime)
        {
            //update the level
            _level.Update(gameTime);

            //update the player
            HandleInput(gameTime);
            _player.Update(gameTime);
            _cam.Update(gameTime);

            //update the enemies
            Enemy._playerPos = _player.GlobalPosition;
            foreach (Enemy e in _enemyList)
                e.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, _cam.GetTransformation(spriteBatch.GraphicsDevice));

            _level.Draw(spriteBatch);

            foreach (Enemy e in _enemyList)
                e.Draw(spriteBatch);

            _player.Draw(spriteBatch);

            spriteBatch.End();
        }

        public void Activate()
        {

        }

        public void Deactivate()
        {

        }
    }
}
