using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithm
{
    class Line
    {
        private Graphics gr;

        public Line(Graphics gr)
        {
            this.gr = gr;
        }

        public void DrawLine(int x1, int y1, int x2, int y2, Pen pen)
        {
            //Pen pen = new Pen(Color.Black);
            gr.DrawLine(pen, x1, y1, x2, y2);
        }

    }
}
