using System.Threading.Tasks;

namespace Cyclamen.Mobile.Helpers
{
    public interface IResourceHelper
    {
        public string GetResourcePath(string resourceName);
        public Task CopyResourceToFileSystem(string resourceName, bool forceUpdate = false);
    }
}
