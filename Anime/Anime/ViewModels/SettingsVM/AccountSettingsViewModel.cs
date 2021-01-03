using Anime.Models;
using Anime.Navigable;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anime.ViewModels
{
    public class AccountSettingsViewModel : ANavigableViewModel
    {
        public UserModel User { get; set; }

        public AccountSettingsViewModel(INavigationService navigationService) : base(navigationService)
        {
            User = new UserModel(1);
        }
    }
}
