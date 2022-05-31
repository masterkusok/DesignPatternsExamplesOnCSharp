using System;
using System.Drawing;

namespace FlyweightPictureExample.FlyweightAndFactory
{
    public class Flyweight
    {
        private Image _img;

        public Flyweight(Image img)
        {
            _img = img;
        }

        public void Draw(Graphics g, int x, int y)
        {
            g.DrawImage(_img, x, y);
        }
    }
}
