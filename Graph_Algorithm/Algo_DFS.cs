using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithm
{
    class Algo_DFS : IAlgorithm
    {
        private bool[] used = new bool[100];

        private int[] way = new int[100];
        private int cnt = 0;

        private Graph graph;

        public void Run(Graph graph)
        {
            this.graph = graph;
            used[0] = true;
            dfs(0);
            for (int i = 0; i < graph.size_vertex(); i++)
            {
                if (used[i] == false)
                {
                    dfs(i);
                }
            }
        }

        private void dfs(int v)
        {
            used[v] = true;
            way[cnt++] = v;
            for (int i = 0; i < graph.size_vertex(); i++)
            {
                if (v != i && (graph.is_edge(v, i) && used[i] == false))
                {
                    dfs(i);
                }
            }
        }

        public void SetDrawArea(Edge[] edge)
        {
            for(int i = 0; i < cnt - 1; i++)
            {
                if (graph.is_edge(way[i], way[i + 1]))
                {
                    edge[i].v1.x = graph.vertex[way[i]].x;
                    edge[i].v1.y = graph.vertex[way[i]].y;

                    edge[i].v2.x = graph.vertex[way[i + 1]].x;
                    edge[i].v2.y = graph.vertex[way[i + 1]].y;
                }
                else
                {
                    for(int j = i - 1; j >= 0; j--)
                    {
                        if (graph.is_edge(way[i+1], way[j]))
                        {
                            edge[i].v2.x = graph.vertex[way[i+1]].x;
                            edge[i].v2.y = graph.vertex[way[i+1]].y;

                            edge[i].v1.x = graph.vertex[way[j]].x;
                            edge[i].v1.y = graph.vertex[way[j]].y;
                        }
                    }
                }

            }

            edge[99].v1.y = cnt - 1;

        }

    }
}
