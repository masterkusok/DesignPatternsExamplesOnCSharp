using FlyweightPictureExample.ImageInsertProcessor;

namespace FlyweightPictureExample
{
    public partial class Form1 : Form
    {
        private FlyweightInsertProcessor _flyweightProcessor;
        private NonFlyweightInsertProcessor _nonFlyweightProcessor;

        private Bitmap _flyweightPicBoxBitmap;
        private Bitmap _nonFlyweightPicBoxBitmap;

        public Form1()
        {
            InitializeComponent();

            Image image = Image.FromFile($"{Directory.GetCurrentDirectory()}/pochita.png");

            _flyweightPicBoxBitmap = new Bitmap(FlyweightPictureBox.Width, FlyweightPictureBox.Height);
            _nonFlyweightPicBoxBitmap = new Bitmap(NonFlyweightPictureBox.Width, NonFlyweightPictureBox.Height);

            _flyweightProcessor = new FlyweightInsertProcessor(Graphics.FromImage(_flyweightPicBoxBitmap), image);
            _nonFlyweightProcessor = new NonFlyweightInsertProcessor(Graphics.FromImage(_nonFlyweightPicBoxBitmap), image);
            
        }

        private void FlyweightPictureBox_Click(object sender, MouseEventArgs e)
        {
            _flyweightProcessor.InsertImage(e);
            FlyweightPictureBox.Image = _flyweightPicBoxBitmap;

            RAMUsageInfoTextBox.Text = $"Flyweight image creation took {_flyweightProcessor.LastCreationMemoryUse} bytes";
        }

        private void NonFlyweightPictureBox_Click(object sender, MouseEventArgs e)
        {
            _nonFlyweightProcessor.InsertImage(e);
            NonFlyweightPictureBox.Image = _nonFlyweightPicBoxBitmap;

            RAMUsageInfoTextBox.Text = $"Heavy-weight image creation took {_nonFlyweightProcessor.LastCreationMemoryUse} bytes";
        }


    }
}