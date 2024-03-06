using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;

namespace TheBestPaintInTheWorld
{
    static class DrawShape
    {
        static public void CreateShape(Pen outline, SolidBrush fill, Graphics canvas, bool isFill, Point mouseUp, Point mouseDown, List<Shape> allShapes, ref Rectangle boundingBox, Shapes shapeToDraw)
        {
            var Height = Math.Abs(mouseUp.Y - mouseDown.Y);
            var Width = Math.Abs(mouseUp.X - mouseDown.X);
            AdjustingPositionOfShape(ref mouseUp, ref mouseDown);
            boundingBox = new Rectangle(mouseDown.X, mouseDown.Y, Width, Height);
            if (isFill)
            {
                CreateFillShape(outline, fill, canvas, allShapes, shapeToDraw, ref boundingBox);
            }
            else
            {
                CreateShapeWithoutFill(outline, canvas, allShapes, shapeToDraw, ref boundingBox);
            }
        }

        static private void AdjustingPositionOfShape(ref Point mouseUp, ref Point mouseDown)
        {

            if (((mouseUp.Y - mouseDown.Y) < 0) && ((mouseUp.X - mouseDown.X) < 0))
            {
                mouseDown.Y = mouseUp.Y;
                mouseDown.X = mouseUp.X;
            }
            else if ((mouseUp.Y - mouseDown.Y) < 0)
            {
                mouseDown.Y = mouseUp.Y;
            }
            else if ((mouseUp.X - mouseDown.X) < 0)
            {
                mouseDown.X = mouseUp.X;
            }
        }

        static private void CreateFillShape(Pen outline, SolidBrush fill, Graphics canvas, List<Shape> allShapes, Shapes shape, ref Rectangle boundingBox)
        {
            canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawFillShape(outline, fill, canvas, shape, boundingBox);
            var Shape = new Shape(outline, fill, shape, boundingBox);
            allShapes.Insert(0, Shape);
        }

        static private void CreateShapeWithoutFill(Pen outline, Graphics canvas, List<Shape> allShapes, Shapes shape, ref Rectangle boundingBox)
        {
            DrawShapeWithoutFill(outline, canvas, shape, boundingBox);
            var Shape = new Shape(outline, shape, boundingBox);
            allShapes.Insert(0, Shape);
        }

        static private void CircleSize(ref Rectangle boundingBox)
        {
            if (boundingBox.Height > boundingBox.Width)
            {
                boundingBox.Width = boundingBox.Height;
            }
            else
            {
                boundingBox.Height = boundingBox.Width;
            }
        }

        static public void ReDrawShapes(Graphics canvas, Color backgroundColor, List<Shape> allShapes)
        {
            canvas.Clear(backgroundColor);
            foreach (Shape shape in allShapes)
            {
                if (shape.IsFill)
                {
                    DrawFillShape(shape.Outline, shape.FillColor, canvas, shape.TypeOfShape, shape.BoundingBox);
                }
                else
                {
                    DrawShapeWithoutFill(shape.Outline, canvas, shape.TypeOfShape, shape.BoundingBox);
                }
            }
        }

        static private void DrawFillShape(Pen outline, SolidBrush fill, Graphics canvas, Shapes shape, Rectangle boundingBox)
        {
            canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            switch (shape)
            {
                case Shapes.Rectangle:
                    canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                    canvas.FillRectangle(fill, boundingBox);
                    canvas.DrawRectangle(outline, boundingBox);
                    break;

                case Shapes.Circle:
                    CircleSize(ref boundingBox);
                    canvas.FillEllipse(fill, boundingBox);
                    canvas.DrawEllipse(outline, boundingBox);
                    break;

                case Shapes.Elips:
                    canvas.FillEllipse(fill, boundingBox);
                    canvas.DrawEllipse(outline, boundingBox);
                    break;
            }
        }

        static private void DrawShapeWithoutFill(Pen outline, Graphics canvas, Shapes shape, Rectangle boundingBox)
        {
            canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            switch (shape)
            {
                case Shapes.Rectangle:
                    canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                    canvas.DrawRectangle(outline, boundingBox);
                    break;

                case Shapes.Circle:
                    CircleSize(ref boundingBox);
                    canvas.DrawEllipse(outline, boundingBox);
                    break;

                case Shapes.Elips:
                    canvas.DrawEllipse(outline, boundingBox);
                    break;
            }
        }
    }
}
