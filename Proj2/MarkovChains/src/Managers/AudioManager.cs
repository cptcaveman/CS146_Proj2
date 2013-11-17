using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace MarkovChains.Managers
{
    public class AudioManager
    {
        private static AudioManager _instance;

        /// <summary>
        /// Singleton instance of class.
        /// </summary>
        public static AudioManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AudioManager();

                return _instance;
            }
        }

        public AudioManager()
        {

        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
