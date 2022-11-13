using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp_project_netframework
{

//선택정렬 
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
            
            for(int i=0;i<int_arr.Length;i++)
            {
                int start_index = i;
                for(int j=i+1;j<int_arr.Length;j++)
                {
                    if(int_arr[j] < int_arr[start_index])
                    {
                        start_index = j;
                    }
                }

                if (start_index != i)//정렬 검색을 시작한 지점이 데이터중 최솟값이 있는 지점과 다르다면 변경 
                {
                    int temp = int_arr[i];
                    int_arr[i] = int_arr[start_index];
                    int_arr[start_index] = temp;
                    arr_index++;
                }
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
            Console.WriteLine(total_cnt); 
        }


    }
}
