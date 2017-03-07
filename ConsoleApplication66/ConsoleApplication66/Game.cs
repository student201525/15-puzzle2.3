using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication66
{
    class Game
    {

        public int[] point = new int[100];
        public int Length = 0;

        public static int[] ArrayText = new int[100];
        public const int width = 4, height = 4;
        public int[,] field = new int[width, height];
        public Points[] FieldValue = new Points[100];

        public Game(int[] point)
        {

            int ruru = 0;

            //string[] file = new string[4];
           
            Length = width*height;

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    field[j, i] = point[ruru];
                    FieldValue[point[ruru]] = new Points(j, i);
                    ruru++;

                }
            }

        }

        public int this[int x, int y]
        {
            get
            {
                if (x < 0 || x >= width*height || y < 0 || y >= width * height)
                {
                    throw new ArgumentOutOfRangeException("Indexes are out of range");
                }
                return field[x, y];
            }
        }

        public Points GetLocation(int value)
        {

            return FieldValue[value];
        }


        public void drawField()
        {

            Console.Write("~~~~~~~~~~~~~~~~~~~~~~~~~~~~" + "\n");
            for (int i = 0; i < width; i++)
            {

                for (int j = 0; j < height; j++)
                {
                    Console.Write(field[i, j] + "\t");
                }
                Console.WriteLine();

            }

            Console.Write("~~~~~~~~~~~~~~~~~~~~~~~~~~~~" + "\n");

        }

        public void Move(int value, Game3 obj)
        {

            try
            {

                if (value > 15 || value < 0)
                {
                    throw new ArgumentException();
                }

                int x = GetLocation(0).x;
                int y = GetLocation(0).y;

                int ValueX = GetLocation(value).x;
                int ValueY = GetLocation(value).y;

                if ((ValueX == x && (ValueY == y - 1 || ValueY == y + 1)) || (ValueY == y && (ValueX == x - 1 || ValueX == x + 1)))
                {

                    field[x, y] = value;
                    field[ValueX, ValueY] = 0;

                    var vere = FieldValue[0];
                    FieldValue[0] = FieldValue[value];
                    FieldValue[value] = vere;

                    obj.History(value);

                }

                else
                {
                    throw new Exception();
                }
            }

            catch (ArgumentException)
            {
                Console.WriteLine("Такого числа не существует, попробуйте еще раз: ");
            }
            catch (Exception)
            {
                Console.WriteLine("Рядом с этим числом нету 0, попробуйте еще раз: ");
            }


        }

        //public static int TextSCV()
        //{
        //    int ruru = 0;
        //    try
        //    {
        //        string[] text = File.ReadAllLines(@"C:\Users\сергей\Desktop\TriangleGit\Switty\ConsoleApplication9\ConsoleApplication9\text.csv");
        //        Char place = ' ';

        //        for (int i = 0; i < text.Length; ++i)
        //        {
        //            string[] row = text[i].Split(place);
        //            foreach (var substring in row)
        //            {
        //                ArrayText[ruru] = Convert.ToInt32(substring);
        //                //Console.WriteLine(ArrayText[ruru]);
        //                ++ruru;
        //            }
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("The file could not be read:");
        //        Console.WriteLine(e.Message);
        //    }
        //    return ruru;
        //}
    }
}