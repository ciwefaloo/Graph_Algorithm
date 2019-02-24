using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithm
{
    class Algo_Prima : IAlgorithm
    {
        private Graph graph;
        private const int INF = 1000000000;
        private bool[] used = new bool[100];

        private int[] way = new int[100];
        private int cnt = 0;


        public void Run(Graph graph)
        {
            this.graph = graph;
            int[] min_e = new int[100];
            int[] prev_v = new int[100];
            for(int i = 0; i < graph.size_vertex(); i++)
            {
                min_e[i] = INF;
            }
            min_e[0] = 0;
            for (int i = 0; i < graph.size_vertex(); i++)
            {
                int v = -1;
                for (int j = 0; j < graph.size_vertex(); j++)
                {
                    if (used[j] != false && (v == -1 || min_e[j] < min_e[v]))
                    {
                        v = j;
                    }
                        
                }
                    
                used[v] = true;

                for (int to = 0; to < graph.size_vertex(); to++)
                {
                    if (graph.is_edge(v,to) &&  graph.get_value(v, to) < min_e[to])
                    {
                        min_e[to] = graph.get_value(v, to);
                        prev_v[to] = v;
                    }
                }                  
            }
            
        }

        public void SetDrawArea(Edge[] edge)
        {

        }
    }
}
