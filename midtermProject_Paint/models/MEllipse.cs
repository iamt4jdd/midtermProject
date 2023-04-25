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
    public class MEllipse : MRectangle
    {
        public MEllipse()
        {
            name = "Ellipse";
        }

        public MEllipse(Color color)
        {
            name = "Ellipse";
            this.color = color;
        }

        protected override GraphicsPath graphicsPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(
                new Rectangle(startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y));
                return path;
            }
        }

    }
}
