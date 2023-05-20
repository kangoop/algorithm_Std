using System;

namespace Temp_Proejct
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] datas = new int[] { 13, 19, 5, 12, 8, 7, 4, 21, 2, 5 };


            int last_index = Partition(datas, 0, 10);

            for(int i = 0; i < datas.Length; i++)
            {
                if (i==last_index)
                {
                    Console.Write($"[{datas[i]}]\t");
                }
                else
                {
                    Console.Write(datas[i] + "\t");

                }
            }

            Console.WriteLine();
            Console.WriteLine("Last_Index:"+last_index);

            Partition(datas, 0, 3);

            for(int i = 0; i < 3; i++)
            {
                Console.Write(datas[i] + "\t");
            }

            Console.WriteLine();
            last_index = Partition(datas, 4,10);
            for (int i = 4; i < datas.Length; i++)
            {
                if (i == last_index)
                {
                    Console.Write($"[{datas[i]}]\t");
                }
                else
                {
                    Console.Write(datas[i] + "\t");

                }
            }


            Console.WriteLine();
            Console.WriteLine("Last_Index:" + last_index);

            Partition(datas, 4, 6);

            for (int i = 4; i < 6; i++)
            {
                Console.Write(datas[i] + "\t");
            }
            Console.WriteLine();
            last_index = Partition(datas, 7, 10);
            for (int i = 7; i < datas.Length; i++)
            {
                if (i == last_index)
                {
                    Console.Write($"[{datas[i]}]\t");
                }
                else
                {
                    Console.Write(datas[i] + "\t");

                }
            }

            Console.WriteLine();



            foreach (var item in datas) { Console.Write(item + "\t"); }


        }
        static public void QuickSort(int[] input, int left, int right)
        {
            if (left < right)
            {
                int q = Partition(input, left, right);
                QuickSort(input, left, q - 1);
                QuickSort(input, q + 1, right);
            }
        }

        static public int Partition(int[] data, int left_idx, int right_idx)
        {
            int target = data[right_idx - 1]; //배열의 마지막요소값
            int i = left_idx - 1;

            for (int j = left_idx; j < right_idx; j++)
            {
                if (data[j] <= target)
                {
                    i = i + 1;

                    Swap(data, i, j);

                }
                else
                {

                    int index = i + 1;
                    if (data[index] > target)
                    {

                    }
                    else
                    {
                        Swap(data, index, right_idx - 1);
                    }
                }
            }

            return i;

        }

        static public void Swap(int[] data, int a, int b)
        {
            int temp = data[a];
            data[a] = data[b];
            data[b] = temp;
        }

    }
}
