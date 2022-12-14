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
            int cmd_cnt= InputData_Step();

            string[] cmd_arr= InputData_Step2(cmd_cnt);

            Process_Step1(cmd_arr);
        }

        static int InputData_Step()
        {
            int command_cnt= int.Parse(Console.ReadLine());

            return command_cnt;
        }

        public static string[] InputData_Step2(int arr_size)
        {
            string[] str_arr = new string[arr_size];

            for(int i=0;i<arr_size;i++)
            {
                string temp = Console.ReadLine();

                str_arr[i] = temp;
            }

            return str_arr;

        }


        public static void Process_Step1(string[] str_arr)
        {
            My_Dictionary dic = new My_Dictionary();

            StringBuilder sb = new StringBuilder();

            for(int i=0;i<str_arr.Length;i++)
            {
                string[] txt = str_arr[i].Split(' ');

                switch(txt[0])
                {
                    case "insert":
                        dic.Insert_Key(txt[1]);
                        break;
                    case "find":
                        if(dic.Find_Key(txt[1])=="Y")
                        {
                            Console.WriteLine("yes");
                        }
                        else
                        {
                            Console.WriteLine("no");
                        }
                        break;
                }

            }

        }



        public class My_Dictionary
        {

            private readonly long Mod = 104_652_7;

            private string[] value_arr = new string[104_652_7];

            private int Char_To_Number(char ch)
            {
                int result = -1;

                switch (ch)
                {
                    case 'A':
                        result = 1;
                        break;
                    case 'C':
                        result = 2;
                        break;
                    case 'G':
                        result = 3;
                        break;
                    case 'T':
                        result = 4;
                        break;

                }

                return result;
            }

            public void Insert_Key(string value)
            {
                long convert_key = 0;
                long point = 1;
                for (int i = 0; i < value.Length; i++)
                {
                    convert_key += point * Char_To_Number(value[i]);
                    point *= 5;
                }

                long hash;
                for (int j = 0; ; j++)
                {
                    hash = (h1(convert_key) + j * h2(convert_key)) % Mod;

                    if (value_arr[hash] == value)
                    {
                        return;
                    }
                    else if (string.IsNullOrEmpty(value_arr[hash]))
                    {
                        value_arr[hash] = value;
                        return;
                    }
                }

            }

            public string Find_Key(string value)
            {
                long convert_key = 0;
                long point = 1;
                for (int i = 0; i < value.Length; i++)
                {
                    convert_key += point * Char_To_Number(value[i]);
                    point *= 5;
                }

                long hash;
                for (int j = 0; ; j++)
                {
                    hash = (h1(convert_key) + j * h2(convert_key)) % Mod;

                    if (value_arr[hash] == value)
                    {
                        return "Y";
                    }
                    else if (string.IsNullOrEmpty(value_arr[hash]))
                    {
                        return "N";
                    }
                }

            }

            private long h1(long key)
            {
                return key % Mod;
            }

            private long h2(long key)
            {
                return 1 + (key % (Mod - 1));
            }
        }

    }

}
