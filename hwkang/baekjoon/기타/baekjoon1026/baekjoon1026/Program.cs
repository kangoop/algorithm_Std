using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baekjoon1026
{
    class Program
    {
        static int arrsize; //배열의 길이 

        static void Main(string[] args)
        {
            Tuple<List<int>,List<int>> tuple = InputData();

            int result = FilterFunc(tuple);

            OutputData(result);
        }

        private static Tuple<List<int>, List<int>> InputData()
        {
            arrsize = int.Parse(Console.ReadLine());

            string a = Console.ReadLine().Replace(" ", ",");
            string b = Console.ReadLine().Replace(" ",",");

            a = a.Insert(a.Length, ",");
            b = b.Insert(b.Length, ",");

            List<int> a_list = new List<int>();
            List<int> b_list = new List<int>();

            int index = 0;
            for (int i = 0; i < arrsize; i++)
            {
                int commaindex = a.IndexOf(',', index);
                string value = a.Substring(index, commaindex);
                a_list.Add(int.Parse(value));
                a = a.Substring(commaindex+1);

                commaindex = b.IndexOf(',', index);
                value = b.Substring(index, commaindex);
                b_list.Add(int.Parse(value));
                b = b.Substring(commaindex+1);
            }
            //" " 을 "," 으로 변경하여 데이터를 입력
            Tuple<List<int>, List<int>> tuple = new Tuple<List<int>, List<int>>(a_list, b_list);
            return tuple;
        }

        private static int FilterFunc(Tuple<List<int>,List<int>> tuple)
        {
            int result = 0;
            List<int> a = tuple.Item1;
            List<int> b = tuple.Item2;
            for(int i=0;i<arrsize;i++)
            {
                int value_a = a.Min();//a의 최솟값
                int value_b = b.Max();//b의 최대값

                result += value_a * value_b;

                a.Remove(value_a);
                b.Remove(value_b);
            }
            return result;
        }

        private static void OutputData(int value)
        {
            Console.WriteLine(value);
        }
    }
}
