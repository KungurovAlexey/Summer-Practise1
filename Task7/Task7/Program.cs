using System;

namespace Task7
{
    class Program
    {

        // Проверка, есть ли еще возможные комбинации
        static public bool Check(int[] mas, int Max)
        {
            // Логический флаг
            bool ok = true;
            // Вспомогательная переменная для прохода по массиву
            int i = 0;
            while (ok && i < mas.Length)
                if (mas[i] == Max - mas.Length + i + 1)
                    ok = true;
                else
                    ok = false;

            return !ok;
        }

        // Генерация следующей комбинации
        static public void Add(int[] mas, int Max)
        {
            // Вспомогательная переменная для прохода по массиву
            int i = mas.Length - 1;
            while (mas[i] == Max - mas.Length + i + 1)
                i--;
            mas[i]++;
            for (i = i + 1; i < mas.Length; i++)
                mas[i] = (mas[i - 1] + 1);
        }

        static void Main(string[] args)
        {
            // Количество элементов
            int N, K;
            // Длина сочетаний
            // Флаг правильности ввода
            bool ok;

            // Ввод количества элементов
            do
            {
                Console.WriteLine("Введите количество элементов для сочетаний:");
                ok = int.TryParse(Console.ReadLine(), out N) && N > 0;
                if ((!ok )|| (N < 0))
                    Console.WriteLine("Введите натуральное число");
            } while ((!ok) || (N <= 0));
            // Ввод длины сочетаний
            do
            {
                Console.WriteLine("Введите длину сочетаний - от 1 до {0}:", N);
                ok = int.TryParse(Console.ReadLine(), out K) && K > 0 && K <= N;
                if ((!ok) || (K > N))
                    Console.WriteLine(" введите натуральное число от 1 до {0}.", N);
            } while ((!ok) || (K > N));

            // Максиммальный возможный элемент
            // Массив для представления сочетания
            int[] arr = new int[K];
            for (int i = 0; i < K; i++)
                arr[i] = i;
            Console.WriteLine("Сочетания без повторений:");
            for (int i = 0; i < arr.Length; i++)
                Console.Write("{0} ", arr[i] + 1);
            Console.WriteLine();
            while (Check(arr, N-1))
            {
                Add(arr, N-1);
                for (int i = 0; i < arr.Length; i++)
                    Console.Write("{0} ", arr[i] + 1);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
