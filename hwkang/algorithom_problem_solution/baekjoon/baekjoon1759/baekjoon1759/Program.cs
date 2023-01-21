using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baekjoon1759
{
    class Program
    {
        //4 6
        //a t c i s w
        static List<string> Charlist;
        
        static void Main(string[] args)
        {
           var inputdata = InputData();

            //var outputdata =
            FillterData(inputdata);
        }

        static object InputData()
        {
            var line1 = Console.ReadLine().Replace(" ",",").Split(',');

            (int pdsize, int charcnt) t1
               = (Convert.ToInt32(line1[0]), Convert.ToInt32(line1[1]));

            var line2 = Console.ReadLine().Replace(" ",",").Split(',');
            List<string> charlist = line2.ToList();


            return (t1, charlist);

        }

        static void FillterData(object Data)
        {
           ((int,int),List<string>)ConvertData
                =(((int,int),List<string>))Data;

            int Passwordsize = ConvertData.Item1.Item1;
            int CharCnt = ConvertData.Item1.Item2;

            Charlist = ConvertData.Item2;
            check = new bool[Charlist.Count];
            check_combination = new bool[Charlist.Count];

            Test_Permutation(0, 4);

            passwordlist.Sort();

            foreach (var item in passwordlist)
            {
                int vowel_cnt = 0;

                vowel_cnt = item.Replace('a', '0').Replace('e', '0').
                    Replace('i', '0').Replace('o', '0')
                    .Replace('u', '0').Count(i => i == '0');

                if ((Passwordsize - vowel_cnt) >= 2 && (vowel_cnt >= 1))
                {
                    Console.WriteLine(item);
                }
            }

            Console.WriteLine("=============");

            Test_Combination(0, 0, 4);

            passwordlist_combination.Sort();

            foreach (var item in passwordlist_combination)
            {
                int vowel_cnt = 0;

                vowel_cnt = item.Replace('a', '0').Replace('e', '0').
                    Replace('i', '0').Replace('o', '0')
                    .Replace('u', '0').Count(i => i == '0');

                if( (Passwordsize-vowel_cnt) >= 2 && (vowel_cnt>=1))
                {
                    var orderby = new string(item.OrderBy(i => i).ToArray());
                    Console.WriteLine(orderby);
                }
            }
        }

        static List<char> word = new List<char>();
        static List<string> passwordlist = new List<string>();
        static bool[] check;
        //순열
        static void Test_Permutation(int n,int r)
        {
            if(n==r)
            {

                var password = new string(word.ToArray());
                passwordlist.Add(password);
                return;
            }
            else
            {
                for(int i=0; i<Charlist.Count;i++)
                {
                    if(check[i]==true)
                    {
                        continue;
                    }
                    else
                    {
                        check[i] = true;
                        word.Add(Charlist[i][0]);
                        Test_Permutation(n + 1, r);
                        word.RemoveAt(word.Count - 1);
                        check[i] = false;
                    }
                }
            }
        }
        static List<string> passwordlist_combination = new List<string>();
        static bool[] check_combination;
        static List<char> word_combination = new List<char>();
        //조합
        static void Test_Combination(int idx,int n,int r)
        {
            if(n==r)
            {
                for(int i=0;i<Charlist.Count;i++)
                {
                    if(check_combination[i]==true)
                    {
                        word_combination.Add(Charlist[i][0]);
                    }
                }
                passwordlist_combination.Add(new string(word_combination.ToArray()));
                word_combination.Clear();
            }
            else
            {
                for(int i=idx;i<Charlist.Count;i++)
                {
                    if(check_combination[i]==true)
                    {
                        continue;
                    }
                    else
                    {
                        check_combination[i] = true;
                        Test_Combination(i, n + 1, r);
                        check_combination[i] = false;
                    }
                }
            }
        }
        
    }
}
