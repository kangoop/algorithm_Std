using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp_project_netframework
{
    public class Item_value
    {
        public int value
        {
            get; set;
        }
        public int value_idx
        {
            get; set;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {

            OutputData(Process_Data(InputData()));
        }


        static List<int> InputData()
        {
            List<int> data = new List<int>();

            while (true)
            {
                string temp = Console.ReadLine();

                if(temp ==null || temp==string.Empty)
                {
                    break;
                }
                else
                {
                    data.Add(int.Parse(temp));

                }

            }
            

            return data;
        }

        static int Process_Data(List<int> data)
        {
            int data_cnt = data[0];

            List<Item_value> list_item = new List<Item_value>();

            for(int i=1;i<data.Count;i++)
            {
                list_item.Add(new Item_value { value = data[i], value_idx = i });
            }

            int max_profit = int.MinValue;
            int min_profit = list_item[0].value;

            for(int i=1;i<data_cnt;i++)
            {
                int profit = list_item[i].value - min_profit;

                if(profit > max_profit) // 현재최대이익이 계산된 이익보다 클 경우 최대이익 변경  
                {
                    max_profit = profit;
                }

                if(list_item[i].value < min_profit)	// 최대이익을 위해 최소 이익값을 변경 
                {
                    min_profit = list_item[i].value;
                }
            }


            int result_value = max_profit;

            return result_value;
        }

        static void OutputData(object answer)
        {
            Console.WriteLine(answer.ToString());
        }


    }
}
