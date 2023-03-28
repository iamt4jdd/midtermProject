using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using midtermProject_Paint.models;
using midtermProject_Paint.controller.Draw;
using midtermProject_Paint.utilities;


namespace midtermProject_Paint
{
    public partial class Form1 : Form
    {
        //private IDrawGraphic DrawGraphic;
        //Graphics graphic;
        Pen myPen;
        GraphicType graphicType;
        List<Shape> shapeList = new List<Shape>();
        Color color = Color.Black;
        int width;
        bool isMouseDown;
        bool isFill, isDash, isPolygon;
        Shape myShape;
        bool moving;
        Point point;
        

        public Form1()
        {
            InitializeComponent();
            initComponents();
            
        }

        private void initComponents()
        {
            //DrawGraphic = new DrawGraphic();
            mainPanel.SetDoubleBuffered();
            //graphic = this.mainPanel.CreateGraphics();
            width = 5;
            myPen = new Pen(color, width);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void lineBtn_Click(object sender, EventArgs e)
        {
            // DrawGraphic.onClickDrawLine();
             graphicType = GraphicType.Line;
        }

        private void ellipseBtn_Click(object sender, EventArgs e)
        {
            // DrawGraphic.onClickDrawEllipse();
             graphicType = GraphicType.Ellipse;
        }

        private void rectangleBtn_Click(object sender, EventArgs e)
        {
            // DrawGraphic.onClickDrawRectangle();
             graphicType = GraphicType.Rectangle;
        }

        private void circleBtn_Click(object sender, EventArgs e)
        {
            //DrawGraphic.onClickDrawCircle();
             graphicType = GraphicType.Circle;
        }

        private void arcBtn_Click(object sender, EventArgs e)
        {
            graphicType = GraphicType.Arc;
        }

        private void polygonBtn_Click(object sender, EventArgs e)
        {
            graphicType = GraphicType.Polygon;
            isPolygon = false;

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            // DrawGraphic.getDrawing(graphic, myPen);
           
                shapeList.ForEach((shape) =>
                {
                    shape.drawShape(e.Graphics);
                });
            
            
        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            //for (var i = shapeList.Count - 1; i >= 0; i--)
            //{
            //    if (shapeList[i].isSelect(e.Location))
            //    {
            //        myShape = shapeList[i];
             
                
            //        break;
            //    }
            //}
            //if (myShape != null)
            //{
            //    moving = true;
            //    point = e.Location;
            //}
            base.OnMouseDown(e);
            // DrawGraphic.onClickMouseDown(e.Location);
            isMouseDown = true;
            switch (graphicType)
            {
                case GraphicType.Line:
                    addShape(new MLine
                    {
                        startPoint = e.Location,
                        endPoint = e.Location,
                        width =  width,
                        color =  color,
                        isDash = isDash
                    });
                    break;
                case GraphicType.Rectangle:
                    addShape(new MRectangle
                    {
                        startPoint = e.Location,
                        endPoint = e.Location,
                        width =  width,
                        color =  color,
                        isFill = isFill,
                        isDash = isDash
                    });
                    break;
                case GraphicType.Ellipse:
                    addShape(new MEllipse
                    {
                        startPoint = e.Location,
                        endPoint = e.Location,
                        width =  width,
                        color =  color,
                        isFill = isFill,
                        isDash = isDash
                    });
                    break;
                case GraphicType.Circle:
                    addShape(new MCircle
                    {
                        startPoint = e.Location,
                        endPoint = e.Location,
                        width = width,
                        color = color,
                        isFill = isFill,
                        isDash = isDash
                    });
                    break;
                case GraphicType.Arc:
                    if (graphicType == GraphicType.Arc)
                    {
                        MArc arc = new MArc
                        {
                            startPoint = e.Location,
                            endPoint = e.Location,
                            width = width,
                            color = color,
                            isFill = isFill,
                            isDash = isDash
                        };
                        arc.points.Add(e.Location);
                        arc.points.Add(e.Location);
                        addShape(arc);
                    }
                    else
                    {
                        MArc arc = shapeList[shapeList.Count - 1] as MArc;
                        arc.points[arc.points.Count - 1] = e.Location;
                        arc.points.Add(e.Location);
                    }
                    isMouseDown = false;
                    break;
                case GraphicType.Polygon:
                    if(graphicType == GraphicType.Polygon && !isPolygon)
                    {
                        MPolygon polygon = new MPolygon
                        {
                            startPoint = e.Location,
                            endPoint = e.Location,
                            width = width,
                            color = color,
                            isFill = isFill,
                            isDash = isDash
                    };
                        polygon.points.Add(e.Location);
                        polygon.points.Add(e.Location);
                        addShape(polygon);
                        isPolygon = true;
                    }
                    else
                    {
                        MPolygon polygon = shapeList[shapeList.Count - 1] as MPolygon;
                        polygon.points[polygon.points.Count - 1] = e.Location;
                        polygon.points.Add(e.Location);
                        Console.WriteLine(polygon);
                        Console.WriteLine(polygon.points);
                    }
                    isMouseDown = false;
                    mainPanel.Invalidate();
                    break;
                    default:
                    break;
                 
                    
            }

            Console.WriteLine(shapeList.Count);
   
        }

        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            //if (moving)
            //{
            //    var d = new PointF(e.X - point.X, e.Y - point.Y);
            //    myShape.Move(d);
            //    PreviousPoint = e.Location;
            //    Main_PBox.Invalidate();
            //}
            base.OnMouseMove(e);
            //DrawGraphic.onClickMouseMove(e.Location);
            if (isMouseDown)
            {
                shapeList[shapeList.Count - 1].endPoint = e.Location;
                this.mainPanel.Refresh();
            }
            if (graphicType == GraphicType.Polygon && isPolygon == true)
            {
          
                    MPolygon polygon = shapeList[shapeList.Count - 1] as MPolygon;
                    polygon.points[polygon.points.Count - 1] = e.Location;
                    this.mainPanel.Refresh();
                
            }
            else if (graphicType == GraphicType.Arc)
            {
                if (shapeList.Count > 0)
                {
                    MArc arc = shapeList[shapeList.Count - 1] as MArc;
                    arc.points[arc.points.Count - 1] = e.Location;
                    this.mainPanel.Refresh();
                }
            }
        }
       
            
        private void mainPanel_MouseUp(object sender, MouseEventArgs e)
        {
            //DrawGraphic.onClickMouseUp(e.Location);
             
            if(graphicType != GraphicType.Polygon)
            {
                isMouseDown = false;
            }
        }

        private void colordiaBtn_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                color = dlg.Color;
                currentColorBtn.BackColor = dlg.Color;
            }
        }

        private void btnWidth_ValueChanged(object sender, EventArgs e)
        {
            width = (int)btnWidth.Value;
        }


        //--------------------------------\\
        private void addShape(Shape shape)
        {
            shapeList.Add(shape);
        }

        private void brushBtn_Click(object sender, EventArgs e)
        {
            if (!isFill) { isFill = true; isDash = false; } else isFill = false;
        }

        private void penBtn_Click(object sender, EventArgs e)
        {
            isDash = false;
            isFill = false;
        }

       

        private void dashBtn_Click(object sender, EventArgs e)
        {
            if (!isDash) { isDash = true; isFill = false; } else isDash = false;
        }
    }
}