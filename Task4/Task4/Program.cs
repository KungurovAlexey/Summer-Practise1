using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            double b = Math.PI;
            double E, c;
            double fa, fc;
            bool ok;

            Console.WriteLine("Введите Эпсилент(погрешность)");
            do
            {
                ok = double.TryParse(Console.ReadLine(), out E);
                if (!ok || (E <= 0)) Console.WriteLine("Введите число больше 0");
            } while (!ok || (E <= 0));

            fa = 2 * Math.Sin(a) * Math.Sin(a) / 3 - 3 * Math.Cos(a) * Math.Cos(a) / 4;
            while (Math.Abs(a - b) > E)
            {
                c = (a + b) / 2;
                fc = 2 * Math.Sin(c) * Math.Sin(c) / 3 - 3 * Math.Cos(c) * Math.Cos(c) / 4;
                if (fc * fa < 0)
                    b = c;
                else
                {
                    a = c;
                    fa = fc;
                }
            }
            Console.WriteLine("Корень уравнения с погрешностью: {0} равен:{1:0.00000}", E,a);
        }
    }
}
