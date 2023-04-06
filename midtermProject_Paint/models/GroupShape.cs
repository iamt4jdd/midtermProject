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
    public class GroupShape : Shape
    {
        public List<Shape> shapes = new List<Shape>();

        public GroupShape()
        {
            this.name = "Group";
        }
        
        
        private GraphicsPath[] graphicsPaths
        {
            get
            {
                GraphicsPath[] paths = new GraphicsPath[shapes.Count];

                for (int i = 0; i < shapes.Count; i++)
                {
                    GraphicsPath path = new GraphicsPath();
                    if (shapes[i] is MLine)
                    {
                        MLine line = (MLine)shapes[i];
                        path.AddLine(line.startPoint, line.endPoint);
                    }
                    else if (shapes[i] is MArc)
                    {
                        MArc arc = (MArc)shapes[i];
                        int startAngle = 0;
                        int sweepAngle = -180;

                        if (startPoint.Y > endPoint.Y) // If startPoint is below endPoint
                        {
                            startAngle = 0;
                            sweepAngle = 180;
                        }
                        if (Math.Abs(arc.endPoint.Y - arc.startPoint.Y) == 0 && Math.Abs(arc.endPoint.X - arc.startPoint.X) == 0)
                        {
                            Rectangle rect = new Rectangle(
                             Math.Min(arc.startPoint.X, arc.endPoint.X),
                             Math.Min(arc.startPoint.Y, arc.endPoint.Y),
                             Math.Abs(arc.endPoint.X - arc.startPoint.X + 10),
                             Math.Abs(arc.endPoint.Y - arc.startPoint.Y + 10));
                            path.AddArc(rect, startAngle, sweepAngle);
                        }
                        else if (Math.Abs(arc.endPoint.Y - arc.startPoint.Y) == 0)
                        {
                            Rectangle rect = new Rectangle(
                             Math.Min(arc.startPoint.X, arc.endPoint.X),
                             Math.Min(arc.startPoint.Y, arc.endPoint.Y),
                             Math.Abs(arc.endPoint.X - arc.startPoint.X),
                             Math.Abs(arc.endPoint.Y - arc.startPoint.Y + 10));
                            path.AddArc(rect, startAngle, sweepAngle);
                        }
                        else if (Math.Abs(arc.endPoint.X - arc.startPoint.X) == 0)
                        {
                            Rectangle rect = new Rectangle(
                            Math.Min(arc.startPoint.X, arc.endPoint.X),
                            Math.Min(arc.startPoint.Y, arc.endPoint.Y),
                            Math.Abs(arc.endPoint.X - arc.startPoint.X + 10),
                            Math.Abs(arc.endPoint.Y - arc.startPoint.Y));
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


                      
                    }
                    else if (shapes[i] is MEllipse)
                    {
                        MEllipse ellipse = (MEllipse)shapes[i];
                        path.AddEllipse(new Rectangle(ellipse.startPoint.X,
                            ellipse.startPoint.Y,
                            ellipse.endPoint.X - ellipse.startPoint.X,
                            ellipse.endPoint.Y - ellipse.startPoint.Y));
                    }
                    else if (shapes[i] is MRectangle)
                    {
                        MRectangle rect = (MRectangle)shapes[i];

                        path.AddRectangle(new RectangleF(Math.Min(rect.startPoint.X, rect.endPoint.X),
                            Math.Min(rect.startPoint.Y, rect.endPoint.Y),
                            Math.Abs(rect.endPoint.X - rect.startPoint.X),
                            Math.Abs(rect.endPoint.Y - rect.startPoint.Y)));
                    }
                    else if (shapes[i] is MPolygon)
                    {
                        MPolygon polygon = (MPolygon)shapes[i];
                        path.AddPolygon(polygon.points.ToArray());
                    }
                    else if (shapes[i] is MPen pen)
                    {
                        for (int j = 0; j < pen.points.Count - 1; j++)
                        {
                            path.AddLine(pen.points[j], pen.points[j + 1]);
                        }
                    }
                    else if (shapes[i] is GroupShape)
                    {
                        GroupShape group = (GroupShape)shapes[i];
                        for (int j = 0; j < group.graphicsPaths.Length; j++)
                        {
                            path.AddPath(group.graphicsPaths[j], false);
                        }
                    }
                    paths[i] = path;
                }

                return paths;
            }
        }

        public void addShape(Shape shape)
        {
            shapes.Add(shape);
        }

        public override void drawShape(Graphics graphic)
        {
            GraphicsPath[] paths = graphicsPaths;
            for (int i = 0; i < paths.Length; i++)
            {
                using (GraphicsPath path = paths[i])
                {
                    if (shapes[i] is MRectangle || shapes[i] is MEllipse || shapes[i] is MPolygon)
                    {
                        if (shapes[i].isFill)
                        {
                            using (Brush brush = new SolidBrush(shapes[i].color))
                            {
                                graphic.FillPath(brush, path);
                            }
                        }
                        else
                        {

                            using (Pen myPen = new Pen(shapes[i].color, shapes[i].width))
                            {
                                graphic.DrawPath(myPen, path);
                            }
                        }
                    }
                    else if (shapes[i] is GroupShape)
                    {
                        GroupShape group = (GroupShape)shapes[i];
                        group.drawShape(graphic);
                    }
                   
                    else
                    {
                        using (Pen myPen = new Pen(shapes[i].color, shapes[i].width))
                        {
                            graphic.DrawPath(myPen, path);
                        }
                    }
                }
            }
        }

        public override bool isSelect(Point point)
        {
          
            GraphicsPath[] paths = graphicsPaths;
            for (int i = 0; i < paths.Length; i++)
            {
                using (GraphicsPath path = paths[i])
                {
                    if (shapes[i] is MRectangle || shapes[i] is MEllipse)
                    {
                        if (((MRectangle)shapes[i]).isFill)
                        {
                            using (Brush brush = new SolidBrush(Color.Black))
                            {
                                if (path.IsVisible(point))
                                {
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            using (Pen pen = new Pen(Color.Black, width + 3))
                            {
                                if (path.IsOutlineVisible(point, pen))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    else if (!(shapes[i] is GroupShape))
                    {
                        using (Pen pen = new Pen(Color.Black, width + 3))
                        {
                            if (path.IsOutlineVisible(point, pen))
                            {
                                return true;
                            }
                        }
                    }
                    else if (shapes[i] is GroupShape)
                    {
                        GroupShape group = (GroupShape)shapes[i];
                        return group.isSelect(point);
                    }
                }
            }

            return false;
        }

        public override void moveShape(Point distance)
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                
                    shapes[i].moveShape(distance);
                
            }
            startPoint = new Point(startPoint.X + distance.X, startPoint.Y + distance.Y);
            endPoint = new Point(endPoint.X + distance.X, endPoint.Y + distance.Y);
        }

        public void LinkShapes()
        {
            int minX = int.MaxValue;
            int minY = int.MaxValue;
            int maxX = int.MinValue;
            int maxY = int.MinValue;

            for (int i = 0; i < this.shapes.Count; i++)
            {
                Shape shape = shapes[i];

                if (shape is MPolygon polygon)
                {
                    polygon.LinkPoints();
                }
                if (shape.startPoint.X < minX)
                {
                    minX = shape.startPoint.X;
                }
                if (shape.endPoint.X < minX)
                {
                    minX = shape.endPoint.X;
                }

                if (shape.startPoint.Y < minY)
                {
                    minY = shape.startPoint.Y;
                }
                if (shape.endPoint.Y < minY)
                {
                    minY = shape.endPoint.Y;
                }

                if (shape.startPoint.X > maxX)
                {
                    maxX = shape.startPoint.X;
                }
                if (shape.endPoint.X > maxX)
                {
                    maxX = shape.endPoint.X;
                }

                if (shape.startPoint.Y > maxY)
                {
                    maxY = shape.startPoint.Y;
                }
                if (shape.endPoint.Y > maxY)
                {
                    maxY = shape.endPoint.Y;
                }
            }

            this.startPoint = new Point(minX, minY);
            this.endPoint = new Point(maxX, maxY);
        }
        public void UnGroup(List<Shape> Shapes)
        {
            foreach (var shape in shapes)
            {
                shape.isSelected = false;
                Shapes.Add(shape);
            }
        }
        protected override GraphicsPath graphicsPath
        {
            get { throw new NotImplementedException(); }
        }
    }
}
