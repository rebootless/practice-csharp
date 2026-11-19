using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Forms
{
    class Arrays
    {
        public bool error = false;

        private int[] a;
        private int length;

        public Arrays(int size)
        {
            a = new int[size];
            length = size;
        }

        public int Length
        {
            get { return length; }
        }

        public int Min
        {
            get
            {
                int min = a[0];

                for (int i = 0; i < length; i++)
                {
                    if (a[i] < min)
                        min = a[i];
                }

                return min;
            }
        }

        public int this[int i]
        {
            get
            {
                if (i >= 0 && i < length)
                    return a[i];
                else
                {
                    error = true;
                    return 0;
                }
            }
            set
            {
                if (i >= 0 && i < length &&
                    value >= -100 && value <= 100)
                    a[i] = value;
                else
                    error = true;
            }
        }
    }
}
