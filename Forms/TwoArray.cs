using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms
{
    class TwoArray
    {
        public bool error = false;

        private int[,] a;
        private int lengthi;
        private int lengthj;

        private int minValue;
        private int maxValue;

        public TwoArray(int size1, int size2, int min, int max)
        {
            if (size1 <= 0 || size2 <= 0)
                throw new ArgumentException(
                    "The array dimensions must be greater than zero");

            if (min > max)
                throw new ArgumentException("Incorrect number range");

            a = new int[size1, size2];

            lengthi = size1;
            lengthj = size2;

            minValue = min;
            maxValue = max;
        }

        public int Lengthi
        {
            get
            {
                return lengthi;
            }
        }

        public int Lengthj
        {
            get
            {
                return lengthj;
            }
        }

        // Two-dimensional array indexer
        public int this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < lengthi &&
                    j >= 0 && j < lengthj)
                {
                    return a[i, j];
                }
                else
                {
                    error = true;
                    return 0;
                }
            }

            set
            {
                if (i >= 0 && i < lengthi &&
                    j >= 0 && j < lengthj &&
                    value >= minValue && value <= maxValue)
                {
                    a[i, j] = value;
                }
                else
                {
                    error = true;
                }
            }
        }

        // Searching for the workshop with minimum resources
        public int[] Min
        {
            get
            {
                int[] summ = new int[lengthi];

                for (int i = 0; i < lengthi; i++)
                {
                    int s = 0;

                    for (int j = 0; j < lengthj; j++)
                    {
                        s = checked(s + a[i, j]);
                    }

                    summ[i] = s;
                }

                int min = summ[0];
                int indexMin = 0;

                for (int i = 1; i < summ.Length; i++)
                {
                    if (summ[i] < min)
                    {
                        min = summ[i];
                        indexMin = i;
                    }
                }

                int[] massiv = new int[summ.Length + 1];

                massiv[0] = indexMin;

                for (int i = 0; i < summ.Length; i++)
                {
                    massiv[i + 1] = summ[i];
                }

                return massiv;
            }
        }
    }
}
