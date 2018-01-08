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
                    DrawBlackLine(Points[Points.Count() - 2], Points[Points.Count() - 1]);
                    DrawBlackLine(Points[0], Points[Points.Count() - 1]);
                    break;
                case 5:
                    label1.Text = "My point is X = " + Points[0].X + "; Y = " + Points[0].Y;
                    MyPoint = p;
                    //DrawLineTransparent();
                    VerifyWherePointIs();
                    break;
                default:
                    Points.Add(p);
                    if (Points.Count() > 1)
                        DrawBlackLine(Points[Points.Count() - 2], Points[Points.Count() - 1]);
                    break;
            }
        }

        private void VerifyWherePointIs()
        {
            bool isOnSide = CheckIfItsOnSide();
            bool isInTriangle1 = PointInTriangle(MyPoint, Points[0], Points[1], Points[2]);
            bool isInTriangle2 = PointInTriangle(MyPoint, Points[1], Points[2], Points[3]);
            bool isInTriangle3 = PointInTriangle(MyPoint, Points[2], Points[3], Points[4]);
            bool isInTriangle4 = PointInTriangle(MyPoint, Points[3], Points[4], Points[0]);
            bool isInTriangle5 = PointInTriangle(MyPoint, Points[4], Points[0], Points[1]);
            bool isInTriangle6 = PointInTriangle(MyPoint, Points[0], Points[1], Points[3]);

            if (isOnSide)
            {
                label1.Text = "Punctul se afla pe latura poligonului.";
                return;
            }

            if (isInTriangle1)
            {
                label1.Text = "Punctul se afla in interiorul triunghiului.";
                DrawLine(Points[0], Points[2]);
            }
            else
            {
                if (isInTriangle2)
                {
                    label1.Text = "Punctul se afla in interiorul triunghiului.";
                    DrawLine(Points[1], Points[3]);
                }
                else
                {
                    if (isInTriangle3)
                    {
                        label1.Text = "Punctul se afla in interiorul triunghiului.";
                        DrawLine(Points[2], Points[4]);
                    }
                    else
                    {
                        if (isInTriangle4)
                        {
                            label1.Text = "Punctul se afla in interiorul triunghiului.";
                            DrawLine(Points[3], Points[0]);
                        }
                        else
                        {
                            if (isInTriangle5)
                            {
                                label1.Text = "Punctul se afla in interiorul triunghiului.";
                                DrawLine(Points[1], Points[4]);
                            }
                            else
                            {
                                if (isInTriangle6)
                                {
                                    label1.Text = "Punctul se afla in interiorul triunghiului.";
                                    DrawLine(Points[2], Points[4]);
                                    DrawLine(Points[0], Points[2]);
                                }
                                else
                                    label1.Text = "Punctul se afla in exteriorul poligonului.";
                            }
                        }
                    }
                }
            }
        }

        private void DrawLineTransparent()
        {
            Graphics gObject = this.CreateGraphics();
            Pen pen = new Pen(Color.White, 5);
            gObject.DrawLine(pen, Points[0], Points[2]);
            gObject.DrawLine(pen, Points[1], Points[3]);
            gObject.DrawLine(pen, Points[2], Points[4]);
            gObject.DrawLine(pen, Points[3], Points[0]);
            gObject.DrawLine(pen, Points[1], Points[4]);
            gObject.Dispose();
        }

        private void DrawLine(Point p1, Point p2)
        {
            Graphics gObject = this.CreateGraphics();
            Pen pen = new Pen(Color.Red, 5);
            gObject.DrawLine(pen, p1, p2);
            gObject.Dispose();
        }

        private void DrawBlackLine(Point p1, Point p2)
        {
            Graphics gObject = this.CreateGraphics();
            Pen pen = new Pen(Color.Black, 5);
            gObject.DrawLine(pen, p1, p2);
            gObject.Dispose();
        }

        private bool CheckIfItsOnSide()
        {
            for (int i = 0; i < 4; i++)
            {
                double d1 = Math.Sqrt(Math.Pow(Points[i].X - MyPoint.X, 2) + Math.Pow(Points[i].Y - MyPoint.Y, 2));
                double d2 = Math.Sqrt(Math.Pow(MyPoint.X - Points[i + 1].X, 2) + Math.Pow(MyPoint.Y - Points[i + 1].Y, 2));
                double d3 = Math.Sqrt(Math.Pow(Points[i].X - Points[i + 1].X, 2) + Math.Pow(Points[i].Y - Points[i + 1].Y, 2));

                if ((int)d1 + (int)d2 == (int)d3)
                    return true;
            }
            return false;
        }

        bool PointInTriangle(Point pt, Point v1, Point v2, Point v3)
        {
            bool b1, b2, b3;

            b1 = sign(pt, v1, v2) < 0.0f;
            b2 = sign(pt, v2, v3) < 0.0f;
            b3 = sign(pt, v3, v1) < 0.0f;

            return ((b1 == b2) && (b2 == b3));
        }

        float sign(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }
    }
}
