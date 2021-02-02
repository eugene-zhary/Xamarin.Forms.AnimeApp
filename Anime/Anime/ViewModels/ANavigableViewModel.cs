using Anime.Navigable;

namespace Anime.ViewModels
{
    public abstract class ANavigableViewModel : BaseViewModel
    {
        protected INavigationService NavigationService { get; }

        protected ANavigableViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}
