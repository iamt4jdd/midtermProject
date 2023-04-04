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
        List<Shape> selectedShapeList = new List<Shape>();
        Color color;
        int width;
        bool isMouseDown;
        bool isFill, isDash, isPolygon, isMoving = false, isCtrlPressed = false;
        Shape selectedShape, deleteShape;
        Point previousPoint;

        Brush MovingBrush = new SolidBrush(Color.FromArgb(61, 165, 129));
        Pen MovingFrame = new Pen(Color.FromArgb(0, 30, 81), 1.5f)
        {
            DashPattern = new float[] { 3, 3, 3, 3 },
        };
      

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
            color = Color.Black;
            width = 3;
            myPen = new Pen(color, width);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        //Drawing implementation
        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            // DrawGraphic.getDrawing(graphic, myPen);
            shapeList.ForEach((shape) =>
            {
                shape.drawShape(e.Graphics);
                if (graphicType == GraphicType.Group)
                {
                    if (shape.isSelected == true)
                    {
                        if (shape is MPolygon polygon)
                        {
                            SelectFrame.DrawSelectPointsPolygon(e.Graphics, MovingBrush, polygon.points);
                        }
                        else if (shape is MLine)
                        {
                            SelectFrame.DrawSelectPointsLine(e.Graphics, MovingBrush,
                                                         shape.startPoint,
                                                         shape.endPoint);
                        }
                        else if (shape is MArc)
                        {
                            //SelectFrame.DrawSelectPointsArc(e.Graphics, MovingBrush,
                            //                             selectedShape.startPoint,
                            //                             selectedShape.endPoint);
                        }
                        else
                        {
                            SelectFrame.DrawSelectPoints(e.Graphics, MovingBrush,
                                                         shape.startPoint,
                                                         shape.endPoint);
                        }
                        if (!(shape is MLine) && !(shape is MArc))
                        {
                            
                                SelectFrame.DrawSelectFrame(e.Graphics, MovingFrame,
                                new Rectangle(shape.startPoint.X,
                                shape.startPoint.Y,
                                shape.endPoint.X - shape.startPoint.X,
                                shape.endPoint.Y - shape.startPoint.Y));
                            
                        }
                        graphicType = GraphicType.Select;
                        shape.isSelected = false;
                    }
                    else
                    {
                        shape.drawShape(e.Graphics);
                    }

                }
                else if (selectedShape != null || isMoving)
                {
                    
                    selectedShapeList.ForEach((selectedShape) =>
                    {   
                        
                        if (selectedShape is MPolygon polygon)
                        {
                            SelectFrame.DrawSelectPointsPolygon(e.Graphics, MovingBrush, polygon.points);
                        }
                        else if (selectedShape is MLine)
                        {
                            SelectFrame.DrawSelectPointsLine(e.Graphics, MovingBrush,
                                                         selectedShape.startPoint,
                                                         selectedShape.endPoint);
                        }
                        else if (selectedShape is MArc)
                        {
                            //SelectFrame.DrawSelectPointsArc(e.Graphics, MovingBrush,
                            //                             selectedShape.startPoint,
                            //                             selectedShape.endPoint);
                        }
                        else 
                        {
                            SelectFrame.DrawSelectPoints(e.Graphics, MovingBrush,
                                                         selectedShape.startPoint,
                                                         selectedShape.endPoint);
                        }
                        if (!(selectedShape is MLine) && !(selectedShape is MArc))
                        {                    
                            if (selectedShape.startPoint.X < selectedShape.endPoint.X 
                            && selectedShape.startPoint.Y < selectedShape.endPoint.Y)
                            {
                                SelectFrame.DrawSelectFrame(e.Graphics, MovingFrame,
                                new Rectangle(selectedShape.startPoint.X,
                                selectedShape.startPoint.Y,
                                selectedShape.endPoint.X - selectedShape.startPoint.X,
                                selectedShape.endPoint.Y - selectedShape.startPoint.Y));
                            }
                            else if(selectedShape.startPoint.X > selectedShape.endPoint.X
                            && selectedShape.startPoint.Y < selectedShape.endPoint.Y)
                            {
                                SelectFrame.DrawSelectFrame(e.Graphics, MovingFrame,
                                new Rectangle(selectedShape.endPoint.X,
                                selectedShape.startPoint.Y,
                                selectedShape.startPoint.X - selectedShape.endPoint.X,
                                selectedShape.endPoint.Y - selectedShape.startPoint.Y));
                            }
                            else if (selectedShape.startPoint.X < selectedShape.endPoint.X 
                            && selectedShape.startPoint.Y > selectedShape.endPoint.Y)
                            {
                                SelectFrame.DrawSelectFrame(e.Graphics, MovingFrame,
                                new Rectangle(selectedShape.startPoint.X,
                                selectedShape.endPoint.Y,
                                selectedShape.endPoint.X - selectedShape.startPoint.X,
                                selectedShape.startPoint.Y - selectedShape.endPoint.Y));
                            }
                            else
                            {
                                SelectFrame.DrawSelectFrame(e.Graphics, MovingFrame,
                                new Rectangle(selectedShape.endPoint.X,
                                selectedShape.endPoint.Y,
                                selectedShape.startPoint.X - selectedShape.endPoint.X,
                                selectedShape.startPoint.Y - selectedShape.endPoint.Y));
                            }
                        }
                        
                    });
                    
                }
                else shape.drawShape(e.Graphics);
            });



        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                isCtrlPressed = true;
            }

            if (graphicType == GraphicType.Select)
            {
                if (isCtrlPressed)
                {
                   
                    if (selectedShape == null || !selectedShapeList.Contains(selectedShape))
                    {   
                        for (int i = shapeList.Count - 1; i >= 0; i--)
                        {
                            if (shapeList[i].isSelect(e.Location))
                            {
                                
                                selectedShapeList.Add(shapeList[i]);
                                selectedShape = shapeList[i];
                                previousPoint = e.Location;
                                isMoving = true;
                                break;
                            }
                        }
                       
                    }
                    
                    else
                    {
                       
                        selectedShapeList.Remove(selectedShape);
                        selectedShape = null;
                        isMoving = false;
                    }
                }
                else 
                {
                    for (int i = 0; i < shapeList.Count; i++)
                    {
                        if (shapeList[i].isSelect(e.Location))
                        {
                            selectedShape = shapeList[i];
                            selectedShapeList.Clear();
                            selectedShapeList.Add(selectedShape);
                            previousPoint = e.Location;
                            isMoving = true;
                        }
                        else
                        {
                            if (selectedShape != shapeList[i])
                            {
                                selectedShapeList.Remove(shapeList[i]);
                            }
                        }
                    }
                }
            }


    
            isMouseDown = true;
            switch (graphicType)
            {
                case GraphicType.Line:
                    addShape(new MLine
                    {
                        startPoint = e.Location,
                        endPoint = e.Location,
                        width = width,
                        color = color,
                        isDash = isDash
                    });
                    break;
                case GraphicType.Rectangle:
                    addShape(new MRectangle
                    {
                        startPoint = e.Location,
                        endPoint = e.Location,
                        width = width,
                        color = color,
                        isFill = isFill,
                        isDash = isDash
                    });
                    break;
                case GraphicType.Ellipse:
                    addShape(new MEllipse
                    {
                        startPoint = e.Location,
                        endPoint = e.Location,
                        width = width,
                        color = color,
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
                    addShape(new MArc
                    {
                        startPoint = e.Location,
                        endPoint = e.Location,
                        width = width,
                        color = color,
                        isFill = isFill,
                        isDash = isDash
                    });
                    break;
                case GraphicType.Polygon:
                    if (graphicType == GraphicType.Polygon && !isPolygon)
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
                     
                    }
                    isMouseDown = false;
                    mainPanel.Invalidate();
                    break;
                default:
                    break;


            }




        }

        private void mainPanel_MouseMove(object sender, MouseEventArgs e)
        {

            if (selectedShape != null && selectedShape.isInside == true && graphicType == GraphicType.Select)
            {
                this.Cursor = Cursors.SizeAll;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }

            if (isMoving && graphicType == GraphicType.Select)
            {
                if(selectedShape != null)
                {
                    var distance = new Point(e.X - previousPoint.X, e.Y - previousPoint.Y);
                    selectedShape.moveShape(distance);
                    previousPoint = e.Location;
                    mainPanel.Invalidate();
                 
                    
                }
            }
           
        
            if (isMouseDown && !isMoving && graphicType != GraphicType.Select)
            {
                shapeList[shapeList.Count - 1].endPoint = e.Location;
                this.mainPanel.Refresh();
            }
            if (graphicType == GraphicType.Polygon && isPolygon)
            {
          
                    MPolygon polygon = shapeList[shapeList.Count - 1] as MPolygon;
                    polygon.points[polygon.points.Count - 1] = e.Location;
                    this.mainPanel.Refresh();
                
            }

            
        }
       
            
        private void mainPanel_MouseUp(object sender, MouseEventArgs e)
        {
        
            if (Control.ModifierKeys == Keys.Control)
            {
                isCtrlPressed = false;
            }

            if (isMoving)
            {
                deleteShape = selectedShape;
               
                selectedShape = null;
                isMoving = false;
            }
           
            if (graphicType != GraphicType.Polygon)
                isMouseDown = false;
                
        }

        private void mainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (graphicType == GraphicType.Polygon && isPolygon == true)
                {
                    MPolygon polygon = shapeList[shapeList.Count - 1] as MPolygon;
                    polygon.points.Remove(polygon.points[polygon.points.Count - 1]);
                    isPolygon = false;
                    this.mainPanel.Refresh();

                }
               
            }

           
        }
      

      
        //Color and width handler
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

        //Select Drawing object and Drawing mode
        private void lineBtn_Click(object sender, EventArgs e)
        {
            graphicType = GraphicType.Line;
        }

        private void ellipseBtn_Click(object sender, EventArgs e)
        {    
            graphicType = GraphicType.Ellipse;
        }

        private void rectangleBtn_Click(object sender, EventArgs e)
        {
            graphicType = GraphicType.Rectangle;
        }

        private void circleBtn_Click(object sender, EventArgs e)
        {
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


        private void groupBtn_Click(object sender, EventArgs e)
        {
            graphicType = GraphicType.Group;
            if (selectedShapeList.Count() > 1)
            {
                GroupShape group = new GroupShape();
                selectedShapeList.ForEach((shape) =>
                {
                    group.addShape(shape);
                    shapeList.Remove(shape);
                });
                group.LinkShapes();
                group.isSelected = true;
                shapeList.Add(group);
                deleteShape = group;
                selectedShapeList.Clear();
                this.mainPanel.Invalidate();
                Console.WriteLine(selectedShapeList.Count());
            }
            

        }
        
        private void unGroupBtn_Click(object sender, EventArgs e)
        {

            GroupShape group = new GroupShape();
            group = (GroupShape)deleteShape;
            group.UnGroup(shapeList);
            shapeList.Remove(group);
            this.mainPanel.Invalidate();
            deleteShape = null;
            graphicType = GraphicType.Select;



        }

        private void eraseBtn_Click(object sender, EventArgs e)
        {
            graphicType = GraphicType.Select;
            shapeList.Remove(deleteShape);
            selectedShapeList.ForEach((shape) =>
            {
                shapeList.Remove(shape);
            });
            selectedShapeList.Clear();
            this.mainPanel.Invalidate();
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            graphicType = GraphicType.Select;
        }

        //Helper
        //--------------------------------\\
        private void addShape(Shape shape)
        {
            shapeList.Add(shape);
        }
        
        public void setCursor(Cursor cursor)
        {
            mainPanel.Cursor = Cursor;
        }
    }
}