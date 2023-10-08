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
		문제
		루트 없는 트리가 주어진다. 이때, 트리의 루트를 1이라고 정했을 때, 각 노드의 부모를 구하는 프로그램을 작성하시오.

		입력
		첫째 줄에 노드의 개수 N (2 ≤ N ≤ 100,000)이 주어진다. 둘째 줄부터 N-1개의 줄에 트리 상에서 연결된 두 정점이 주어진다.

		출력
		첫째 줄부터 N-1개의 줄에 각 노드의 부모 노드 번호를 2번 노드부터 순서대로 출력한다.

		예제 입력 1 
		7
		1 6
		6 3
		3 5
		4 1
		2 4
		4 7
		예제 출력 1 
		4
		6
		1
		3
		1
		4
		
		예제 입력 2 
		12
		1 2
		1 3
		2 4
		3 5
		3 6
		4 7
		4 8
		5 9
		5 10
		6 11
		6 12
		예제 출력 2 
		1
		1
		2
		3
		3
		4
		4
		5
		5
		6
		6
		
		 
		해결 방식
		미리 주어지는 값이 연결 되어 있다는 보장 이 없다.
		
		즉 주어지는 값을 서로 연결되어 있다고 
		
		사전 값으로 저장 한후 
		
		1 루트 임으로 
		
		1이 연결되어 있는 구조 부터 탐색하여 구조 를 만든다.
		
		이때 연결되어 있는 구조가 미리 있다면 추가할필요 없다 위에서 부터 내려 왔음으로 
		
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
                    MakeNode(link_list, item, link_list[item],myNodes);
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
                        MakeNode(link_list, item, link_list[item], myNodes);
                    }
                    else
                    {
                        continue;
                    }
                    
                }
            }
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

            Console.Write(sb);

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