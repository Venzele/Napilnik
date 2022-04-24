using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    class Program
    {
        public static int Enumerate(int[] array, int element)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == element)
                    return i;

            return -1;
        }
    }
}