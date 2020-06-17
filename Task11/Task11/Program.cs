using System;

namespace Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 11;
            int k = 0;
            string str;
            bool ok;
            
            do
            {
                str = Console.ReadLine();
                if (str.Length < n * n)
                    Console.WriteLine("Введите строку из 121 буквы");             
                if (str.Length < n * n) 
                    ok = false;
                else ok = true;
            } while (!ok);

            char[,] mas = new char[n,n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mas[i, j] = str[j+k];
                    Console.Write(mas[i,j]);
                }
                Console.WriteLine();
                k = k + 5;
            }
            Console.WriteLine();
            Console.WriteLine();
            k = 0;

            string kod = "";//закодированная строка
            int min = 0;//минимальный индекс для данного слоя
            int max = n - 1;//максимальный индекс для данного слоя
            do
            {
                //начинаем новый слой
                for (int i = min; i <= max; i++)//Перебираем элементы верхней строки данного слоя(слева направо, начиная с первого и заканчивая последним)
                    kod = mas[min, i].ToString() + kod;
                for (int i = min + 1; i <= max; i++)//Перебираем элементы правого столбца данного слоя(сверху вниз, начиная со второго и заканчивя последним)
                    kod = mas[i, max].ToString() + kod;
                for (int i = max - 1; i >= min; i--)//Перебираем элементы нижней строки данного слоя (справа налево, начиная с предпоследнего и заканчивая первым)
                    kod = mas[max, i].ToString() + kod;
                for (int i = max - 1; i >= min + 1; i--)//Перебираем элементы левого столбца данного слоя (снизу вверх, начиная с предпоследнего и заканчивая вторым)
                    kod = mas[i, min].ToString() + kod;
                //заканчиваем слой
                min++;//увеличиваем минимальный индекс для нового слоя
                max--;//уменьшаем максимальный индекс для нового слоя
            } while (kod.Length != n * n);

            Console.WriteLine(kod);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mas[i, j] = kod[j + k];
                    Console.Write(mas[i, j]);
                }
                Console.WriteLine();
                k = k + 5;
            }

            k = n * n - 1;//номер элемента зашифрованной строки
            min = 0;//минимальный индекс для данного слоя
            max = n - 1;//максимальный индекс для данного слоя
            do
            {
                //начинаем заполнять новый слой массива
                for (int i = min; i <= max; i++)//Перебираем элементы верхней строки данного слоя(слева направо, начиная с первого и заканчивая последним)
                {
                    mas[min, i] = kod[k];
                    k--;
                }
                for (int i = min + 1; i <= max; i++)//Перебираем элементы правого столбца данного слоя(сверху вниз, начиная со второго и заканчивя последним)
                {
                    mas[i, max] = kod[k];
                    k--;
                }
                for (int i = max - 1; i >= min; i--)//Перебираем элементы нижней строки данного слоя (справа налево, начиная с предпоследнего и заканчивая первым)
                {
                    mas[max, i] = kod[k];
                    k--;
                }
                for (int i = max - 1; i >= min + 1; i--)//Перебираем элементы левого столбца данного слоя (снизу вверх, начиная с предпоследнего и заканчивая вторым)
                {
                    mas[i, min] = kod[k];
                    k--;
                }
                //заканчиваем заполнять слой
                min++;//увеличиваем минимальный индекс для нового слоя
                max--;//уменьшаем максимальный индекс для нового слоя
            } while (k != -1);
            
            string text = "";
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    text = text + mas[i, j].ToString();
            Console.WriteLine(text);

        }


    }
}
