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
                        if (isDash) myPen.DashStyle = dashStyle;
                        graphic.DrawPath(myPen, path);
                
                    }
                }
                else
                {
                    using (HatchBrush myBrush = new HatchBrush(brushStyle, color))
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
            for (int i = 0; i < points.Count; i++)
            {
                points[i] = new Point(points[i].X + distance.X, points[i].Y + distance.Y);
            }
        }

        public void LinkPoints()
        {
            int minX = int.MaxValue;
            int minY = int.MaxValue;
            int maxX = int.MinValue;
            int maxY = int.MinValue;

            this.points.ForEach(p =>
            {
                if (minX > p.X) { minX = p.X; }
                if (minY > p.Y) { minY = p.Y; }
                if (maxX < p.X) { maxX = p.X; }
                if (maxY < p.Y) { maxY = p.Y; }
            });
            startPoint = new Point(minX, minY);
            endPoint = new Point(maxX, maxY);
        }

      

        public override int SelectControlPoint(Point p)
        {
            for (int i = 0; i < points.Count; i++)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(new Rectangle(points[i].X - 4, points[i].Y - 4, 8, 8));

                if (path.IsVisible(p)) return i;
            }
            return -1;
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
