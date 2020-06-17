using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Components
{
    class Picture
    {
        private int _pictureHeight;
        private int _pictureWidth;

        private int x;
        private int y;

        public int Height
        {
            get { return _pictureHeight; }
            set { _pictureHeight = value; }
        }

        public int Width
        {
            get { return _pictureWidth; }
            set { _pictureWidth = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Picture(int height, int width)
        {
            _pictureHeight = height;
            _pictureWidth = width;
        }
    }
}
