using System.IO;
using System.ServiceModel.Web;

namespace WCF.ImageServer
{
    public class ImageService : IImageService
    {
        public Stream GetImage()
        {
            FileStream fs = File.OpenRead(@"D:\a.jpg");
            WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
            return fs;
        }
    }
}
