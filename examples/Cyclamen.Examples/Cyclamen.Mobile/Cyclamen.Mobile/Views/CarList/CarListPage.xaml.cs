using Cyclamen.Mobile.Models.MainPage;
using Cyclamen.Mobile.ViewModels.CarList;
using Cyclamen.Mobile.Views.CarDetail;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Cyclamen.Mobile.Views.CarList
{
    [DesignTimeVisible(false)]
    public partial class CarListPage : ContentPage, ICarListPage
    {
        [Inject]
        private readonly ICarDetailPage _carDetailPage;
        [Inject]
        private readonly ICarListPageViewModel _carListPageViewModel;

        public CarListPage()
        {
            this.InjectProperties(App.Factory);
            InitializeComponent();
        }

        private async void OnReloadCars(object sender, EventArgs e)
            => await _carListPageViewModel.ReloadCars();

        private async void OnItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync((Page)_carDetailPage);
            if (e.SelectedItem is CarModel carModel)
                await _carDetailPage.LoadCar(carModel.Id);
        }
    }
}
