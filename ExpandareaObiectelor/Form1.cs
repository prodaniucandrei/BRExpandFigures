using ExpandareaObiectelor.Models;
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
        Figure figure;
        List<Figure> figures;
        Graphics gp;
        Point _previousPoint;
        Point _finishPoint;
        Pen pen;
        GraphicsPath path;
        Figure dragFigure;
        bool drag;
        Point StartDrag;

        public Form1()
        {
            InitializeComponent();
            gp = panel.CreateGraphics();
            pen = new Pen(Color.Black);
            figures = new List<Figure>();
            _previousPoint = new Point();
            _finishPoint = new Point();

        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            if (_previousPoint.X > 0 && _previousPoint.Y > 0)
            {
                gp.DrawEllipse(pen, p.X, p.Y, 5, 5);
                gp.DrawLine(pen, _previousPoint, p);
                path.AddLine(_previousPoint, p);
                _previousPoint = p;
                figure.Points.Add(p);
                figure.Path.AddLine(_previousPoint, p);
                if (Math.Abs(_finishPoint.X - p.X) < 5 && Math.Abs(_finishPoint.Y - p.Y) < 5)
                {
                    var brush = new SolidBrush(Color.Black);
                    gp.FillPath(brush, path);
                    _previousPoint.X = 0;
                    _previousPoint.Y = 0;
                    figures.Add(figure);
                }
            }
            else
            {
                figure = new Figure();
                path = new GraphicsPath();
                gp.DrawEllipse(pen, p.X, p.Y, 5, 5);
                figure.Points.Add(p);
                _finishPoint = p;
                _previousPoint = p;
            }

            foreach (var figure in figures)
            {
                if (figure.Path.IsVisible(e.X, e.Y))
                {
                    dragFigure = figure;
                    drag = true;
                    StartDrag = new Point(e.X, e.Y);
                }
            }

        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            var xOff = e.X-_previousPoint.X;
            var yOff = e.Y-_previousPoint.Y;
            var pathDrag = new GraphicsPath();
            if (drag)
            {
                for (var i = 1; i < dragFigure.Points.Count; i++)
                {
                    pathDrag.AddLine(dragFigure.Points[i - 1].X + xOff, dragFigure.Points[i - 1].Y + yOff, dragFigure.Points[i].X + xOff, dragFigure.Points[i].Y + yOff);
                }
                gp.Clear(Color.White);
                gp.FillPath(new SolidBrush(Color.Pink), pathDrag);
            }
            StartDrag.X = e.X;
            StartDrag.Y = e.Y;
        }

        private void panel_DoubleClick(object sender, EventArgs e)
        {

        }

        private void expandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //gp.Clear(Color.White);
            //var path = new GraphicsPath();
            //var figure = figures.FirstOrDefault();
            //figure.Points = figure.Points.OrderBy(p => p.X).ToList();
            //for (int i = 1; i < figure.Points.Count; i++)
            //{
            //    path.AddLine(figure.Points[i - 1], figure.Points[i]);
            //}

            //var isvisible = path.IsVisible(50, 50);
            //gp.DrawPath(pen, path);
            drag = true;
        }

        private void panel_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            foreach (var figure in figures)
            {
                if (figure.Path.IsVisible(e.X, e.Y))
                {
                    dragFigure = figure;
                    drag = true;
                    StartDrag = new Point(e.X, e.Y);
                }
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gp.Clear(Color.White);
        }
    }
}
