using Anime.Navigable;
using Anime.ViewModels;
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
            SetHue(0.4);

            Sharpnado.Shades.Initializer.Initialize(false);
            Sharpnado.Tabs.Initializer.Initialize(true, false);

            var viewLocator = DependencyContainer.Instance.GetInstance<IViewLocator>();
            var firstScreenView = viewLocator.GetViewFor<BottomTabsViewModel>();

            MainPage = new NavigationPage((Page)firstScreenView);
        }

        public void SetHue(double hue)
        {
            this.Resources["PrimaryColor"] =
                    Color.FromHsla(hue, 0.8, 0.4);

            this.Resources["SubColor"] =
                    Color.FromHsla(hue, 0.4, 0.8);

            this.Resources["BackColor"] =
                    Color.FromHsla(hue, 1, 0.04);

            this.Resources["FrontColor"] =
                    Color.FromHsla(hue, 1, 0.08);

            this.Resources["TabColor"] =
                    Color.FromHsla(hue, 1, 0.12);
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
