using System;
using System.Collections.Generic;
using System.Text;

namespace total_lib
{
    class data_structure
    {

    }


    /// <summary>
    /// 배열버전
    /// </summary>
    public class MyStack_Array
    {
        private int top = -1; //스택가 가리킬 현재의 Index Push는 선증가 Pop는 후감소

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
            if ((top) >= _mystacksize)
            {
                int Before = _mystacksize;
                _mystacksize *= 2;
                object[] temp_arr = _mystack.Clone() as object[];
                _mystack = new object[_mystacksize];
                temp_arr.CopyTo(_mystack, 0);
            }

            _mystack[++top] = item;
        }

        public object Pop()
        {
            if (top <= -1)
            {
                throw new Exception("No Data");
                return null;
            }

            object item = _mystack[top];
            _mystack[top--] = null; //top 도 감소 시키지만 top 이 가리키던 데이터도 지워야한다.
            return item;
        }

        /// <summary>
        /// true 스택이 비어 있음 false 스택이 비어 있지 않음
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if (top <= -1)
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
            if (top == StackSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class MyQueue_Array
    {

        private int front;
        private int rear;

        private object[] myqueuedata;

        public MyQueue_Array()
        {
            front = 0;
            rear = -1;
            myqueuedata = new object[100];
        }

        public MyQueue_Array(int queuesize)
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
            if (rear >= (myqueuedata.Length - 1))
            {
                //if(rear - front > (myqueuedata.Length-1) )
                //{
                int queuesize = myqueuedata.Length * 2;
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
            if (front > rear)
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
            if (rear >= (myqueuedata.Length - 1))
            {
                return true;
            }

            return false;
        }


    }



    /// <summary>
    /// 연결리스트 
    /// </summary>
    public class MyLinkedList
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

        private Node head = null;
        private Node tail = null;

        public MyLinkedList()
        {

        }

        public bool HeadIsnull
        {
            get
            {
                if (head == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public object HeadItem
        {
            get
            {
                return head.Item;
            }
        }

        public object TailItem
        {
            get
            {
                return tail.Item;
            }
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

        /// <summary>
        /// 새로운 Node를 뒤에 붙이는 식으로 추가 
        /// </summary>
        /// <param name="value"></param>
        public void Add(object value)
        {
            Node newnode = new Node { Item = value };

            if (head == null)
            {
                head = tail = newnode;
                head.PreNode = null;  //newnode.PreNode  = null;
                tail.NextNode = null; //newnode.NextNode= null;
            }
            else
            {
                tail.NextNode = newnode;
                newnode.PreNode = tail;
                newnode.NextNode = null;
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

        public bool Find(string item)
        {
            Node current = head;

            if (current == null)
            {
                return false;
            }

            while (current != null)
            {
                if (current.Item.ToString() == item)
                {
                    return true;
                }

                if (current.NextNode == null)
                {
                    return false;
                }

                current = current.NextNode;
            }

            return false;
        }

        public bool LastFind(string item)
        {
            Node current = tail;

            if (current == null)
            {
                return false;
            }

            while (current != null)
            {
                if (current.Item.ToString() == item)
                {
                    return true;
                }

                if (current.PreNode == null)
                {
                    return false;
                }

                current = current.PreNode;
            }

            return false;
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

        public string Print_NewLine_Item()
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
                    sb.AppendLine($"{current.Item.ToString()}");
                }

                current = current.NextNode;
            }

            return sb.ToString();
        }
    }
}
