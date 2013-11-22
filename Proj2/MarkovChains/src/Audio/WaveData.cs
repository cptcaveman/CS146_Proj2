using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkovChains.src.Audio
{
    public class WaveData
    {
        public byte[] Data;
        public int Format;
        public int SamlpeRate;

        private WaveData(byte[] data, int format, int sampleRate)
        {
            this.Data = data;
            this.Format = format;
            this.SamlpeRate = sampleRate;
        }

        public void Dispose()
        {
            Data = null;
        }

        public static WaveData Create(byte[] buffer)
        {
            try
            {
                return new WaveData(null, 0, 0);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to create from byte array, " + e.Message);
            }
            return new WaveData(null, 0, 0);
        }
    }
}
