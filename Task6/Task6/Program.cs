using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Task6
{
    class Program
    {
        static int a1, a2, a3, N, E;
        
        static public int Search(int x)
        {
            if (x == 1)
            {
                return a1;
            }
            if (x == 2)
            {
                return a2;
            }
            if (x == 3)
            {
                return a3;
            }

            int s = Search(x - 1) + 2 * Search(x - 2) * Search(x - 3);
            return s;
        }   
        static void Main(string[] args)
        {
            int x;
            bool ok;
            int count = 4;

            Console.Write("N = ");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out N);
                if ((!ok) || (N < 1)) Console.WriteLine("Ошибка ввода.");
            } while ((!ok) || (N < 1));
            
            Console.Write("a1 = ");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out a1);
                if (!ok) Console.WriteLine("Ошибка ввода.");
            } while (!ok);

            Console.Write("a2 = ");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out a2);
                if (!ok) Console.WriteLine("Ошибка ввода.");
            } while (!ok);

            Console.Write("a3 = ");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out a3);
                if (!ok) Console.WriteLine("Ошибка ввода.");
            } while (!ok);

            Console.Write("E = ");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out E);
                if (!ok) Console.WriteLine("Ошибка ввода.");
            } while (!ok);

            while (count != N + 4)
            {
                x = Search(count);
                if (Math.Abs(x - a3) > E)
                    Console.Write($"{x}:{count}  ");
                else N++;
                count++;
            }
        }
    }
}
