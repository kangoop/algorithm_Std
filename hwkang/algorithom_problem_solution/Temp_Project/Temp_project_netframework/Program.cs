using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
            string[] InputData = InputData_Step();

            string[] InputData_char = InputData_Step2();

            string result =Process_Step(int.Parse(InputData[0]), InputData_char);

            OutputData_Step(result);
        }

        static string[] InputData_Step()
        {
            string[] result = Console.ReadLine().Split(' ');

            return result;
        }

        static string[] InputData_Step2()
        {
            string[] result = Console.ReadLine().Split(' ');

            return result;
        }

        static string Process_Step(int password_len,string[] char_list)
        {
            string[] sort_char_list = char_list.OrderBy(i=>i).ToArray();

            //NEW_PASSWORD_MAKE(password_len, sort_char_list, "", 0);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < password_len; i++)
            {
                string[] param_char = new string[sort_char_list.Length - i];
                Array.Copy(sort_char_list, i, param_char, 0, sort_char_list.Length - i);
                bool[] check = new bool[sort_char_list.Length - i];
                check[0] = true;
                Password_Maker(password_len, 1, 0, sort_char_list[i], param_char, check, sb);
            }

            return sb.ToString();
        }

        static void NEW_PASSWORD_MAKE(int password_len,string[] select_char,string password,int index)
        {
            if (password.Length == password_len)
            {
                if (Password_Check(password))
                {
                    Console.WriteLine(password);
                }
                return;
            }
            
            if(index >= select_char.Length)
            {
                return;
            }

            NEW_PASSWORD_MAKE(password_len, select_char, password + select_char[index], index + 1);
            NEW_PASSWORD_MAKE(password_len, select_char, password, index + 1);
        }

        static bool Password_Check(string password)
        {
            int vowel = 0;
            int consonant = 0;

            foreach(var item in password)
            {
                if (item == 'a' || item == 'e' || item == 'i' || item == 'o' || item == 'u')
                {
                    vowel++;
                }
                else
                {
                    consonant++;
                }
            }

            return vowel >= 1 && consonant >= 2;
        }

        static StringBuilder Password_Maker(int max_level, int current_level,int before_index, string password_value, string[] select_char_list,bool[] check,StringBuilder sb)
        {
            if (max_level == password_value.Length)
            {
                int vowel = 0;
                int consonant = 0;

                foreach(var item in password_value)
                {
                    if (item == 'a' || item == 'e' || item == 'i' || item == 'o' || item == 'u')
                    {
                        vowel++;
                    }
                    else
                    {
                        consonant++;
                    }
                }

                if(vowel>=1 && consonant >= 2)
                {
                    sb.AppendLine(password_value);
                }

                //if (password_value.IndexOfAny(new char[] { 'a', 'e', 'i', 'o', 'u' }) > -1)
                //{
                //    if (password_value.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "").Length >= 2)
                //    {
                //        sb.AppendLine(password_value);
                //    }
                //}
            }else if (password_value.Length > max_level)
            {
                return sb;
            }
            else
            {
                for(int i = current_level; i < select_char_list.Length; i++)
                {
                    if (!check[i])
                    {
                        check[i] = true;
                        if(before_index <= i) // 정렬된 가능성 있는 암호 
                        {
                            Password_Maker(max_level, current_level + 1, i, password_value + select_char_list[i], select_char_list, check, sb);
                        }                                                  
                        check[i] = false;
                    }
                }

            }

            return sb;
        }
      

        static void OutputData_Step(string result)
        {
            Console.Write(result);
        }


    }
}