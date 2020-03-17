using System.Threading.Tasks;

namespace Cyclamen.Mobile.Models.CarDetailPage
{
    public interface ICarDetailPageModel
    {
        public Task<CarDetailModel> LoadCar(int carId);
    }
}
