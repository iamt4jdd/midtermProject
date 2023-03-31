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
    public class MLine : Shape
    {
        public MLine()
        {
            name = "Line";
        }

        public MLine(Color color)
        {
            name = "Line";
            this.color = color;
        }

        public override void drawShape(Graphics graphic)
        {
            using (Pen myPen = new Pen(color, width))
            {
                if (isDash) myPen.DashStyle = DashStyle.Dash;
                graphic.DrawLine(myPen, this.startPoint, this.endPoint);
            }
        }

        public override bool isSelect(Point point)
        {
            isInside = false;
            using (GraphicsPath path = graphicsPath)
            {
                using (Pen pen = new Pen(color, width + 3))
                {
                    isInside = path.IsOutlineVisible(point, pen);
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
                path.AddLine(startPoint, endPoint);
                return path;
            }
        }

    }
}
