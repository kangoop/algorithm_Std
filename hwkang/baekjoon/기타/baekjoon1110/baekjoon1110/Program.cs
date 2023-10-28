using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baekjoon1110
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputData = InputData();

            int outputData = FilterFunc(inputData);

            OutPutData(outputData);
        }

        private static int InputData()
        {
            int Data = Convert.ToInt32(Console.ReadLine());

            return Data;
        }

        private static int FilterFunc(int paramter)
        {
            int Cnt = 0;

            int Data = paramter;
            int Temp_Result = Data;


            int before_Data;
            int ten_digit;//십의자리
            int one_digit;//일의자리
            int right_digit_add_ten_one_digit;//digit add 

            do
            {
                Cnt++;

                if(Temp_Result<10)
                {
                    Temp_Result = (Temp_Result * 10) + Temp_Result;

                }
                else
                {
                    ten_digit = Temp_Result / 10;
                    one_digit = Temp_Result - (ten_digit * 10);
                    right_digit_add_ten_one_digit = 
                        (ten_digit + one_digit) >= 10 ? (ten_digit+one_digit)%10 : 
                                                       (ten_digit+one_digit);

                    Temp_Result = (one_digit * 10) + right_digit_add_ten_one_digit;
                }

                if(Data==Temp_Result)
                {
                    break;
                }

            } while (true);

            return Cnt;
        }

        private static void OutPutData(int paramter)
        {
            Console.WriteLine(paramter);
        }
    }
}
