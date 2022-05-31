using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPictureExample.ImageContexts
{
    public class NonFlyweightContext : ImageContext
    {
        private Image _img;

        public NonFlyweightContext(Image img, int X, int Y)
        {
            _img = img;
            this.X = X;
            this.Y = Y;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(_img, X, Y);
        }
    }
}
