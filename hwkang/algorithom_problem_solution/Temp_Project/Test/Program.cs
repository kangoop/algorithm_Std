using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 5, 7, 10, 21 };
            for(int i = 0; i < arr.Length; i++)
            {
                test_func(arr, new int[i+1], 0, 0);
            }
            
        }

        static void test_func(int[] arr,int[] list,int index,int depth)
        {
            if (depth == list.Length)
            {
                for(int i = 0; i < list.Length; i++)
                {
                    if (i < (list.Length-1))
                    {
                        Console.Write(list[i] + ",");
                    }
                    else
                    {
                        Console.Write(list[i]);
                    }

                }
                Console.WriteLine();

                return;
            }
            else
            {
              for(int i = index; i < arr.Length; i++)
                {
                    list[depth] = arr[i];
                    test_func(arr, list, i + 1, depth + 1);
                }
            }
        }


    }
}
