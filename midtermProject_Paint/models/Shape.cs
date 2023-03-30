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

        public bool isFill { get; set; }

        public bool isDash { get; set; }

        public Color color { get; set; }

        public int width { get; set; }

        public abstract void drawShape(Graphics graphic);

        public abstract bool isSelect(Point point);

        public abstract void moveShape(Point distance);

        protected abstract GraphicsPath graphicsPath { get; }
        

    }
}
