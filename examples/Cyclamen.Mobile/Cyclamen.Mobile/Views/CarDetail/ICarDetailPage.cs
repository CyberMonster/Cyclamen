using System.Threading.Tasks;

namespace Cyclamen.Mobile.Views.CarDetail
{
    public interface ICarDetailPage
    {
        public Task LoadCar(int carId);
    }
}
