using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp_project_netframework
{
//https://js1jj2sk3.tistory.com/79 참고 사이트 
    public class Program
    {
        /*
         * 단계를 3단계로 구분 하여 표현
         * InputData 단계 조건을 입력받는 과정
         * 
         * Process 단계 로직을 진행하여 결과를 출력하는 과정
         * 
         * OutputData 단계 입력받은 데이터를 가지고 로직과정을 거쳐서 출력하는 표현하는 과정
         * 
         * 만약 각 단계마다 끝나지 않는 다면 
         * StepXXX 을 붙여서 진행 하도록 한다 EX) Step1 -> Step2 ... 이런식으로 
         * 
         * 
         */
        static void Main(string[] args)
        {
            string  str   = InputData_Step();

            OutputData(Process_Step1(str));
        }

        static string InputData_Step()
        {
            string data = Console.ReadLine();

            return data;
        }

        //H=1,C=12,O=16
		//새로운 스택이 종료된 후에 는 숫자가 올지 알파벳이 올지 괄호가 올지 모른다.
        static string Process_Step1(string str)
        {
            Stack<int> stack = new Stack<int>();

            int temp_value=0;
            for(int i=0;i<str.Length;i++)
            {
                char item = str[i];

                if(item=='H')
                {
                    temp_value = 1;
                    if(stack.Count()==0)
                    {
                        stack.Push(temp_value);
                    }
                    else
                    {
                        int pop_value = stack.Pop();
                        pop_value += temp_value;
                        stack.Push(pop_value);
                    }
                }

                else if (item == 'C')
                {
                    temp_value = 12;
                    if (stack.Count() == 0)
                    {
                        stack.Push(temp_value);
                    }
                    else
                    {
                        int pop_value = stack.Pop();
                        pop_value += temp_value;
                        stack.Push(pop_value);
                    }
                }

                else if (item == 'O')
                {
                    temp_value = 16;
                    if (stack.Count() == 0)
                    {
                        stack.Push(temp_value);
                    }
                    else
                    {
                        int pop_value = stack.Pop();
                        pop_value += temp_value;
                        stack.Push(pop_value);
                    }
                }

                else if(item=='(') //새로운 스택을 쌓는게 중요 
                {
                    stack.Push(0);
                }

                else if(item==')')
                {
                    int pop_value = stack.Pop();
                    temp_value = pop_value;
                    if(stack.Count()==0)
                    {
                        stack.Push(pop_value);
                    }
                    else
                    {
                        int pop_value2 = stack.Pop();
                        stack.Push(pop_value + pop_value2);
                    }

                }

                else if((int)item>='2' && (int)item<='9')
                {
                    int pop_value = temp_value * ((int)item-(int)'1');
                    int pop_value2 = stack.Pop();
                    stack.Push(pop_value + pop_value2);
                }
            }

            int result_value = stack.Pop();

            return result_value.ToString();
        }

     

        static void OutputData(string str)
        {
            Console.WriteLine(str);

        }


    }

}
