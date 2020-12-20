using Anime.DataServices;
using Anime.Models;
using Anime.Navigable;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anime.ViewModels
{
    public class UserInfoViewModel : ANavigableViewModel
    {
        public UserModel User { get; set; }

        public UserInfoViewModel(INavigationService navigationService) : base(navigationService)
        {
            User = (DataService.GetData(DataType.User) as UserModel);
        }
    }
}
