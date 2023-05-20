using System;
using System.Security.Principal;
using System.Text;

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
         */

        static void Main(string[] args)
        {
            int InputData_int = InputData_Step();

            int[] InputData = InputData_Step2(InputData_int);

            int[] output_data = Counting_Sort(InputData, new int[InputData.Length], InputData.Length);

            OutputData_Step(output_data);
        }

        static int InputData_Step()
        {
            string input = Console.ReadLine();

            return int.Parse(input);
        }

        static int[] InputData_Step2(int cnt)
        {
            string[] input = Console.ReadLine().Split(' ');

            int[] output = new int[input.Length];
            for(int i=0; i < cnt; i++)
            {
                output[i] = int.Parse(input[i]); 
            }

            return output;
        }

        static int[] Counting_Sort(int[] data_arr, int[] output_arr,int maxsize)
        {
            int[] count_arr = new int[10_001];

            for(int i = 0; i < maxsize; i++)
            {
                int value = data_arr[i];

                count_arr[value]++;
            }


            for(int i = 1; i <= count_arr.Length-1; i++)
            {
                count_arr[i] = count_arr[i] + count_arr[i - 1];
            }

            for(int j= maxsize - 1; j >= 0; j--)
            {
                var item = data_arr[j];
                var count_idx = count_arr[item];
                output_arr[count_idx - 1] = item;
                count_arr[item]--;
            }

            return output_arr;
        }



        static void OutputData_Step(int[] output)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < output.Length; i++)
            {
                if (i == (output.Length - 1)){
                    sb.Append(output[i]);                   
                }
                else
                {
                    sb.Append(output[i]+" ");
                }
            }
            Console.WriteLine(sb.ToString());
        }


    }
}