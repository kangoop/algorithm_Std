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

                if (mynodes[int.Parse(node_id)] == null) //생성되지 않은 노드라면 생성 
                {
                    MyNode node = new MyNode();
                    mynodes[int.Parse(node_id)] = node;
                    mynodes[int.Parse(node_id)].value = node_id;
                }

                MyNode parentnode = mynodes[int.Parse(node_id)]; //첫번째 노드 이후는 자식노드들 


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


    #region Binary Tree
    public class BinaryTree
    {
        /* EX CODE)
        Sample Input 1
        9
        0 1 4
        1 2 3
        2 -1 -1
        3 -1 -1
        4 5 8
        5 6 7
        6 -1 -1
        7 -1 -1
        8 -1 -1
        Sample Output 1
        node 0: parent = -1, sibling = -1, degree = 2, depth = 0, height = 3, root
        node 1: parent = 0, sibling = 4, degree = 2, depth = 1, height = 1, internal node
        node 2: parent = 1, sibling = 3, degree = 0, depth = 2, height = 0, leaf
        node 3: parent = 1, sibling = 2, degree = 0, depth = 2, height = 0, leaf
        node 4: parent = 0, sibling = 1, degree = 2, depth = 1, height = 2, internal node
        node 5: parent = 4, sibling = 8, degree = 2, depth = 2, height = 1, internal node
        node 6: parent = 5, sibling = 7, degree = 0, depth = 3, height = 0, leaf
        node 7: parent = 5, sibling = 6, degree = 0, depth = 3, height = 0, leaf
        node 8: parent = 4, sibling = 5, degree = 0, depth = 2, height = 0, leaf
        */

        /*tree 순회 추가
         * Sample Input 1
        9
        0 1 4
        1 2 3
        2 -1 -1
        3 -1 -1
        4 5 8
        5 6 7
        6 -1 -1
        7 -1 -1
        8 -1 -1
        Sample Output 1
        Preorder
         0 1 2 3 4 5 6 7 8
        Inorder
         2 1 3 0 6 5 7 4 8
        Postorder
         2 3 1 6 7 5 8 4 0
         * 
         */

        static void Main(string[] args)
        {
            int node_cnt = InputData_Step();

            MyNode_Binary[] mynodes = new MyNode_Binary[node_cnt];

            Process_Step(node_cnt, mynodes);

            OutputData_Step(mynodes);
        }

        static int InputData_Step()
        {
            string node_cnt = Console.ReadLine();

            return int.Parse(node_cnt);
        }

        static void Process_Step(int node_cnt, MyNode_Binary[] mynodes)
        {
            for (int i = 0; i < node_cnt; i++)
            {
                string[] node_info = Console.ReadLine().Replace(" ", ",").Split(',');

                string node_idx = node_info[0];

                if (mynodes[int.Parse(node_idx)] == null)
                {
                    MyNode_Binary node = new MyNode_Binary();
                    mynodes[int.Parse(node_idx)] = node;
                    mynodes[int.Parse(node_idx)].nodevalue = node_idx;
                }

                MyNode_Binary parentnode = mynodes[int.Parse(node_idx)];

                for (int j = 1; j < node_info.Length; j++)
                {
                    string node_value_idx = node_info[j];

                    if (node_value_idx != "-1")
                    {
                        MyNode_Binary node;
                        if (mynodes[int.Parse(node_value_idx)] != null)
                        {
                            node = mynodes[int.Parse(node_value_idx)];
                            node.AddparentNode(parentnode);
                            node.nodevalue = node_value_idx;
                        }
                        else
                        {
                            node = new MyNode_Binary();
                            node.AddparentNode(parentnode);
                            mynodes[int.Parse(node_value_idx)] = node;
                            node.nodevalue = node_value_idx;
                        }

                        if (j == 1) //left
                        {
                            parentnode.AddchildNode("left", node);
                        }
                        else if (j == 2) //right
                        {
                            parentnode.AddchildNode("right", node);
                        }
                    }
                    else // node_value_idx == -1
                    {

                    }
                }
            }
        }

        static void OutputData_Step(MyNode_Binary[] mynodes)
        {
            foreach (var node in mynodes)
            {
                Console.WriteLine($"node {node.nodevalue}: parent = {node.ParentNodeValue()}, sibling = {node.SiblingValue()}, degree = {node.DegreeValue()}, depth = {node.DepthValue()}, height = {node.HeightValue()}, {node.NodeType()}");
            }

            /*
             * 트리 순회
             */
            foreach (var node in mynodes)
            {
                node.Preorder();
                node.Inorder();
                node.Postorder();
            }

        }
    }

    public class MyNode_Binary
    {
        MyNode_Binary parentnode;
        MyNode_Binary left;
        MyNode_Binary right;
        private string nodelocation { get; set; } //현재 자신이 LEFT ,RIGHT 인지 나타낸다.
        public string nodevalue { get; set; } //노드의 위치 


        public MyNode_Binary()
        {

        }

        public string ParentNodeValue()
        {
            if (this.parentnode == null)
            {
                return "-1";
            }
            else
            {
                return this.parentnode.nodevalue;
            }
        }

        public string SiblingValue()
        {
            if (this.parentnode == null)
            {
                return "-1";
            }


            if (nodelocation == "left")
            {
                if (this.parentnode.right == null)
                {
                    return "-1";
                }

                return this.parentnode.right.nodevalue;
            }
            else if (nodelocation == "right")
            { 
                if (this.parentnode.left == null)
                {
                    return "-1";
                }

                return this.parentnode.left.nodevalue;
            }

            return "-1";
        }

        public string DegreeValue()
        {
            if (this.right != null && this.left != null)
            {
                return "2";
            }
            else if (this.right == null && this.left == null)
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }

        //재귀반복으로 변경
        public string DepthValue()
        {
            int node_depth = 0;

            node_depth = DepthFunc(this);

            return node_depth.ToString();
        }

        private int DepthFunc(MyNode_Binary node)
        {
            int depth = 0;

            if (node.parentnode != null)
            {
                depth = DepthFunc(node.parentnode);

                depth++;
            }

            return depth;
        }

        //재귀반복으로 변경
        public string HeightValue()
        {
            int node_height = 0;

            node_height = HeightFunc(this);

            return node_height.ToString();

        }

        private int HeightFunc(MyNode_Binary node)
        {
            int left_height = 0;
            int right_height = 0;

            if (node.left != null)
            {
                left_height = HeightFunc(node.left);
                left_height++;
            }

            if (node.right != null)
            {
                right_height = HeightFunc(node.right);
                right_height++;
            }

            return left_height > right_height ? left_height : right_height;
        }

        public string NodeType()
        {
            if (this.parentnode == null)
            {
                return "root";
            }
            else if (this.left == null && this.right == null)
            {
                return "leaf";
            }
            else
            {
                return "internal node";
            }
        }

        public void AddparentNode(MyNode_Binary node)
        {
            this.parentnode = node;
        }

        public void AddchildNode(string node_location, MyNode_Binary childnode)
        {
            switch (node_location)
            {
                case "left":
                    childnode.nodelocation = "left";
                    left = childnode;
                    break;
                case "right":
                    childnode.nodelocation = "right";
                    right = childnode;
                    break;
            }
        }

        private void NodeVisit(string location, MyNode_Binary _node)
        {

            switch (location)
            {
                case nameof(Preorder):
                    if (_node != null)
                    {
                        if (_node.parentnode != null)
                        {
                            Console.Write($" {_node.nodevalue}");
                        }
                    }
                    else
                    {
                        return;
                    }
                    NodeVisit(location, _node.left);
                    NodeVisit(location, _node.right);
                    break;
                case nameof(Inorder):
                    if (_node != null)
                    {
                        NodeVisit(location, _node.left);
                        Console.Write($" {_node.nodevalue}");
                        //Console.WriteLine(_node.parentnode.nodevalue);
                        NodeVisit(location, _node.right);
                    }
                    else
                    {
                        return;
                    }
                    break;
                case nameof(Postorder):
                    if (_node != null)
                    {
                        NodeVisit(location, _node.left);
                        NodeVisit(location, _node.right);
                        Console.Write($" {_node.nodevalue}");
                    }
                    else
                    {
                        return;
                    }
                    break;
            }
        }
        //전위순위
        public void Preorder()
        {
            if (this.parentnode == null) // root 노드
            {
                Console.WriteLine(nameof(Preorder));
                Console.Write($" {this.nodevalue}");
                NodeVisit("Preorder", this.left);
                NodeVisit("Preorder", this.right);
                Console.WriteLine();
            }
        }

        //중위순위
        public void Inorder()
        {
            if (this.parentnode == null) // root 노드
            {
                Console.WriteLine(nameof(Inorder));
                NodeVisit("Inorder", this.left);
                Console.Write($" {this.nodevalue}");
                NodeVisit("Inorder", this.right);
                Console.WriteLine();
            }
        }


        //후위순위
        public void Postorder()
        {
            if (this.parentnode == null)
            {
                Console.WriteLine(nameof(Postorder));
                NodeVisit("Postorder", this.left);
                NodeVisit("Postorder", this.right);
                Console.Write($" {this.nodevalue}");
                Console.WriteLine();

            }
        }
    }
    #endregion
}
