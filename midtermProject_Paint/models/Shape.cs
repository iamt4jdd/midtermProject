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
    public abstract class Shape
    {

        public string name { get; set; }

        public Point startPoint { get; set; }

        public Point endPoint { get; set; }

        public Point previousLocation { get; set; }

        public bool isSelected { get; set; }

        public bool isInside { get; set; }

        public bool isFill { get; set; }

        public bool isDash { get; set; }

        public Color color { get; set; }

        public HatchStyle brushStyle { get; set; }

        public DashStyle dashStyle { get; set; }

        public int width { get; set; }

        public abstract void drawShape(Graphics graphic);

        public abstract bool isSelect(Point point);

        public abstract void moveShape(Point distance);

        public static List<Point> getControlPoints(Shape shape)
        {
            List<Point> points = new List<Point>();
            int xCenter = (shape.startPoint.X + shape.endPoint.X) / 2;
            int yCenter = (shape.startPoint.Y + shape.endPoint.Y) / 2;
            points.Add(new Point(shape.startPoint.X, shape.startPoint.Y));
            points.Add(new Point(xCenter, shape.startPoint.Y));
            points.Add(new Point(shape.endPoint.X, shape.startPoint.Y));
            points.Add(new Point(shape.startPoint.X, yCenter));
            points.Add(new Point(shape.endPoint.X, yCenter));
            points.Add(new Point(shape.startPoint.X, shape.endPoint.Y));
            points.Add(new Point(xCenter, shape.endPoint.Y));
            points.Add(new Point(shape.endPoint.X, shape.endPoint.Y));
            return points;
        }
        public virtual int SelectControlPoint(Point points)
        {

            List<Point> selectPoints = getControlPoints(this);
            for (int i = 0; i < 8; i++)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(new Rectangle(selectPoints[i].X - 4, selectPoints[i].Y - 4, 8, 8));

                if (path.IsVisible(points)) return i;
            }
            return -1;

        }

        public virtual void changePoint(int index)
        {
          
            if (index == 2)
            {
                int a = endPoint.X;
                int b = startPoint.Y;
                startPoint = new Point(startPoint.X, endPoint.Y);
                endPoint = new Point(a, b);
            }
            if (index == 5)
            {
                int a = startPoint.X;
                int b = endPoint.Y;
                startPoint = new Point(endPoint.X, startPoint.Y);
                endPoint = new Point(a, b);
            }
        }

      

        protected abstract GraphicsPath graphicsPath { get; }
        

    }
}
