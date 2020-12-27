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
            User = (DataService.GetData(DataType.User, 1) as UserModel);
        }
    }
}
