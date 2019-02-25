using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithm
{
    class Algo_Bellman : IAlgorithm
    {

        private Graph graph;
        private int[] d = new int[100];
        
        private Vector2[] edge = new Vector2[100];
        private int[] way = new int[100];
        private int cnt = 0;
        private int[] path = new int[100];

        public void Run(Graph graph)
        {
            this.graph = graph;
            int n = graph.size_vertex();
            int temp = 0;
            int[] weight = new int[100];
            const int INF = 1000000000;

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(j>i && graph.is_edge(i, j))
                    {
                        edge[temp] = new Vector2();
                        edge[temp].x = i;
                        edge[temp].y = j;
                        weight[temp] = graph.get_value(i, j);
                        temp++;

                        edge[temp] = new Vector2();
                        edge[temp].x = j;
                        edge[temp].y = i;
                        weight[temp] = graph.get_value(i, j);
                        temp++;
                    }
                }
            }


            int m = graph.size_edge();
            for(int i = 0; i < n; i++)
            {
                d[i] = INF;
            }
            d[0] = 0;
            for(int i = 0; i < n-1; i++)
            {
                for(int j = 0; j < m * 2; j++)
                {
                    if(d[edge[j].y] > d[edge[j].x] + weight[j])
                    {
                        d[edge[j].y] = d[edge[j].x] + weight[j];
                        path[edge[j].y] = edge[j].x;
                    }
                }
            }

        }


        public void SetDrawArea(Edge[] edge)
        {
            int x = 7;
            int sum = 0;
            way[cnt++] = x;
            while (x != 0)
            {
                x = path[x];
                way[cnt++] = x;
            }
            for(int i = 0; i < cnt / 2; i++)
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
