using ExpandareaObiectelor.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ExpandareaObiectelor
{
    public partial class Form1 : Form
    {
        Mod mod;
        Color color;
        Figure figure;
        List<Figure> figures;
        Graphics gp;
        Point _previousPoint;
        Point _finishPoint;
        Pen pen;
        List<ToolStripButton> butttons;
        SizeDialog dialog;
        Guid copyId;
        Point StartDrag;
        Guid dragFigure;
        bool drag;
        SolidBrush brush = new SolidBrush(Color.Blue);
        GraphicsPath pathDrag;
        Figure deleteFigure;

        public Form1()
        {
            InitializeComponent();
            gp = panel.CreateGraphics();
            pen = new Pen(Color.Black);
            figures = new List<Figure>();
            _previousPoint = new Point();
            _finishPoint = new Point();
            AddButtons();
        }
        private void AddButtons()
        {
            butttons = new List<ToolStripButton>();
            butttons.Add(freeDrawBtn);
            butttons.Add(squareBtn);
            butttons.Add(triangleBtn);
            butttons.Add(circleBtn);
            butttons.Add(dragBtn);
            color = dragBtn.BackColor;
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (mod == Mod.FreeDraw)
            {
                Point p = new Point(e.X, e.Y);
                if (_previousPoint.X > 0 && _previousPoint.Y > 0)
                {
                    if (Math.Abs(_finishPoint.X - p.X) < 10 && Math.Abs(_finishPoint.Y - p.Y) < 10)
                    {
                        figure.Path.AddLine(_previousPoint, _finishPoint);
                        gp.FillPath(brush, figure.Path);
                        _previousPoint = new Point();
                        figures.Add(figure);
                    }
                    else
                    {
                        gp.DrawEllipse(pen, p.X, p.Y, 5, 5);
                        gp.DrawLine(pen, _previousPoint, p);
                        figure.Path.AddLine(_previousPoint, p);
                        _previousPoint = p;
                    }

                }
                else
                {
                    figure = new Figure();
                    gp.DrawEllipse(pen, p.X, p.Y, 5, 5);
                    _finishPoint = p;
                    _previousPoint = p;
                }
            }
            else if (mod == Mod.Drag)
            {
                foreach (var figure in figures)
                {
                    if (figure.Path.IsVisible(e.X, e.Y))
                    {
                        dragFigure = figure.Id;
                        drag = true;
                        StartDrag = new Point(e.X, e.Y);
                    }
                }
            }
            else if (mod == Mod.Square)
            {


                figure = new Figure();
                var rect = new Rectangle(e.X, e.Y, dialog.Width, dialog.Height);
                gp.DrawRectangle(pen, rect);
                figure.Path.AddRectangle(rect);
                figures.Add(figure);
                gp.FillPath(brush, figure.Path);
            }
            else if (mod == Mod.Triangle)
            {
                figure = new Figure();
                var triangleA = new Point(e.X, e.Y);
                var triangleB = new Point(e.X + 10, e.Y + 50);
                var triangleC = new Point(e.X + 50, e.Y + 10);

                figure.Path.AddLine(triangleA, triangleB);
                figure.Path.AddLine(triangleB, triangleC);
                figure.Path.AddLine(triangleC, triangleA);
                figures.Add(figure);
                gp.FillPath(brush, figure.Path);
            }
            else if (mod == Mod.Circle)
            {

                figure = new Figure();
                var circle = new RectangleF(e.X, e.Y, dialog.Width, dialog.Height);
                figure.Path.AddEllipse(circle);
                figures.Add(figure);
                gp.FillPath(brush, figure.Path);
            }

        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (mod == Mod.Drag)
            {
                _previousPoint = new Point();
                _finishPoint = new Point();
                //dragFigure = Guid.Empty;
                drag = false;
            }
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                var xOff = e.X - StartDrag.X;
                var yOff = e.Y - StartDrag.Y;
                pathDrag = new GraphicsPath();
                PointF[] points = figures.FirstOrDefault(f => f.Id == dragFigure).Path.PathPoints;

                for (var i = 1; i < points.Count(); i++)
                {
                    pathDrag.AddLine(points[i - 1].X + xOff, points[i - 1].Y + yOff, points[i].X + xOff, points[i].Y + yOff);
                }
                figures.FirstOrDefault(f => f.Id == dragFigure).Path = pathDrag;

                gp.Clear(Color.White);
                foreach (var figure in figures)
                {
                    if (figure.Id != dragFigure)
                        gp.FillPath(brush, figure.Path);
                }
                gp.FillPath(new SolidBrush(Color.Pink), pathDrag);
                _previousPoint.X = e.X;
                _previousPoint.Y = e.Y;
                StartDrag.X = e.X;
                StartDrag.Y = e.Y;
            }
        }


        private void expandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Yellow;
            pen.Width = 20;
            foreach (var figure in figures)
            {
                gp.DrawPath(pen, figure.Path);

            }
            pen = new Pen(Color.Black);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gp.Clear(Color.White);
            figures = new List<Figure>();
            _previousPoint = new Point();
            _finishPoint = new Point();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            freeDrawBtn.BackColor = Color.Aqua;
            ResetBtns(freeDrawBtn);
            mod = Mod.FreeDraw;
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            squareBtn.BackColor = Color.Aqua;
            ResetBtns(squareBtn);
            mod = Mod.Square;
            if (dialog != null)
                dialog.Dispose();
            dialog = new SizeDialog("square");
            dialog.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            triangleBtn.BackColor = Color.Aqua;
            ResetBtns(triangleBtn);
            mod = Mod.Triangle;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            circleBtn.BackColor = Color.Aqua;
            ResetBtns(circleBtn);
            mod = Mod.Circle;
            if (dialog != null)
                dialog.Dispose();
            dialog = new SizeDialog("circle");
            dialog.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            dragBtn.BackColor = Color.Aqua;
            ResetBtns(dragBtn);
            mod = Mod.Drag;
        }

        private void ResetBtns(ToolStripButton btn)
        {
            foreach (var item in butttons)
            {
                if (item != btn)
                {
                    item.BackColor = color;
                }
            }
        }

        private void expandBtn_Click(object sender, EventArgs e)
        {
            pen.Color = Color.Red;
            foreach (var figure in figures)
            {
                figure.Path = ConvexHull(figure);
                gp.FillPath(brush, figure.Path);
            }
            pen = new Pen(Color.Black);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                var cpFigure = new Figure();
                var points = figures.FirstOrDefault(i => i.Id == dragFigure).Path.PathPoints;
                for (int i = 1; i < points.Length; i++)
                {
                    cpFigure.Path.AddLine(points[i - 1].X + 40, points[i - 1].Y + 40, points[i].X + 40, points[i].Y + 40);
                }
                figures.Add(cpFigure);
                copyId = cpFigure.Id;
            }
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                var paste = figures.FirstOrDefault(f => f.Id == copyId);
                if (paste != null)
                    gp.FillPath(brush, paste.Path);
            }

        }

        private GraphicsPath ConvexHull(Figure figure)
        {
            InitOrderdPoints(figure);
            var path = Compute();
            prepareNewConvexHull();
            return path;
        }


        #region compute
        #region structures
        public struct Segment
        {
            public PointF p;
            public PointF q;

            public bool contains(SuperPoint point)
            {
                if (p.Equals(point.P) || q.Equals(point.P))
                    return true;
                return false;
            }

        }

        public struct SuperPoint
        {
            public PointF P;
            public int ID;

            public SuperPoint(PointF p, int id)
            {
                P = p;
                ID = id;
            }
        }
        #endregion


        #region Globals
        List<SuperPoint> pointsList = new List<SuperPoint>();
        List<Segment> Segments = new List<Segment>();
        int pID = 0;
        List<List<SuperPoint>> renderingPoints = new List<List<SuperPoint>>();
        List<List<Segment>> renderingEdges = new List<List<Segment>>();
        List<PointF[]> renderingAreas = new List<PointF[]>();
        #endregion

        #region Functions

        private void renderPoint(float x, float y, Color c)
        {
            Pen p = new Pen(Color.Red);
            // gp.DrawEllipse(p, x - 5, y - 5, 10, 10);
            gp.DrawLine(p, x, y - 5, x, y - 5 - 2.5f);
            gp.DrawLine(p, x - 5, y, x - 5 - 2.5f, y);
            gp.DrawLine(p, x, y + 5, x, y + 5 + 2.5f);
            gp.DrawLine(p, x + 5, y, x + 5 + 2.5f, y);
            gp.FillEllipse(Brushes.Lime, x - 1.25f, y - 1.25f, 2.5f, 2.5f);
        }

        private GraphicsPath renderEdges(List<Segment> edges)
        {
            List<PointF> list = new List<PointF>();
            for (int i = 0; i < edges.Count; i++)
            {
                if (i == 0)
                    list.Add(edges[i].p);
                foreach (Segment s in edges)
                {

                    if (s.p == list[list.Count - 1])
                    {
                        list.Add(s.q);
                        break;
                    }
                }
            }

            Pen p = new Pen(Color.Red);
            GraphicsPath path = new GraphicsPath();
            foreach (Segment opEdge in edges)
            {
                path.AddLine(opEdge.p.X, opEdge.p.Y, opEdge.q.X, opEdge.q.Y);
                //gp.DrawLine(p, opEdge.p, opEdge.q);
            }


            foreach (SuperPoint sp in pointsList)
            {
                //renderPoint(sp.P.X, sp.P.Y, Color.Lime);
            }
            return path;
        }

        private void prepareNewConvexHull()
        {
            this.pID = 0;
            pointsList.Clear();
            Segments.Clear();
        }

        private GraphicsPath Compute()
        {
            List<SuperPoint> ProcessingPoints = new List<SuperPoint>();
            int i = 0;
            int j = 0;
            for (i = 0; i < Segments.Count;)
            {
                //ProcessingPoints will be the points that are not in the current segment
                ProcessingPoints = new List<SuperPoint>(pointsList);

                for (j = 0; j < ProcessingPoints.Count;)
                {

                    if (Segments[i].contains(ProcessingPoints[j]))
                    {
                        ProcessingPoints.Remove(ProcessingPoints[j]);
                        j = 0;
                        continue;
                    }
                    j++;

                }

                if (!isEdge(ProcessingPoints, Segments[i]))
                {
                    Segments.Remove(Segments[i]);
                    i = 0;
                    continue;
                }
                else
                { i++; }
            }

            return renderEdges(Segments);
            //List<SuperPoint> superPointsList = new List<SuperPoint>(pointsList);
            //List<Segment> segmentsList = new List<Segment>(Segments);
            //renderingPoints.Add(superPointsList);
            //renderingEdges.Add(segmentsList);

        }

        private bool isEdge(List<SuperPoint> processingPoints, Segment edge)
        {
            for (int k = 0; k < processingPoints.Count; k++)
            {
                if (isLeft(edge, processingPoints[k].P))
                {
                    return false;
                }
            }
            return true;
        }

        private bool isLeft(Segment segment, PointF r)
        {
            float D = 0;
            float px, py, qx, qy, rx, ry = 0;
            //The determinant
            // | 1 px py |
            // | 1 qx qy |
            // | 1 rx ry |
            //if the determinant result is positive then the point is left of the segment
            px = segment.p.X;
            py = segment.p.Y;
            qx = segment.q.X;
            qy = segment.q.Y;
            rx = r.X;
            ry = r.Y;

            D = ((qx * ry) - (qy * rx)) - (px * (ry - qy)) + (py * (rx - qx));

            if (D <= 0)
                return false;

            return true;
        }

        private void InitOrderdPoints(Figure figure)
        {
            //Initialize all possible segments from the picked points
            foreach (var item in figure.Path.PathPoints)
            {
                pID++;
                PointF p = new PointF(item.X, item.Y);
                SuperPoint sp = new SuperPoint(p, pID);
                pointsList.Add(sp);
            }
            for (int i = 0; i < pointsList.Count; i++)
            {
                for (int j = 0; j < pointsList.Count; j++)
                {
                    if (i != j)
                    {
                        Segment op = new Segment();
                        PointF p1 = pointsList[i].P;
                        PointF p2 = pointsList[j].P;
                        op.p = p1;
                        op.q = p2;

                        Segments.Add(op);
                    }
                }
            }
        }

        #endregion

        #endregion


    }
}
