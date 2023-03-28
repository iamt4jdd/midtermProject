using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using midtermProject_Paint.utilities;
using midtermProject_Paint.models;

namespace midtermProject_Paint.controller.Draw
{
    interface IDrawGraphic
    {
        public void getDrawing(Graphics graphic, Pen myPen);

        public void onClickMouseDown(Point point);


        public void onClickMouseMove(Point point);


        public void onClickMouseUp(Point point);


        public void onClickDrawLine();


        public void onClickDrawRectangle();


        public void onClickDrawEllipse();

        public void onClickDrawCircle();

        public void onClickDrawPolygon();
       

        public void onClickStopDrawing(MouseButtons mouse);
       
    }
}
