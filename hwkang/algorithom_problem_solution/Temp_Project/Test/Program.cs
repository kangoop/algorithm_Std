﻿using System;
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
            Console.WriteLine("bcz".IndexOfAny(new char[] { 'a', 'e', 'i', 'o', 'u' }));
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
