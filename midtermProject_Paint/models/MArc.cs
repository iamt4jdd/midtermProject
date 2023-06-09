﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace midtermProject_Paint.models
{
    public class MArc : Shape
    {
    
        public MArc()
        {
            name = "Arc";
        }

        public MArc(Color color)
        {
            name = "Arc";
            this.color = color;
        }

        public override void drawShape(Graphics graphic)
        {

            using (GraphicsPath path = graphicsPath)
            {
                using (Pen myPen = new Pen(color, width))
                {
                    if (isDash) myPen.DashStyle = dashStyle;
                    graphic.DrawPath(myPen, path);
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
                int startAngle = 0;
                int sweepAngle = -180;
               
                    if (startPoint.Y > endPoint.Y) // If startPoint is below endPoint
                    {
                        startAngle = 0;
                        sweepAngle = 180;
                    }
                    if (Math.Abs(endPoint.Y - startPoint.Y) == 0 && Math.Abs(endPoint.X - startPoint.X) == 0)
                    {
                        Rectangle rect = new Rectangle(
                         Math.Min(startPoint.X, endPoint.X),
                         Math.Min(startPoint.Y, endPoint.Y),
                         Math.Abs(endPoint.X - startPoint.X + 10),
                         Math.Abs(endPoint.Y - startPoint.Y + 10));
                        path.AddArc(rect, startAngle, sweepAngle);
                    }
                    else if (Math.Abs(endPoint.Y - startPoint.Y) == 0)
                    {
                        Rectangle rect = new Rectangle(
                         Math.Min(startPoint.X, endPoint.X),
                         Math.Min(startPoint.Y, endPoint.Y),
                         Math.Abs(endPoint.X - startPoint.X),
                         Math.Abs(endPoint.Y - startPoint.Y + 10));
                        path.AddArc(rect, startAngle, sweepAngle);
                    }
                    else if (Math.Abs(endPoint.X - startPoint.X) == 0)
                    {
                        Rectangle rect = new Rectangle(
                        Math.Min(startPoint.X, endPoint.X),
                        Math.Min(startPoint.Y, endPoint.Y),
                        Math.Abs(endPoint.X - startPoint.X + 10),
                        Math.Abs(endPoint.Y - startPoint.Y));
                        path.AddArc(rect, startAngle, sweepAngle);
                    }
                    else
                    {
                        Rectangle rect = new Rectangle(
                          Math.Min(startPoint.X, endPoint.X),
                          Math.Min(startPoint.Y, endPoint.Y),
                          Math.Abs(endPoint.X - startPoint.X),
                          Math.Abs(endPoint.Y - startPoint.Y));
                        path.AddArc(rect, startAngle, sweepAngle);
                    }
                
                return path;
            }
        }

    }
}
