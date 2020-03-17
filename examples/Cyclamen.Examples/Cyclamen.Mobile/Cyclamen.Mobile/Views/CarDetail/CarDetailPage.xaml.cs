using Cyclamen.Mobile.ViewModels.CarDetail;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cyclamen.Mobile.Views.CarDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarDetailPage : ContentPage, ICarDetailPage
    {
        [Inject]
        private readonly ICarDetailPageViewModel _carDetailPageViewModel;

        public CarDetailPage()
        {
            this.InjectProperties(App.Factory);
            InitializeComponent();
        }

        public Task LoadCar(int carId)
            => _carDetailPageViewModel.LoadCar(carId);
    }
}