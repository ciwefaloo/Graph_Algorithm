using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithm
{
    class Algo_BFS : IAlgorithm
    {
        private Graph graph;
        private Queue queue = new Queue();
        private int[] way = new int[100];
        private bool[] used = new bool[100];
        private int cnt = 0;

        public void Run(Graph graph)
        {  

            this.graph = graph;
            queue.Enqueue(0);
            used[0] = true;
            way[cnt++] = 0;
            int n = graph.size();
            while (queue.Count != 0)
            {
                object obj = queue.Peek();
                queue.Dequeue();
                int v = Int32.Parse(obj.ToString());
                for(int i = 0; i < n; i++)
                {
                    if (i != v && used[i] == false && graph.is_edge(v, i))
                    {
                        queue.Enqueue(i);
                        used[i] = true;
                        way[cnt++] = i;
                    }
                }
            }
        }

        public void SetDrawArea(Edge[] edge)
        {
            for (int i = 0; i < cnt - 1; i++)
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
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (graph.is_edge(way[i + 1], way[j]))
                        {
                            edge[i].v2.x = graph.vertex[way[i + 1]].x;
                            edge[i].v2.y = graph.vertex[way[i + 1]].y;

                            edge[i].v1.x = graph.vertex[way[j]].x;
                            edge[i].v1.y = graph.vertex[way[j]].y;
                        }
                    }
                }

            }
        }
    }
}
