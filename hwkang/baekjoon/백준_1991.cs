using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Temp_project_netframework
{
    public class Program
    {
        /*
이진 트리를 입력받아 전위 순회(preorder traversal), 중위 순회(inorder traversal), 후위 순회(postorder traversal)한 결과를 출력하는 프로그램을 작성하시오.



예를 들어 위와 같은 이진 트리가 입력되면,

전위 순회한 결과 : ABDCEFG // (루트) (왼쪽 자식) (오른쪽 자식)
중위 순회한 결과 : DBAECFG // (왼쪽 자식) (루트) (오른쪽 자식)
후위 순회한 결과 : DBEGFCA // (왼쪽 자식) (오른쪽 자식) (루트)
         */

        static void Main(string[] args)
        {
            int node_cnt = InputData_Step();

            //MyNode_Binary[] mynodes = new MyNode_Binary[node_cnt];

            List<MyNode_Binary> mynode_list = new List<MyNode_Binary>();

            Process_Step(node_cnt, mynode_list);

            OutputData_Step(mynode_list);
        }

        static int InputData_Step()
        {
            string node_cnt = Console.ReadLine();

            return int.Parse(node_cnt);
        }

        static void Process_Step(int node_cnt, List<MyNode_Binary> myNodes)
        {
            for (int i = 0; i < node_cnt; i++)
            {
                string[] node_info = Console.ReadLine().Replace(" ", ",").Split(',');

                string nodevalue = node_info[0];
                string nodevalue_number = string.Empty;

                nodevalue_number = stringtobytenumber(nodevalue);

                MyNode_Binary mynode = null;

                if (myNodes.Where(x => x.nodevalue == nodevalue_number).ToList().Count > 0){

                    mynode = myNodes.Where(x => x.nodevalue == nodevalue_number).First();

                }
                else
                {
                    mynode = new MyNode_Binary();
                    mynode.NodeValueSet(nodevalue_number,MyNode_Binary.Types.bytesvalue);
                    myNodes.Add(mynode);
                }
               
                for(int j = 1; j < node_info.Length; j++)
                {
                    if (node_info[j] == ".")
                    {
                        continue;
                    }

                    if (j == 1) //left
                    {
                        nodevalue = node_info[j];

                        nodevalue_number= stringtobytenumber(nodevalue);

                        MyNode_Binary left = new MyNode_Binary();
                        left.NodeValueSet(nodevalue_number, MyNode_Binary.Types.bytesvalue);

                        if (myNodes.Where(x => x.nodevalue == nodevalue_number).ToList().Count > 0)
                        {

                        }
                        else
                        {
                            myNodes.Add(left);
                        }

                        mynode.AddchildNode(nameof(left), left);
                        left.AddparentNode(mynode);

                    }

                    if (j == 2) //right
                    {
                        nodevalue = node_info[j];

                        nodevalue_number = stringtobytenumber(nodevalue);

                        MyNode_Binary right = new MyNode_Binary();
                        right.NodeValueSet(nodevalue_number, MyNode_Binary.Types.bytesvalue);

                        if (myNodes.Where(x => x.nodevalue == nodevalue_number).ToList().Count > 0)
                        {

                        }
                        else
                        {
                            myNodes.Add(right);
                        }

                        mynode.AddchildNode(nameof(right), right);
                        right.AddparentNode(mynode);
                    }
                }
            }

            string stringtobytenumber(string value)
            {
                var stringtobytes = Encoding.UTF8.GetBytes(value);

                string result_number = string.Empty;

                if (stringtobytes.Length < 2)
                {
                    result_number = stringtobytes[0].ToString();
                }
                else
                {
                    result_number = BitConverter.ToInt32(stringtobytes, 0).ToString();
                }

                return result_number;
            }
                
        }

        static void OutputData_Step(List<MyNode_Binary> mynodes)
        {
            foreach (var node in mynodes)
            {
                node.NEWPreorder();
                node.NEWInorder();
                node.NEWPostorder();
            }

        }
    }

    


    public class MyNode_Binary 
    {
        public enum Types
        {
            intvalue    = 1,
            doublevalue = 2,
            stringvalue = 4,
            bytesvalue  = 8,
        }

        MyNode_Binary parentnode;
        MyNode_Binary left;
        MyNode_Binary right;
        private string nodelocation { get; set; }
        public Types nodevalueType { get; set; }

        public string nodevalue
        {
            get;set;
        }


        public MyNode_Binary()
        {
            
        }

        public void NodeValueSet(string value,Types type)
        {
            nodevalue = value;
            nodevalueType = type;
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
            if(this.parentnode == null)
            {
                return "-1";
            }


            if (nodelocation == "left")
            {
                if(this.parentnode.right == null)
                {
                    return "-1";
                }

                return this.parentnode.right.nodevalue;
            }
            else if(nodelocation=="right") 
            { //right
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
            if(this.right != null && this.left != null)
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
            else if(this.left == null && this.right == null)
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

        public void AddchildNode(string node_location,MyNode_Binary childnode)
        {
            switch (node_location.ToLower())
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


        private void NodeVisit(string location,MyNode_Binary _node)
        {

            switch (location)
            {
                case nameof(Preorder):
                    if (_node != null)
                    {
                        if (_node.parentnode != null)
                        {
                            Console.Write($" {_node.ConvertNodeValue()}"); //Console.Write($" {this.nodevalue}");
                        }
                    }
                    else
                    {
                        return;
                    }
                    NodeVisit(location,_node.left);
                    NodeVisit(location,_node.right);
                    break;
                case nameof(Inorder):
                    if (_node != null)
                    {
                        NodeVisit(location, _node.left);
                        Console.Write($" {_node.ConvertNodeValue()}"); //Console.Write($" {this.nodevalue}");
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
                        Console.Write($" {_node.ConvertNodeValue()}"); //Console.Write($" {this.nodevalue}");
                    }
                    else
                    {
                        return;
                    }
                    break;
            }
        }

        private void NEWNodeVisit(string location, MyNode_Binary _node)
        {

            switch (location)
            {
                case nameof(Preorder):
                    if (_node != null)
                    {
                        if (_node.parentnode != null)
                        {
                            Console.Write($"{_node.ConvertNodeValue()}"); //Console.Write($" {this.nodevalue}");
                        }
                    }
                    else
                    {
                        return;
                    }
                    NEWNodeVisit(location, _node.left);
                    NEWNodeVisit(location, _node.right);
                    break;
                case nameof(Inorder):
                    if (_node != null)
                    {
                        NEWNodeVisit(location, _node.left);
                        Console.Write($"{_node.ConvertNodeValue()}"); //Console.Write($" {this.nodevalue}");
                        NEWNodeVisit(location, _node.right);
                    }
                    else
                    {
                        return;
                    }
                    break;
                case nameof(Postorder):
                    if (_node != null)
                    {
                        NEWNodeVisit(location, _node.left);
                        NEWNodeVisit(location, _node.right);
                        Console.Write($"{_node.ConvertNodeValue()}"); //Console.Write($" {this.nodevalue}");
                    }
                    else
                    {
                        return;
                    }
                    break;
            }
        }

        public string ConvertNodeValue()
        {
            if (this.nodevalueType == Types.bytesvalue)
            {
                byte[] bytevalues = { byte.Parse(this.nodevalue) };

                return Encoding.UTF8.GetString(bytevalues);
            }
            else
            {
                return this.nodevalue;
            }
        }

        //전위순위
        public void Preorder()
        {
            if (this.parentnode == null) // root 노드
            {
                Console.WriteLine(nameof(Preorder));
                Console.Write($" {ConvertNodeValue()}"); //Console.Write($" {this.nodevalue}");
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
                Console.Write($" {ConvertNodeValue()}"); //Console.Write($" {this.nodevalue}");
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
                Console.Write($" {ConvertNodeValue()}"); //Console.Write($" {this.nodevalue}");
                Console.WriteLine();

            }
        }

        //전위순위
        public void NEWPreorder()
        {
            if (this.parentnode == null) // root 노드
            {
                Console.Write($"{ConvertNodeValue()}"); //Console.Write($" {this.nodevalue}");
                NEWNodeVisit("Preorder", this.left);
                NEWNodeVisit("Preorder", this.right);
                Console.WriteLine();
            }
        }

        //중위순위
        public void NEWInorder()
        {
            if (this.parentnode == null) // root 노드
            {
                NEWNodeVisit("Inorder", this.left);
                Console.Write($"{ConvertNodeValue()}"); //Console.Write($" {this.nodevalue}");
                NEWNodeVisit("Inorder", this.right);
                Console.WriteLine();
            }
        }

        //후위순위
        public void NEWPostorder()
        {
            if (this.parentnode == null)
            {
                NEWNodeVisit("Postorder", this.left);
                NEWNodeVisit("Postorder", this.right);
                Console.Write($"{ConvertNodeValue()}"); //Console.Write($" {this.nodevalue}");
                Console.WriteLine();

            }
        }
    }
 
}