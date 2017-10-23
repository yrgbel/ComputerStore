using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Store.ImageService.ServiceContracts
{
    /// <summary>
    /// Image server service contract.
    /// </summary>
    [ServiceContract]
    public interface IImageService
    {
        [OperationContract, WebGet(UriTemplate = "GetProductImageLarge/{productId}")]
        Stream GetProductImageLarge(string productId);

        [OperationContract, WebGet(UriTemplate = "GetProductImageSmall/{productId}")]
        Stream GetProductImageSmall(string productId);

        [OperationContract, WebGet(UriTemplate = "GetProductImageThumbnail/{productId}")]
        Stream GetProductImageThumbnail(string productId);
    }
}
