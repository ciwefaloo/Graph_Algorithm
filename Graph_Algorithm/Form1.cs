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

            int n = 5;
            int[,] arr = new int[n, n];
            arr[0, 1] = 1;
            arr[0, 4] = 1;
            arr[1, 0] = 1;
            arr[2, 4] = 1;
            arr[2, 3] = 1;
            arr[3, 2] = 1;
            arr[4, 2] = 1;
            arr[4, 0] = 1;

            Graph graph = new Graph(arr, n, point);


            Circle c = new Circle(gr);
            for (int i = 0; i < 5; i++)
            {
                c.DrawCircle(point[i].x, point[i].y);
            }

            Line l = new Line(gr);

            Pen black = new Pen(Color.Black);
            l.DrawLine(150 + H_RADIUS, 20 + H_RADIUS, 50 + H_RADIUS, 70 + H_RADIUS, black);
            l.DrawLine(150 + H_RADIUS, 20 + H_RADIUS, 250 + H_RADIUS, 100 + H_RADIUS, black);
            l.DrawLine(250 + H_RADIUS, 100 + H_RADIUS, 230 + H_RADIUS, 200 + H_RADIUS, black);
            l.DrawLine(230 + H_RADIUS, 200 + H_RADIUS, 70 + H_RADIUS, 300 + H_RADIUS, black);


            IAlgorithm myAlgo = new Algo_DFS();
            myAlgo.Run(graph);
        }
    }
}
