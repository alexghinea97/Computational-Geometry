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
                    VerifyWherePointIs();
                    break;
                default:
                    Points.Add(p);
                    break;
            }

            if (Points.Count() > 5)
                VerifyWherePointIs();
        }

        private void VerifyWherePointIs()
        {
            bool isOnSide = CheckIfItsOnSide();

            if (isOnSide)
                label1.Text = "Punctul se afla pe latura poligonului.";
        }

        private bool CheckIfItsOnSide()
        {
            for(int i=0;i<4;i++)
            {
                double d1 = Math.Sqrt(Math.Pow(Points[i].X - MyPoint.X, 2) + Math.Pow(Points[i].Y - MyPoint.Y, 2));
                double d2 = Math.Sqrt(Math.Pow(MyPoint.X - Points[i+1].X, 2) + Math.Pow(MyPoint.Y - Points[i+1].Y, 2));
                double d3 = Math.Sqrt(Math.Pow(Points[i].X - Points[i+1].X, 2) + Math.Pow(Points[i].Y - Points[i+1].Y, 2));

                if ((int)d1 + (int)d2 == (int)d3)
                    return true;
            }
            return false;
        }

        private void CreatePoligon()
        {
            Graphics gObject = this.CreateGraphics();
            Pen pen = new Pen(Color.Black, 5);
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
