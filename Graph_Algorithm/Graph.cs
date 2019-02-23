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
        private int count_edge = 0;

        public Graph(int[,] p_arr, int p_n, Vector2[] point)
        {
            n = p_n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = p_arr[i, j];
                    if (arr[i, j] > 0)
                    {
                        count_edge++;
                    }
                }

                vertex[i] = new Vector2();
                vertex[i].x = point[i].x;
                vertex[i].y = point[i].y;

            }
            count_edge /= 2;
        }

        public int size_vertex()
        {
            return n;
        }

        public int size_edge()
        {
            return count_edge;
        }


        public int get_value(int a, int b)
        {
            return arr[a, b];
        }

        public bool is_edge(int a, int b)
        {
            if (arr[a, b] >=1 || arr[b,a] >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
