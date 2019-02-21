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
        private const int H_RADIUS = 20;

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

            point[0] = new Vector2();
            point[0].x = 50;
            point[0].y = 70;

            point[1] = new Vector2();
            point[1].x = 70;
            point[1].y = 300;

            point[2] = new Vector2();
            point[2].x = 150;
            point[2].y = 20;

            point[3] = new Vector2();
            point[3].x = 230;
            point[3].y = 200;

            point[4] = new Vector2();
            point[4].x = 250;
            point[4].y = 100;


            Circle c = new Circle(gr);
            for (int i = 0; i < 5; i++)
            {
                c.DrawCircle(point[i].x, point[i].y);
            }

            Line l = new Line(gr);

            l.DrawLine(150 + H_RADIUS, 20 + H_RADIUS, 50 + H_RADIUS, 70 + H_RADIUS);
            l.DrawLine(150 + H_RADIUS, 20 + H_RADIUS, 250 + H_RADIUS, 100 + H_RADIUS);
            l.DrawLine(250 + H_RADIUS, 100 + H_RADIUS, 230 + H_RADIUS, 200 + H_RADIUS);
            l.DrawLine(230 + H_RADIUS, 200 + H_RADIUS, 70 + H_RADIUS, 300 + H_RADIUS);


        }
    }
}
