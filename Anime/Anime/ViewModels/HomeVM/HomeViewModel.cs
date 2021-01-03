using Anime.Navigable;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class HomeViewModel : ANavigableViewModel
    {
        public TopViewModel TopViewModel { get; set; }

        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
            TopViewModel = new TopViewModel(navigationService);
        }


        static Random rand = new Random();

        public ICommand OnTapped => new Command((item) => {
            App.SetHue(rand.NextDouble());
        });

    }
}
