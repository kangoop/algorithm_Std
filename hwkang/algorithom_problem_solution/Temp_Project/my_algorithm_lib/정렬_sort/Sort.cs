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

        #region MergeSort


        /// <summary>
        /// 분할 -> 정렬 -> 결합 , 안정적 정렬 
        /// </summary>
        /// <param name="data">입력데이터</param>
        /// <param name="size">입력데이터크기</param>
        /// <param name="left_idx">start 인덱스</param>
        /// <param name="right_idx">end 인덱스</param>
        /// <param name="sort_cnt">정렬 카운트</param>
        /// <param name="n1">임시데이터 사이즈 Left</param>
        /// <param name="n2">임시데이터 사이즈 Right</param>
        /// <returns></returns>
        public int MergeSort(int[] data, int size, int left_idx, int right_idx, int sort_cnt, int[] n1, int[] n2)
        {
            int cnt = sort_cnt;
            if ((left_idx + 1) < right_idx)
            {

                int mid = (left_idx + right_idx) / 2;
                int sort_cnt_1 = MergeSort(data, size, left_idx, mid, sort_cnt, n1, n2);
                cnt += sort_cnt_1;
                int sort_cnt_2 = MergeSort(data, size, mid, right_idx, sort_cnt, n1, n2);
                cnt += sort_cnt_2;
                int sort_cnt_3 = Merge(data, size, left_idx, mid, right_idx, n1, n2);
                cnt += sort_cnt_3;

            }

            return cnt;
        }

        public int Merge(int[] data, int size, int left_idx, int mid_idx, int right_idx, int[] n1_arr, int[] n2_arr)
        {
            int cnt = 0;

            int n1 = mid_idx - left_idx;
            int n2 = right_idx - mid_idx;

            int i = 0;
            for (i = 0; i < n1; i++)
            {
                n1_arr[i] = data[left_idx + i];
            }

            for (i = 0; i < n2; i++)
            {
                n2_arr[i] = data[mid_idx + i];
            }


            n1_arr[n1] = int.MaxValue; //리터럴 값
            n2_arr[n2] = int.MaxValue; 
            //리터럴 값

            i = 0;
            int j = 0;

            for (int k = left_idx; k < (right_idx); k++)
            {
                cnt++;
                if (n1_arr[i] <= n2_arr[j])
                {
                    data[k] = n1_arr[i];
                    i = i + 1;
                }
                else
                {
                    data[k] = n2_arr[j];
                    j = j + 1;
                }
            }

            return cnt;
        }

        #endregion

        #region parititon 

        /// <summary>
        /// right_idx 의 값을 기준으로 해당 값보다 낮은 것은 left 로 높은것은 right 옮기는것
        /// </summary>
        /// <param name="data"></param>
        /// <param name="left_idx"></param>
        /// <param name="right_idx"></param>
        /// <returns></returns>
        public int Partition(int[] data, int left_idx, int right_idx)
        {
            int target = data[right_idx - 1]; //배열의 마지막요소값
            int i = left_idx - 1;

            for (int j = left_idx; j < right_idx; j++)
            {
                if (data[j] <= target)
                {
                    i = i + 1;

                    Swap(data, i, j);

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

        public void Swap(int[] data, int a, int b)
        {
            int temp = data[a];
            data[a] = data[b];
            data[b] = temp;
        }


        #endregion



        #region Quck Sort

        public void QuickSort(string[] input, int left, int right)
        {
            if (left < right)
            {
                int q = Partition(input, left, right);
                QuickSort(input, left, q - 1);
                QuickSort(input, q + 1, right);
            }
        }

        public int Partition(string[] data, int left_idx, int right_idx)
        {
            int target = int.Parse(data[right_idx].Split(' ')[1]);
            int i = left_idx - 1;

            for (int j = left_idx; j < right_idx; j++)
            {
                if (int.Parse(data[j].Split(' ')[1]) <= target)
                {
                    i = i + 1;
                    Swap(data, i, j);
                }
            }
            Swap(data, i + 1, right_idx);

            return i + 1;
        }



        public void Swap(string[] data, int a, int b)
        {
            string temp = data[a];
            data[a] = data[b];
            data[b] = temp;
        }

        #endregion


        #region Count Sort

        //조건 정렬데이터의 요소 가 0 이상 and 정렬데이터의 요소의 최대 크키 에 비례하는 저장 공간 

        /// <summary>
        /// 정렬데이터 ==> data_arr , 출력데이터 output_arr
        /// </summary>
        /// <param name="data_arr"></param>
        /// <param name="output_arr"></param>
        /// <param name="maxsize"></param>
        /// <returns></returns>
        public int[] Counting_Sort(int[] data_arr, int[] output_arr, int maxsize)
        {
            int[] count_arr = new int[10_001];

            for (int i = 0; i < maxsize; i++)
            {
                int value = data_arr[i];

                count_arr[value]++;
            }

            for (int i = 1; i <= count_arr.Length - 1; i++)
            {
                count_arr[i] = count_arr[i] + count_arr[i - 1];
            }   //누적 합계 계산


            
            for (int j = maxsize - 1; j >= 0; j--)
            {
                var item = data_arr[j];
                var count_idx = count_arr[item];
                output_arr[count_idx - 1] = item;
                count_arr[item]--; //중복되는 요소의 위치 떄문에 감소
            }

            return output_arr;
        }

        #endregion


    }
}
