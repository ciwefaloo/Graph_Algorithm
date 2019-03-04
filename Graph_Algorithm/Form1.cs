using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Graph_Algorithm
{
    public partial class Form1 : Form
    {
        public const int H_RADIUS = 20;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            StreamReader sr_pos = new StreamReader(@"E:\sol\Graph_Algorithm\Graph_Algorithm\position.txt");
            StreamReader sr_graph = new StreamReader(@"E:\sol\Graph_Algorithm\Graph_Algorithm\graph.txt");

            Vector2[] point = new Vector2[100];


            Circle c = new Circle(gr);
            Line l = new Line(gr);

            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
            Pen black = new Pen(Color.Black);


            int n = 0, num_str= 0; ;
            string temp= sr_pos.ReadLine();
            int pos = 0;
            while (pos != temp.Length)
            {
                n = n * 10 + (temp[pos] - '0');
                pos++;
            }

            while (num_str!=n)
            {
                int x = 0, y = 0;
                pos = 0;
                temp = "";
                temp = sr_pos.ReadLine();              
                while (temp[pos]!=' ')
                {
                    x = x * 10 + (temp[pos] - '0');
                    pos++;
                }
                pos++;
                while (pos != temp.Length)
                {
                    y = y * 10 + (temp[pos] - '0');
                    pos++;
                }
                point[num_str] = new Vector2();
                point[num_str].x = x;
                point[num_str].y = y;
                c.DrawCircle(point[num_str].x, point[num_str].y, solidBrush, num_str);
                num_str++;
            }
            
            

            int[,] arr = new int[n, n];
            temp = sr_graph.ReadLine();
            num_str = 0;
            int num_edge = 0;
            pos = 0;
            while (pos != temp.Length)
            {
                num_edge = num_edge * 10 + (temp[pos] - '0');
                pos++;
            }


            while (num_str!= num_edge)
            {
                temp = "";
                temp = sr_graph.ReadLine();
                int a = 0, b = 0, w = 0;
                pos = 0;
                while(temp[pos]!=' ')
                {
                    a = a * 10 + (temp[pos]-'0');
                    pos++;
                }
                pos++;
                while (temp[pos] != ' ')
                {
                    b = b * 10 + (temp[pos]-'0');
                    pos++;
                }
                pos++;
                while (pos!=temp.Length)
                {
                    w = w * 10 + (temp[pos]-'0');
                    pos++;
                }
                arr[a, b] = w;
                arr[b, a] = w;
                num_str++;

                l.DrawLine(point[a].x + H_RADIUS, point[a].y + H_RADIUS, point[b].x + H_RADIUS, point[b].y + H_RADIUS, black, arr[a, b]);

            }
            
            Graph graph = new Graph(arr, n, point);

            IAlgorithm myAlgo = new Algo_DFS();
            //IAlgorithm myAlgo = new Algo_BFS();
            //IAlgorithm myAlgo = new Algo_Kruskal();
           //IAlgorithm myAlgo = new Algo_Floyd();
            //IAlgorithm myAlgo = new Algo_Bellman();
            //IAlgorithm myAlgo = new Algo_Prima();
            //IAlgorithm myAlgo = new Algo_Dijkstra();
            //IAlgorithm myAlgo = new Algo_Johnson();
            //IAlgorithm myAlgo = new Algo_Falkerson();


            myAlgo.Run(graph);

            Edge[] edge = new Edge[100];
            for(int i = 0; i < 100; i++)
            {
                edge[i] = new Edge();
            }

            myAlgo.SetDrawArea(edge);


            SolidBrush solid = new SolidBrush(Color.FromArgb(255, 255, 0, 0));

            string s = "";

            int cnt_edge = edge[99].v1.y;


            if (edge[98].str!="")
            {
                s = edge[98].str;
                s += "flow : " + edge[99].v1.x.ToString();
                MessageBox.Show(s);
                return;
            }

            int q = 0;
            
            for (int i = 0; i < cnt_edge; i++)
            {
                int v1_x = edge[i].v1.x;
                int v1_y = edge[i].v1.y;

                int v2_x = edge[i].v2.x;
                int v2_y = edge[i].v2.y;

                c.DrawCircle(v1_x, v1_y, solid);

                System.Threading.Thread.Sleep(500);

                l.DrawLine(v1_x + H_RADIUS, v1_y + H_RADIUS, v2_x + H_RADIUS, v2_y + H_RADIUS, new Pen(Color.Red));

                System.Threading.Thread.Sleep(500);

                c.DrawCircle(v2_x, v2_y, solid);

                System.Threading.Thread.Sleep(250);

            }
            if (edge[99].v1.x != 0)
            {
                q = edge[99].v1.x;
                string mn = "";
                mn += q;
                MessageBox.Show("the shortest way: " + mn);
            }
            
            sr_graph.Close();
            sr_pos.Close();
        }
    }
}
