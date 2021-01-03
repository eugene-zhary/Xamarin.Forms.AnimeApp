using Anime.DataServices;
using Anime.Models;
using Anime.Navigable;

namespace Anime.ViewModels
{
    public class UserInfoViewModel : ANavigableViewModel
    {
        public UserModel User { get; set; }

        public UserInfoViewModel(INavigationService navigationService) : base(navigationService)
        {
            User = new UserModel(1);
        }
    }
}
