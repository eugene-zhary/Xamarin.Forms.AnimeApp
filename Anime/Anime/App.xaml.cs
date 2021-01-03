using Anime.Navigable;
using Anime.ViewModels;
using Anime.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Anime
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (App.Current.Properties.ContainsKey("hue")) {
                SetHue((double)App.Current.Properties["hue"]);
            }
            else {
                SetHue(0.0d);
            }

            Sharpnado.Shades.Initializer.Initialize(false);
            Sharpnado.Tabs.Initializer.Initialize(true, false);

            var viewLocator = DependencyContainer.Instance.GetInstance<IViewLocator>();
            var firstScreenView = viewLocator.GetViewFor<BottomTabsViewModel>();

            MainPage = new NavigationPage((Page)firstScreenView);
        }

        public static void SetHue(double hue)
        {
            App.Current.Resources["PrimaryColor"] =
                   Color.FromHsla(hue, 0.8, 0.4);

            App.Current.Resources["SubColor"] =
                    Color.FromHsla(hue, 0.4, 0.8);

            App.Current.Resources["BackColor"] =
                    Color.FromHsla(hue, 1, 0.04);

            App.Current.Resources["FrontColor"] =
                    Color.FromHsla(hue, 1, 0.08);

            App.Current.Resources["TabColor"] =
                    Color.FromHsla(hue, 1, 0.12);

            App.Current.Properties["hue"] = hue;
        }

        public static double GetHue() => (App.Current.Properties.ContainsKey("hue")) ?
            (double)App.Current.Properties["hue"] : 0.0d;


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
