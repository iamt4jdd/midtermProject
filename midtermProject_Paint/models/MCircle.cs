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
    public class MCircle : MEllipse
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
            using (GraphicsPath path = graphicsPath)
            {
                using (Pen myPen = new Pen(this.color, this.width))
                {
                    if (isDash) myPen.DashStyle = DashStyle.Dash;
                    graphic.DrawPath(myPen, path);
                }
                if (this.isFill)
                {
                    using (Brush brush = new SolidBrush(this.color))
                    {
                        graphic.FillPath(brush, path);
                    }
                }
            }
        }

        public override bool isSelect(Point point)
        {
            isInside = false;
            using (GraphicsPath path = graphicsPath)
            {
                if (!isFill)
                {
                    using (Pen pen = new Pen(this.color, this.width + 3))
                    {
                        isInside = path.IsOutlineVisible(point, pen);
                    }
                }
                else
                {
                    isInside = path.IsVisible(point);
                }
            }

            return isInside;
        }

        public override void moveShape(Point distance)
        {
            startPoint = new Point(startPoint.X + distance.X, startPoint.Y + distance.Y);
            endPoint = new Point(endPoint.X + distance.X, endPoint.Y + distance.Y);
        }

        protected override GraphicsPath graphicsPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                int Diameter = ((endPoint.X - startPoint.X) + (endPoint.Y - startPoint.Y)) / 2;
                path.AddEllipse(new Rectangle(startPoint.X, startPoint.Y, Diameter, Diameter));
                endPoint = new Point(startPoint.X + Diameter, startPoint.Y + Diameter);
                return path;
            }
        }

    }
}
