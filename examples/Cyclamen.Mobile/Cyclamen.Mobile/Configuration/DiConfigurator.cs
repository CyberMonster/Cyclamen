using Cyclamen.Mobile.Helpers;
using Cyclamen.Mobile.Models.CarDetailPage;
using Cyclamen.Mobile.Models.MainPage;
using Cyclamen.Mobile.Repositories.Cars;
using Cyclamen.Mobile.ViewModels.CarDetail;
using Cyclamen.Mobile.ViewModels.CarList;
using Cyclamen.Mobile.Views.CarDetail;
using Cyclamen.Mobile.Views.CarList;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;

namespace Cyclamen.Mobile.Configuration
{
    internal static class DiConfigurator
    {
        internal static IServiceProvider Configure(this IServiceCollection services)
            => services
                .AddPlatformSingleton<IResourceHelper>()

                .AddSingleton<ICopyFilesStartupTask, CopyFilesStartupTask>()
                .AddSingleton<ICarRepository, CarRepository>()

                .AddTransient<ICarListPage, CarListPage>()
                .AddTransient<IMainPageModel, MainPageModel>()
                .AddTransient<ICarListPageViewModel, CarListPageViewModel>()

                .AddTransient<ICarDetailPage, CarDetailPage>()
                .AddTransient<ICarDetailPageModel, CarDetailPageModel>()
                .AddTransient<ICarDetailPageViewModel, CarDetailPageViewModel>()

                .BuildServiceProvider();

        internal static IServiceCollection AddPlatformSingleton<TType>(this IServiceCollection services) where TType : class
        {
            DependencyService.Register<TType>();
            return services.AddSingleton(DependencyService.Get<TType>());
        }
    }
}
