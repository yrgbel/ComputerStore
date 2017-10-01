using System;
using System.IO;
using System.Linq;
using System.ServiceModel.Web;
using Store.ImageService.ServiceContracts;
using Store.Infrastructure;

namespace Store.ImageService.ServiceImplementations
{
    /// <summary>
    /// Image server service implementation. Returns requested images.
    /// The service provides also add, edit, delete functionality.
    /// </summary>
    public class ImageService : IImageService
    {
        /// <summary>
        /// Gets large product image
        /// </summary>
        /// <param name="productId">Product Identifier.</param>
        /// <returns>Image stream.</returns>
        public Stream GetProductImageLarge(string productId)
        {
            return GetProductImage("Large", productId);
        }

        /// <summary>
        /// Gets small product image
        /// </summary>
        /// <param name="productId">Product Identifier.</param>
        /// <returns>Image stream.</returns>
        public Stream GetProductImageSmall(string productId)
        {
            return GetProductImage("Small", productId);
        }

        /// <summary>
        /// Helper methods. Gets large or small product image.
        /// </summary>
        /// <param name="size">Image size. Small or Large.</param>
        /// <param name="productId">Product Identifier.</param>
        /// <returns>Image stream.</returns>
        private Stream GetProductImage(string size, string productId)
        {
            // Get host folder
            string path = AppDomain.CurrentDomain.BaseDirectory;

            // Application has up to 91 images. Note: image upload is not implemented.
            // If the product id isn't a number then set id to zero for use silhouette image.
            const string notFoundImageId = "0";
            const string notFoundImageExtension = ".jpg";

            string id = productId.IsNumeric() ? productId : notFoundImageId;

            string partPathfile = Path.Combine(path, @"Images\Products\" + size + @"\");

            string fileExtension = GetExtensionExistFile(partPathfile, id);

            string pathFile = fileExtension == null ?
                partPathfile + notFoundImageId + notFoundImageExtension :
                partPathfile + id + fileExtension;

            var stream = new FileStream(pathFile, FileMode.Open, FileAccess.Read, FileShare.Read);

            WebOperationContext.Current.OutgoingResponse.ContentType =
                GetMimeTypeByExtension(fileExtension.Return(e => e, notFoundImageExtension));
            
            return stream;
        }

        private string GetExtensionExistFile(string partPathfile, string productId)
        {
            string[] imageExtensions = { ".jpg", ".jpeg", ".gif", ".png" };
            return imageExtensions.FirstOrDefault(e => File.Exists(partPathfile + productId + e));
        }


        private string GetMimeTypeByExtension(string extension)
        {
            switch (extension)
            {
                case ".jpg":
                case ".jpeg": return "image/jpeg";
                case ".png": return "image/png";
                case ".gif": return "image/gif";
                default: return string.Empty;
            }
        }
    }
}
