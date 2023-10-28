using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baekjoon2661
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            string result = ResultFunc(length);

            ResultOutput(result);

        }

        static bool Good_Bad_Check(string str)
        {
            int loop = str.Length / 2;
            int start = str.Length - 1;
            int end = str.Length;

            for(int i=1;i<=loop;i++)
            {
                //Console.WriteLine($"str.Substring(start-i,end-i):{start - i},{end - i},{str.Substring(start - i, end-i-(start-i))}");
                //Console.WriteLine($"str.Substring(start,end-start):{start},{end - start},{str.Substring(start, end - start)}");
                if(str.Substring(start-i, end - i - (start - i)).Equals(str.Substring(start,end-start)))
                {
                   // Console.WriteLine("false");
                    return false;
                }
                start -= 1;
            }
            //Console.WriteLine("true");
            return true;
        }

        static string ResultFunc(int length)
        {
            int txtcnt = 1;
            string txt = "1";
            string beforeaddtxt = "1";

            while (true)
            {
                if(txt.Length==length)
                {
                    break;
                }

                switch (beforeaddtxt)
                {
                    case "1":
                        if( (Good_Bad_Check(txt+"2")==false) && (Good_Bad_Check(txt+"3")==false) )
                        {
                            txt = beforetxtFront(txt);
                            beforeaddtxt = txt.Last().ToString();
                        }
                        else if(Good_Bad_Check(txt+"2"))
                        {
                            txt = txt + "2";
                            beforeaddtxt = txt.Last().ToString();
                        }
                        else
                        {
                            txt = txt + "3";
                            beforeaddtxt = txt.Last().ToString();
                        }
                        break;

                    case "2":
                        if ((Good_Bad_Check(txt + "1") == false) && (Good_Bad_Check(txt + "3") == false))
                        {
                            txt = beforetxtFront(txt);
                            beforeaddtxt = txt.Last().ToString();
                        }
                        else if (Good_Bad_Check(txt + "1"))
                        {
                            txt = txt + "1";
                            beforeaddtxt = txt.Last().ToString();
                        }
                        else
                        {
                            txt = txt + "3";
                            beforeaddtxt = txt.Last().ToString();
                        }
                        break;

                    case "3":
                        if ((Good_Bad_Check(txt + "1") == false) && (Good_Bad_Check(txt + "2") == false))
                        {
                            txt = beforetxtFront(txt);
                            beforeaddtxt = txt.Last().ToString();
                        }
                        else if (Good_Bad_Check(txt + "1"))
                        {
                            txt = txt + "1";
                            beforeaddtxt = txt.Last().ToString();
                        }
                        else
                        {
                            txt = txt + "2";
                            beforeaddtxt = txt.Last().ToString();
                        }
                        break;
                }

                txtcnt++;
            }

            return txt;


            string beforetxtFront(string str)
            {
                Console.WriteLine($"  str is      {str}");
                string BeforeTxtFront = str[str.Length - 2].ToString();//마지막 문자의 이전문자 
                string LastTxt = str.Last().ToString();//변경해야되는 마지막 문자

                switch (BeforeTxtFront)
                {
                    case "1"://2,3
                        if (LastTxt == "2")
                        {
                            str = str.Substring(0, str.Length - 1) + "3";
                        }
                        else
                        {
                            str = str.Substring(0, str.Length - 1) + "2";
                        }

                        break;
                    case "2"://1,3
                        if(LastTxt=="1")
                        {
                            str = str.Substring(0, str.Length - 1) + "3";
                        }
                        else
                        {
                            str = str.Substring(0, str.Length - 1) + "1";
                        }

                        break;
                    case "3"://1,2
                        if (LastTxt == "1")
                        {
                            str = str.Substring(0, str.Length - 1) + "2";
                        }
                        else
                        {
                            str = str.Substring(0, str.Length - 1) + "1";
                        }

                        break;
                }

                bool check = Good_Bad_Check(str);

                if(check==false)
                {
                    Console.WriteLine($"check is false{str}");
                    beforetxtFront(str);
                }
                else
                {
                    Console.WriteLine($"check is true {str}");

                }
                return str;            
            }
        }

        static void ResultOutput(string txt)
        {
            Console.WriteLine(txt);
            Console.Read();
        }


    }
}
