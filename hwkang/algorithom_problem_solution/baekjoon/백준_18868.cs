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
            int[]  int_arr = InputData_Step(); //[ 우주의 갯수,우주마다 행성의 갯수]

            int[,] int_arr2 = InputData_Step2(int_arr); //우주마다 존재하는 행성의 크기


            OutputData(Process_Data_Step(int_arr, int_arr2));
        }

        static int[] InputData_Step()
        {
            string[] data = Console.ReadLine().Replace(' ', ',').Split(',');

            int[] first_data = new int[data.Length];

            for(int i=0;i<first_data.Length;i++)
            {
                first_data[i] = int.Parse(data[i]);
            }

            return first_data;
        }

        static int[,] InputData_Step2(int[] arr_size)
        {          
            int[,] arr2_size = new int[arr_size[0], arr_size[1]];

            for(int i=0; i< arr_size[0];i++)
            {
                string[] data = Console.ReadLine().Replace(' ', ',').Split(',');
                
                for(int j=0;j<arr_size[1];j++)
                {
                    arr2_size[i, j] = int.Parse(data[j]);
                }
            }         
            return arr2_size;
        }

        static int Process_Data_Step(int[] int_arr,int[,] int_arr2)
        {
            int[] swap_arr = new int[int_arr[0]];
            int[] temp_int_arr;
            int[] temp_int_index;

            for(int i=0;i<int_arr[0];i++)
            {
                temp_int_index = new int[int_arr[1]];
                temp_int_arr = new int[int_arr[1]];
                for(int j=0;j<int_arr[1];j++)
                {
                    temp_int_arr[j] = int_arr2[i, j];
                }
                temp_int_index  = Process_Data_Step2(temp_int_arr);

                for (int k = 0; k < int_arr[1]; k++)
                {
                    int_arr2[i, k] = temp_int_index[k];
                }
            }

            int total_cnt = 0;

            for(int i=0;i<int_arr[0]-1;i++)
            {
                for(int j=i+1;j<int_arr[0];j++)
                {
                    for(int k=0;k<int_arr[1];k++)
                    {
                        if(int_arr2[i,k]!=int_arr2[j,k])
                        {
                            break;
                        }

                        if(int_arr2[i, k] == int_arr2[j, k] && k==(int_arr[1]-1))
                        {
                            total_cnt++;
                        }
                    }

                }
            }

            return total_cnt;
        }

        //버블정렬 Swap Count Check
        static int[] Process_Data_Step2(int[] int_arr)
        {
            bool flag = true;
            int[] int_index = new int[int_arr.Length];
            int[] int_copy = (int_arr.Clone() as int[]);
            //int swap_cnt = 0;
            int sort_index = 0;
            while (flag)
            {
                flag = false;
                for (int i = int_arr.Length - 1; i > sort_index; i--)
                {
                    if (int_arr[i] < int_arr[i - 1])
                    {
                        int temp_value = int_arr[i];
                        int_arr[i] = int_arr[i - 1];
                        int_arr[i - 1] = temp_value;
                        flag = true;
                        //swap_cnt++;
                    }
                }
                sort_index++;
            }

            for(int i=0;i<int_copy.Length;i++)
            {
                int temp_value = int_copy[i];
                for(int j=0;j<int_copy.Length;j++)
                {
                    if(temp_value==int_arr[j])
                    {
                        int_index[i] = j + 1;
                        break;
                    }
                }
            }

            return int_index;

        }

        static void OutputData(int int_value)
        {

            Console.WriteLine(int_value);

        }


    }
}
