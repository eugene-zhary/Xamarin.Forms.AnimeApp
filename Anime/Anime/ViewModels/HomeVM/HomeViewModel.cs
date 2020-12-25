using Anime.Navigable;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class HomeViewModel : ANavigableViewModel
    {

        public TopViewModel TopViewModel { get; set; }

        public HomeViewModel(INavigationService navigationService) :base(navigationService)
        {
            TopViewModel = new TopViewModel(navigationService);
        }


        static Random rand = new Random();

        public ICommand OnTapped => new Command((item) => {

            double hue = rand.NextDouble();

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
        });
    }
}
