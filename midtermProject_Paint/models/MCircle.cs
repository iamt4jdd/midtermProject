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
                    int diameter = (int)Math.Sqrt(Math.Pow(this.endPoint.X - this.startPoint.X, 2) + Math.Pow(this.endPoint.Y - this.startPoint.Y, 2));
                    int radius = diameter / 2;
                    int centerX = Math.Min(this.startPoint.X, this.endPoint.X) + radius;
                    int centerY = Math.Min(this.startPoint.Y, this.endPoint.Y) + radius;
                    graphic.DrawEllipse(myPen, centerX - radius, centerY - radius, diameter, diameter);
                }
            }
            else
            {
                using (Brush myBrush = new SolidBrush(color))
                {
                    int diameter = (int)Math.Sqrt(Math.Pow(this.endPoint.X - this.startPoint.X, 2) + Math.Pow(this.endPoint.Y - this.startPoint.Y, 2));
                    int radius = diameter / 2;
                    int centerX = Math.Min(this.startPoint.X, this.endPoint.X) + radius;
                    int centerY = Math.Min(this.startPoint.Y, this.endPoint.Y) + radius;
                    graphic.FillEllipse(myBrush, centerX - radius, centerY - radius, diameter, diameter);
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
         
                return path;
            }
        }

    }
}
