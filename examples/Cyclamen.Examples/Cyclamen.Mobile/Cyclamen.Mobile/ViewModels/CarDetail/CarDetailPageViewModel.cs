using Cyclamen.Mobile.Models.CarDetailPage;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Cyclamen.Mobile.ViewModels.CarDetail
{
    public class CarDetailPageViewModel : ICarDetailPageViewModel
    {
        [Inject]
        private readonly ICarDetailPageModel _carDetailPageModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public CarDetailPageViewModel()
            => this.InjectProperties(App.Factory);

        private CarDetailModel car;
        public CarDetailModel Car
        {
            get => car;
            set
            {
                car = value;
                OnPropertyChanged(nameof(Car));
            }
        }

        public async Task LoadCar(int carId)
            => Car = await _carDetailPageModel.LoadCar(carId);

        protected void OnPropertyChanged(string propName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
