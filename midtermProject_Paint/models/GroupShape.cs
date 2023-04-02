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

        public Shape this[int index]
        {
            get
            {
                return shapes[index];
            }
            set
            {
                shapes[index] = value;
            }
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
                        Rectangle rectangle = new Rectangle(Math.Min(startPoint.X, endPoint.X),
                            Math.Min(startPoint.Y, endPoint.Y),
                            Math.Abs(endPoint.X - startPoint.X),
                            Math.Abs(endPoint.Y - startPoint.Y));
                        path.AddRectangle(rectangle);
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

                        path.AddRectangle(new RectangleF(rect.startPoint.X,
                            rect.startPoint.Y,
                            rect.endPoint.X - rect.startPoint.X,
                            rect.endPoint.Y - rect.startPoint.Y));
                    }
                    else if (shapes[i] is MPolygon)
                    {
                        MPolygon polygon = (MPolygon)shapes[i];
                        path.AddPolygon(polygon.points.ToArray());
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
                            using (Pen pen = new Pen(shapes[i].color, shapes[i].width))
                            {
                                graphic.DrawPath(pen, path);
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
                        using (Pen pen = new Pen(shapes[i].color, shapes[i].width))
                        {
                            graphic.DrawPath(pen, path);
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
                if (shapes[i] is GroupShape)
                {
                    GroupShape group = (GroupShape)shapes[i];
                    group.moveShape(distance);
                }
                else
                {
                    shapes[i].moveShape(distance);
                }
            }
            startPoint = new Point(startPoint.X + distance.X, startPoint.Y + distance.Y);
            endPoint = new Point(endPoint.X + distance.X, endPoint.Y + distance.Y);
        }

        protected override System.Drawing.Drawing2D.GraphicsPath graphicsPath
        {
            get { throw new NotImplementedException(); }
        }
    }
}
