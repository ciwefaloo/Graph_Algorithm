using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithm
{
    class Graph
    {
        private int[,] arr = new int[100, 100];
        private int n;
        public Vector2[] vertex = new Vector2[100];

        public Graph(int[,] p_arr, int p_n, Vector2[] point)
        {
            n = p_n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = p_arr[i, j];
                }

                vertex[i] = new Vector2();
                vertex[i].x = point[i].x;
                vertex[i].y = point[i].y;

            }
        }

        public int size()
        {
            return n;
        }

        public bool is_edge(int a, int b)
        {
            if (arr[a, b] == 1 || arr[b,a] == 1)
            {
                return true;
            }
            return false;
        }
    }
}
