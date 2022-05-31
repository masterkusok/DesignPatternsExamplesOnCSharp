using FlyweightPictureExample.FlyweightAndFactory;
using FlyweightPictureExample.ImageContexts;

namespace FlyweightPictureExample.ImageInsertProcessor
{
    public abstract class ImageInsertProcessor
    {
        Graphics _g;
        protected Image _img;

        protected int _lastX;
        protected int _lastY;

        protected List<ImageContext> _imageContexts;

        private long _firstMemoryUsePoint;
        public long LastCreationMemoryUse { get; set; }

        public ImageInsertProcessor(Graphics g, Image img)
        {
            _g = g;
            _imageContexts = new List<ImageContext>();
            _img = img;
        }

        public void InsertImage(MouseEventArgs e)
        {
            FindClickedCoordinate(e);
            StartCountingMemoryUse();
            CreateNeccessaryContext();
            StopCountingMemoryUse();
            DrawAllImages();
        }

        private void FindClickedCoordinate(MouseEventArgs e)
        {
            _lastX = e.X; 
            _lastY = e.Y;
        }

        protected abstract void CreateNeccessaryContext();

        private void DrawAllImages()
        {
            _g.Clear(Color.White);
            foreach(ImageContext context in _imageContexts)
            {
                context.Draw(_g);
            }
        }

        private void StartCountingMemoryUse()
        {
            _firstMemoryUsePoint = GC.GetTotalMemory(true);
        }

        private void StopCountingMemoryUse()
        {
            LastCreationMemoryUse = GC.GetTotalMemory(true) - _firstMemoryUsePoint;
        }

    }
}
