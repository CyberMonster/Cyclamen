using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cyclamen.Mobile.Models.MainPage
{
    public interface IMainPageModel
    {
        public Task<List<CarModel>> LoadCars();
    }
}
