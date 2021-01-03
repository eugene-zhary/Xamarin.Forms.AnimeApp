using Anime.Navigable;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class SettingsViewModel : ANavigableViewModel
    {
        public AccountSettingsViewModel AccountSettingsViewModel { get; set; }
        public ColorSettingsViewModel ColorSettingsViewModel { get; set; }

        public SettingsViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.AccountSettingsViewModel = new AccountSettingsViewModel(navigationService);
            this.ColorSettingsViewModel = new ColorSettingsViewModel();
        }
    }
}
