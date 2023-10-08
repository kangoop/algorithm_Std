using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
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

            MyNode[] myNodes = new MyNode[100_010];

            Process_Step(node_cnt - 1, myNodes);

            OutputData_Step(myNodes);

        }

        static int InputData_Step()
        {
            string node_cnt = Console.ReadLine();

            return int.Parse(node_cnt);
        }


        static void Process_Step(int node_cnt, MyNode[] myNodes)
        {
            Dictionary<int, List<int>> link_list = new Dictionary<int, List<int>>();
            for (int i = 0; i < node_cnt; i++)
            {
                string read = Console.ReadLine();

                string[] values = read.Split(' ');

                int value_first = int.Parse(values[0]);

                int value_second = int.Parse(values[1]);

                if (link_list.ContainsKey(value_first))
                {
                    link_list[value_first].Add(value_second);
                }
                else
                {
                    link_list.Add(value_first, new List<int>() { value_second });
                }

                if (link_list.ContainsKey(value_second))
                {
                    link_list[value_second].Add(value_first);
                }
                else
                {
                    link_list.Add(value_second, new List<int>() { value_first });
                }

            }


            MakeNode(link_list,1, link_list[1], myNodes);

        }

        static void MakeNode(Dictionary<int,List<int>> link_list, int keyvalue, List<int> values, MyNode[] myNodes)
        {

            if (myNodes[keyvalue] == null)
            {
                MyNode new_node = new MyNode();
                new_node.NodeValue = keyvalue.ToString();
                myNodes[keyvalue] = new_node;

                foreach (var item in values)
                {
                    if (myNodes[item] == null)
                    {
                        MyNode new_node_child = new MyNode();
                        new_node_child.NodeValue = item.ToString();
                        myNodes[item] = new_node_child;
                        new_node_child.ParentNode = new_node;
                        new_node.Nodes.Add(new_node_child);
                    }
                    else
                    {
                        myNodes[item].ParentNode = new_node;
                        new_node.Nodes.Add(myNodes[item]);
                    }
                    if (link_list.ContainsKey(item))
                    {
                        MakeNode(link_list, item, link_list[item], myNodes);
                    }
                    
                }
            }
            else
            {
                MyNode contain_node = myNodes[keyvalue];

                foreach (var item in values)
                {
                    if (myNodes[item] == null)
                    {
                        MyNode new_node_child = new MyNode();
                        new_node_child.NodeValue = item.ToString();
                        myNodes[item] = new_node_child;
                        new_node_child.ParentNode = contain_node;
                        contain_node.Nodes.Add(new_node_child);
                        if (link_list.ContainsKey(item))
                        {
                            MakeNode(link_list, item, link_list[item], myNodes);
                        }                       
                    }
                    else
                    {
                        continue;
                    }
                    
                }
            }
            link_list.Remove(keyvalue);
        }

        static void OutputData_Step(MyNode[] mynodes)
        {
            StringBuilder sb =new StringBuilder();
            foreach(var item in mynodes)
            {
                
                if(item != null)
                {
                    if (item.NodeValue != "1")
                    {
                        sb.AppendLine(item.ParentNode.NodeValue);
                        //Console.WriteLine(item.ParentNode.NodeValue);
                    }
                }
            }

            Console.Write(sb.ToString());

        }
    }

    
    


    public class MyNode
    {


        public List<MyNode> Nodes { get; set; }

        public string NodeValue { get; set; }

        public MyNode ParentNode { get; set; }

        public MyNode()
        {
            Nodes = new List<MyNode>();
        }

        public void AddNode(MyNode node)
        {
            Nodes.Add(node);
        }
    }
 
}