using System.Configuration;

namespace Store.DomainModel.Helpers
{
    public static class DataSettingsProvider
    {
        public static readonly string ImageService = ConfigurationManager.AppSettings["ImageService"];

        public static string GetProductImageLargeUrl(int id)
        {
            return ImageService + "GetProductImageLarge/" + id;
        }

        public static string GetProductImageSmallUrl(int id)
        {
            return ImageService + "GetProductImageSmall/" + id;
        }

        public static string GetProductImageThumbnailUrl(int id)
        {
            return ImageService + "GetProductImageThumbnail/" + id;
        }
    }
}
