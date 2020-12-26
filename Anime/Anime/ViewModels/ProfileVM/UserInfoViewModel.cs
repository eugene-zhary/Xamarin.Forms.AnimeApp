using Anime.DataServices;
using Anime.Models;
using Anime.Navigable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class UserInfoViewModel : ANavigableViewModel
    {
        public UserModel User { get; set; }

        public UserInfoViewModel(INavigationService navigationService) : base(navigationService)
        {
            User = (DataService.GetData(DataType.User, 1) as UserModel);
        }

        public ICommand SettingsCommand => new Command(()=> {
            NavigationService.NavigateFromMenuToAsync<SettingsViewModel>();
        });
    }
}
