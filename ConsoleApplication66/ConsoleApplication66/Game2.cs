using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication66
{
    class Game2 : Game
    {
        public Game2(int[] point): base(point)
        {
        }

        public bool finish()
        {
            int value = 1;
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    if (field[i, j] == value)
                    {
                        ++value;
                        if (value == Length)
                        {
                            value = 0;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }

            }
            return true;

        }

        public void mixer(int[] p)
        {

            int tmp = 0;

            Random rnd = new Random();

            for (int i = 0; i < p.Length; i++)
            {
                bool isExist = false;
                do
                {
                    isExist = false;
                    tmp = rnd.Next(0, p.Length);
                    for (int j = 0; j < i; j++)
                    {
                        if (tmp == p[j]) { isExist = true; }
                    }
                }
                while (isExist);
                p[i] = tmp;
            }
        }


    }
}
