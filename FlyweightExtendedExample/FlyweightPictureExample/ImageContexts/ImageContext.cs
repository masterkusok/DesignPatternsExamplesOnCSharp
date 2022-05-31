namespace FlyweightPictureExample.ImageContexts
{
    public abstract class ImageContext
    {
        public int X;
        public int Y;

        abstract public void Draw(Graphics g);
    }
}
