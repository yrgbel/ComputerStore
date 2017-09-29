using System.Configuration;

namespace Store.Data.Helpers
{
    public static class DataSettingsProvider
    {
        public static readonly string ImageOriginalPath = ConfigurationManager.AppSettings["ImageOriginalPath"];
        public static readonly string ImagCroppedPath = ConfigurationManager.AppSettings["ImageCroppedPath"];
    }
}
