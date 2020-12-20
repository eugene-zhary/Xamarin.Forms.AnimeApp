using Anime.Navigable;

namespace Anime.ViewModels
{
    public class HomeViewModel : ANavigableViewModel
    {
        public TopViewModel TopViewModel { get; set; }

        public HomeViewModel(INavigationService navigationService) :base(navigationService)
        {
            TopViewModel = new TopViewModel(navigationService);
        }
    }
}
