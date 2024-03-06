using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestPaintInTheWorld
{
    struct Shape
    {
        public bool IsFill { get; set; }
        public SolidBrush FillColor { get; set; }
        public Pen Outline { get; set; }
        public Shapes TypeOfShape { get; set; }
        public Rectangle BoundingBox { get; set; }

        public Shape(Pen outline, SolidBrush fillColor, Shapes shape, Rectangle boundingBox)
        {
            Outline = new Pen(outline.Color);
            Outline.Width = 3.0f;
            FillColor = new SolidBrush(fillColor.Color);
            IsFill = true;
            TypeOfShape = shape;
            BoundingBox = boundingBox;
        }
        public Shape(Pen outline, Shapes shape, Rectangle boundingBox)
        {
            Outline = new Pen(outline.Color);
            Outline.Width = 3.0f;
            IsFill = false;
            TypeOfShape = shape;
            BoundingBox = boundingBox;
        }
    }
}
