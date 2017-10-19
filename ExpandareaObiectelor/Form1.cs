using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpandareaObiectelor
{
    public partial class Form1 : Form
    {
        Graphics gp;
        List<Point> points;
        Point _previousPoint;
        Pen pen;
        bool draw;
        public Form1()
        {
            points = new List<Point>();
            InitializeComponent();
            gp = panel.CreateGraphics();
            pen = new Pen(Color.Black);
            _previousPoint = new Point();
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            if (_previousPoint.X > 0 && _previousPoint.Y > 0)
            {

                gp.DrawLine(pen, _previousPoint.X, _previousPoint.Y, e.X, e.Y);
            }

            _previousPoint.X = e.X;
            _previousPoint.Y = e.Y;
            points.Add(_previousPoint);

        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void panel_DoubleClick(object sender, EventArgs e)
        {
            draw = false;
        }

        private void expandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pen.Width = 20;
            var path = new GraphicsPath();

            for (int i = 0; i < points.Count - 1; i++)
            {
                //gp.DrawLine(pen, points[i], points[i+1]);
                path.StartFigure();
                path.AddLine(points[i], points[i + 1]);
                if (i == points.Count - 2)
                {
                    path.AddLine(points[i+1], points[0]);
                    path.AddCurve(new Point[] { points[i], points[i + 1], points[0] });
                }
            }
            pen.Color = Color.Red;

            gp.DrawPath(pen, path);



        }
    }
}
