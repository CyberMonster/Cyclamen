using Cyclamen.Mobile.Models.MainPage;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Cyclamen.Mobile.ViewModels
{
    public interface IMainPageViewModel : INotifyPropertyChanged
    {
        ObservableCollection<CarModel> Cars { get; set; }
        Task ReloadCars();
    }

    public class MainPageViewModel : IMainPageViewModel
    {
        [Inject]
        private IMainPageModel _mainPageModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
            => this.InjectProperties(App.Factory);

        private int a = 0;
        public string Text { get => a.ToString(); set => OnPropertyChanged(nameof(Text)); }

        private ObservableCollection<CarModel> cars;
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
        {
            a++;
            Text = "";
            Cars = new ObservableCollection<CarModel>(await _mainPageModel.LoadCars());
        }

        protected void OnPropertyChanged(string propName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
