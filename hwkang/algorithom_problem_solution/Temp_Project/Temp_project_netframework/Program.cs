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