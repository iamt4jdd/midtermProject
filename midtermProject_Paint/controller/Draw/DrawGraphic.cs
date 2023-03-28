using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using midtermProject_Paint.utilities;
using midtermProject_Paint.models;

namespace midtermProject_Paint.controller.Draw
{
    public class DrawGraphic : IDrawGraphic
    {

        Handler handler;

        public DrawGraphic()
        {
            handler = Handler.getInstance();
        }

        

        public void getDrawing(Graphics graphic, Pen myPen)
        {
            handler.shapeList.ForEach(shape =>
            {
                shape.drawShape(graphic);
            });
        }
        public void onClickMouseDown(Point point)
        {
            handler.isMouseDown = true;
            switch (handler.graphicType)
            {
                case GraphicType.Line:
                    handler.addShape(new MLine
                    {
                        startPoint = point,
                        endPoint = point,
                        width = handler.width,
                        color = handler.color
                    });
                    break;
                case GraphicType.Rectangle:
                    handler.addShape(new MRectangle
                    {
                        startPoint = point,
                        endPoint = point,
                        width = handler.width,
                        color = handler.color
                    });
                    break;
                case GraphicType.Ellipse:
                    handler.addShape(new MEllipse
                    {
                        startPoint = point,
                        endPoint = point,
                        width = handler.width,
                        color = handler.color
                    });
                    break;
                case GraphicType.Circle:
                    handler.addShape(new MCircle
                    {
                        startPoint = point,
                        endPoint = point,
                        width = handler.width,
                        color = handler.color
                    });
                    break;
                case GraphicType.Arc:
                    handler.addShape(new MArc
                    {
                        startPoint = point,
                        endPoint = point,
                        width = handler.width,
                        color = handler.color
                    });
                    break;
                case GraphicType.Polygon:
                    handler.addShape(new MPolygon
                    {
                        startPoint = point,
                        endPoint = point,
                        width = handler.width,
                        color = handler.color
                    });
                    break;
            }
        }

        public void onClickMouseMove(Point point)
        {
            if(handler.isMouseDown)
            {
                handler.shapeList[handler.shapeList.Count - 1].endPoint = point;
            }
        }

        public void onClickMouseUp(Point point)
        {
            handler.isMouseDown = false;
      
        }

        public void onClickDrawLine()
        {
            handler.graphicType = GraphicType.Line;
        }

        public void onClickDrawRectangle()
        {
            handler.graphicType = GraphicType.Rectangle;
        }

        public void onClickDrawEllipse()
        {
            handler.graphicType = GraphicType.Ellipse;
        }

        public void onClickDrawCircle()
        {
            handler.graphicType = GraphicType.Circle;
        }
        public void onClickDrawPolygon()
        {
            handler.graphicType = GraphicType.Polygon;
        }

        public void onClickStopDrawing(MouseButtons mouse)
        {

        }
    }
}
