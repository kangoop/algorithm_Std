using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp_project_netframework
{

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
            string[]  str_arr = InputData_Step(); //[ 우주의 갯수,우주마다 행성의 갯수]

            OutputData(Process_Data_Step(str_arr));
        }

        static string[] InputData_Step()
        {
            string[] data = Console.ReadLine().Replace(' ', ',').Split(',');

            return data;
        }


        /// <summary>
        /// 연산의 시작과 끝 은 무조건 A -,+,* B 으로 시작 됨으로 POP POP PUSH 구조를 가지고
        /// 마지막은 A B (-,+,*) 을 가져서 해당 문제를 해결
        /// </summary>
        /// <param name="str_arr"></param>
        /// <returns></returns>
        static int Process_Data_Step(string[] str_arr)
        {
            MyStack_Array _stack = new MyStack_Array(str_arr.Length);

            for(int i=0;i<str_arr.Length;i++)
            {
                string temp_data = str_arr[i];
                int? temp_data_int=new int?();
                switch(temp_data)
                {
                    case "+":
                        object value1 = _stack.Pop();
                        object value2 = _stack.Pop();
                        int int_value_1 = int.Parse(value1.ToString());
                        int int_value_2 = int.Parse(value2.ToString());
                        temp_data_int = int_value_2 + int_value_1;
                        _stack.Push((object)temp_data_int);
                        break;
                    case "-":
                        value1 = _stack.Pop();
                        value2 = _stack.Pop();
                        int_value_1 = int.Parse(value1.ToString());
                        int_value_2 = int.Parse(value2.ToString());
                        temp_data_int = int_value_2 - int_value_1;
                        _stack.Push((object)temp_data_int);
                        break;
                    case "*":
                        value1 = _stack.Pop();
                        value2 = _stack.Pop();
                        int_value_1 = int.Parse(value1.ToString());
                        int_value_2 = int.Parse(value2.ToString());
                        temp_data_int = int_value_2 * int_value_1;
                        _stack.Push((object)temp_data_int);
                        break;
                    default:
                        _stack.Push(temp_data);
                        break;
                }

              
            }

            object result_data = _stack.Pop();

            return (int)result_data;
         
        }

        static void OutputData(int int_value)
        {

            Console.WriteLine(int_value);

        }


    }

    public class MyStack_Array
    {
        private int top=-1; //스택가 가리킬 현재의 Index Push는 선증가 Pop는 후감소

        private int _mystacksize;//현재 스택 의 사이즈

        public int StackSize //현재 스택 의 사이즈
        {
            get
            {
                return _mystacksize;
            }
        }

        private object[] _mystack; //스택이 가지고 있는 데이터들 

        public MyStack_Array()
        {
            _mystacksize = 100;
            _mystack = new object[_mystacksize];
        }

        public MyStack_Array(int stacksize)
        {
            _mystacksize = stacksize;
            _mystack = new object[_mystacksize];
        }

        public void Push(object item)
        {
            //if((top) >=_mystacksize)
            //{
            //    int Before = _mystacksize;
            //    _mystacksize *= 2;
            //    object[] temp_arr = _mystack.Clone() as object[];
            //    _mystack = new object[_mystacksize];
            //    temp_arr.CopyTo(_mystack,0);
            //}

            _mystack[++top] = item;
        }

        public object Pop()
        {
            if(top <= -1)
            {
                return null;
            }

            object item = _mystack[top];
            _mystack[top--] = null;
            return item;
        }

        /// <summary>
        /// true 스택이 비어 있음 false 스택이 비어 있지 않음
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if(top <= -1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// true 스택이 꽉 차있는 상태 false 스택이 꽉 차있지 않은 상태
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            if(top ==StackSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
