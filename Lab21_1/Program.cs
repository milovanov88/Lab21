using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab21_1
{
    class Program
    {
        static int[,] field;
        static int y;
        static int x;

        static void Main(string[] args)
        {
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            field = new int[x, y];

            ThreadStart threadStart = new ThreadStart(Gardener1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardener2();



            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(field[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static void Gardener1()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (field[i, j] == 0)
                        field[i, j] = -1;
                    Thread.Sleep(1);
                }
            }
        }

        private static void Gardener2()
        {
            for (int i = y - 1; i >= 0; i--)
            {
                for (int j = x - 1; j > 0; j--)
                {
                    if (field[j, i] == 0)
                        field[j, i] = -2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}
