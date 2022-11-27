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
            int[] int_arr_data   = InputData_Step();

            int[] int_arr_find = InputData_Step2();

            int output = Process_Step1(int_arr_data,int_arr_find);

            OutputData(output);
        }

        static int[] InputData_Step()
        {
            int intarr_size = int.Parse(Console.ReadLine());

            int[] intarr = new int[intarr_size];

            string[] data = Console.ReadLine().Split(' ');

            for(int i=0;i<intarr_size;i++)
            {
                intarr[i] = int.Parse(data[i]);
            }

            return intarr;
        }

        static int[] InputData_Step2()
        {
            int intarr_size = int.Parse(Console.ReadLine());

            int[] intarr = new int[intarr_size];

            string[] data = Console.ReadLine().Split(' ');

            for (int i = 0; i < intarr_size; i++)
            {
                intarr[i] = int.Parse(data[i]);
            }

            return intarr;
        }

        
        static int Process_Step1(int[] int_arr_data,int[] int_arr_find)
        {
            int match_cnt = 0;

            if(int_arr_data.Length==0 || int_arr_find.Length==0)
            {
                return 0;
            }

            for(int i=0;i<int_arr_find.Length;i++)
            {
                int find_value = int_arr_find[i];
                for(int j=0;j<int_arr_data.Length;j++)
                {
                    if(find_value==int_arr_data[j])
                    {
                        match_cnt++;
                        break;
                    }
                }
            }

            return match_cnt;           
        }

    
        static void OutputData(int result)
        {
            Console.WriteLine(result);
        }


    }

}
