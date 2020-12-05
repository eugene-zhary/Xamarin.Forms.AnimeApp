using Anime.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Anime
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Bootstrapper.Init();

            MainPage = Resolver.Resolve<ShellView>();
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
