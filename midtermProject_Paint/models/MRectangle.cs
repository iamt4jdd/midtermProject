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
                    if (isDash) myPen.DashStyle = DashStyle.Dash;
                    graphic.DrawRectangle(myPen, Math.Min(this.startPoint.X, this.endPoint.X),
                    Math.Min(this.startPoint.Y, this.endPoint.Y),
                    Math.Abs(this.endPoint.X - this.startPoint.X),
                    Math.Abs(this.endPoint.Y - this.startPoint.Y));
                }
            }
           else
           {
                using (Brush myBrush = new SolidBrush(color))
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
            throw new NotImplementedException();
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
