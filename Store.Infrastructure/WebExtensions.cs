using System;
using System.Collections.Concurrent;
using Microsoft.Win32;

namespace Store.Infrastructure
{
    public static class WebExtensions
    {
        public static string ConvertMimeTypeToExtension(this string mimeType)
        {
            var mimeTypeToExtension = new ConcurrentDictionary<string, string>();

            if (string.IsNullOrWhiteSpace(mimeType))
                throw new ArgumentNullException("mimeType");

            string key = string.Format(@"MIME\Database\Content Type\{0}", mimeType);
            string result;
            if (mimeTypeToExtension.TryGetValue(key, out result))
                return result;

            RegistryKey regKey;
            object value;

            regKey = Registry.ClassesRoot.OpenSubKey(key, false);
            value = regKey != null ? regKey.GetValue("Extension", null) : null;
            result = value != null ? value.ToString() : string.Empty;

            mimeTypeToExtension[key] = result;
            return result;
        }

        public static string ConvertExtensionToMimeType(this string extension)
        {
            var extensionToMimeType = new ConcurrentDictionary<string, string>();

            if (string.IsNullOrWhiteSpace(extension))
                throw new ArgumentNullException("extension");

            if (!extension.StartsWith("."))
                extension = "." + extension;

            string result;
            if (extensionToMimeType.TryGetValue(extension, out result))
                return result;

            RegistryKey regKey;
            object value;

            regKey = Registry.ClassesRoot.OpenSubKey(extension, false);
            value = regKey != null ? regKey.GetValue("Content Type", null) : null;
            result = value != null ? value.ToString() : string.Empty;

            extensionToMimeType[extension] = result;
            return result;
        }
    }
}
