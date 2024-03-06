using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Drawing2D;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Collections.Generic;
namespace TheBestPaintInTheWorld
{
    public partial class PaintWindow : Form
    {
        private Graphics canvas;
        private Rectangle boundingBox;
        private ResizeBox resizeBox = new ResizeBox();
        private List<Shape> allShapes = new List<Shape>();
        private bool isFill = false;
        private bool isShapeSelected = false;
        private bool isDraggingShape = false;
        private int selectedShapeIndex;
        private Pen outline = new Pen(Color.Black);
        private SolidBrush fill = new SolidBrush(Color.Black);
        private Point mouseDown;
        private Point mouseUp;
        private Color backgroundColor = Color.White;
        private Shapes shapeToDraw = Shapes.Rectangle;
        private ResizeMods resizeMod;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]

        private static extern bool ReleaseCapture();
        [DllImport("User32.dll")]

        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public PaintWindow()
        {
            InitializeComponent();
            canvas = CreateGraphics();
            outline.Width = 3.0f;
        }

        private void SizeBittonClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }


        private void HideButtonClick(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void ToolStripEraseClick(object sender, EventArgs e)
        {
            canvas.Clear(backgroundColor);
            allShapes.Clear();
        }

        private void ToolStripOutlineÑolorClick(object sender, EventArgs e)
        {
            if (isShapeSelected == false)
            {
                if (OutlineColorDialog.ShowDialog() == DialogResult.OK)
                {
                    outline.Color = OutlineColorDialog.Color;
                }
            }
            else
            {
                if (OutlineColorDialog.ShowDialog() == DialogResult.OK)
                {
                    allShapes[selectedShapeIndex].Outline.Color = OutlineColorDialog.Color;
                    DrawShape.ReDrawShapes(canvas, backgroundColor, allShapes);
                }
            }
        }

        private void ToolStripFillColorClick(object sender, EventArgs e)
        {
            if (FillColorDialog.ShowDialog() == DialogResult.OK)
            {
                var Shape = allShapes[selectedShapeIndex];
                SolidBrush FillColor = new SolidBrush(FillColorDialog.Color);
                Shape = new Shape(
                Shape.Outline,
                FillColor,
                Shape.TypeOfShape,
                Shape.BoundingBox
                );
                allShapes[selectedShapeIndex] = Shape;
                DrawShape.ReDrawShapes(canvas, backgroundColor, allShapes);
            }
        }

        private void ToolStripBackgroundColorClick(object sender, EventArgs e)
        {
            if (BackgroundColorDialog.ShowDialog() == DialogResult.OK)
            {
                backgroundColor = BackgroundColorDialog.Color;
                DrawShape.ReDrawShapes(canvas, backgroundColor, allShapes);
            }
        }

        private void PaintWindowMouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = e.Location;
            if (isShapeSelected == true)
            {
                if (IsPointIncludedInCurrentShape(mouseDown))
                {
                    isDraggingShape = true;
                }
                else
                {
                    DeterminateModeOfSizeChange();
                }
            }
        }

        private void PaintWindowMouseUp(object sender, MouseEventArgs e)
        {
            mouseUp = e.Location;
            if (isShapeSelected == false)
            {
                DrawShape.CreateShape(outline, fill, canvas, isFill, mouseUp, mouseDown, allShapes, ref boundingBox, shapeToDraw);
            }
            else
            {
                if (isDraggingShape == true)
                {
                    var HorizontalOffset = allShapes[selectedShapeIndex].BoundingBox.Location.X - mouseDown.X;
                    var VerticalOffset = allShapes[selectedShapeIndex].BoundingBox.Location.Y - mouseDown.Y;
                    var Shape = allShapes[selectedShapeIndex];
                    Shape.BoundingBox = new Rectangle(
                    mouseUp.X + HorizontalOffset,
                    mouseUp.Y + VerticalOffset,
                    Shape.BoundingBox.Width,
                    Shape.BoundingBox.Height
                    );
                    allShapes[selectedShapeIndex] = Shape;
                    DrawShape.ReDrawShapes(canvas, backgroundColor, allShapes);
                    var NewResizeBox = new ResizeBox(allShapes[selectedShapeIndex].BoundingBox);
                    resizeBox = NewResizeBox;
                    DrawResizeBox();
                    isDraggingShape = false;
                }
                else if (resizeMod != ResizeMods.None)
                {
                    ResizeShape(resizeMod);
                    resizeMod = ResizeMods.None;
                    DrawShape.ReDrawShapes(canvas, backgroundColor, allShapes);
                    DrawResizeBox();
                }
            }
        }


        private void ToolStripFillClick(object sender, EventArgs e)
        {
            if (isFill)
            {
                isFill = false;
            }
            else
            {
                isFill = true;
            }
        }

        private void ToolStripCircleClick(object sender, EventArgs e)
        {
            shapeToDraw = Shapes.Circle;
            ToolStripShapeSelection.Text = "Êðóã";
        }

        private void ToolStripElipsClick(object sender, EventArgs e)
        {
            shapeToDraw = Shapes.Elips;
            ToolStripShapeSelection.Text = "Ýëèïñ";
        }

        private void ToolStripRectangleClick(object sender, EventArgs e)
        {
            shapeToDraw = Shapes.Rectangle;
            ToolStripShapeSelection.Text = "Ïðÿìîóãîëüíèê";
        }

        private void PaintWindowMouseDoubleClick(object sender, MouseEventArgs e)
        {
            var click = e.Location;
            if (isShapeSelected == false)
            {
                if (IsPointIncludedInShape(click))
                {
                    SearchingForShapeInList(allShapes, click);
                    var NewResizeBox = new ResizeBox(allShapes[selectedShapeIndex].BoundingBox);
                    resizeBox = NewResizeBox;
                    DrawResizeBox();
                }
            }
            else
            {
                if (IsPointIncludedInShape(click))
                {
                    var IndexOfSelectedShapeBeforeMethod = selectedShapeIndex;
                    SearchingForShapeInList(allShapes, click);
                    if (IndexOfSelectedShapeBeforeMethod == selectedShapeIndex)
                    {
                        isShapeSelected = false;
                        Cursor = Cursors.Default;
                        DrawShape.ReDrawShapes(canvas, backgroundColor, allShapes);
                    }
                }
            }
        }

        private bool IsPointIncludedInCurrentShape(Point click)
        {
            if (allShapes[selectedShapeIndex].BoundingBox.Contains(click))
            {
                return true;
            }
            return false;
        }


        private void SearchingForShapeInList(List<Shape> allShapes, Point click)
        {
            for (int indexOfShape = 0; indexOfShape < allShapes.Count; indexOfShape++)
            {
                if (allShapes[indexOfShape].BoundingBox.Contains(click))
                {
                    isShapeSelected = true;
                    selectedShapeIndex = indexOfShape;
                    Cursor = Cursors.Hand;
                    break;
                }
            }
        }

        private void DrawResizeBox()
        {
            var DashPen = new Pen(Color.Black);
            DashPen.DashStyle = DashStyle.Dash;
            canvas.DrawRectangle(DashPen, resizeBox.MainResizeBox);
            canvas.FillRectangle(Brushes.Orange, resizeBox.TopLeftCornerBox);
            canvas.FillRectangle(Brushes.Orange, resizeBox.LeftSideBox);
            canvas.FillRectangle(Brushes.Orange, resizeBox.BottomLeftCornerBox);
            canvas.FillRectangle(Brushes.Orange, resizeBox.BottomSideBox);
            canvas.FillRectangle(Brushes.Orange, resizeBox.BottomRightCornerBox);
            canvas.FillRectangle(Brushes.Orange, resizeBox.RightSideBox);
            canvas.FillRectangle(Brushes.Orange, resizeBox.TopRightCornerBox);
            canvas.FillRectangle(Brushes.Orange, resizeBox.TopSideBox);
        }
        private bool IsPointIncludedInShape(Point click)
        {
            for (int IndexOfShape = 0; IndexOfShape < allShapes.Count; IndexOfShape++)
            {
                if (allShapes[IndexOfShape].BoundingBox.Contains(click))
                {
                    return true;
                }
            }
            return false;
        }

        private void DeterminateModeOfSizeChange()
        {
            if (resizeBox.TopLeftCornerBox.Contains(mouseDown))
            {
                resizeMod = ResizeMods.TopLeftCorner;
            }
            else if (resizeBox.LeftSideBox.Contains(mouseDown))
            {
                resizeMod = ResizeMods.LeftSide;
            }
            else if (resizeBox.BottomLeftCornerBox.Contains(mouseDown))
            {
                resizeMod = ResizeMods.BottomLeftCorner;
            }
            else if (resizeBox.BottomSideBox.Contains(mouseDown))
            {
                resizeMod = ResizeMods.BottomSide;
            }
            else if (resizeBox.BottomRightCornerBox.Contains(mouseDown))
            {
                resizeMod = ResizeMods.BottomRightCorner;
            }
            else if (resizeBox.RightSideBox.Contains(mouseDown))
            {
                resizeMod = ResizeMods.RightSide;
            }
            else if (resizeBox.TopRightCornerBox.Contains(mouseDown))
            {
                resizeMod = ResizeMods.TopRightCorner;
            }
            else if (resizeBox.TopSideBox.Contains(mouseDown))
            {
                resizeMod = ResizeMods.TopSide;
            }
            else
            {
                resizeMod = ResizeMods.None;
            }
        }

        private void ResizeShape(ResizeMods Mod)
        {
            var HeightChange = Math.Abs(mouseUp.Y - mouseDown.Y);
            var WidthChange = Math.Abs(mouseUp.X - mouseDown.X);
            var Shape = allShapes[selectedShapeIndex];
            switch (Mod)
            {
                case ResizeMods.TopLeftCorner:
                    Shape.BoundingBox = new Rectangle(
                    mouseUp.X,
                    mouseUp.Y,
                    Shape.BoundingBox.Width + WidthChange,
                    Shape.BoundingBox.Height + HeightChange
                    );
                    break;
                case ResizeMods.LeftSide:
                    Shape.BoundingBox = new Rectangle(
                    mouseUp.X,
                    Shape.BoundingBox.Y,
                    Shape.BoundingBox.Width + WidthChange,
                    Shape.BoundingBox.Height
                    );
                    break;
                case ResizeMods.BottomLeftCorner:
                    Shape.BoundingBox = new Rectangle(
                    mouseUp.X,
                    Shape.BoundingBox.Y,
                    Shape.BoundingBox.Width + WidthChange,
                    Shape.BoundingBox.Height + HeightChange
                    );
                    break;
                case ResizeMods.BottomSide:
                    Shape.BoundingBox = new Rectangle(
                    Shape.BoundingBox.X,
                    Shape.BoundingBox.Y,
                    Shape.BoundingBox.Width,
                    Shape.BoundingBox.Height + HeightChange
                    );
                    break;
                case ResizeMods.BottomRightCorner:
                    Shape.BoundingBox = new Rectangle(
                    Shape.BoundingBox.X,
                    Shape.BoundingBox.Y,
                    Shape.BoundingBox.Width + WidthChange,
                    Shape.BoundingBox.Height + HeightChange
                    );
                    break;
                case ResizeMods.RightSide:
                    Shape.BoundingBox = new Rectangle(
                    Shape.BoundingBox.X,
                    Shape.BoundingBox.Y,
                    Shape.BoundingBox.Width + WidthChange,
                    Shape.BoundingBox.Height
                    );
                    break;
                case ResizeMods.TopRightCorner:
                    Shape.BoundingBox = new Rectangle(
                    Shape.BoundingBox.X,
                    mouseUp.Y,
                    Shape.BoundingBox.Width + WidthChange,
                    Shape.BoundingBox.Height + HeightChange
                    );
                    break;
                case ResizeMods.TopSide:
                    Shape.BoundingBox = new Rectangle(
                    Shape.BoundingBox.X,
                    mouseUp.Y,
                    Shape.BoundingBox.Width,
                    Shape.BoundingBox.Height + HeightChange
                    );
                    break;
            }
            allShapes[selectedShapeIndex] = Shape;
            var NewResizeBox = new ResizeBox(allShapes[selectedShapeIndex].BoundingBox);
            resizeBox = NewResizeBox;
        }
    }
}
