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

        public override void drawShape(Graphics graphic)
        {

        }

        public override bool isSelect(Point point)
        {
            return true;
        }

        public override void moveShape(Point distance)
        {

        }

        protected override GraphicsPath graphicsPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();
                path.AddLine(startPoint, endPoint);
                return path;
            }
        }
    }
}
