using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp_project_netframework
{

//삽입 정렬
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
         */
        static void Main(string[] args)
        {
            OutputData(Process_Data(InputData_Step2()));
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

        static string[] Process_Data(int[] int_arr)
        {
            string[] arr_str = new string[int_arr.Length];

            int[] sort_arr = (int_arr.Clone() as int[]);

            int str_index = 1;
            for(int i=1; i<sort_arr.Length;i++)
            {
                int v = sort_arr[i];
                int j = i - 1;

                while(j>=0 && sort_arr[j]>v)
                {
                    sort_arr[j + 1] = sort_arr[j];
                    j--;
                }
                sort_arr[j + 1] = v;

                string str = "";
                for(int k=0;k<sort_arr.Length;k++)
                {
                    if(k==(sort_arr.Length-1))
                    {
                        str += sort_arr[k].ToString();
                    }
                    else
                    {
                        str += sort_arr[k].ToString()+" ";
                    }
                }
                arr_str[str_index++] = str;                
            }

            string arr_int_str = "";
            for (int k = 0; k < int_arr.Length; k++)
            {
                if (k == (int_arr.Length - 1))
                {
                    arr_int_str += int_arr[k].ToString();
                }
                else
                {
                    arr_int_str += int_arr[k].ToString() + " ";
                }
            }

            arr_str[0] = arr_int_str;

            return arr_str;
        }

        static void OutputData(string[] arr_str)
        {
           foreach(var item in arr_str)
            {
                Console.WriteLine(item);
            }
        }


    }
}
