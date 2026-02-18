using System;
using System.Collections.Concurrent;

namespace ConsoleApplication1
{
        internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[,] array = new int[10, 10];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(100);
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1);)
                {
                    if (j == array.GetLength(1) - 1) break;
                    if (array[i, j] > array[i, j + 1])
                    {
                        int temp = array[i, j + 1];
                        array[i, j + 1] = array[i, j];
                        array[i, j] = temp;
                        j = 0;
                    }
                    else
                    {
                        j++;  
                    }
                    //Console.WriteLine($"i={i}, j={j}, value={array[i, j]}, value={array[i, j + 1]}");
                }
            }
            
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            
        } 
    }
}

