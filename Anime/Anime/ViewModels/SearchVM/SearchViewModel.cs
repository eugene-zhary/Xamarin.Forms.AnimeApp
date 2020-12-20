using Anime.Navigable;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class SearchViewModel : ANavigableViewModel
    {
        private int selectedViewModelIndex = 0;

        public int SelectedViewModelIndex {
            get => selectedViewModelIndex;
            set => Set(ref selectedViewModelIndex, value);
        }

        public SearchViewModel(INavigationService navigationService) : base(navigationService)
        {
            TypesViewModel = new TypesViewModel(navigationService);
            GenresViewModel = new GenresViewModel(navigationService);
        }

        public TypesViewModel TypesViewModel { get; set; }
        public GenresViewModel GenresViewModel { get; set; }
    }
}
