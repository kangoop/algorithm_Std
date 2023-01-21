using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baekjoon2930
{
    class Program
    {
        static void Main(string[] args)
        {
            Tuple<string, List<string>> tuple = InputData();


        }


        private static Tuple<string,List<string>> InputData()
        {
            int round = int.Parse(Console.ReadLine());
            //라운드 수

            string str = Console.ReadLine();
            //상근이의 값

            int man_cnt = int.Parse(Console.ReadLine());
            //친구의 수

            List<string> man_value = new List<string>();

            for(int i=0;i<man_cnt;i++)
            {
                string value = Console.ReadLine();

                man_value.Add(value);
            }

            Tuple<string, List<string>> tuple = new Tuple<string,List<string>>(str, man_value);

            return tuple;

        }
    }
}
