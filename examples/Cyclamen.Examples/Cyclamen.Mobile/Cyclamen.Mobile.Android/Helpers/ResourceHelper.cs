using Cyclamen.Mobile.Droid.Helpers;
using Cyclamen.Mobile.Helpers;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ResourceHelper))]
namespace Cyclamen.Mobile.Droid.Helpers
{
    public class ResourceHelper : IResourceHelper
    {
        public static int copyBufferLengthBytes = 50 * 1024;

        public string GetResourcePath(string resourceName)
            => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), resourceName);

        public async Task CopyResourceToFileSystem(string resourceName, bool forceUpdate = false)
        {
            var path = GetResourcePath(resourceName);
            if (!File.Exists(path) || forceUpdate)
            {
                var assetStream = Forms.Context.Assets.Open(resourceName);

                var fileStream = new FileStream(path, FileMode.OpenOrCreate);
                var buffer = new byte[copyBufferLengthBytes];
                int trueLength;

                while ((trueLength = await assetStream.ReadAsync(buffer, 0, copyBufferLengthBytes)) > 0)
                    await fileStream.WriteAsync(buffer, 0, trueLength);

                fileStream.Flush();
                fileStream.Close();
                assetStream.Close();
            }
        }
    }
}