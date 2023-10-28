using System;
using System.Collections.Generic;
using System.Linq;
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
            int[] int_arr_data = InputData_Step();

            int[] int_arr_find = InputData_Step2();

            int output = Process_Step1(int_arr_data, int_arr_find);

            OutputData(output);
        }

        static int[] InputData_Step()
        {
            int intarr_size = int.Parse(Console.ReadLine());

            int[] intarr = new int[intarr_size];

            string[] data = Console.ReadLine().Split(' ');

            for (int i = 0; i < intarr_size; i++)
            {
                intarr[i] = int.Parse(data[i]);
            }

            return intarr;
        }

        static int[] InputData_Step2()
        {
            int intarr_size = int.Parse(Console.ReadLine());

            int[] intarr = new int[intarr_size];

            string[] data = Console.ReadLine().Split(' ');

            for (int i = 0; i < intarr_size; i++)
            {
                intarr[i] = int.Parse(data[i]);
            }

            return intarr;
        }


        static int Process_Step1(int[] int_arr_data, int[] int_arr_find)
        {
            int match_cnt = 0;

   
            for(int i = 0;i < int_arr_find.Length;i++)
            {
                int find_value = int_arr_find[i];
                int find_start = 0;
                int find_end = int_arr_data.Length;
                int find_start_index = int_arr_data.Length / 2;
                bool flag = true;
                while(flag)
                {
                    int value = int_arr_data[find_start_index];

                    if(value==find_value)
                    {
                        match_cnt++;
                        break;
                    }

                    int check_value = find_end - find_start;
                    if (check_value==1 || check_value==0)
                    {
                        break;
                    }


                    if(find_value<value)
                    {
                        find_end = find_start_index;
                        find_start_index = ((find_start + find_start_index) / 2);

                    }
                    else
                    {
                        find_start = find_start_index;
                        find_start_index = ((find_end + find_start_index) / 2);
                    }
                }
            }

            return match_cnt;
        }


        static void OutputData(int result)
        {
            Console.WriteLine(result);
        }


    }

}
