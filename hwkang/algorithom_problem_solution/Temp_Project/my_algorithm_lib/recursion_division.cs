using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_algorithm_lib
{
    public class recursion_division
    {
        public recursion_division()
        {

        }


        public string[] Exhaustive_Search_Process_Step(int[] value_arr, int valuesize, int[] solve_arr, int solvesize)
        {
            string[] result = new string[solve_arr.Length];

            for (int i = 0; i < valuesize; i++)
            {
                result = Exhaustive_Search(value_arr, new int[i + 1], 0, 0, new int[i + 1], solve_arr, result);
            }

            for (int i = 0; i < result.Length; i++)
            {
                if (string.IsNullOrEmpty(result[i]))
                {
                    result[i] = "no";
                }
            }

            return result;
        }

        /// <summary>
        /// 전체탐색
        /// </summary>
        /// <param name="value_arr">아이템 리스트</param>
        /// <param name="solve_arr">찾은 아이템 리스트</param>
        /// <param name="index">찾은 아이템의 시작점</param>
        /// <param name="depth">찾을 아이템의 사이즈</param>
        /// <param name="use_chk">찾은 아이템의 위치를 넣는 리스트</param>
        /// <param name="find_list">찾아야 하는 아이템 리스트</param>
        /// <param name="values">찾기 유무 를 표현하는 리스트</param>
        /// <returns></returns>
        public string[] Exhaustive_Search(int[] value_arr, int[] solve_arr, int index, int depth, int[] use_chk, int[] find_list, string[] values)
        {
            if (depth == solve_arr.Length) //찾아야하는 깊이가 찾은 아이템 길이와 동일하면 체크
            {
                int result = 0;
                string find_chk = "no";
                for (int i = 0; i < solve_arr.Length; i++)
                {
                    result += solve_arr[i];
                }

                for (int i = 0; i < find_list.Length; i++)
                {
                    if (result == find_list[i])
                    {
                        find_chk = "yes";
                        values[i] = find_chk;
                    }
                }

                return values;
            }
            else
            {
                for (int i = index; i < value_arr.Length; i++)
                {
                    solve_arr[depth] = value_arr[i];
                    use_chk[depth] = i;
                    values = Exhaustive_Search(value_arr, solve_arr, i + 1, depth + 1, use_chk, find_list, values);
                }

                return values;

            }
        }

        #region Koch_Curve
        /*
         * 벡터 계산 관련하여 공부 필요 
         * 
         */
        public string Process_Step(int cnt)
        {
            StringBuilder sb = new StringBuilder();

            double start_x = 0.0;
            double start_y = 0.0;

            double end_x = 100.0;
            double end_y = 0.0;

            sb.AppendLine(start_x.ToString("F8") + " " + start_y.ToString("F8"));
            Koch_Curve(cnt, start_x, start_y, end_x, end_y, sb);
            sb.AppendLine(end_x.ToString("F8") + " " + end_y.ToString("F8"));

            return sb.ToString();
        }



        public void Koch_Curve(int cnt, double start_x, double start_y, double end_x, double end_y, StringBuilder sb)
        {
            if (cnt > 0)
            {
                double th = Math.PI * (60.0 / 180.0);
                double s_x = (2.0 * start_x + 1.0 * end_x) / 3; //Math.Round(Math.Sqrt(Math.Pow(end_x - start_x, 2) + Math.Pow(end_y - start_y, 2)) / 3, 8);
                double s_y = (2.0 * start_y + 1.0 * end_y) / 3;//start_y;
                double t_x = (1.0 * start_x + 2.0 * end_x) / 3;//Math.Round(s_x * 2,8);
                double t_y = (1.0 * start_y + 2.0 * end_y) / 3;//end_y;
                double u_x = ((t_x - s_x) * Math.Cos(th)) - ((t_y - s_y) * Math.Sin(th)) + s_x;
                //Math.Round(Math.Sqrt(Math.Pow(end_x - start_x, 2) + Math.Pow(end_y - start_y, 2)) / 2, 8);
                double u_y = ((t_x - s_x) * Math.Sin(th)) + ((t_y - s_y) * Math.Cos(th)) + s_y;
                //Math.Sqrt(Math.Pow((t_x - s_x), 2) - (Math.Pow((u_x - s_x), 2))) + s_y;


                int next_cnt = cnt - 1;
                if (next_cnt > 0)
                {
                    Koch_Curve(next_cnt, start_x, start_y, s_x, s_y, sb);
                    sb.AppendLine(s_x.ToString("F8") + " " + s_y.ToString("F8"));
                    Koch_Curve(next_cnt, s_x, s_y, u_x, u_y, sb);
                    sb.AppendLine(u_x.ToString("F8") + " " + u_y.ToString("F8"));
                    Koch_Curve(next_cnt, u_x, u_y, t_x, t_y, sb);
                    sb.AppendLine(t_x.ToString("F8") + " " + t_y.ToString("F8"));
                    Koch_Curve(next_cnt, t_x, t_y, end_x, end_y, sb);
                }
                else
                {

                    sb.AppendLine(s_x.ToString("F8") + " " + s_y.ToString("F8"));
                    sb.AppendLine(u_x.ToString("F8") + " " + u_y.ToString("F8"));
                    sb.AppendLine(t_x.ToString("F8") + " " + t_y.ToString("F8"));

                }


            }

        }

        #endregion

        #region Fibonacci_Number 피보나치 수

        public string Fibonacci_number_Process_Step(int cnt)
        {
            int value = Fibonacci_number(cnt);

            return value.ToString();
        }

        public int Fibonacci_number(int number)
        {
            if (number >= 0)
            {
                if (number == 0)
                {
                    return 0;
                }
                else if (number == 1)
                {
                    return 1;
                }
                else
                {
                    return (Fibonacci_number(number - 1) + Fibonacci_number(number - 2));
                }
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region Factorial 팩토리얼

        public string Factorial_Process_Step(int cnt)
        {
            long value = 1;
            long result = Factorial(cnt, value);

            return result.ToString();
        }

        public long Factorial(int number, long value)
        {
            if (number >= 0)
            {
                value = Factorial(number - 1, value);
                if (number == 0)
                {
                    value = value * 1;
                }
                else
                {
                    value = value * number;
                }
                return value;
            }
            else
            {
                return value;
            }
        }

        #endregion

        #region backjoon 1759
        /*
         * 1759 해결은 하였으나 확인 필요
         */
        static void Main(string[] args)
        {
            string[] InputData = InputData_Step_1759();

            string[] InputData_char = InputData_Step2_1759();

            string result = Process_Step_1759(int.Parse(InputData[0]), InputData_char);

            OutputData_Step(result);
        }

        static string[] InputData_Step_1759()
        {
            string[] result = Console.ReadLine().Split(' ');

            return result;
        }

        static string[] InputData_Step2_1759()
        {
            string[] result = Console.ReadLine().Split(' ');

            return result;
        }

        static string Process_Step_1759(int password_len, string[] char_list)
        {
            string[] sort_char_list = char_list.OrderBy(i => i).ToArray();

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

        static void NEW_PASSWORD_MAKE(int password_len, string[] select_char, string password, int index)
        {
            if (password.Length == password_len)
            {
                if (Password_Check(password))
                {
                    Console.WriteLine(password);
                }
                return;
            }

            if (index >= select_char.Length)
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

            foreach (var item in password)
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

        static StringBuilder Password_Maker(int max_level, int current_level, int before_index, string password_value, string[] select_char_list, bool[] check, StringBuilder sb)
        {
            if (max_level == password_value.Length)
            {
                int vowel = 0;
                int consonant = 0;

                foreach (var item in password_value)
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

                if (vowel >= 1 && consonant >= 2)
                {
                    sb.AppendLine(password_value);
                }
            }
            else if (password_value.Length > max_level)
            {
                return sb;
            }
            else
            {
                for (int i = current_level; i < select_char_list.Length; i++)
                {
                    if (!check[i])
                    {
                        check[i] = true;
                        if (before_index <= i) // 정렬된 가능성 있는 암호 
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
    #endregion
}
