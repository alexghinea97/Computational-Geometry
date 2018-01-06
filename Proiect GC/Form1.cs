using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_GC
{
    public partial class Form1 : Form
    {
        List<Point> Points = new List<Point>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            Points.Add(p);

            label1.Text = "X = " + Points[0].X + "; Y = " + Points[0].Y;
        }
    }
}
