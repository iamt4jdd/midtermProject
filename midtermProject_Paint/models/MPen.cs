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
    public class MPen : Shape
    {

        public List<Point> points { get; set; } = new List<Point>();
        public MPen()
        {
            this.name = "Pen";
        }
        public MPen(int Width, Color ShapeColor)
        {
            this.name = "Pen";
            this.width = Width;
            this.color = ShapeColor;
  
            
        }
        
        protected override GraphicsPath graphicsPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                for (int i = 0; i < points.Count - 1; i++)
                {
                    path.AddLine(points[i], points[i + 1]);
                }
                return path;
            }
        }
        public override void drawShape(Graphics graphic)
        {
            Pen myPen = new Pen(color, width);
            myPen.StartCap = myPen.EndCap = LineCap.Round;
            graphic.DrawPath(myPen, graphicsPath);
        }
        public override bool isSelect(Point point)
        {
            Pen myPen = new Pen(color, width + 3);
            return graphicsPath.IsOutlineVisible(point, myPen);
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
        
        public void Linkpoints()
        {
            int minX = int.MaxValue;
            int minY = int.MaxValue;
            int maxX = int.MinValue;
            int maxY = int.MinValue;

            points.ForEach(p =>
            {
                if (minX > p.X) { minX = p.X; }
                if (minY > p.Y) { minY = p.Y; }
                if (maxX < p.X) { maxX = p.X; }
                if (maxY < p.Y) { maxY = p.Y; }
            });
            startPoint = new Point(minX, minY);
            endPoint = new Point(maxX, maxY);
        }
    }
}
