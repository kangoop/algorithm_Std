using System;

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
            int InputData = InputData_Step();

            int[] InputData_int = InputData_Step2(InputData);


            int idx  = Partition(InputData_int, 0, InputData);

            OutputData_Step(InputData_int,idx);
        }

        static int InputData_Step()
        {
            string input = Console.ReadLine();

            return int.Parse(input);
        }

        static int[] InputData_Step2(int cnt)
        {
            string[] result = Console.ReadLine().Split(' ');

            int[] data_cnt = new int[cnt];

            for(int i=0;i< result.Length;i++)
            {
                data_cnt[i] = int.Parse(result[i]);

            }

            return data_cnt;
        }

        static int Partition(int[] data,int left_idx ,int right_idx)
        {
            int target = data[right_idx-1];
            int i= left_idx-1;

            for(int j = left_idx; j < right_idx; j++)
            {
                if (data[j] <= target)
                {
                    i = i + 1;

                    Swap(data,i ,j);

                }
                else
                {
                    
                    int index = i + 1;
                    if (data[index] > target)
                    {

                    }
                    else
                    {
                        Swap(data, index, right_idx - 1);
                    }
                }
            }

            return i;
            
        }

        static void Swap(int[] data, int  a,int b)
        {
            int temp = data[a];
            data[a] = data[b];
            data[b] = temp;
        }
     
        static void OutputData_Step(int[] data,int idx)
        {
            for(int i = 0; i < data.Length; i++)
            {
                if (i == idx)
                {
                    if (i == data.Length - 1)
                    {
                        Console.WriteLine("[" + data[i] + "]");
                    }
                    else
                    {
                        Console.Write("[" + data[i] + "] ");
                    }
                   
                }
                else
                {
                    if (i == data.Length - 1)
                    {
                        Console.WriteLine(data[i]);
                    }
                    else
                    {
                        Console.Write(data[i] + " ");
                    }

                }

            }
            
        }


    }
}