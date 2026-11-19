using System;

namespace Forms
{
    class TwoArray
    {
        public bool error = false;

        private int[,] a;
        private int length1;
        private int length2;

        public TwoArray(int size1, int size2)
        {
            if (size1 <= 0 || size2 <= 0)
                throw new ArgumentException("Array dimensions must be greater than 0");

            a = new int[size1, size2];

            length1 = size1;
            length2 = size2;
        }

        public int Length1
        {
            get { return length1; }
        }

        public int Length2
        {
            get { return length2; }
        }

        public int this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < length1 && j >= 0 && j < length2)
                    return a[i, j];

                error = true;
                return 0;
            }
            set
            {
                if (i >= 0 && i < length1 &&
                    j >= 0 && j < length2 &&
                    value >= -100 && value <= 100)
                {
                    a[i, j] = value;
                }
                else
                {
                    error = true;
                }
            }
        }

        public int CountNegative
        {
            get
            {
                int count = 0;

                for (int i = 0; i < length1; i++)
                {
                    for (int j = 0; j < length2; j++)
                    {
                        if (i + j > length2 - 1 && a[i, j] < 0)
                            count++;
                    }
                }

                return count;
            }
        }
    }
}