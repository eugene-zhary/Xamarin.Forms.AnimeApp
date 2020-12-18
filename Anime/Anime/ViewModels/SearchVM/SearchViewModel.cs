using Anime.Navigable;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class SearchViewModel : ANavigableViewModel
    {
        public GenresViewModel GenresViewModel { get; set; }
        public TypesViewModel TypesViewModel { get; set; }

        private bool isRefresh;
        public bool IsRefresh {
            get => isRefresh;
            set => SetAndRaise(ref isRefresh, value);
        }

        public SearchViewModel(INavigationService navigationService) : base(navigationService)
        {
            GenresViewModel = new GenresViewModel(navigationService);
            TypesViewModel = new TypesViewModel(navigationService);
        }
    }
}
