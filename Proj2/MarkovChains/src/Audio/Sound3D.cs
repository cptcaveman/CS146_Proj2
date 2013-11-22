using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;
using MarkovChains.src.Scene;

namespace MarkovChains.Audio
{
    public class Sound3D : Entity
    {
        private static int _bufferIdCounter = 0;

        private int _bufferID;
        private int _positionID;

        public Vector3 Velocity;

        private ALFormat format = ALFormat.Stereo16;
        private int _size;
        private int _freq;

        private Vector3 _listenerPos;
        private Vector3 _listenerUp;

        public Sound3D()
        {
            LoadALData();
        }

        public Sound3D(Vector2 _pos)
        {
            this.LocalPosition = _pos;

            LoadALData();
        }

        private bool LoadALData()
        {
            Velocity = new Vector3();
            _listenerPos = new Vector3();
            _listenerUp = new Vector3();

            AL.GenBuffers(1, out _bufferID);

            if (AL.GetError() != ALError.NoError)
                return false;

            if (Managers.AudioManager.Instance.XRam.IsInitialized)
                Managers.AudioManager.Instance.XRam.SetBufferMode(1, ref _bufferID, XRamExtension.XRamStorage.Hardware);

            //OpenTK.Audio.OpenAL.AL

            return false;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch)
        {

        }
    }
}
