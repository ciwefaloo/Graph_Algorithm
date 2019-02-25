﻿using System;
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
            arr[0, 1] = 5;
            arr[0, 4] = 9;
            arr[1, 0] = 5;
            arr[2, 4] = 10;
            arr[2, 3] = 15;
            arr[3, 2] = 15;
            arr[4, 2] = 10;
            arr[4, 0] = 9;
            arr[5, 1] = 7;
            arr[1, 5] = 7;
            arr[6, 2] = 30;
            arr[2, 6] = 30;
            arr[6, 7] = 5;
            arr[7, 6] = 5;
            arr[7, 3] = 19;
            arr[3, 7] = 19;

            Graph graph = new Graph(arr, n, point);

            Circle c = new Circle(gr);

            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));

            for (int i = 0; i < 8; i++)
            {
                c.DrawCircle(point[i].x, point[i].y, solidBrush,i);
            }

            Line l = new Line(gr);

            Pen black = new Pen(Color.Black);
            l.DrawLine(point[0].x + H_RADIUS, point[0].y + H_RADIUS, point[1].x + H_RADIUS, point[1].y + H_RADIUS, black, arr[0, 1]);
            l.DrawLine(point[0].x + H_RADIUS, point[0].y + H_RADIUS, point[4].x + H_RADIUS, point[4].y + H_RADIUS, black, arr[0, 4]);
            l.DrawLine(point[4].x + H_RADIUS, point[4].y + H_RADIUS, point[2].x + H_RADIUS, point[2].y + H_RADIUS, black, arr[4, 2]);
            l.DrawLine(point[2].x + H_RADIUS, point[2].y + H_RADIUS, point[3].x + H_RADIUS, point[3].y + H_RADIUS, black, arr[2, 3]);

            l.DrawLine(point[1].x + H_RADIUS, point[1].y + H_RADIUS, point[5].x + H_RADIUS, point[5].y + H_RADIUS, black, arr[1, 5]);
            l.DrawLine(point[2].x + H_RADIUS, point[2].y + H_RADIUS, point[6].x + H_RADIUS, point[6].y + H_RADIUS, black, arr[2, 6]);
            l.DrawLine(point[6].x + H_RADIUS, point[6].y + H_RADIUS, point[7].x + H_RADIUS, point[7].y + H_RADIUS, black, arr[6, 7]);
            l.DrawLine(point[7].x + H_RADIUS, point[7].y + H_RADIUS, point[3].x + H_RADIUS, point[3].y + H_RADIUS, black, arr[7, 3]);


            //IAlgorithm myAlgo = new Algo_DFS();
            //IAlgorithm myAlgo = new Algo_BFS();
            //IAlgorithm myAlgo = new Algo_Kruskal();
            //IAlgorithm myAlgo = new Algo_Floyd();
            //IAlgorithm myAlgo = new Algo_Bellman();
            IAlgorithm myAlgo = new Algo_Prima();


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

            for (int i = 0; i < cnt_edge; i++)
            {
                s += edge[i].v1.x;
                s = s + " " + edge[i].v1.y + "    " + edge[i].v2.x + " " + edge[i].v1.y + '\n';
            }
            
            MessageBox.Show(s);
            

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
        }
    }
}
