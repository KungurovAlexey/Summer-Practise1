using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Task12
{
    class Program
    {
        public static int compares = 0;
        public static int changes = 0;
        public static int range = 10;
        public static int length = 2;
        public static int[] Copy(int[] sourse, int sourse_index, int length1)
        {
            int[] mas = new int[length1];
            Array.Copy(sourse, sourse_index, mas, 0, length1);
            return mas;
        }


        public static int[] sorting(int[] arr)
        {
            int[] mas = Copy(arr, 0, arr.Length);
            ArrayList[] lists = new ArrayList[range];
            for (int i = 0; i < range; ++i)
                lists[i] = new ArrayList();

            if (mas.Length > 1)
            {
                for (int step = 0; step < length; ++step)
                {
                    //распределение по спискам
                    for (int i = 0; i < mas.Length; ++i)
                    {
                        int temp = (mas[i] % (int)Math.Pow(range, step + 1)) /
                                                      (int)Math.Pow(range, step);
                        lists[temp].Add(arr[i]);
                    }
                    //сборка
                    int k = 0;
                    for (int i = 0; i < range; ++i)
                    {
                        for (int j = 0; j < lists[i].Count; ++j)
                        {
                            mas[k++] = (int)lists[i][j];
                            changes++;
                        }
                        compares++;
                    }
                    for (int i = 0; i < range; ++i)
                        lists[i].Clear();

                }
            }
            return mas;
        }


        public static int[] BubbleSort(int[] arr)
        {
            int[] mas = Copy(arr, 0, arr.Length);
            changes = 0;
            compares = 0;
            if (mas.Length > 1)
            {
                for (int i = 0; i < mas.Length; i++)
                {

                    for (int j = mas.Length - 2; j >= i; j--)
                    {
                        if (mas[j] > mas[j + 1])
                        {
                            int num = mas[j];
                            mas[j] = mas[j + 1];
                            mas[j + 1] = num;
                            changes++;
                        }
                        compares++;
                    }
                }
            }
            return mas;
        }

        public static int[] MergeSort(int[] arr)
        {
            int[] mas = Copy(arr, 0, arr.Length);
            if (mas.Length > 1)
            {
                int index = mas.Length / 2;
                int[] arr1 = MergeSort(Copy(mas, 0, index));
                int[] arr2 = MergeSort(Copy(mas, index, mas.Length - index));

                int count1 = 0, count2 = 0, i = 0;
                for (i = 0; count1 != arr1.Length && count2 != arr2.Length; i++)
                {
                    if (arr1[count1] > arr2[count2]) mas[i] = arr2[count2++];
                    else mas[i] = arr1[count1++];
                    compares++;
                    changes++;
                }
                while (count1 != arr1.Length) { mas[i++] = arr1[count1++]; compares++; changes++; }               
            }
            return mas;
        }

        public static int[] StartMergeSort(int[] arr)
        {
            changes = 0;
            compares = 0;
            return MergeSort(arr);
        }

        public static string ArrToString(int[] arr)
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i] + " ";
            }
            return str.Trim();
        }

        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] arr2 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] arr3 = new int[] { 5, 8, 1, 3, 6, 2, 9, 4, 10, 7 };

            Console.WriteLine($"Упорядоченный по возрастанию массив: {ArrToString(arr1)}");
            Console.WriteLine($"Упорядоченный по убыванию массив: {ArrToString(arr2)}");
            Console.WriteLine($"Неупорядоченный массив: {ArrToString(arr3)}");

            Console.WriteLine($"\nУпорядоченный по возрастанию массив. Сортировка пузырьком.\n{ArrToString(sorting(arr1))}\nКоличество пересылок: {changes}. Количество сравнений: {compares}");

            Console.WriteLine($"\nУпорядоченный по убыванию массив. Сортировка пузырьком.\n{ArrToString(BubbleSort(arr2))}\nКоличество пересылок: {changes}. Количество сравнений: {compares}");

            Console.WriteLine($"\nНеупорядоченный массив. Сортировка пузырьком.\n{ArrToString(BubbleSort(arr3))}\nКоличество пересылок: {changes}. Количество сравнений: {compares}");

            Console.WriteLine($"\nУпорядоченный по возрастанию массив. Сортировка слияниями.\n{ArrToString(StartMergeSort(arr1))}\nКоличество пересылок: {changes}. Количество сравнений: {compares}");

            Console.WriteLine($"\nУпорядоченный по убыванию массив. Сортировка слияниями.\n{ArrToString(StartMergeSort(arr2))}\nКоличество пересылок: {changes}. Количество сравнений: {compares}");

            Console.WriteLine($"\nНеупорядоченный массив. Сортировка слияниями.\n{ArrToString(StartMergeSort(arr3))}\nКоличество пересылок: {changes}. Количество сравнений: {compares}");

            Console.ReadKey();
        }
    }
}

