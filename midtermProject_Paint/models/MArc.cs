using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace midtermProject_Paint.models
{
    public class MArc : Shape
    {
        public List<Point> points;

        public MArc()
        {
            name = "Arc";
            points = new List<Point>();
        }

        public MArc(Color color)
        {
            name = "Arc";
            this.color = color;
            points = new List<Point>();
        }

        public override void drawShape(Graphics graphic)
        {
            using (GraphicsPath path = graphicsPath)
            {
                using (Pen pen = new Pen(color, width))
                {
                    graphic.DrawPath(pen, path);
                }
            }
        }

        public override bool isSelect(Point point)
        {
            throw new NotImplementedException();
        }

        protected override GraphicsPath graphicsPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                path.AddCurve(points.ToArray());
                return path;
            }
        }
    }
}
