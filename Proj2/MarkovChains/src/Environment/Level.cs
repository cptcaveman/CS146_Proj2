using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkovChains.src.Environment
{
    public class Level
    {
        Texture2D _tileTexture1, _tileTexture2;
        private readonly int TILE_SIZE = 256;
        private int _width, _height;
        Vector2 _tileOrig;
        float _tileScale = 1.0f;

        int[][] _tileTextures;

        public Level(int numTilesX, int numTilesY)
        {
            _tileTexture1 = Game1.Instance.Content.Load<Texture2D>(@"Textures\grass_tile_1");
            _tileTexture2 = Game1.Instance.Content.Load<Texture2D>(@"Textures\grass_tile_2");

            _tileTextures = new int[numTilesX][];

            Random rand = new Random();

            for (int i = 0; i < _tileTextures.Length; ++i)
            {
                _tileTextures[i] = new int[numTilesY];
                for (int j = 0; j < _tileTextures[i].Length; ++j)
                {
                    if (rand.Next(10) < 2)
                        _tileTextures[i][j] = 0;
                    else
                        _tileTextures[i][j] = 1;
                }
            }

            _width = numTilesX * TILE_SIZE;
            _height = numTilesY * TILE_SIZE;
            _tileOrig = new Vector2(_tileTexture1.Bounds.Center.X, _tileTexture1.Bounds.Center.Y);
            _tileScale = (float)TILE_SIZE / _tileTexture1.Width;
        }

        public void Update(GameTime gameTime)
        {

        }

        public Vector2 GetCenter()
        {
            return new Vector2((float)_width / 2f, (float)_height / 2f);
        }

        Vector2 _tilePos = Vector2.Zero;

        public void Draw(SpriteBatch batch)
        {
            DrawTiles(batch);
        }

        private void DrawTiles(SpriteBatch batch)
        {
            int halfWidth = _width / 2;
            int helfHeight = _height / 2;

            int numTilesX = _width / TILE_SIZE;
            int numTilesY = _height / TILE_SIZE;

            for (int w = 0; w < numTilesX; w++)
            {
                _tilePos.X = w * TILE_SIZE;

                for (int h = 0; h < numTilesY; h++)
                {
                    _tilePos.Y = h * TILE_SIZE;

                    if(_tileTextures[w][h] == 1)
                        batch.Draw(_tileTexture1, _tilePos, null, Color.White, 0.0f, _tileOrig, _tileScale, SpriteEffects.None, 0.0f);
                    else
                        batch.Draw(_tileTexture2, _tilePos, null, Color.White, 0.0f, _tileOrig, _tileScale, SpriteEffects.None, 0.0f);
                }
            }
        }
    }
}
