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

            MyNode_Binary[] mynodes = new MyNode_Binary[node_cnt];

            Process_Step(node_cnt,mynodes);

            OutputData_Step(mynodes);
        }

        static int InputData_Step()
        {
            string node_cnt = Console.ReadLine();

            return int.Parse(node_cnt);
        }

        static void Process_Step(int node_cnt, MyNode_Binary[] mynodes)
        {
            for(int i = 0; i < node_cnt; i++)
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

                for(int j = 1; j < node_info.Length; j++)
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
                        else if(j == 2) //right
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
            
        }
    }

    public class MyNode_Binary 
    {
        MyNode_Binary parentnode;
        MyNode_Binary left;
        MyNode_Binary right;
        private string nodelocation { get; set; }
        public string nodevalue { get; set; }


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
    }
 
}