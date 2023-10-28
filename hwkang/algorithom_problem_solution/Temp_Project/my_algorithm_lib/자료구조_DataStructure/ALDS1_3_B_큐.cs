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
            string[]  str_arr   = InputData_Step();
            string[]  str_arr_2 = InputData_Step2(str_arr);

            OutputData(Process_Data_Step(str_arr,str_arr_2));
        }

        static string[] InputData_Step()
        {
            string[] data = Console.ReadLine().Replace(' ', ',').Split(',');

            return data;
        }

        static string[] InputData_Step2(string[] str_arr)
        {
            int process_cnt = int.Parse(str_arr[0]);

            string[] process_info = new string[process_cnt];

            for(int i=0;i<process_cnt;i++)
            {
                process_info[i] = Console.ReadLine();
            }

            return process_info;
        }
        static string[] Process_Data_Step(string[] process_init,string[] process_info)
        {
            int process_cnt = int.Parse(process_init[0]);
            int process_time = int.Parse(process_init[1]); //프로세스 처리시간
            MyQueue queue = new MyQueue(process_cnt);

            Process_Data[] process = new Process_Data[process_cnt];
            for(int i=0;i<process_info.Length;i++)
            {
                string[] info = process_info[i].Replace(' ', ',').Split(',');
                string p_name = info[0];
                int p_time = int.Parse(info[1]);

                process[i] = new Process_Data(p_name, p_time);
                queue.Endqueue(process[i]);
            }

            string[] process_end = new string[process_cnt];//프로세스 출력정보 

            int process_end_index = 0;
            int accumu_time = 0;//누적된 프로세스 처리 시간
            while(queue.IsEmpty()==false)
            {
                Process_Data p = queue.Dequeue() as Process_Data;


                //프로세스 정리 시간 이전이라면 남은 프로세스 시간을 누적시간에 더한다.
                if(p.RemainTime <= process_time)
                {
                    process_end[process_end_index++] = $"{p.Name} {p.RemainTime+accumu_time}";
                    accumu_time += p.RemainTime;
                }
                else
                {
                    p.RemainTime -= process_time;
                    queue.Endqueue(p);
                    accumu_time += process_time;
                }
            }

            return process_end;
        }

        //큐 원형 미적용
        static void OutputData(string[] str_arr)
        {

            foreach(var item in str_arr)
            {
                Console.WriteLine(item);
            }

        }


    }

    public class Process_Data
    {
        private string process_name;
        private int process_time;

        public string Name
        {
            get
            {
                return process_name;
            }
        }

        public int RemainTime
        {
            set
            {
                process_time = value;
            }
            get
            {
                return process_time;
            }
        }

        public Process_Data()
        {

        }

        public Process_Data(string name,int time)
        {
            process_name = name;
            process_time = time;
        }
    }

    public class MyQueue
    {
        
        private int front;
        private int rear;

        private object[] myqueuedata;

        public MyQueue()
        {
            front = 0;
            rear = -1;
            myqueuedata = new object[100];
        }

        public MyQueue(int queuesize)
        {
            myqueuedata = new object[queuesize];
            front = 0;
            rear = -1;
        }

        /// <summary>
        /// 큐끝에 요소 추가 
        /// </summary>
        /// <param name="data"></param>
        public void Endqueue(object data)
        {
            if(rear>=(myqueuedata.Length-1))
            {
                //if(rear - front > (myqueuedata.Length-1) )
                //{
                    int queuesize = myqueuedata .Length * 2;
                    object[] temp_data = myqueuedata.Clone() as object[];
                    myqueuedata = new object[queuesize];
                    temp_data.CopyTo(myqueuedata, 0);
                //}
                //else
                //{
                //    object[] temp_data = new object[myqueuedata.Length];

                //    int j = 0;//temp_data index;
                //    for (int i = front; i < rear; i++)
                //    {
                //        temp_data[j++] = myqueuedata[i];
                //    }

                //    myqueuedata = temp_data;

                //    rear = rear - front;
                //    front = 0;
                    
                //}
            }

            myqueuedata[++rear] = data;
        }

        /// <summary>
        /// 큐 가장 앞에 요소 추출
        /// </summary>
        /// <returns></returns>
        public object Dequeue()
        {
            object item = myqueuedata[front++];
            return item;
        }


        /// <summary>
        /// true 큐 비어 있음 false 데이터 존재
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if(front>rear)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// true 큐 MAX false 큐 MAX X
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            if(rear >= (myqueuedata.Length - 1))
            {
                return true;
            }

            return false;
        }
        

    }

}
