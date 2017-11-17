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
            Path = new GraphicsPath();
            ExpandedPath = new GraphicsPath();
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
        public GraphicsPath Path{ get; set; }
        public GraphicsPath ExpandedPath{ get; set; }
        
    }
}
