using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithm
{
    class Algo_Floyd : IAlgorithm
    {
        private Graph graph;
        private int INF = 1000;
        private int[] way = new int[100];
        private int cnt = 0;

        private int[,] path = new int[100, 100];


        public void Run(Graph graph)
        {
            this.graph = graph;
            int[,] d = new int[100, 100];
            int n = graph.size_vertex();
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        path[i, j] = i;
                    }
                    if (graph.get_value(i, j) == 0)
                    {
                        d[i,j]=INF;
                        path[i, j] = 100;
                    }
                    else
                    {
                        d[i, j] = graph.get_value(i, j);
                        path[i,j] = j;
                    }
                }
                d[i, i] = 0;
            }


            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if(d[i, k] + d[k, j] < d[i, j])
                        {
                            d[i, j] = d[i, k] + d[k, j];
                            path[i,j] = path[i,k];
                        }
                    }    
                }    
            }
        }

        public void SetDrawArea(Edge[] edge)
        {
            int sum = 0;
            int x = 0;
            way[cnt++] = x;
            while (x != 7)
            {
                x = path[x,7];
                way[cnt++] = x;
            }

            for (int i = 0; i < cnt - 1; i ++)
            {
                edge[i].v1.x = graph.vertex[way[i]].x;
                edge[i].v1.y = graph.vertex[way[i]].y;

                edge[i].v2.x = graph.vertex[way[i + 1]].x;
                edge[i].v2.y = graph.vertex[way[i + 1]].y;
                sum += graph.get_value(way[i], way[i + 1]);
            }
            edge[99].v1.x = sum;
            edge[99].v1.y = cnt-1;
        }

    }
}
