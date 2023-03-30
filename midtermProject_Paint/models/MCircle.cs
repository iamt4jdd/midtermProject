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
    public class MCircle : Shape
    {
        public MCircle()
        {
            name = "Circle";
        }

        public MCircle(Color color)
        {
            name = "Circle";
            this.color = color;
        }

        public override void drawShape(Graphics graphic)
        {
            if (!isFill)
            {
                using (Pen myPen = new Pen(color, width))
                {
                    if (isDash) myPen.DashStyle = DashStyle.Dash;
                    graphic.DrawEllipse(myPen, Math.Min(this.startPoint.X, this.endPoint.X),
                    Math.Min(this.startPoint.Y, this.endPoint.Y),
                    Math.Abs(this.endPoint.Y - this.startPoint.Y),
                    Math.Abs(this.endPoint.Y - this.startPoint.Y));
                }
            }
            else
            {
                using (Brush myBrush = new SolidBrush(color))
                {
                    graphic.FillEllipse(myBrush, Math.Min(this.startPoint.X, this.endPoint.X),
                    Math.Min(this.startPoint.Y, this.endPoint.Y),
                    Math.Abs(this.endPoint.Y - this.startPoint.Y),
                    Math.Abs(this.endPoint.Y - this.startPoint.Y));
                }
            }
        }

        public override bool isSelect(Point point)
        {
            bool inside = false;
            using (GraphicsPath path = graphicsPath)
            {
                if (isFill)
                {
                    inside = path.IsVisible(point);
                }
                else
                {
                    using (Pen pen = new Pen(color, width + 3))
                    {
                        inside = path.IsOutlineVisible(point, pen);
                    }
                }
            }

            return inside;
        }

        public override void moveShape(Point distance)
        {
            throw new NotImplementedException();
        }

        protected override GraphicsPath graphicsPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                int Diameter = ((endPoint.X - startPoint.X) + (endPoint.Y - startPoint.Y)) / 2;
                path.AddEllipse(new RectangleF(startPoint.X, startPoint.Y, Diameter, Diameter));
                endPoint = new Point(startPoint.X + Diameter, startPoint.Y + Diameter);
                return path;
            }
        }

    }
}
