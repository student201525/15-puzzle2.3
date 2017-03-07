using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication66
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;

            int[] p = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };

            Console.WriteLine("\t *******************");
            Console.Write("\t * ИГРА - ПЯТНАШКИ *" + "\n");
            Console.WriteLine("\t *******************");

            Game2 Random= new Game2(p);
            Random.mixer(p);
            Game3 MyGame = new Game3(p);
            MyGame.drawField();

            for (; ; )
           {
                Console.WriteLine("Выберите число: ");
                int a = Convert.ToInt32(Console.ReadLine());

                MyGame.Move(a, MyGame);
                MyGame.drawField();


                Console.WriteLine("1 - Отменить ход, 2 - продолжить");
                int tmp = Convert.ToInt32(Console.ReadLine());


                if (tmp > 2 || tmp < 1) 
                {
                    Console.WriteLine("Нужно выбрать либо 1, либо 2");
                    Console.WriteLine("1 - Отменить ход, 2 - продолжить");
                    tmp = Convert.ToInt32(Console.ReadLine());
                }

                if (tmp == 1)
                {
                    Console.WriteLine("Вы выбрали 1 ");
                    MyGame.Undo(a);
                    MyGame.drawField();
                    Console.WriteLine("1 - Отменить откат, 2 - продолжить");
                    tmp = Convert.ToInt32(Console.ReadLine());

                    if (tmp > 2)
                    {
                        Console.WriteLine("Нужно выбрать либо 1, либо 2");
                        Console.WriteLine("1 - Отменить ход, 2 - продолжить");
                        tmp = Convert.ToInt32(Console.ReadLine());
                    }

                    if (tmp == 1)
                    {
                        Console.WriteLine("Вы выбрали 1 ");
                        MyGame.Redo(a);
                        MyGame.drawField();
                    }
                    if (tmp == 2)
                    {
                        Console.WriteLine("Вы выбрали 2 ");
                    }
                }

                if (tmp == 2)
                {
                    Console.WriteLine("Вы выбрали 2 ");
                }

                if (MyGame.finish())
                {
                    MyGame.drawField();
                    Console.WriteLine("Вы выиграли!!!!");
                    Console.WriteLine("Конец игры");
                    break;
                }
                score++;

                Console.WriteLine("Количество ходов: " + score);
            }
        }
    }
}