using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_App
{

//삽입 정렬
    public class Program
    {
        
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
                int v = sort_arr[i]; //정렬되지 않은 부분에서 추출한 요소
                int j = i - 1;

                //추출한 요소 보다 큰 요소를 뒤로 이동 시키는 작업
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

            //데이터를 입력 받은 초기 부분
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

        //출력
        static void OutputData(string[] arr_str)
        {
           foreach(var item in arr_str)
            {
                Console.WriteLine(item);
            }
        }


    }
}
