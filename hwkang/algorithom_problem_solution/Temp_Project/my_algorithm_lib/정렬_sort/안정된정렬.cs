using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp_project_netframework
{
//안정된정렬
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
            string[] data = InputData_Step2();

            string[] data_copy1 = (data.Clone() as string[]);
            string[] data_copy2 = (data.Clone() as string[]);
            OutputData(Process_Data_Step(data_copy1), Process_Data_Step2(data_copy2));
        }

        static int InputData_Step()
        {
            string data = Console.ReadLine();

            return int.Parse(data);
        }

        static string[] InputData_Step2()
        {
            int arr_size = InputData_Step();

            var data = Console.ReadLine().Replace(" ",",").Split(',');

            string[] str_arr = new string[arr_size];

            for(int i=0;i<arr_size;i++)
            {
                str_arr[i] = data[i];
            }

            return str_arr;
        }

        static string[] Process_Data_Step(string[] str_arr)
        {
            bool flag = true;

            int sort_index = 0;

            while(flag)
            {
                flag = false;

                for(int i=str_arr.Length-1;i>sort_index;i--)
                {
                    int card_number_1 = Process_Func(str_arr[i]);

                    int card_number_2 = Process_Func(str_arr[i-1]);

                    if (card_number_1 < card_number_2)
                    {
                        string temp = str_arr[i];
                        str_arr[i] = str_arr[i - 1];
                        str_arr[i - 1] = temp;
                        flag = true;
                    }
                }

                sort_index++;
            }

            return str_arr;
        }

        static string[] Process_Data_Step2(string[] str_arr)
        {      
            for (int i = 0; i < str_arr.Length; i++)
            {
                int start_index = i;
                for (int j = i + 1; j < str_arr.Length; j++)
                {
                    int card_number_1 = Process_Func(str_arr[j]);

                    int card_number_2 = Process_Func(str_arr[start_index]);

                    if(card_number_1 < card_number_2)
                    {
                        start_index = j;
                    }
                }

                if (start_index != i)//정렬 검색을 시작한 지점이 데이터중 최솟값이 있는 지점과 다르다면 변경 
                {
                    string temp = str_arr[i];
                    str_arr[i] = str_arr[start_index];
                    str_arr[start_index] = temp;
                }
            }

            return str_arr;
        }

        static int Process_Func(string str)
        {
            return int.Parse(str.Replace("H", string.Empty).Replace("C", string.Empty)
                       .Replace("D", string.Empty).Replace("S", string.Empty));
        }

        static void OutputData(string[] str_arr,string[] str_arr2)
        {
            //"Stable" or "Not stable"
            string out_str = "";
            for(int i=0;i<str_arr.Length;i++)
            {
                if (i == (str_arr.Length - 1))
                {
                    out_str += str_arr[i].ToString();
                }
                else
                {
                    out_str += str_arr[i].ToString() + " ";

                }
            }

            Console.WriteLine(out_str);
            Console.WriteLine("Stable");

            string out_str2 = "";
            for (int i = 0; i < str_arr2.Length; i++)
            {
                if (i == (str_arr2.Length - 1))
                {
                    out_str2 += str_arr2[i].ToString();
                }
                else
                {
                    out_str2 += str_arr2[i].ToString() + " ";

                }
            }

            Console.WriteLine(out_str2);
            if(out_str!=out_str2) //버블정렬이 안정된 정렬 이므로 해당 결과를 비교하여 출력
            {
                Console.WriteLine("Not stable");
            }
            else
            {
                Console.WriteLine("Stable");
            }
        }


    }
}
