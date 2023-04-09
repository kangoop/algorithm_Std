using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baekjoon2621
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Tuple<string, int>> tuple = InputData();

            OutputPoint(tuple);
        }

        private static List<Tuple<string,int>> InputData()
        {
            List<Tuple<string, int>> list_tuple = new List<Tuple<string, int>>();
            for(int i=0;i<5;i++)
            {
                string str = Console.ReadLine();
                string item = str.Replace(" ","");
                Tuple<string, int> tuple = new Tuple<string, int>(item[0].ToString(),  Convert.ToInt32(item[1].ToString()));
                list_tuple.Add(tuple);
            }

            return list_tuple;

        }

        private static void OutputPoint(List<Tuple<string,int>> cards)
        {
            Tuple<string, int>[] tuples = cards.ToArray();

            bool allcolors = tuples.All((a) => a.Item1 == tuples[0].Item1);//카드의 색이 모두 동일한지 확인

            bool number_case = NumberType(cards); // true 숫자가 연속적 

            List<Tuple<int,int>> number_equls = NumberType_Equls(tuples);//Index별 숫자가 동일한 갯수 파악 숫자의갯수,값

            bool same_4 = false;
            bool same_3_2 = false;
            bool same_3 = false;
            bool same_2_2 = false;
            bool same_2 = false;

            List<int> index_cnt = new List<int>();
            foreach(var item in number_equls)
            {
                index_cnt.Add(item.Item1);
            }

            

            same_4 = index_cnt.Contains(4);
            same_3_2 = (index_cnt.Contains(3) && index_cnt.Contains(2)) ? true : false;
            
            if(index_cnt.Contains(3))
            {
                int cnt = 0;
                foreach(var item in index_cnt)
                {
                    if(item==1)
                    {
                        cnt++;
                    }
                }
                same_3 = cnt == 2 ? true : false;
            }
            else if(index_cnt.Contains(2))
            {
                
                int cnt = 0;
                foreach (var item in index_cnt)
                {
                    if (item == 1)
                    {
                        cnt++;
                    }
                }
                same_2 = cnt == 3 ? true : false;
            }

            same_2_2 = index_cnt.FindAll((a) => a == 2).Count==2? true:false;


            int point = 100;
            if(allcolors==true && number_case==true)
            {
                point = 900;
                int max = cards.Max((a) => a.Item2);

                point = point + max;

                Console.WriteLine(point);
            }
            else if(same_4==true)
            {
                point = 800;
                var query = from row in number_equls
                            where row.Item1 == 4
                            select row.Item2;
                point = point + query.Max();

                Console.WriteLine(point);
            }
            else if(same_3_2==true)
            {
                point = 700;
                var query = from row in number_equls
                            where row.Item1 == 3
                            select row.Item2;
                int same3 = query.Max()*10;

                query = from row in number_equls
                        where row.Item1 == 2
                        select row.Item2;
                int same2 = query.Max();

                point = point + same3 + same2;

                Console.WriteLine(point);
            }
            else if(allcolors==true)
            {
                point = 600;
                int max = cards.Max((a) => a.Item2);

                point = point + max;

                Console.WriteLine(point);
            }    
            else if(number_case==true)
            {
                point = 500;
                int max = cards.Max((a) => a.Item2);

                point = point + max;

                Console.WriteLine(point);
            }
            else if(same_3==true)
            {
                point = 400;
                var query = from row in number_equls
                            where row.Item1 == 3
                            select row.Item2;
                int same3 = query.Max();

                point = point + same3;

                Console.WriteLine(point);
            }
            else if(same_2_2==true)
            {
                point = 300;
                var query = from row in number_equls
                            where row.Item1 == 2
                            select row.Item2;
                int[] same2 = query.ToArray();
                point = same2.Max() * 10 + same2.Min() + point;

                Console.WriteLine(point);
            }
            else if(same_2==true)
            {
                point = 200;
                var query = from row in number_equls
                            where row.Item1 == 2
                            select row.Item2;

                int same2 = query.Max();

                point = point + same2;

                Console.WriteLine(point);
            }
            else
            {
                point = 100;
                int max = cards.Max((a) => a.Item2);

                point = point + max;

                Console.WriteLine(point);
            }
           
        }

        private static bool NumberType(List<Tuple<string, int>> tuples)
        {
            tuples.Sort((a, b) => a.Item2.CompareTo(b.Item2));

            bool numberstep = true;//반복문 종료후 true 연속적 or 비연속적
            int Indexnum = tuples[0].Item2;
            for(int i=0;i<tuples.Count;i++)
            {
                if(Indexnum==tuples[i].Item2)
                {
                    Indexnum++;
                }
                else
                {
                    numberstep = false;
                    break;
                }
            }

            return numberstep;
        }

        private static List<Tuple<int,int>> NumberType_Equls(Tuple<string,int>[] tuples)
        {
            List<Tuple<int,int>> result = new List<Tuple<int, int>>();

            for(int i=0;i<tuples.Length;i++)
            {
                int index_cnt = tuples.Count((a) => a.Item2 == tuples[i].Item2);
                Tuple<int, int> item = new Tuple<int, int>(index_cnt, tuples[i].Item2);
                if (result.Contains(item) == false)
                {
                    result.Add(item);
                }
            }

            return result;
        }

        
    }
}
