using System.Runtime.InteropServices;
using System.Drawing;
namespace TheBestPaintInTheWorld
{
    public partial class PaintWindow : Form
    {
        private Graphics canvas;
        private Rectangle boundingBox;
        private List<Shape> allShapes = new List<Shape>();
        private bool isFill = false;
        private Pen outline = new Pen(Color.Black);
        private SolidBrush fill = new SolidBrush(Color.Black);
        private Point mouseDown;
        private Point mouseUp;
        private Color backgroundColor = Color.White;
        private Shapes shapeToDraw = Shapes.Rectangle;
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

        private void SizeBitton_Click(object sender, EventArgs e)
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


        private void HideButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void CloseButton_Click(object sender, EventArgs e)
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

        private void ToolStripErase_Click(object sender, EventArgs e)
        {
            canvas.Clear(backgroundColor);
        }

        private void ToolStripOutlineÑolor_Click(object sender, EventArgs e)
        {
            if (OutlineColorDialog.ShowDialog() == DialogResult.OK)
            {
                outline.Color = OutlineColorDialog.Color;
            }
        }

        private void ToolStripFillColor_Click(object sender, EventArgs e)
        {
            if (FillColorDialog.ShowDialog() == DialogResult.OK)
            {
                fill.Color = FillColorDialog.Color;
            }
        }

        private void ToolStripBackgroundColor_Click(object sender, EventArgs e)
        {
            if (BackgroundColorDialog.ShowDialog() == DialogResult.OK)
            {
                backgroundColor = BackgroundColorDialog.Color;
                canvas.Clear(backgroundColor);
            }
        }

        private void PaintWindow_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = e.Location;
        }

        private void PaintWindow_MouseUp(object sender, MouseEventArgs e)
        {
            mouseUp = e.Location;
            CreateShape();
        }

        private void CreateShape()
        {
            var Height = Math.Abs(mouseUp.Y - mouseDown.Y);
            var Width = Math.Abs(mouseUp.X - mouseDown.X);
            AdjustingPositionOfShape();
            boundingBox = new Rectangle(mouseDown.X, mouseDown.Y, Width, Height);
            if (isFill)
            {
                CreateFillShape(shapeToDraw, ref boundingBox);
            }
            else
            {
                CreateShapeWithoutFill(shapeToDraw, ref boundingBox);
            }
        }

        private void AdjustingPositionOfShape()
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

        private void CreateShapeWithoutFill(Shapes shape, ref Rectangle boundingBox)
        {
            switch (shape)
            {
                case Shapes.Rectangle:
                    canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                    canvas.DrawRectangle(outline, boundingBox);
                    break;

                case Shapes.Circle:
                    CircleSize(ref boundingBox);
                    canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    canvas.DrawEllipse(outline, boundingBox);
                    break;

                case Shapes.Elips:
                    canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    canvas.DrawEllipse(outline, boundingBox);
                    break;
            }
        }

        private void CreateFillShape(Shapes shape, ref Rectangle boundingBox)
        {
            switch (shape)
            {
                case Shapes.Rectangle:
                    canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                    canvas.FillRectangle(fill, boundingBox);
                    canvas.DrawRectangle(outline, boundingBox);
                    break;

                case Shapes.Circle:
                    CircleSize(ref boundingBox);
                    canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    canvas.FillEllipse(fill, boundingBox);
                    canvas.DrawEllipse(outline, boundingBox);
                    break;

                case Shapes.Elips:
                    canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    canvas.FillEllipse(fill, boundingBox);
                    canvas.DrawEllipse(outline, boundingBox);
                    break;
            }
        }

        private void CircleSize(ref Rectangle boundingBox)
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

        private void ToolStripFill_Click(object sender, EventArgs e)
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

        private void ToolStripCircle_Click(object sender, EventArgs e)
        {
            shapeToDraw = Shapes.Circle;
            ToolStripShapeSelection.Text = "Êðóã";
        }

        private void ToolStripElips_Click(object sender, EventArgs e)
        {
            shapeToDraw = Shapes.Elips;
            ToolStripShapeSelection.Text = "Ýëèïñ";
        }

        private void ToolStripRectangle_Click(object sender, EventArgs e)
        {
            shapeToDraw = Shapes.Rectangle;
            ToolStripShapeSelection.Text = "Ïðÿìîóãîëüíèê";
        }
    }
}
