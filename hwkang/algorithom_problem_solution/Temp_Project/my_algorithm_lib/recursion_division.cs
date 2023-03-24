using System;
using System.Collections.Generic;
using System.Text;

namespace total_lib
{
    public class recursion_division
    {
        public recursion_division()
        {

        }


        public string[] Process_Step(int[] value_arr, int valuesize, int[] solve_arr, int solvesize)
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
    }
}
