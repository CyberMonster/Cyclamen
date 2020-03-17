using Cyclamen.Mobile.Models.MainPage;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Cyclamen.Mobile.ViewModels.CarList
{
    public class CarListPageViewModel : ICarListPageViewModel
    {
        [Inject]
        private readonly IMainPageModel _mainPageModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public CarListPageViewModel()
            => this.InjectProperties(App.Factory);

        private ObservableCollection<CarModel> cars = new ObservableCollection<CarModel>();
        public ObservableCollection<CarModel> Cars
        {
            get => cars;
            set
            {
                cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }

        public async Task ReloadCars()
            => Cars = new ObservableCollection<CarModel>(await _mainPageModel.LoadCars());

        protected void OnPropertyChanged(string propName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
