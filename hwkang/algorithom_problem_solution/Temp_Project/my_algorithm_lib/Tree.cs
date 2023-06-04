using System;
using System.Collections.Generic;
using System.Text;

namespace my_algorithm_lib
{
    #region root trees 
    public class RootTrees
    {
        //샘플 
        /*
         *  Input 
            13
            0 3 1 4 10
            1 2 2 3
            2 0
            3 0
            4 3 5 6 7
            5 0
            6 0
            7 2 8 9
            8 0
            9 0
            10 2 11 12
            11 0
            12 0
         *  Output 
            node 0: parent = -1, depth = 0, root, [1, 4, 10]
            node 1: parent = 0, depth = 1, internal node, [2, 3]
            node 2: parent = 1, depth = 2, leaf, []
            node 3: parent = 1, depth = 2, leaf, []
            node 4: parent = 0, depth = 1, internal node, [5, 6, 7]
            node 5: parent = 4, depth = 2, leaf, []
            node 6: parent = 4, depth = 2, leaf, []
            node 7: parent = 4, depth = 2, internal node, [8, 9]
            node 8: parent = 7, depth = 3, leaf, []
            node 9: parent = 7, depth = 3, leaf, []
            node 10: parent = 0, depth = 1, internal node, [11, 12]
            node 11: parent = 10, depth = 2, leaf, []
            node 12: parent = 10, depth = 2, leaf, []
         */

        public void Start(string[] args)
        {
            int node_cnt = InputData_Step();

            MyNode[] mynodes = new MyNode[node_cnt];

            Process_Step(node_cnt, mynodes);

            OutputData_Step(mynodes);
        }

        public int InputData_Step()
        {
            string node_cnt = Console.ReadLine();

            return int.Parse(node_cnt);
        }


        public void Process_Step(int node_cnt, MyNode[] mynodes)
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

                        childnode.value = childnode_id;

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


        public void OutputData_Step(MyNode[] mynodes)
        {
            foreach (var node in mynodes)
            {
                Console.WriteLine($"node {node.value}: parent = {node.GetParentNodeId()}, depth = {node.NodeDepth()}, {node.Nodetype()}, {node.Childnode()}");
            }
        }

    }

    /// <summary>
    /// 노드(node) + 노드를 연결하는 에지(edge) 를 사용해서 표현 하는 자료구조 
    /// </summary>
    public class MyNode
    {
        MyNode parentnode;
        List<MyNode> childnodes = new List<MyNode>();

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
            if (value == node.value)
            {
                parentnode = null;
            }
            else
            {
                parentnode = node;
            }

        }

        /// <summary>
        /// 노드가 가진 자식의 수를 차수 (degree)
        /// </summary>
        /// <param name="childnode"></param>
        public void Addchildnode(MyNode childnode)
        {
            childnodes.Add(childnode);

        }

        /// <summary>
        /// 루트는 부모를 갖지 않는 유일한 노드 
        /// 자식을 갖지 않는 노드를 외부노드(external node) or 잎(leaf)
        /// 리프가 아닌 노드는 내부노드(internal node)
        /// </summary>
        /// <returns></returns>
        public string Nodetype()
        {
            if (parentnode == null)
            {
                return "root";
            }
            else if (childnodes == null || childnodes.Count <= 0)
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
    #endregion
}
