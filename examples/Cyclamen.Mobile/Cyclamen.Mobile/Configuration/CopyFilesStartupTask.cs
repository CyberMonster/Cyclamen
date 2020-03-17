using Cyclamen.Mobile.Helpers;
using System.Threading.Tasks;

namespace Cyclamen.Mobile.Configuration
{
    internal interface ICopyFilesStartupTask
    {
        Task Run();
    }

    internal class CopyFilesStartupTask : ICopyFilesStartupTask
    {
        private IResourceHelper _resourceHelper;
        public CopyFilesStartupTask(IResourceHelper resourceHelper)
            => _resourceHelper = resourceHelper;

        public Task Run()
            => _resourceHelper.CopyResourceToFileSystem(ReposConnection.CarRepositoryConnection, true);
    }
}
