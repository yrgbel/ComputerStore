using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCF.ImageServer
{
    [ServiceContract]
    public interface IImageService
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetImage", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        Stream GetImage();
    }
}
