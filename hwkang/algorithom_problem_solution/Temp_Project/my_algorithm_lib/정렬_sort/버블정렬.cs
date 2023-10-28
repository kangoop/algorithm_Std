using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp_project_netframework
{
//버블정렬
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
            OutputData(Process_Data(InputData_Step2(),out int total_cnt),total_cnt);
        }

        static int InputData_Step()
        {
            string data = Console.ReadLine();

            return int.Parse(data);
        }

        static int[] InputData_Step2()
        {
            int arr_size = InputData_Step();

            var data = Console.ReadLine().Replace(" ",",").Split(',');

            int[] int_arr = new int[arr_size];

            for(int i=0;i<arr_size;i++)
            {
                int_arr[i] = int.Parse(data[i]);
            }

            return int_arr;
        }

        static int[] Process_Data(int[] int_arr,out int arr_index)
        {
            arr_index = 0;
            bool flag_value = true;

            int sort_index = 0; //정렬이 진행될수록 정렬되어 있는 부분은 증가 함으로 
            while(flag_value)
            {
                flag_value = false;

                for(int j=int_arr.Length-1;j>sort_index;j--)
                {                    
                    if(int_arr[j] < int_arr[j-1])
                    {
                        int temp_value = int_arr[j];
                        int_arr[j] = int_arr[j - 1];
                        int_arr[j - 1] = temp_value;
                        flag_value = true;
                        arr_index++;
                    }

                }

                sort_index++;
            }

            return int_arr;


        }

        static void OutputData(int[] int_arr,int total_cnt)
        {
            string out_str = "";
            for(int i=0;i<int_arr.Length;i++)
            {
                if (i == (int_arr.Length - 1))
                {
                    out_str += int_arr[i].ToString();
                }
                else
                {
                    out_str += int_arr[i].ToString() + " ";

                }
            }

            Console.WriteLine(out_str);
            Console.WriteLine(total_cnt); //swap(변경 한 횟수를 가지고 얼마나 정렬되어 있지 않는지를 알수 있다)
            
        }


    }
}
