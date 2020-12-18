using Anime.Navigable;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class SearchViewModel : ANavigableViewModel
    {
        public TypesViewModel TypesViewModel { get; set; }
        public GenresViewModel GenresViewModel { get; set; }

        private bool isRefresh;
        public bool IsRefresh {
            get => isRefresh;
            set => SetAndRaise(ref isRefresh, value);
        }

        public SearchViewModel(INavigationService navigationService) : base(navigationService)
        {
            TypesViewModel = new TypesViewModel(navigationService);
            GenresViewModel = new GenresViewModel(navigationService);
        }

        public override async Task Load()
        {
            await TypesViewModel.Load();
            await GenresViewModel.Load();
        }
    }
}
