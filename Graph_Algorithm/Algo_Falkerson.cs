using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithm
{
    class Algo_Falkerson : IAlgorithm
    {
        private Graph graph;
        private int finish=7;
        private bool[] used = new bool[100];
        private Vector2[,] arr = new Vector2[100, 100];
        private int n = 0;
        private int answer=0;

        public void Run(Graph graph)
        {
            this.graph = graph;
            n = graph.size_vertex();
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    arr[i, j] = new Vector2();
                    arr[i, j].x = 0;
                    arr[i, j].y = graph.get_value(i, j);

                    arr[j, i] = new Vector2();
                    arr[j, i].x = 0;
                    arr[j, i].y = graph.get_value(j, i);
                }
            }


            while (true)
            {
                int temp = dfs(0, 999, arr);
                answer += temp;
                for(int i = 0; i < n; i++)
                {
                    used[i] = false;
                }
                if (temp == 0) break;
            }
        }

        private int dfs(int u, int Cmin, Vector2[,] arr)
        {
            if (u == finish)
            {
                return Cmin;
            }
            used[u] = true;

            for(int v = 0; v < n; v++)
            {
                if (graph.is_edge(u, v))
                {
                    if(!used[v] && arr[u, v].x < arr[u, v].y)
                    {
                        int mn = Cmin;
                        if(arr[u, v].y - arr[u, v].x < Cmin)
                        {
                            mn = arr[u, v].y - arr[u, v].x;
                        }
                        int delta = dfs(v, mn, arr);

                        if (delta > 0)
                        {
                            arr[u, v].x += delta;
                            arr[v, u].x -= delta;
                            return delta;
                        }

                    }
                }
            }

            return 0;
        }

        public void SetDrawArea(Edge[] edge)
        {
             int max_flow = 0;
             for (int i = 0; i < n; i++)
             {
                 if (graph.is_edge(i, finish))
                 {
                     max_flow += arr[i, finish].x;
                 }
             }


            edge[0].v1.x = arr[0, 1].x;
            edge[1].v1.x = arr[0, 4].x;

            edge[2].v1.x = arr[1, 5].x;
            edge[3].v1.x = arr[4, 2].x;

            edge[4].v1.x = arr[2, 3].x;
            edge[5].v1.x = arr[2, 6].x;

            edge[6].v1.x = arr[3, 7].x;
            edge[7].v1.x = arr[6, 7].x;

            edge[8].v1.x = arr[0, 2].x;

            edge[99].v1.y = 9;

        }

    }
}
