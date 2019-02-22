using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            Vector2[] point = new Vector2[100];

            point[1] = new Vector2();
            point[1].x = 50;
            point[1].y = 70;

            point[3] = new Vector2();
            point[3].x = 70;
            point[3].y = 300;

            point[0] = new Vector2();
            point[0].x = 150;
            point[0].y = 20;

            point[2] = new Vector2();
            point[2].x = 230;
            point[2].y = 200;

            point[4] = new Vector2();
            point[4].x = 250;
            point[4].y = 100;

            point[5] = new Vector2();
            point[5].x = 70;
            point[5].y = 150;

            point[6] = new Vector2();
            point[6].x = 300;
            point[6].y = 300;

            point[7] = new Vector2();
            point[7].x = 200;
            point[7].y = 400;


            int n = 8;
            int[,] arr = new int[n, n];
            arr[0, 1] = 1;
            arr[0, 4] = 1;
            arr[1, 0] = 1;
            arr[2, 4] = 1;
            arr[2, 3] = 1;
            arr[3, 2] = 1;
            arr[4, 2] = 1;
            arr[4, 0] = 1;
            arr[5, 1] = 1;
            arr[1, 5] = 1;
            arr[6, 2] = 1;
            arr[2, 6] = 1;
            arr[6, 7] = 1;
            arr[7, 6] = 1;
            arr[7, 3] = 1;
            arr[3, 7] = 1;

            Graph graph = new Graph(arr, n, point);

            Circle c = new Circle(gr);

            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));

            for (int i = 0; i < 8; i++)
            {
                c.DrawCircle(point[i].x, point[i].y, solidBrush);
            }

            Line l = new Line(gr);

            Pen black = new Pen(Color.Black);
            l.DrawLine(150 + H_RADIUS, 20 + H_RADIUS, 50 + H_RADIUS, 70 + H_RADIUS, black);
            l.DrawLine(150 + H_RADIUS, 20 + H_RADIUS, 250 + H_RADIUS, 100 + H_RADIUS, black);
            l.DrawLine(250 + H_RADIUS, 100 + H_RADIUS, 230 + H_RADIUS, 200 + H_RADIUS, black);
            l.DrawLine(230 + H_RADIUS, 200 + H_RADIUS, 70 + H_RADIUS, 300 + H_RADIUS, black);

            l.DrawLine(50 + H_RADIUS, 70 + H_RADIUS, 70 + H_RADIUS, 150 + H_RADIUS, black);
            l.DrawLine(230 + H_RADIUS, 200 + H_RADIUS, 300 + H_RADIUS, 300 + H_RADIUS, black);
            l.DrawLine(300 + H_RADIUS, 300 + H_RADIUS, 200 + H_RADIUS, 400 + H_RADIUS, black);
            l.DrawLine(200 + H_RADIUS, 400 + H_RADIUS, 70 + H_RADIUS, 300 + H_RADIUS, black);

            
            IAlgorithm myAlgo = new Algo_BFS();
            myAlgo.Run(graph);

            Edge[] edge = new Edge[100];
            for(int i = 0; i < 100; i++)
            {
                edge[i] = new Edge();
            }

            myAlgo.SetDrawArea(edge);


            SolidBrush solid = new SolidBrush(Color.FromArgb(255, 255, 0, 0));

            for (int i = 0; i < n-1; i++)
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
            
        }
    }
}
