using System;
using System.Collections.Immutable;
using System.IO;
using System.Xml;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            string line1, line2;
            try
            {
                using (StreamReader sr = new StreamReader("INPUT.TXT", System.Text.Encoding.Default))
                {
                    line1 = sr.ReadLine();
                    line2 = sr.ReadToEnd();
                    Console.WriteLine(line1);
                    Console.WriteLine(line2);
                }

                if ((line1 != null) && (line2 != null))
                {
                    string StrN = "";
                    string StrM = "";
                    int num = 0;

                    while (line1[num] != ' ')
                    {
                        StrN = StrN + line1[num].ToString();
                        num++;
                    }

                    num++;
                    while (line1[num] != ' ')
                    {
                        StrM= StrM + line1[num].ToString();
                        num++;
                        if (num >= line1.Length)
                            break;
                    }
                    
                    int n = Convert.ToInt32(StrN);
                    int m = Convert.ToInt32(StrM);

                    char[,] ch = new char[n, m];
                    char[,] ch1 = new char[n, m];
                    char[,] ch2 = new char[n, m];
                    Random rand = new Random();

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            if (i % 2 == 0)
                            {
                                if (j % 2 == 0)
                                {
                                    ch1[i, j] = 'B';
                                    ch2[i, j] = 'W';
                                }
                                else
                                {
                                    ch1[i, j] = 'W';
                                    ch2[i, j] = 'B';
                                }
                            }
                            else
                            {
                                if (j % 2 == 1)
                                {
                                    ch1[i, j] = 'B';
                                    ch2[i, j] = 'W';
                                }
                                else
                                {
                                    ch1[i, j] = 'W';
                                    ch2[i, j] = 'B';
                                }
                            }
                        }
                    }

                    int t = 0;
                    string str = line2.Replace(" ", "");

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            ch[i, j] = str[t + j];
                        }
                        t = t + n; ;
                    }

                        using (StreamWriter sw = new StreamWriter("OUTPUT.TXT", true, System.Text.Encoding.Default))
                        {
                            
                            
                        
                                         
                    
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            if (ch[0, 0] == ch1[0, 0])
                            {
                                if (ch[i, j] != ch1[i, j])
                                {
                                    ch[i, j] = ch1[i, j];
                                    count++;
                                    Console.WriteLine($"{i + 1} {j+1}");
                                    sw.WriteLine($"{i + 1} {j+1}");
                                }
                            }
                            else
                            {
                                if (ch[i, j] != ch2[i, j])
                                {
                                    ch[i, j] = ch2[i, j];
                                    count++;
                                    Console.WriteLine($"{i + 1} {j+1}");
                                    sw.WriteLine($"{i + 1} {j+1}");
                                }
                            }
                        }
                    }
                        sw.WriteLine(count);
                        Console.WriteLine(count);
                    }
                Console.WriteLine("Запись выполнена");
                
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            Console.Write(ch[i, j] + " ");
                        }
                        Console.WriteLine();
                        t = t + n; ;
                    }                    

                }else Console.WriteLine("Пустой файл");
            }            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }                     
        }
    }
}  

