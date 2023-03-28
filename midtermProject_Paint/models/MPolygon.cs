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
    public class MPolygon : Shape
    {
        public List<Point> points { get; set; } = new List<Point>();

        public MPolygon()
        {
            name = "Polygon";
        }

        public MPolygon(Color color)
        {
            name = "Polygon";
            this.color = color;
        }

        public override void drawShape(Graphics graphic)
        {
           
            using(GraphicsPath path = this.graphicsPath)
            {
                if (!this.isFill)
                {
                    using (Pen myPen = new Pen(color, width))
                    {
                        if (isDash) myPen.DashStyle = DashStyle.Dash;
                        graphic.DrawPath(myPen, path);
                
                    }
                }
                else
                {
                    using (Brush myBrush = new SolidBrush(color))
                    {
                        if (points.Count < 3)
                        {
                            using (Pen myPen = new Pen(color, width))
                            {
                                graphic.DrawPath(myPen, path);
                            }
                        }
                        else
                        {
                            graphic.FillPath(myBrush, path);
                        }
                    }
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
                if (points.Count < 3)
                {
                    path.AddLine(points[0], points[1]);
                }
                else
                {

                    path.AddPolygon(points.ToArray());
                }

                return path;
            }
        }

    }
}
