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
    public class MCircle : MEllipse
    {

        public MCircle()
        {
            name = "Circle";
        }

        public MCircle(Color color)
        {
            name = "Circle";
            this.color = color;
        }

        protected override GraphicsPath graphicsPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                int Diameter = ((endPoint.X - startPoint.X) + (endPoint.Y - startPoint.Y)) / 2;
                path.AddEllipse(new Rectangle(startPoint.X, startPoint.Y, Diameter, Diameter));
                endPoint = new Point(startPoint.X + Diameter, startPoint.Y + Diameter);
                return path;
            }
        }

    }
}
