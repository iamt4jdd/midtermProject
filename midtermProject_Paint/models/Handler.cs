using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using midtermProject_Paint.utilities;
using midtermProject_Paint.models;

namespace midtermProject_Paint.models
{
    public class Handler
    {
        public static Handler instance;

 
        public List<Shape> shapeList { get; set; }

  
        public Shape shapeToMove { get; set; }

 
        public System.Drawing.Rectangle rectangleRegion;

       
        public bool isMouseDown { get; set; }

        public bool isMovingShape { get; set; }

 
        public bool isMovingMouse { get; set; }

        public bool isDrawingCurve { get; set; }

       
        public bool isDrawingPolygon { get; set; }

       
        public bool isDrawingPen { get; set; }

        public bool isDrawingEraser { get; set; }

        public bool isFill { get; set; }

       
        public bool isSave { get; set; }

        public bool isNotNone { get; set; }

     
        public bool isSelectAll { get; set; }

       
        public int pointToResize { get; set; }

        public GraphicType graphicType { get; set; }
        public Point cursorCurrent { get; set; }

      
        public Color color { get; set; }

        public int width { get; set; }

        private Handler()
        {
            shapeList = new List<Shape>();
            pointToResize = -1;
        }

        public static Handler getInstance()
        {
            if (instance == null) instance = new Handler();
            return instance;
        }

     
        public void addShape(Shape shape)
        {
            shapeList.Add(shape);
        }


        
    }
}
