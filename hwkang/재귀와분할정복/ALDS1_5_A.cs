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
            int arrsize = InputData_Step();

            int[] process_int_arr = InputData_Step2(arrsize);


            int arrsize2 = InputData_Step();

            int[] process_int_arr2 = InputData_Step2(arrsize2);

            string[] result_arr = Process_Step(process_int_arr, arrsize, process_int_arr2, arrsize2);

            OutputData_Step(result_arr);
        }

        static int InputData_Step()
        {
            int command_cnt = int.Parse(Console.ReadLine());

            return command_cnt;
        }

        static int[] InputData_Step2(int size)
        {
            int[] int_arr = new int[size];           
            string[] input_data = Console.ReadLine().Split();

            for (int i = 0; i < size; i++)
            {
                int value = int.Parse(input_data[i]);

                int_arr[i] = value;
            }

            return int_arr;
        }

      

        static string[] Process_Step(int[] value_arr,int valuesize,int[] solve_arr, int solvesize)
        {
            string[] result = new string[solve_arr.Length];

            for(int i = 0; i < valuesize; i++)
            {
               result = Exhaustive_Search(value_arr, new int[i + 1], 0, 0,new int[i+1],solve_arr,result);
            }

            for(int i = 0; i < result.Length; i++)
            {
                if (string.IsNullOrEmpty(result[i]))
                {
                    result[i] = "no";
                }
            }

            return result;
        }


        static string[] Exhaustive_Search(int[] value_arr,int[] solve_arr,int index,int depth,int[] use_chk,int[] find_list,string[] values)
        {
            if (depth == solve_arr.Length)
            {


                int result = 0;
                string find_chk = "no";
                for (int i = 0; i < solve_arr.Length; i++)
                {
                    result += solve_arr[i]; 
                }

                for (int i = 0; i < find_list.Length; i++)
                {
                    if (result == find_list[i])
                    {
                        find_chk = "yes";
                        values[i] = find_chk;
                    }
                }

                return values;
            }
            else
            {
                for(int i = index; i < value_arr.Length; i++)
                {
                    solve_arr[depth] = value_arr[i];
                    use_chk[depth] = i;
                    values = Exhaustive_Search(value_arr, solve_arr, i + 1, depth + 1,use_chk,find_list,values);
                }

                return values;
                
            }
        }


        static void OutputData_Step(string[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }


    }
}