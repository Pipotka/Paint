using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestPaintInTheWorld
{
    struct ResizeBox
    {
        public Rectangle MainResizeBox { get; set; }
        public Rectangle TopLeftCornerBox { get; set; }
        public Rectangle TopRightCornerBox { get; set; }
        public Rectangle LeftSideBox { get; set; }
        public Rectangle RightSideBox { get; set; }
        public Rectangle BottomLeftCornerBox { get; set; }
        public Rectangle BottomRightCornerBox { get; set; }
        public Rectangle BottomSideBox { get; set; }
        public Rectangle TopSideBox { get; set; }

        public ResizeBox(Rectangle MainResizeBox)
        {
            this.MainResizeBox = MainResizeBox;
            TopLeftCornerBox = new Rectangle(MainResizeBox.X - 10, MainResizeBox.Y - 10, 10, 10);
            LeftSideBox = new Rectangle(MainResizeBox.X - 10, MainResizeBox.Y + MainResizeBox.Height / 2 - 5, 10, 10);
            BottomSideBox = new Rectangle(MainResizeBox.X + MainResizeBox.Width / 2 - 5, MainResizeBox.Bottom, 10, 10);
            BottomLeftCornerBox = new Rectangle(MainResizeBox.X - 10, MainResizeBox.Bottom, 10, 10);
            TopSideBox = new Rectangle(MainResizeBox.X + MainResizeBox.Width / 2 - 5, MainResizeBox.Top - 10, 10, 10);
            BottomRightCornerBox = new Rectangle(MainResizeBox.X + MainResizeBox.Width, MainResizeBox.Bottom, 10, 10);
            TopRightCornerBox = new Rectangle(MainResizeBox.X + MainResizeBox.Width, MainResizeBox.Y - 10, 10, 10);
            RightSideBox = new Rectangle(MainResizeBox.X + MainResizeBox.Width, MainResizeBox.Y + MainResizeBox.Height / 2 - 5, 10, 10);
        }
    }
}
