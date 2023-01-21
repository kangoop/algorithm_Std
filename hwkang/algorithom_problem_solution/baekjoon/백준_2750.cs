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
            OutputData(Process_Data_Step2(InputData_Step2()));
        }

        static int InputData_Step()
        {
            string data = Console.ReadLine();

            return int.Parse(data);
        }

        static int[] InputData_Step2()
        {
            int arr_size = InputData_Step();

            int[] int_arr = new int[arr_size];

            for(int i=0; i< arr_size;i++)
            {
                int_arr[i] = int.Parse(Console.ReadLine());
            }

            return int_arr;
        }

        static int[] Process_Data_Step(int[] int_arr)
        {
            bool flag = true;
            int sort_index = 0;
            while(flag)
            {
                flag = false;
                for(int i=int_arr.Length-1;i>sort_index;i--)
                {
                    if(int_arr[i]<int_arr[i-1])
                    {
                        int temp_value = int_arr[i];
                        int_arr[i] = int_arr[i - 1];
                        int_arr[i - 1] = temp_value;
                        flag = true;
                    }
                }
                sort_index++;
            }

            return int_arr;
            
        }

        //삽입정렬
        static int[] Process_Data_Step2(int[] int_arr)
        {
            for(int i=1;i<int_arr.Length;i++)
            {
                int temp_value = int_arr[i];
                int j = i - 1;
                while(j>=0 && int_arr[j]>temp_value)
                {
                    int_arr[j + 1] = int_arr[j];
                    j--;
                }
                int_arr[j + 1] = temp_value;

            }

            return int_arr;

        }

        static void OutputData(int[] int_arr)
        {
            foreach(var item in int_arr)
            {
                Console.WriteLine(item);
            }
        }


    }
}
