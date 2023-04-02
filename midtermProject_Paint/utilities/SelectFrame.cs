using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midtermProject_Paint.models { 

    public static class SelectFrame
    {
        public static void DrawRectangle(this Graphics graphics, Pen pen, Rectangle rect)
        {
            graphics.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
        }
          

        public static void DrawSelectPoints(Graphics graphics, Brush brush, Point startPoint, Point endPoint)
        {
            //Console.WriteLine($"{startPoint}, {endPoint}");
            //graphics.FillRectangle(brush, new Rectangle(startPoint.X - 5, startPoint.Y - 5, 10, 10));
            //graphics.FillRectangle(brush, new Rectangle(endPoint.X - 5, endPoint.Y - 5, 10, 10));
            if (startPoint.X < endPoint.X)
            {
                graphics.FillRectangle(brush, new Rectangle(Math.Max(startPoint.X, endPoint.X) - (endPoint.X - startPoint.X) - 4
                , Math.Min(startPoint.Y, endPoint.Y) - 4, 10, 10));
                graphics.FillRectangle(brush, new Rectangle(Math.Min(startPoint.X, endPoint.X) + (endPoint.X - startPoint.X) - 4
                , Math.Max(startPoint.Y, endPoint.Y) - 4, 10, 10));
            }
            else
            {
                graphics.FillRectangle(brush, new Rectangle(Math.Max(startPoint.X, endPoint.X) - (startPoint.X - endPoint.X) - 4
                , Math.Min(startPoint.Y, endPoint.Y) - 4, 10, 10));
                graphics.FillRectangle(brush, new Rectangle(Math.Min(startPoint.X, endPoint.X) + (startPoint.X - endPoint.X) - 4
                , Math.Max(startPoint.Y, endPoint.Y) - 4, 10, 10));
            }
            
            graphics.FillRectangle(brush, new Rectangle(Math.Max(startPoint.X, endPoint.X) - 4
            , Math.Min(startPoint.Y, endPoint.Y) - 4, 10, 10));
            graphics.FillRectangle(brush, new Rectangle(Math.Min(startPoint.X, endPoint.X) - 4
            , Math.Max(startPoint.Y, endPoint.Y) - 4, 10, 10));

        }

        public static void DrawSelectPointsLine(Graphics graphics, Brush brush, Point startPoint, Point endPoint)
        {
 
            graphics.FillRectangle(brush, new Rectangle(startPoint.X - 5, startPoint.Y - 5, 10, 10));
            graphics.FillRectangle(brush, new Rectangle(endPoint.X - 5, endPoint.Y - 5, 10, 10));
           
        }

        public static void DrawSelectPointsArc(Graphics graphics, Brush brush, Point startPoint, Point endPoint)
        {
            int radius = Math.Abs(startPoint.Y - endPoint.Y) / 2;
            int centerX = Math.Min(startPoint.X, endPoint.X) + radius;
            int centerY = Math.Min(startPoint.Y, endPoint.Y) + radius;

            // Calculate the start and end points of the arc
            double startAngle = Math.Atan2(startPoint.Y - centerY, startPoint.X - centerX);
            double endAngle = Math.Atan2(endPoint.Y - centerY, endPoint.X - centerX);

            // Convert the angles from radians to degrees
            startAngle = startAngle * (180 / Math.PI);
            endAngle = endAngle * (180 / Math.PI);

            // Ensure that the start angle is always less than the end angle
            if (startAngle > endAngle)
            {
                double temp = startAngle;
                startAngle = endAngle;
                endAngle = temp;
            }
           
            // Calculate the coordinates of the start and end points
            Point start = new Point((int)(centerX + radius * Math.Cos(startAngle)),
                                    (int)(centerY + radius * Math.Sin(startAngle)));
            Point end = new Point((int)(centerX + radius * Math.Cos(endAngle)),
                                  (int)(centerY + radius * Math.Sin(endAngle * Math.PI/1080)));
            end.X = endPoint.X;
      
            // Draw the select points at the start and end points of the arc
            graphics.FillRectangle(brush, new Rectangle(start.X - 5, start.Y + 10, 10, 10));
            graphics.FillRectangle(brush, new Rectangle(end.X - 5, end.Y - 10, 10, 10));

        }

       

        public static void DrawSelectPointsPolygon(Graphics graphics, Brush brush, List<Point> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                graphics.FillRectangle(brush, new Rectangle(points[i].X - 5, points[i].Y - 5, 10, 10));
           
            }
        }

        public static void DrawSelectFrame(Graphics graphics, Pen framePen, Rectangle selectZone)
        {
        
            graphics.DrawRectangle(framePen, selectZone);
        }

        public static void DrawSelectedFrameCircle(Graphics graphics, Pen framePen, Rectangle circleRect)
        {
            int diameter = Math.Min(circleRect.Width, circleRect.Height);
            int x = circleRect.X + (circleRect.Width - diameter) / 2;
            int y = circleRect.Y + (circleRect.Height - diameter) / 2;
            Rectangle rect = new Rectangle(x, y, diameter, diameter);
            graphics.DrawRectangle(framePen, rect);
        }
    }
}
