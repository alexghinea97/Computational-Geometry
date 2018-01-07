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
        Point MyPoint = new Point();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);

            switch (Points.Count())
            {
                case 4:
                    Points.Add(p);
                    CreatePoligon();
                    break;
                case 5:
                    label1.Text = "My point is X = " + Points[0].X + "; Y = " + Points[0].Y;
                    MyPoint = p;
                    break;
                default:
                    Points.Add(p);
                    break;
            }
        }

        private void CreatePoligon()
        {
            Graphics gObject = this.CreateGraphics();
            Pen pen = new Pen(Color.Black, 1);
            if (Points.Count() == 5)
            {
                gObject.DrawLine(pen, Points[0], Points[1]);
                gObject.DrawLine(pen, Points[1], Points[2]);
                gObject.DrawLine(pen, Points[2], Points[3]);
                gObject.DrawLine(pen, Points[3], Points[4]);
                gObject.DrawLine(pen, Points[4], Points[0]);
            }
            gObject.Dispose();
        }
    }
}
