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
        private Form1 form;

        public void Run(Graph graph)
        {
            this.graph = graph;
            used[0] = true;
            dfs(0);
            for (int i = 0; i < graph.size(); i++)
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
            for (int i = 0; i < graph.size(); i++)
            {
                if (v != i && (graph.is_edge(v, i) && used[i] == false))
                {
                    dfs(i);
                }
            }
        }

        public void SetDrawArea(Form1 form)
        {
        }

    }
}
