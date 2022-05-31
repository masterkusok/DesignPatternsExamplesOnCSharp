using System.Drawing;
using FlyweightPictureExample.FlyweightAndFactory;

namespace FlyweightPictureExample.ImageContexts
{
    public class FlyweightContext : ImageContext
    {
        Flyweight _flyweight;
        public FlyweightContext(int x, int y, Flyweight flyweight)
        {
            this.X = x;
            this.Y = y;
            _flyweight = flyweight;
        }

        public override void Draw(Graphics g)
        {
            _flyweight.Draw(g, X, Y);
        }
    }
}
