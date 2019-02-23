using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithm
{
    class Algo_Kruskal : IAlgorithm
    {
        private Graph graph;

        private int[] way = new int[100];
        private int cnt = 0;
        private bool[,] used = new bool[100, 100];


        public void Run(Graph graph)
        {
            this.graph = graph;
            for(int k=0;k< graph.size_vertex(); k++)
            {
                int min_edge = 999, v1=0 , v2=0;
                for (int i = 0; i < graph.size_vertex(); i++)
                {
                    for (int j = 0; j < graph.size_vertex(); j++)
                    {
                        if (i != j && graph.get_value(i,j) > 0 && graph.get_value(i, j) < min_edge && used[i,j] == false)
                        {
                            min_edge = graph.get_value(i, j);
                            v1 = i;
                            v2 = j;
                        }
                    }
                }
                if (min_edge != 999)
                {
                    used[v1, v2] = true;
                    used[v2, v1] = true;
                    way[cnt++] = v1;
                    way[cnt++] = v2;
                }
                
            }
        }


        public void SetDrawArea(Edge[] edge)
        {
            int pos = 0;
            for (int i = 0; i < cnt - 1; i += 2)
            {
                edge[pos].v1.x = graph.vertex[way[i]].x;
                edge[pos].v1.y = graph.vertex[way[i]].y;

                edge[pos].v2.x = graph.vertex[way[i + 1]].x;
                edge[pos].v2.y = graph.vertex[way[i + 1]].y;
                pos++;
            }
        }

    }
}
