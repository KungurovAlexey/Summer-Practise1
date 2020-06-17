using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            bool ok;
            double up = 0, down = 0, diag = 0;
            Random rand = new Random();
            
            Console.WriteLine("Введите n");
            do
            {
                ok = int.TryParse(Console.ReadLine(), out n);
                if ((!ok) || (n<1)) Console.WriteLine("Введите натуральное число.");
            } while (!ok);
            
            double[,] arr = new double[n,n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = rand.Next(-10,10);
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < n; i++)
            {
                if (arr[i, 0] < 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i > j)
                            down += arr[i, j];
                        else if (i < j)
                            up += arr[i, j];
                        else diag += arr[i, j];
                    }
                }
            }

            Console.WriteLine($"Сумма элементов над главной диагональю в строках, которые начинаются с отрицательного числа =  {up}");
            Console.WriteLine($"Сумма элементов под главной диагональю в строках, которые начинаются с отрицательного числа =  {down}");
            Console.WriteLine($"Сумма элементов на главной диагональю в строках, которые начинаются с отрицательного числа =  {diag}");
        }

    }
}
