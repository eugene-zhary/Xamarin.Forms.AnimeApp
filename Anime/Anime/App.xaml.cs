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

            Sharpnado.Shades.Initializer.Initialize(false);
            Sharpnado.Tabs.Initializer.Initialize(true, false);

            var viewLocator = DependencyContainer.Instance.GetInstance<IViewLocator>();
            var firstScreenView = viewLocator.GetViewFor<BottomTabsViewModel>();

            MainPage = new NavigationPage((Page)firstScreenView);
            var firstScreenVm = (ANavigableViewModel)firstScreenView.BindingContext;
            firstScreenVm.Load(null);
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
