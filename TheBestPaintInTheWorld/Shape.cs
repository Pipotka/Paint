using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestPaintInTheWorld
{
    struct Shape
    {
        public bool IsFill
        {
            set
            {
                if (value is bool)
                {
                    IsFill = value;
                }
            }
            get
            {
                return IsFill;
            }
        }
        public SolidBrush FillColor
        {
            set
            {
                if (value is SolidBrush)
                {
                    FillColor = value;
                }
            }
            get
            {
                return FillColor;
            }
        }
        public Pen Outline
        {
            set
            {
                if (value is Pen)
                {
                    Outline = value;
                }
            }
            get
            {
                return Outline;
            }
        }
        public Shapes TypeOfShape
        {
            set
            {
                if (value is Shapes)
                {
                    TypeOfShape = value;
                }
            }
            get
            {
                return TypeOfShape;
            }
        }
        public Rectangle BoundingBox
        {
            set
            {
                if (value is Rectangle)
                {
                    BoundingBox = value;
                }
            }
            get
            {
                return BoundingBox;
            }
        }
    }
}
