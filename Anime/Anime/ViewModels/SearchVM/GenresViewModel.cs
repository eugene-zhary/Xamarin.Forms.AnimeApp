using Anime.Navigable;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class GenresViewModel : ANavigableViewModel
    {
        public string Header { get; set; }
        public ObservableCollection<string> AnimeGenres { get; set; }

        public GenresViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Header = "ЖАНРЫ";
            this.AnimeGenres = new ObservableCollection<string>();
        }

        public ICommand TappedOnItem => new Command((item) => {

        });
    }
}
