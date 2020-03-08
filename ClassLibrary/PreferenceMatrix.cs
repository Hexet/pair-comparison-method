using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ClassLibrary
{
    public class PreferenceMatrix
    {
        float[,] Matrix;
        public int size;
        public PreferenceMatrix(int s)
        {
            size = s;
            Matrix = new float[size, size];
        }

        public float this[int index1, int index2]
        {
            get { return Matrix[index1, index2]; }
            set { Matrix[index1, index2] = value; }
        }

        public int[] PreferenceMatrixProcessing()
        {
            int[] orderedIndexAlternatives = new int[size];
            float[] C = new float[size];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    C[i] += Matrix[i,j];
            ArrayList a = new ArrayList();
            for (int i = 0; i < size; i++)
            {
                a.Add(new Tuple<float, int>(C[i], i));
            }
            a.Sort(); int k = size - 1;
            foreach (Tuple<float, int> item in a)
            {
                orderedIndexAlternatives[k] = item.Item2;
                k--;
            }
            return orderedIndexAlternatives;
        }
    }
}