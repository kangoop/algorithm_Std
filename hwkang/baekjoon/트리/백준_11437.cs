using System;
using System.Collections.Generic;
using System.Text;

////참고 사이트 https://cocoon1787.tistory.com/328

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

            Process_Step(node_cnt - 1);
        }

        static int InputData_Step()
        {
            string node_cnt = Console.ReadLine();

            return int.Parse(node_cnt);
        }


        static void Process_Step(int node_cnt)
        {

            List<int>[] nodes = new List<int>[50001];
            Queue<int> queue = new Queue<int>(); //BFS 탐색을 위한 추가 

            bool[] check = new bool[50001]; //방문여부
            int[] parents = new int[50001]; //부모노드의 정보
            int[] depth = new   int[50001]; //노드의 깊이 

            for (int i = 0; i < node_cnt; i++)
            {
                string read = Console.ReadLine();

                string[] values = read.Split(' ');

                int value_first = int.Parse(values[0]);

                int value_second = int.Parse(values[1]);

                if (nodes[value_first] == null)
                {
                    nodes[value_first] = new List<int>() { value_second };
                }
                else
                {
                    nodes[value_first].Add(value_second);
                }

                if (nodes[value_second] == null)
                {
                    nodes[value_second]=new List<int>() { value_first };
                }
                else
                {
                    nodes[value_second].Add(value_first);
                }

            }

            check[1] = true;
            queue.Enqueue(1);

            while (queue.Count > 0)
            {
                int x = queue.Dequeue();

                for(int i = 0; i < nodes[x].Count; i++)
                {
                    int key_value_index = nodes[x][i];

                    if (!check[key_value_index])
                    {
                        depth[key_value_index] = depth[x] + 1;
                        check[key_value_index] = true;
                        parents[key_value_index] = x;
                        queue.Enqueue(key_value_index);
                    }
                }
            }

            int parentnode_cnt = InputData_Step();

            StringBuilder sb= new   StringBuilder();

            for (int i = 0; i < parentnode_cnt; i++)
            {
                string read = Console.ReadLine();

                if (string.IsNullOrEmpty(read))
                {
                    break;
                }

                string[] values = read.Split(' ');

                int value_first = int.Parse(values[0]);

                int value_second = int.Parse(values[1]);
                sb.AppendLine(LCA(value_first, value_second));
            }


            Console.WriteLine(sb.ToString());

            string LCA(int x ,int y)
            {
                // y 를 더깊은 노드 세팅 
                if (depth[x] > depth[y])
                {
                    int temp = x;
                    x = y;
                    y = temp;
                }

                // 노드가 동일한 깊이가 될때까지 올라가기 
                while (depth[x] != depth[y])
                {
                    y = parents[y];
                }

                //두 노드가 같아질떄까지 위로 올라가기 
                while (x != y)
                {
                    x = parents[x];
                    y = parents[y];
                }

                // 최소 공통 조상 리턴 
                return x.ToString();
            }
        }     
    }
}

/* 내가 쓴 코드 시간 초과 
using System;
using System.Collections.Generic;
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

            MyNode[] myNodes = new MyNode[50001];

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


        static int Node_GetDepth(MyNode node,int depth)
        {
            if (node == null)
            {
                return depth;
            }
            else
            {
                return Node_GetDepth(node.ParentNode, depth + 1);
            }
        }

        static void OutputData_Step(MyNode[] mynodes)
        {

            
            int parentnode_cnt = InputData_Step();

           
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < parentnode_cnt; i++)
            {
                string read = Console.ReadLine();

                if (string.IsNullOrEmpty(read))
                {
                    break;
                }

                string[] values = read.Split(' ');

                int value_first = int.Parse(values[0]);

                int value_second = int.Parse(values[1]);

                var firstnode= mynodes[value_first]; 
                var secondnode= mynodes[value_second];


                var firstnode_depth = firstnode.GetDepth(); //Node_GetDepth(firstnode,0);   //GetDepth()
                var second_depth = secondnode.GetDepth(); ///Node_GetDepth(secondnode, 0);  //GetDepth()

                int equal_depth = firstnode_depth <= second_depth ? firstnode_depth : second_depth;


                var firstnode_nodes = firstnode.GetParents(firstnode_depth - equal_depth);


                
                var second_nodes = secondnode.GetParents(second_depth - equal_depth);


                string temp_value = string.Empty;
                for (int j = 0; j <= equal_depth; j++)
                {
                    var firstnode_value = firstnode_nodes[j];
                    var secondnode_value = second_nodes[j];

                    if (firstnode_value == secondnode_value)
                    {
                         sb.AppendLine(firstnode_value);
                        break;
                    }

                }

                //for (int j = equal_depth ; j >= 0; j--)
                //{
                //    var firstnode_value = firstnode_nodes[j];
                //    var secondnode_value = second_nodes[j];


                //    if (firstnode_value == secondnode_value)
                //    {
                //        temp_value = firstnode_value;
                //        if (j == 0)
                //        {
                //            sb.AppendLine(temp_value);
                //        }
                //        continue;
                //    }
                //    else
                //    {
                //        sb.AppendLine(temp_value);
                //        break;
                //    }
                //}

            }

            Console.Write(sb.ToString());


        }
    }

    
    


    public class MyNode
    {
        public List<MyNode> Nodes { get; set; }

        public string NodeValue { get; set; }

        public int Depth { get; set; }

        public MyNode ParentNode { get; set; }

        public MyNode()
        {
            Nodes = new List<MyNode>();
        }



        public void AddNode(MyNode node)
        {
            Nodes.Add(node);
        }

        private void parentnodes(int startiindex,string[] list,int arrayindex)
        {
            if (this.ParentNode == null)
            {
                list[arrayindex]="1";
                return;
            }

            if (startiindex <= 0)
            {
                list[arrayindex] = NodeValue;
                arrayindex = arrayindex + 1;
            }
            this.ParentNode.parentnodes(startiindex -1 <= 0 ? 0:(startiindex - 1), list,arrayindex);
            return;
        }

        public string[] GetParents(int startindex=0)
        
        {
            var list = new string[100];
            parentnodes(startindex,list,0);
            return list;
        }

        private string GetParentNodeValue(int startindex)
        {
            if (this.ParentNode == null)
            {
                return "1";
            }

            if (startindex <= 0)
            {
                return NodeValue;
            }
            return this.ParentNode.GetParentNodeValue(startindex - 1 <= 0 ? 0 : (startindex - 1));
        }

        public string GetParent(int startindex = 0)
        {
            return GetParentNodeValue(startindex);
        }

        private int DepthCheck(ref int depth)
        {
            if (this.ParentNode == null)
            {
                return depth;
            }
            else
            {
                depth += 1;
                this.ParentNode.DepthCheck(ref depth);
                return depth;
            }
        }

        public int GetDepth()
        {
            int depth = 0;
            int result  = DepthCheck(ref depth);

            return depth;
        }
            

        private void ParentNode_Check(string value,ref bool flag)
        {
            if(this.ParentNode == null)
            {
                if (this.NodeValue == value)
                {
                    flag = true;
                }
                else
                {
                    flag = false; 
                }
                
            }
            else
            {
                if (this.ParentNode.NodeValue == value)
                {
                    flag = true;
                }
                else
                {
                    this.ParentNode.ParentNode_Check(value,ref flag);
                    
                }
            }
        }

        public bool FindParentNode(string value)
        {
            bool flag = false;
            ParentNode_Check(value,ref flag);
            return flag;
        }

        public MyNode GetParentNode()
        {
            return this.ParentNode;
        }      
    }
 
}
*/