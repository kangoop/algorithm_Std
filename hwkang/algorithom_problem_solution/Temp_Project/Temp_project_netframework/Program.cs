using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Principal;
using System.Text;

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
         */

        static void Main(string[] args)
        {
            int node_cnt = InputData_Step();

            MyNode[] mynodes = new MyNode[node_cnt];

            Process_Step(node_cnt,mynodes);

            OutputData_Step(mynodes);
        }

        static int InputData_Step()
        {
            string node_cnt = Console.ReadLine();

            return int.Parse(node_cnt);
        }


        static void Process_Step(int node_cnt, MyNode[] mynodes)
        {
            for (int i = 0; i < node_cnt; i++)
            {
                string[] node_info = Console.ReadLine().Replace(" ", ",").Split(',');

                string node_id = node_info[0];
               
                if (mynodes[int.Parse(node_id)] == null)
                {
                    MyNode node = new MyNode();
                    mynodes[int.Parse(node_id)] = node;
                    mynodes[int.Parse(node_id)].value = node_id;
                }

                MyNode parentnode = mynodes[int.Parse(node_id)];


                for (int j = 2; j < node_info.Length; j++) // childnode 추가 
                {
                    string childnode_id = node_info[j];

                    
                    if (mynodes[int.Parse(childnode_id)] == null)
                    {
                        MyNode childnode = new MyNode();

                        mynodes[int.Parse(childnode_id)] = childnode;

                        childnode.value  = childnode_id;

                        childnode.AddParentnode(parentnode);

                        parentnode.Addchildnode(childnode);

                    }
                    else
                    {
                        MyNode childnode = mynodes[int.Parse(childnode_id)];
                        childnode.AddParentnode(parentnode);
                        parentnode.Addchildnode(childnode);

                    }
                }
            }
        }


        static void OutputData_Step(MyNode[] mynodes)
        {
            foreach (var node in mynodes)
            {
                Console.WriteLine($"node {node.value}: parent = {node.GetParentNodeId()}, depth = {node.NodeDepth()}, {node.Nodetype()}, {node.Childnode()}");
            }
        }


    }

    public class MyNode
    {
        MyNode parentnode;
        List<MyNode> childnodes = new List<MyNode>();
        //MyNode[] childnodes = new MyNode[0] { };
        public string value { get; set; }// node id 

        public MyNode()
        {
            
        }

        public string GetParentNodeId()
        {
            return parentnode == null ? "-1" : parentnode.value;
        }

        public void AddParentnode(MyNode node)
        {
            if(value == node.value)
            {
                parentnode = null;
            }
            else
            {
                parentnode = node;
            }
            
        }


        public void Addchildnode(MyNode childnode)
        {
            childnodes.Add(childnode);

        }


        public string Nodetype()
        {
            if (parentnode == null)
            {
                return "root";
            }
            else if (childnodes ==null || childnodes.Count <= 0)
            {
                return "leaf";
            }
            else
            {
                return "internal node";
            }
        }

        public string Childnode()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            //string childnode = string.Empty;
            //childnode = "[";


            for (int i = 0; i < childnodes.Count; i++)
            {
                if (i < childnodes.Count - 1)
                {
                    sb.Append(childnodes[i].value + ", ");
                    //childnode += childnodes[i].value + ", ";
                }
                else
                {
                    sb.Append(childnodes[i].value);
                    //childnode += childnodes[i].value;
                }
            }

            sb.Append("]");//childnode += "]";


            return sb.ToString();

        }

        public int NodeDepth()
        {
            int nodecnt = 0;

            bool parentnodechk = true;

            MyNode temp_node = parentnode;

            while (parentnodechk)
            {

                if (temp_node == null)
                {
                    break;
                }
                else
                {
                    nodecnt++;
                }

                temp_node = temp_node.parentnode;
            }

            return nodecnt;
        }
    }
}