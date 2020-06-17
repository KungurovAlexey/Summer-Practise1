using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y;
            bool ok;
            double U;
            
            Console.WriteLine("Введите x.");
            do
            {
                ok = double.TryParse(Console.ReadLine(), out x);
                if (!ok) Console.WriteLine("Введите число.");
            } while (!ok);

            Console.WriteLine("Введите y.");
            do
            {
                ok = double.TryParse(Console.ReadLine(), out y);
                if (!ok) Console.WriteLine("Введите число.");
            } while (!ok);

            if ((x * x + y * y <= 2) && (y >= -x) && (y >= x))
                U = Math.Sqrt(Math.Abs(x * x - 1));
            else U = x + y;
            Console.WriteLine($"U = {U}");
        }
    }
}
