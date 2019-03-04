using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithm
{
    class Algo_Johnson : IAlgorithm
    {
        private Graph graph;
        private int[,] d = new int[100, 100];
        private const int INF = 1000000000;
        private bool[] used = new bool[100];
        private int[,] prev = new int[100, 100];
        private int[] way = new int[100];


        public void Run(Graph graph)
        {
            this.graph = graph;
            int n = graph.size_vertex();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    d[i, j] = INF;
                }
            }

            for (int k = 0; k < n; k++)
            {
                d[k, k] = 0;
                for (int i = 0; i < n; i++)
                {
                    used[i] = false;
                }

                for (int i = 0; i < n; i++)
                {
                    int v = -1;
                    for (int j = 0; j < n; j++)
                    {
                        if (used[j] == false && (v == -1 || d[k, j] < d[k, v]))
                        {
                            v = j;
                        }
                    }
                    used[v] = true;
                    for (int j = 0; j < n; j++)
                    {
                        if (graph.is_edge(v, j) && d[k, j] > d[k, v] + graph.get_value(v, j))
                        {
                            d[k, j] = d[k, v] + graph.get_value(v, j);
                            prev[k, j] = v;
                        }
                    }
                }
            }

        }


        public void SetDrawArea(Edge[] edge)
        {
            int sum = 0, cnt = 0;
            int x = 7;
            way[cnt++] = x;
            while (x != 0)
            {
                x = prev[0, x];
                way[cnt++] = x;
            }

            for (int i = 0; i < cnt / 2; i++)
            {
                int temp = way[i];
                way[i] = way[cnt - 1 - i];
                way[cnt - 1 - i] = temp;
            }


            for (int i = 0; i < cnt - 1; i++)
            {
                edge[i].v1.x = graph.vertex[way[i]].x;
                edge[i].v1.y = graph.vertex[way[i]].y;

                edge[i].v2.x = graph.vertex[way[i + 1]].x;
                edge[i].v2.y = graph.vertex[way[i + 1]].y;
                sum += graph.get_value(way[i], way[i + 1]);
            }
            edge[99].v1.x = sum;
            edge[99].v1.y = cnt - 1;

        }

    }
}
