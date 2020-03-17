using Cyclamen.Mobile.Configuration;
using Cyclamen.Mobile.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cyclamen.Mobile
{
    public partial class App : Application
    {
        internal static IServiceProvider Factory { get; }

        static App()
            => Factory = new ServiceCollection().Configure();
        public App()
        {
            InitializeComponent();
            Task.Run(() => Factory.GetService<ICopyFilesStartupTask>().Run());
            MainPage = (Page)Factory.GetService<IMainPage>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
