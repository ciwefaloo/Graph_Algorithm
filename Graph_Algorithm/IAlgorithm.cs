using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph_Algorithm
{
    interface IAlgorithm
    {
        void Run(Graph graph);

        void SetDrawArea(Form1 form);


    }
}
