In this solution you can see usage of `Inject` attribute.

For example class of xamarin mobile app:
```CSharp
public partial class CarListPage : ContentPage, ICarListPage
    {
        [Inject]
        private readonly ICarDetailPage _carDetailPage;
        [Inject]
        private readonly ICarListPageViewModel _carListPageViewModel;

        public CarListPage()
        {
            this.InjectProperties(App.Factory);
            BindingContext = _carListPageViewModel;
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
```
And result of run that code:
![Emulator output](http://prntscr.com/rhsjzp)