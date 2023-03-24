using System;

namespace my_algorithm_lib
{
    public class Sort
    {
        public Sort()
        {

        }

        /// <summary>
        /// 삽입 정렬 
        /// </summary>
        /// <param name="int_arr"></param>
        public void Sort_Insertion_Sort(int[] int_arr)
        {
            string[] arr_str = new string[int_arr.Length];

            int[] sort_arr = (int_arr.Clone() as int[]);

            int str_index = 1;
            for (int i = 1; i < sort_arr.Length; i++)
            {
                int v = sort_arr[i];
                int j = i - 1;

                while (j >= 0 && sort_arr[j] > v)
                {
                    sort_arr[j + 1] = sort_arr[j];
                    j--;
                }
                sort_arr[j + 1] = v;

                string str = "";
                for (int k = 0; k < sort_arr.Length; k++)
                {
                    if (k == (sort_arr.Length - 1))
                    {
                        str += sort_arr[k].ToString();
                    }
                    else
                    {
                        str += sort_arr[k].ToString() + " ";
                    }
                }
                arr_str[str_index++] = str;
            }

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

            //return arr_str;
        }

        /// <summary>
        /// 버블 정렬 안정된 정렬 why? 배열요소끼리 비교함으로 
        /// </summary>
        /// <param name="int_arr"></param>
        /// <param name="arr_index"></param>
        public void Sort_Bubble_Sort(int[] int_arr,int arr_index)
        {
            arr_index = 0; //swap 횟수 카운트
            bool flag_value = true;

            int sort_index = 0; 
            while (flag_value)
            {
                flag_value = false;

                for (int j = int_arr.Length - 1; j > sort_index; j--)
                {
                    if (int_arr[j] < int_arr[j - 1])
                    {
                        int temp_value = int_arr[j];
                        int_arr[j] = int_arr[j - 1];
                        int_arr[j - 1] = temp_value;
                        flag_value = true; //모두 정렬되어 있을 경우 while문이 종료된다.
                        arr_index++;
                    }

                }


                //정렬 진행 과정 출력 필요없으나 표현
                foreach (var item in int_arr)
                {
                    Console.Write(item.ToString(), " ");
                }
                Console.WriteLine(); 

                sort_index++; //정렬된 부분이 늘어남으로 증감

            }

            //return int_arr;
        }


        /// <summary>
        /// 선택 정렬 비 안정된 정렬
        /// </summary>
        /// <param name="int_arr"></param>
        /// <param name="arr_index"></param>
        public void Sort_Selection_Sort(int[] int_arr, int arr_index)
        {
            arr_index = 0;

            for (int i = 0; i < int_arr.Length; i++)
            {
                int start_index = i;
                for (int j = i + 1; j < int_arr.Length; j++)
                {
                    if (int_arr[j] < int_arr[start_index])
                    {
                        start_index = j;
                    }
                }

                if (start_index != i)//정렬 검색을 시작한 지점이 데이터중 최솟값이 있는 지점과 다르다면 변경 
                {
                    int temp = int_arr[i];
                    int_arr[i] = int_arr[start_index];
                    int_arr[start_index] = temp;
                    arr_index++;
                }

                //정렬 진행 과정 출력 필요없으나 표현
                foreach (var item in int_arr)
                {
                    Console.Write(item.ToString(), " ");
                }
                Console.WriteLine();
            }

            //return int_arr;
        }

    }
}
