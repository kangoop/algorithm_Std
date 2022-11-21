using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp_project_netframework
{
    public class Node
    {
        private Node _PreNode;

        public Node PreNode
        {
            set
            {
                this._PreNode = value;
            }
            get
            {
                return this._PreNode;
            }

        }

        private Node _nextnode;

        public Node NextNode
        {
            set
            {
                this._nextnode = value;
            }
            get
            {
                return this._nextnode;
            }
        }

        private object _item;
        public object Item
        {
            set
            {
                this._item = value;
            }
            get
            {
                return _item;
            }
        }

        public Node()
        {
            _item = new object();
        }
    }

    public class MyLinkedList
    {
        private Node head = null;
        private Node tail = null;

        public MyLinkedList()
        {

        }

        /// <summary>
        /// 맨앞에 새로운 Node 추가 
        /// </summary>
        /// <param name="value"></param>
        public void Insert(object value)
        {
            Node newnode = new Node();
            newnode.Item = value;

            if (head == null)
            {
                head = tail = newnode;
                head.PreNode = null;     //newnode.PreNode  = null;
                tail.NextNode = null;    //newnode.NextNode = null;
            }
            else
            {
                head.PreNode = newnode;
                newnode.NextNode = head;
                newnode.PreNode = null;
                head = newnode;
            }

        }

        public void Add(object value)
        {
            Node newnode = new Node { Item = value };

            if (head == null)
            {
                head = tail = newnode;
                head.PreNode = null;  //newnode.PreNode  = null;
                tail.NextNode = null;//newnode.NextNode= null;
            }
            else
            {
                tail.NextNode = newnode;
                newnode.PreNode = tail;
                tail.NextNode = null;
                tail = newnode;
            }
        }

        public void Delete(object value)
        {
            string key_value = value.ToString();
            Node current = head;
            if (head == null)
            {

            }
            else
            {
                while (current != null)
                {
                    string node_value = current.Item.ToString();

                    if (key_value == node_value)
                    {
                        if (current.NextNode == null) //마지막 Node 제거
                        {
                            tail = current.PreNode;
                            current.PreNode.NextNode = null;
                            current = null;
                            if (tail.PreNode == null) 
                            {
                                head = null;
                            }
                            break;
                        }
                        else if (current.PreNode == null) //첫번째 Node 제거 
                        {
                            head = current.NextNode;
                            current.NextNode.PreNode = null;
                            current = null;
                            if (head.NextNode == null)
                            {
                                tail = null;
                            }
                            break;
                        }
                        else
                        {
                            current.NextNode.PreNode = current.PreNode;
                            //현재 Node의 다음 노드의 Front 는 현재 Node의 앞선 Node를 본다.
                            current.PreNode.NextNode = current.NextNode;
                            //현재 Node의 이전 노드의 Rear 는 현재 Node의 다음 Node를 본다.
                            current = null;

                            break;
                        }
                    }

                    current = current.NextNode;
                }
            }
        }


        //Head의 NextNode 가 null 이라면 데이터는 없다
        public void DeleteFirst()
        {
            Node first = head;
            head = first.NextNode;
            if (first.NextNode != null)
            {
                first.NextNode.PreNode = null;
            }
            else
            {
                head = null;
                tail = null;
            }
            first = null;
        }

        //Tail의 PreNode 가 null 이라면 데이터는 없다.
        public void DeleteLast()
        {
            Node last = tail;
            tail = last.PreNode;
            if (last.PreNode != null)
            {
                last.PreNode.NextNode = null;
            }
            else
            {
                head = null;
                tail = null;
            }
            last = null;
        }


        public string Print_Item(string seq)
        {
            //출력 시간 out 에 의해서 StringBuilder 형식으로 변경 하여 출력
            StringBuilder sb = new StringBuilder();

            Node current = head;
            while (current != null)
            {
                if (current.NextNode == null)
                {
                    sb.Append($"{current.Item.ToString()}");
                    
                }
                else
                {
                    sb.Append($"{current.Item.ToString()}{seq}");
                }

                current = current.NextNode;
            }

            return sb.ToString();
        }
    }

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
            OutputData(InputData_Step2(str));
        }

        static string InputData_Step()
        {
            string data = Console.ReadLine();

            return data;
        }

        static string InputData_Step2(string str)
        {
            int order_cnt = int.Parse(str);

            MyLinkedList linklist = new MyLinkedList();

            for (int i=0;i <  order_cnt; i++)
            {
                string[] Order_arr = Console.ReadLine().Split(' ');
                switch (Order_arr[0])
                {
                    case "insert":
                        linklist.Insert(Order_arr[1]);
                        break;
                    case "delete":
                        linklist.Delete(Order_arr[1]);
                        break;
                    case "deleteFirst":
                        linklist.DeleteFirst();
                        break;
                    case "deleteLast":
                        linklist.DeleteLast();
                        break;
                }
            }

            string resultlist_item = linklist.Print_Item(" ");

            return resultlist_item;

        }
        //static string Process_Data_Step(string[] order_arr)
        //{
        //    MyLinkedList linklist = new MyLinkedList();

        //    for(int i=0;i< order_arr.Length;i++)
        //    {
        //        string[] str_arr = order_arr[i].Split(' ');

        //        switch(str_arr[0])
        //        {
        //            case "insert":
        //                linklist.Insert(str_arr[1]);
        //                break;
        //            case "delete":
        //                linklist.Delete(str_arr[1]);
        //                break;
        //            case "deleteFirst":
        //                linklist.DeleteFirst();
        //                break;
        //            case "deleteLast":
        //                linklist.DeleteLast();
        //                break;
        //        }
        //    }

        //    string resultlist_item = linklist.Print_Item(" ");

        //    return resultlist_item;
        //}

        static void OutputData(string str)
        {
            Console.WriteLine(str);

        }


    }

}
