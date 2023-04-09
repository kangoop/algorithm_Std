using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Temp_project_netframework
{
    public class Program
    {
        /*
         * 단계를 3단계로 구분 하여 표현
         * InputData 단계 조건을 입력받는 과정
         * 
         * Process 단계 로직을 진행하여 결과를 출력하는 과정
         * 
         * OutputData 단계 입력받은 데이터를 가지고 로직과정을 거쳐서 출력하는 표현하는 과정
         * 
         * 만약 각 단계마다 끝나지 않는 다면 
         * StepXXX 을 붙여서 진행 하도록 한다 EX) Step1 -> Step2 ... 이런식으로 
         * 
         * 
         */
        static void Main(string[] args)
        {
            int cmd_cnt = InputData_Step();

            string[] cmd_arr = InputData_Step2(cmd_cnt);

            int cmd_cnt2 = InputData_Step();

            string[] cmd_arr2 = InputData_Step2(cmd_cnt2);

            string result =Process_Step1(cmd_arr,cmd_arr2);

            OutputData_Step(result);
        }

        static int InputData_Step()
        {
            int command_cnt = int.Parse(Console.ReadLine());

            return command_cnt;
        }

        public static string[] InputData_Step2(int arr_size)
        {
            string[] str_arr = Console.ReadLine().Split(' ');

            return str_arr;
        }


        public static string Process_Step1(string[] str_arr,string[] str_arr2)
        {
            StringBuilder sb = new StringBuilder();

            HashSet<string> hash_set = new HashSet<string>();

            foreach(var item in str_arr)
            {
                hash_set.Add(item.ToString());
            }


            for(int i = 0; i < str_arr2.Length; i++)
            {
                if(i==(str_arr2.Length-1))
                {

                    if (hash_set.Contains(str_arr2[i]))
                    {
                        sb.Append("1");
                    }
                    else
                    {
                        sb.Append("0");
                    }
                }
                else
                {

                    if (hash_set.Contains(str_arr2[i]))
                    {
                        sb.Append("1 ");
                    }
                    else
                    {
                        sb.Append("0 ");
                    }
                }
            }

            return sb.ToString();
        }

        public static void OutputData_Step(string str)
        {
            Console.WriteLine(str);
        }

    }

}