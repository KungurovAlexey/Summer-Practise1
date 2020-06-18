
using System;
using System.Collections.Immutable;
using System.IO;
namespace Task1
{
    class Program
    {
        public static string In = @"Input.txt";
        public static string Out = @"Output.txt";
        static void Main(string[] args)
        {
            int count = 0;
            int n = Convert.ToInt32(Console.ReadLine());
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{n}{k}") ;
            string[] substr = new string[n];
            Random rand = new Random();
            FileStream file = new FileStream(In, FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine($"{n}{k}");
            string message = Console.ReadLine();
            writer.WriteLine(message);
            Console.WriteLine(message);
            FileStream file1 = new FileStream(Out, FileMode.OpenOrCreate);
            StreamWriter writer1 = new StreamWriter(file1);

            for (int i = 0; i < n - k; i++)
                substr[i] = message.Substring(i, k);

            for (int i = 0; i < n - k + 1; i++)
            {
                for (int j = i + 1; j < n - k + 1; j++)
                {
                    if (substr[i] == substr[j])
                        count = 1;
                }
            }

            if (count == 1)
            {
                writer1.WriteLine("YES");
                Console.WriteLine("YES");
            }
            else
            {
                writer1.WriteLine("NO");
                Console.WriteLine("NO");
            }
        }
    }
}
