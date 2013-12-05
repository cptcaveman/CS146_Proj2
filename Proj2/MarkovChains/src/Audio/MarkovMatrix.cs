using System.Collections.Generic;
using System.IO;
using System.Text;
namespace MarkovChains.Audio
{
    public class MarkovMatrix<T, K>
    {
        private List<string> _keys;
        private List<char> _values;

        private float[][] _matrix;

        public MarkovMatrix(int n, int m)
        {
            initializeMatrix(n, m);
        }

        public MarkovMatrix(List<string> rows, List<char> cols, string path, int markovOrder)
        {
            _keys = rows;
            _values = cols;

            initializeMatrix(rows.Count, cols.Count);

            fillMatrix(rows, cols, path, markovOrder);

            normalizeMatrix();
        }

        private void initializeMatrix(int n, int m)
        {
            _matrix = new float[n][];

            for (int x = 0; x < n; ++x)
            {
                _matrix[x] = new float[m];
            }
        }

        private void fillMatrix(List<string> rows, List<char> cols, string path, int markovOrder)
        {
            Stream stream = File.Open(path, FileMode.Open);

            if (stream == null)
                throw new FileNotFoundException();

            char[] buffer = new char[markovOrder + 1];

            int n = 0;
            int m = 0;

            using (StreamReader reader = new StreamReader(stream))
            {
                int numToRead = buffer.Length - 1;
                //this reads in the "prev" notes of the chain
                reader.Read(buffer, 0, numToRead);
                string chain = null;

                while (!reader.EndOfStream)
                {
                    reader.Read(buffer, buffer.Length - 1, 1);

                    //get the note chain
                    chain = new string(buffer, 0, buffer.Length - 1);

                    //check to see if the chain exists
                    if (_keys.Contains(chain))
                    {
                        n = _keys.IndexOf(chain);

                        m = _values.IndexOf(buffer[buffer.Length - 1]);

                        _matrix[n][m] += 1.0f;
                    }

                    //set previous notes. essentially shift the characters in the buffer by 1
                    for (int i = 1; i < buffer.Length; ++i)
                    {
                        buffer[i - 1] = buffer[i];
                    }
                }
            }
        }

        private void normalizeMatrix()
        {
            float rowSum = 0;

            for (int i = 0; i < _matrix.Length; ++i)
            {
                rowSum = 0;
                //find the sum of the row
                for (int j = 0; j < _matrix[i].Length; ++j)
                {
                    rowSum += _matrix[i][j];
                }

                if (rowSum > 0.0f)
                {
                    //normalize the values in the row
                    for (int j = 0; j < _matrix[i].Length; ++j)
                    {
                        _matrix[i][j] /= rowSum;
                    }
                }
            }
        }

        private static StringBuilder bobTheStringBuilder = new StringBuilder();

        public List<string> getKeys()
        {
            return _keys;
        }

        public List<char> getValues()
        {
            return _values;
        }

        public float getProbValue(string chain, char note)
        {
            int n = _keys.IndexOf(chain);
            int m = _values.IndexOf(note);
            return _matrix[n][m];
        }

        public override string ToString()
        {
            bobTheStringBuilder.Clear();

            for (int i = 0; i < _matrix.Length; ++i)
            {
                bobTheStringBuilder.Append("[ ");
                for (int j = 0; j < _matrix[i].Length; ++j)
                {
                    bobTheStringBuilder.Append(_matrix[i][j]);
                    if (j < _matrix[i].Length - 1)
                        bobTheStringBuilder.Append(", ");
                }
                bobTheStringBuilder.Append("]\n");
            }

            return bobTheStringBuilder.ToString();
        }
    }
}