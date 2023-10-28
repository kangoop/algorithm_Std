using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baekjoon2309
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> data_list = InputData();

            List<int> filter_data = Fillter(data_list);

            OutputData(filter_data);
        }

        private static List<int> InputData()
        {
            List<int> listdata = new List<int>();

            for(int i=0;i<9;i++)
            {
                string str = Console.ReadLine();
                int value = int.Parse(str);
                listdata.Add(value);
            }

            return listdata;
        }

        private static List<int> Fillter(List<int> list)
        {
            int diff = list.Sum() - 100;//9명의 총합에서 7명의 총합 100 을 빼고
            //그 차이를 나태내는 2명을 구한다.

            for(int i=0;i<list.Count;i++)
            {
                int item1 = list[i];
                int item2 = diff - item1;

                if(diff<=0 || (item1==item2))
                {
                    continue;
                }
                else
                {
                    int index = list.IndexOf(item2,i);
                    if(index!=-1)
                    {
                        list.Remove(item1);
                        list.Remove(item2);

                        return list;
                    }
                }
            }

            return list;
        }

        private static void OutputData(List<int> list)
        {
            list.Sort();

            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
