using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backjoon8979
{
    class Program
    {
        static void Main(string[] args)
        {
            int rank = Input();

            Output(rank);
        }


        public static int Input()
        {
            Dictionary<int, (int, int, int)> CountryMedal_Dic =
                new Dictionary<int, (int, int, int)>();

            string FirstInput = Console.ReadLine();

            int CountryCnt = Convert.ToInt32(FirstInput.Substring(0, FirstInput.IndexOf(' ')));

            int CountryID = Convert.ToInt32(FirstInput.Substring(FirstInput.IndexOf(' ')));


            string Medal = "";
            string MedalList = "";
            int countryId;
            (int G, int S, int C) TupleMedal;
            for(int i=1; i<=CountryCnt;i++)
            {
                Medal = Console.ReadLine();

                countryId = Convert.ToInt32(Medal.Substring(0, Medal.IndexOf(' ')));

                MedalList = Medal.Substring(Medal.IndexOf(' ')+1);

                int Item1 = Convert.ToInt32(MedalList.Substring(0, MedalList.IndexOf(' '))); //금
                MedalList = MedalList.Substring(MedalList.IndexOf(' ')+1);
                int Item2 = Convert.ToInt32(MedalList.Substring(0, MedalList.IndexOf(' '))); //은
                MedalList = MedalList.Substring(MedalList.IndexOf(' ')+1);
                int item3 = Convert.ToInt32(MedalList.Substring(0)); //동
                TupleMedal =   (
                                Item1,
                                Item2,
                                item3
                               );

                CountryMedal_Dic.Add(countryId, TupleMedal);

            }

            List<(int, (int, int, int))> CurrentMedal
                =new List<(int, (int, int, int))>();//국가 ID , (금,은,동)

            foreach(var item in CountryMedal_Dic)
            {
                CurrentMedal.Add((item.Key, item.Value));
            }

            var OrderBy_Rank = CurrentMedal.OrderByDescending(i => i.Item2).ToList();

            int Rank = 1;

            Dictionary<int, int> ID_Rank = new Dictionary<int, int>();

            for (int i = 0; i < CountryCnt;)
            {
                var RankMedal = OrderBy_Rank[i].Item2;

                var Query = from item in OrderBy_Rank
                            where item.Item2 == RankMedal
                            select item.Item1;

                if(Query.Contains(CountryID)==true)
                {
                    ID_Rank.Add(CountryID, Rank);
                    break;
                }
                else
                {
                    i += Query.Count();
                    Rank += Query.Count();
                }

            }

            return ID_Rank[CountryID];
        }

        public static void Output(object output)
        {
            Console.WriteLine(output);
        }
    }
}
