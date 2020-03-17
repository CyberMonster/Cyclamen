using Cyclamen.Mobile.Models.MainPage;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Cyclamen.Mobile.ViewModels.CarList
{
    public interface ICarListPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CarModel> Cars { get; set; }
        public Task ReloadCars();
    }
}
