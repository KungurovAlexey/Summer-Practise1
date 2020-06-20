
using System;
using System.Collections.Immutable;
using System.IO;
namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1, line2;
            try
            {
                using (StreamReader sr = new StreamReader("INPUT.TXT", System.Text.Encoding.Default))
                {
                    line1 = sr.ReadLine();
                    line2 = sr.ReadLine();
                    Console.WriteLine(line1);
                    Console.WriteLine(line2);
                }

                if ((line1 != null) && (line2 != null))
                {
                    string StrN = "";
                    string StrK = "";
                    int count = 0;
                    int num = 0;
                    
                    while (line1[num] != ' ')
                    {
                        StrN = StrN + line1[num].ToString();
                        num++;
                    }

                    num++;
                    while (line1[num] != ' ')
                    {
                        StrK = StrK + line1[num].ToString();
                        num++;
                        if (num >= line1.Length)
                            break;
                    }
                    int n = Convert.ToInt32(StrN);
                    int k = Convert.ToInt32(StrK);

                    string[] substr = new string[n];
                    Random rand = new Random();

                    for (int i = 0; i < n - k + 1; i++)
                        substr[i] = line2.Substring(i, k);

                    for (int i = 0; i < n - k + 1; i++)
                    {
                        for (int j = i + 1; j < n - k + 1; j++)
                        {
                            if (substr[i] == substr[j])
                                count = 1;
                        }
                    }

                    using (StreamWriter sw = new StreamWriter("OUTPUT.TXT", true, System.Text.Encoding.Default))
                    {
                        if (count == 1)
                        {
                            sw.WriteLine("YES");
                            Console.WriteLine("YES");
                        }
                        else
                        {
                            sw.WriteLine("NO");
                            Console.WriteLine("NO");
                        }
                    }
                    Console.WriteLine("Запись выполнена");
                }
                else Console.WriteLine("Пустой файл");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
