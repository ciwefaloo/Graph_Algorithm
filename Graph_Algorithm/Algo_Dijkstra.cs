using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithm
{
    class Algo_Dijkstra : IAlgorithm
    {

        private Graph graph;
        private const int INF = 1000000000;
        private bool[] used = new bool[100];
        private int[] prev = new int[100];
        private int[] way = new int[100];
        private int cnt = 0;
        private int[] d = new int[100];


        public void Run(Graph graph)
        {
            this.graph = graph;
            int n = graph.size_vertex();
            for(int i = 0; i < n; i++)
            {
                d[i] = INF;
            }
            d[0] = 0;
            for(int i = 0; i < n; i++)
            {
                int v = -1;
                for(int j = 0; j < n; j++)
                {
                    if (used[j] == false && (v==-1 || d[j] < d[v]))
                    {
                        v = j;
                    }
                }
                used[v] = true;
                for(int j = 0; j < n; j++)
                {
                    if(graph.is_edge(v,j) && d[j] > d[v] + graph.get_value(v, j))
                    {
                        d[j] = d[v] + graph.get_value(v, j);
                        prev[j] = v;
                    }
                }
            }

            int x = 7;
            way[cnt++] = x;
            while (x != 0)
            {
                x = prev[x];
                way[cnt++] = x;
            }
            for (int i = 0; i < cnt / 2; i++)
            {
                int temp = way[i];
                way[i] = way[cnt - 1 - i];
                way[cnt - 1 - i] = temp;
            }

        }

        public void SetDrawArea(Edge[] edge)
        {
            int sum = 0;
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
