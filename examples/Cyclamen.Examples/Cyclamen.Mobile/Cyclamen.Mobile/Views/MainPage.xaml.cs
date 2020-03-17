using Cyclamen.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Cyclamen.Mobile.Views
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage, IMainPage
    {
        [Inject]
        public IMainPageViewModel MainPageViewModel { get; set; }

        public MainPage()
        {
            this.InjectProperties(App.Factory);
            BindingContext = MainPageViewModel;
            InitializeComponent();
        }

        private async void OnReloadCars(object sender, System.EventArgs e)
            => await MainPageViewModel.ReloadCars();
    }
}
