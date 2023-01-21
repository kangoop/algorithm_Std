using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baekjoon11399
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> datalist = InputData();

            OutputData(datalist);
        }

        private static List<int> InputData()
        {
            List<int> timelist = new List<int>();

            int man_cnt = Convert.ToInt32(Console.ReadLine());

            string str = Console.ReadLine();
            str  = str.Insert(str.Length," ");
            int start_index = 0;
            for(int i=0;i<man_cnt;i++)
            {
                int index = str.IndexOf(' ', start_index);

                string value = str.Substring(start_index, index);

                int timevalue = Convert.ToInt32(value);

                timelist.Add(timevalue);

                str = str.Substring(index+1);
            }

            return timelist;
        }

        private static void OutputData(List<int> waittimelist)
        {
            long wait_time = 0;
            long sum = 0;
            waittimelist.Sort();

            foreach(var item in waittimelist)
            {
                long value = item + wait_time;
                wait_time = value;
                sum += wait_time;
            }

            Console.Write(sum);
        }
    }
}
