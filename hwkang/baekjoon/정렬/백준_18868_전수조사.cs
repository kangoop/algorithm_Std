using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp_project_netframework
{
//18868_전수조사
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
            int[] int_arr = InputData_Step(); //[ 우주의 갯수,우주마다 행성의 갯수]

            int[,] int_arr2 = InputData_Step2(int_arr); //우주마다 존재하는 행성의 크기


            OutputData(Process_Data_Step(int_arr, int_arr2));
        }

        static int[] InputData_Step()
        {
            string[] data = Console.ReadLine().Replace(' ', ',').Split(',');

            int[] first_data = new int[data.Length];

            for (int i = 0; i < first_data.Length; i++)
            {
                first_data[i] = int.Parse(data[i]);
            }

            return first_data;
        }

        static int[,] InputData_Step2(int[] arr_size)
        {
            int[,] arr2_size = new int[arr_size[0], arr_size[1]];

            for (int i = 0; i < arr_size[0]; i++)
            {
                string[] data = Console.ReadLine().Replace(' ', ',').Split(',');

                for (int j = 0; j < arr_size[1]; j++)
                {
                    arr2_size[i, j] = int.Parse(data[j]);
                }
            }
            return arr2_size;
        }

        static int Process_Data_Step(int[] int_arr, int[,] int_arr2)
        {        
            int total_cnt = 0;

            for (int i = 0; i < int_arr[0] - 1; i++)
            {
                for (int j = i + 1; j < int_arr[0]; j++)
                {
                    bool flag2 = true;
                    for (int k = 0; k < int_arr[1]-1; k++)
                    {
                        bool flag = true;
                        int l ;
                        for (l=k+1; l < int_arr[1]; l++)
                        {
                            bool one = int_arr2[i, k] < int_arr2[i,l];
                            bool two = int_arr2[j, k] < int_arr2[j,l];

                            if (one != two)
                            {
                                flag = false;
                                break;
                            }                          
                        }

                        if(flag)
                        {
                            flag2 = true;
                        }
                        else
                        {
                            flag2 = false;
                            break;
                        }
                    }

					/*
					행성전체를 전체 조사했을때 flag가  true 인 경우 카운트 증가
					*/
                    if(flag2) 
                    {
                        total_cnt++;
                    }

                }
            }

            return total_cnt;
        }

        static void OutputData(int int_value)
        {

            Console.WriteLine(int_value);

        }


    }
}
