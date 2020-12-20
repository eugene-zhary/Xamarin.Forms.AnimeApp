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

        public SearchViewModel(INavigationService navigationService) : base(navigationService)
        {
            TypesViewModel = new TypesViewModel(navigationService);
            GenresViewModel = new GenresViewModel(navigationService);
        }
    }
}
