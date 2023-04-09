using System;
using System.Collections.Generic;
using System.Text;

namespace total_lib
{
    public class Linear_Search
    {
        public  int MatchCnt(int[] int_arr_data, int[] int_arr_find)
        {
            int match_cnt = 0;

            if (int_arr_data.Length == 0 || int_arr_find.Length == 0)
            {
                return 0;
            }

            for (int i = 0; i < int_arr_find.Length; i++)
            {
                int find_value = int_arr_find[i];
                for (int j = 0; j < int_arr_data.Length; j++)
                {
                    if (find_value == int_arr_data[j])
                    {
                        match_cnt++;
                        break;
                    }
                }
            }

            return match_cnt;
        }

        public int[] MatchList_Index(int[] int_arr_data, int[] int_arr_find)
        {
            List<int> match_list = new List<int>();

            if (int_arr_data.Length == 0 || int_arr_find.Length == 0)
            {
                return (match_list.ToArray() as int[]);
            }

            for (int i = 0; i < int_arr_find.Length; i++)
            {
                int find_value = int_arr_find[i];
                for (int j = 0; j < int_arr_data.Length; j++)
                {
                    if (find_value == int_arr_data[j])
                    {
                        match_list.Add(j);
                        break;
                    }
                }
            }

            return (match_list.ToArray() as int[]);
        }
    }


    public class Binary_Search
    {
        public Binary_Search()
        {

        }


        /// <summary>
        /// 총 데이터들 (오름차순정렬 완료 데이터들) , 검색해야할 데이터들
        /// </summary>
        /// <param name="int_arr_data"></param>
        /// <param name="int_arr_find"></param>
        /// <returns></returns>
        public int MatchCnt(int[] int_arr_data, int[] int_arr_find)
        {
            int match_cnt = 0;
            /*
             * -----|-----
             * --|--
             * -
             * 와 같이 진행되는 구조 
             */

            for (int i = 0; i < int_arr_find.Length; i++)
            {
                int find_value = int_arr_find[i];
                int find_start = 0;                             //검색 시작점 
                int find_end = int_arr_data.Length;             //검색 종료점
                int find_start_index = int_arr_data.Length / 2; //시작은 무조건 배열의 중앙
                bool flag = true;
                while (flag)
                {
                    int value = int_arr_data[find_start_index];

                    if (value == find_value)
                    {
                        match_cnt++;
                        break;
                    }

                    int check_value = find_end - find_start; //검색 범위가 1 or 0 이라면 찾을수 있는 범위를 모두 순회 한것
                    
                    if (check_value == 1 || check_value == 0)
                    {
                        break; 
                    }


                    if (find_value < value)
                    {
                        find_end = find_start_index;
                        find_start_index = ((find_start + find_start_index) / 2);

                    }
                    else
                    {
                        find_start = find_start_index;
                        find_start_index = ((find_end + find_start_index) / 2);
                    }
                }
            }

            return match_cnt;
        }

        /// <summary>
        /// 검색해야할데이터들의 첫번째 위치 를 반환한다.
        /// </summary>
        /// <param name="int_arr_data"></param>
        /// <param name="int_arr_find"></param>
        /// <returns></returns>
        public int[] MatchList_Index(int[] int_arr_data, int[] int_arr_find)
        {
            List<int> match_list = new List<int>();
            /*
             * -----|-----
             * --|--
             * -
             * 와 같이 진행되는 구조 
             */

            for (int i = 0; i < int_arr_find.Length; i++)
            {
                int find_value = int_arr_find[i];
                int find_start = 0;                             //검색 시작점 
                int find_end = int_arr_data.Length;             //검색 종료점
                int find_start_index = int_arr_data.Length / 2; //시작은 무조건 배열의 중앙
                bool flag = true;
                while (flag)
                {
                    int value = int_arr_data[find_start_index];

                    if (value == find_value)
                    {
                        match_list.Add(find_start_index);//match_cnt++;
                        break;
                    }

                    int check_value = find_end - find_start; 
                    //검색 범위가 1 or 0 이라면 찾을수 있는 범위를 모두 순회 한것

                    if (check_value == 1 || check_value == 0)
                    {
                        break;
                    }


                    if (find_value < value)
                    {
                        find_end = find_start_index;
                        find_start_index = ((find_start + find_start_index) / 2);

                    }
                    else
                    {
                        find_start = find_start_index;
                        find_start_index = ((find_end + find_start_index) / 2);
                    }
                }
            }

            return match_list.ToArray();
        }
    }

    public class My_Dictionary
    {

        private readonly long Mod = 111_111_1;

        private string[] value_arr = new string[111_111_1];

        private int Char_To_Number(string code)
        {
            int result = 0;

            byte[] bytes = Encoding.UTF8.GetBytes(code);

            foreach (var item in bytes)
            {
                result += Convert.ToInt32(item);
            }

            return result;
        }

        public void Insert_Key(string value)
        {
            long convert_key = 0;
            convert_key = Char_To_Number(value);

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
            convert_key = Char_To_Number(value);

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
