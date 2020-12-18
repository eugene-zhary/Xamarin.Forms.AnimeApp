using Anime.Navigable;
using System.Threading.Tasks;

namespace Anime.ViewModels
{
    public class BottomTabsViewModel : ANavigableViewModel
    {
        private int selectedViewModelIndex = 0;

        public int SelectedViewModelIndex {
            get => selectedViewModelIndex;
            set => SetAndRaise(ref selectedViewModelIndex, value);
        }

        public BottomTabsViewModel(INavigationService navigationService) : base(navigationService)
        {
            HomeViewModel = new HomeViewModel(navigationService);
            SearchViewModel = new SearchViewModel(navigationService);
            ProfileViewModel = new ProfileViewModel(navigationService);
        }

        public HomeViewModel HomeViewModel { get; set; }
        public SearchViewModel SearchViewModel { get; set; }
        public ProfileViewModel ProfileViewModel { get; set; }


        public override async Task Load()
        {
            await HomeViewModel.Load();
            await SearchViewModel.Load();
            await ProfileViewModel.Load();
        }
    }
}
