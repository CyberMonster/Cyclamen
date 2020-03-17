using Cyclamen.Mobile.Helpers;
using Cyclamen.Mobile.Models.MainPage;
using Cyclamen.Mobile.Repositories.Cars;
using Cyclamen.Mobile.ViewModels;
using Cyclamen.Mobile.Views;
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

                .AddTransient<IMainPage, MainPage>()
                .AddTransient<IMainPageModel, MainPageModel>()
                .AddTransient<IMainPageViewModel, MainPageViewModel>()

                .BuildServiceProvider();

        internal static IServiceCollection AddPlatformSingleton<TType>(this IServiceCollection services) where TType : class
        {
            DependencyService.Register<TType>();
            return services.AddSingleton(DependencyService.Get<TType>());
        }
    }
}
