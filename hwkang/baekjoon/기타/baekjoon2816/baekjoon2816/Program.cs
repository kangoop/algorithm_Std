using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baekjoon2816
{
    class Program
    {
        static void Main(string[] args)
        {
            Tuple<int, List<string>, Dictionary<string, int>> tuple = InputData();//채널수,채널명 리스트,KBS1과KBS2의 Index

            string result =FilterFunc(tuple);

            Output(result);

        }

        private static Tuple<int,List<string>,Dictionary<string,int>> InputData()
        {
            int channel_cnt = int.Parse(Console.ReadLine());
            Dictionary<string, int> key_value = new Dictionary<string, int>();
            List<string> channel_list = new List<string>();
            for (int i = 0; i < channel_cnt; i++)
            {
                string channel_nm = Console.ReadLine();
                if(channel_nm=="KBS1")
                {
                    key_value.Add("KBS1", i);
                }
                else if(channel_nm=="KBS2")
                {
                    key_value.Add("KBS2", i);
                }
                channel_list.Add(channel_nm);
            }

            Tuple<int, List<string>, Dictionary<string, int>> tuple = new Tuple<int, List<string>, Dictionary<string, int>>(channel_cnt, channel_list, key_value);

            return tuple;
        }

        private static string FilterFunc(Tuple<int, List<string>, Dictionary<string, int>> tuple)
        {
            string[] items = tuple.Item2.ToArray();
            Dictionary<string, int> key_value = tuple.Item3;
            int kbs_index = key_value["KBS1"];//kbs1의 index
            string btn_key = "";

            string temp = "";
            for(int i=0; i< kbs_index; i++)
            {
                temp += "1";
            }
            btn_key += temp;
            //현재 화살표 위치 kbs1

            temp = "";
            for (int i=0;i< kbs_index; i++)
            {
                temp += "4";          
            }
            //현재 kbs1는 첫번째 채널 리스트에 안착
            btn_key += temp;

            string[] sub = new ArraySegment<string>(items, 0, kbs_index).ToArray();

            items[0] = "KBS1";

            int index = 1;
            foreach(var str in sub)
            {
                items[index++] = str;
            }
            //현재 kbs1가 첫번째 채널 리스트에 안착 후 채널 리스트 상태

            kbs_index = items.ToList().IndexOf("KBS2");//kbs2의 index

            temp = "";
            for (int i = 0; i < kbs_index; i++)
            {
                temp += "1";
            }
            btn_key += temp;
            //현재 화살표 위치 kbs2

            temp = "";
            for (int i = 1; i < kbs_index; i++)
            {
                temp += "4";
            }
            //현재 kbs2는 첫번째 채널 리스트에 안착
            btn_key += temp;

            return btn_key;
        }


        private static void Output(string result)
        {
            Console.WriteLine(result);
        }
    }
}
