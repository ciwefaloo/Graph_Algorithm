using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Algorithm
{
    class Circle
    {
        private Graphics gr;

        public Circle(Graphics gr)
        {
            this.gr = gr;
        }

        public void DrawCircle(int x, int y)
        {
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
            gr.FillEllipse(solidBrush, x, y, 40, 40);
        }
    }
}
