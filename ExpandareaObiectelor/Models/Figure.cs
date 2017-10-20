using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpandareaObiectelor.Models
{
    public class Figure
    {
        public Figure()
        {
            Points = new List<Point>();
            Path = new GraphicsPath();
        }
        public List<Point> Points { get; set; }
        public GraphicsPath Path{ get; set; }
    }
}
