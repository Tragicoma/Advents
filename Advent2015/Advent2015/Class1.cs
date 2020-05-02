using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2015
{
    class GiftBox
    {
        public GiftBox(int length, int width, int height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public int length { get; set; }
        public int width { get; set; }
        public int height { get; set; }

    }
}
