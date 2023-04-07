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
    public class MRectangle : Shape
    {
        public MRectangle()
        {
            name = "Rectangle";
        }

        public MRectangle(Color color)
        {
            name = "Rectangle";
            this.color = color;
        }

        public override void drawShape(Graphics graphic)
        {
           if(!isFill)
           {
                using (Pen myPen = new Pen(color, width))
                {
                   
                    if (isDash) myPen.DashStyle = dashStyle;
                    graphic.DrawRectangle(myPen, Math.Min(this.startPoint.X, this.endPoint.X),
                    Math.Min(this.startPoint.Y, this.endPoint.Y),
                    Math.Abs(this.endPoint.X - this.startPoint.X),
                    Math.Abs(this.endPoint.Y - this.startPoint.Y));
                }
            }
           else
           {
                using (HatchBrush myBrush = new HatchBrush(brushStyle, color))
                {
                    
                    graphic.FillRectangle(myBrush, Math.Min(this.startPoint.X, this.endPoint.X),
                    Math.Min(this.startPoint.Y, this.endPoint.Y),
                    Math.Abs(this.endPoint.X - this.startPoint.X),
                    Math.Abs(this.endPoint.Y - this.startPoint.Y));
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
                Rectangle rectangle = new Rectangle(Math.Min(startPoint.X, endPoint.X),
                            Math.Min(startPoint.Y, endPoint.Y),
                            Math.Abs(endPoint.X - startPoint.X),
                            Math.Abs(endPoint.Y - startPoint.Y));
                path.AddRectangle(rectangle);
                return path;
            }
        }


    }
}
