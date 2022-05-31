using FlyweightPictureExample.ImageContexts;
using FlyweightPictureExample.FlyweightAndFactory;

namespace FlyweightPictureExample.ImageInsertProcessor
{
    public class FlyweightInsertProcessor : ImageInsertProcessor
    {
        private FlyweightFactory _factory = new FlyweightFactory();

        public FlyweightInsertProcessor(Graphics g, Image img) : base(g, img)
        {
        }

        protected override void CreateNeccessaryContext()
        {
            Flyweight flyweight = _factory.GetOrCreateFlyweight(new Flyweight(_img));
            _imageContexts.Add(new FlyweightContext(_lastX, _lastY, flyweight));
        }
    }
}
