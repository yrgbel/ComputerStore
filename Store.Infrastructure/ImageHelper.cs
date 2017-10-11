using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.ServiceModel;

namespace Store.Infrastructure
{
    public static class ImageHelper
    {
        public static ImageView GetDimensions(string uri)
        {
            ScreenShotClient client;
        public ScreenImage(string baseAddress)
        {
            InitializeComponent();
            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
            binding.TransferMode = TransferMode.StreamedResponse;
            binding.MaxReceivedMessageSize = 1024 * 1024 * 2;
            client = new ScreenShotClient(binding, new EndpointAddress(baseAddress));

                return new ImageView(image.Width, image.Height);
        }
    }

    public struct ImageView
    {
        /// <summary>
        /// Constructor for set dimensions.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public ImageView(int width, int height)
        {
            Height = height;
            Width = width;
        }

        public int Width { get; }
        public int Height { get; }
    }
}
