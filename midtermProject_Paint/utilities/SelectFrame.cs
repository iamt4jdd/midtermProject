using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midtermProject_Paint.models { 

    public static class SelectFrame
    {
        public static void DrawRectangle(this Graphics g, Pen pen, Rectangle rect)
        {
            g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
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
    }
}
