using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midtermProject_Paint.models
{
    public static class SelectFrame
    {
        public static void DrawRectangle(this Graphics g, Pen pen, Rectangle rect) =>
           g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);

        public static void DrawSelectPoints(Graphics graphics, Brush brush, Point point0, Point point1)
        {
          
            graphics.FillRectangle(brush, new Rectangle(point0.X - 5, point0.Y - 5, 10, 10));
            graphics.FillRectangle(brush, new Rectangle(point1.X - 5, point1.Y - 5, 10, 10));
            graphics.FillRectangle(brush, new Rectangle(Math.Max(point0.X, point1.X) - 4, Math.Min(point0.Y, point1.Y) - 4, 10, 10));
            graphics.FillRectangle(brush, new Rectangle(Math.Min(point0.X, point1.X) - 4, Math.Max(point0.Y, point1.Y) - 4, 10, 10));
        }

        public static void DrawSelectPointsLine(Graphics graphics, Brush brush, Point point0, Point point1)
        {
 
            graphics.FillRectangle(brush, new Rectangle(point0.X - 5, point0.Y - 5, 10, 10));
            graphics.FillRectangle(brush, new Rectangle(point1.X - 5, point1.Y - 5, 10, 10));
           
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
