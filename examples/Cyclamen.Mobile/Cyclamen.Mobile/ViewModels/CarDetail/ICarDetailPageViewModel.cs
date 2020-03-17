using Cyclamen.Mobile.Models.CarDetailPage;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Cyclamen.Mobile.ViewModels.CarDetail
{
    public interface ICarDetailPageViewModel : INotifyPropertyChanged
    {
        public CarDetailModel Car { get; set; }
        public Task LoadCar(int carId);
    }
}
