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

            if (Points.Count() == 5)
            {
                label1.Text = "X = " + Points[0].X + "; Y = " + Points[0].Y;
                CreatePoligon();
            }
            else
                Points.Add(p);
        }

        private void CreatePoligon()
        {
            Graphics gObject = this.CreateGraphics();
            Pen pen = new Pen(Color.Black, 1);
            if (Points.Count() == 5)
                gObject.DrawLine(pen, Points[0], Points[1]);
            gObject.Dispose();
        }
    }
}
