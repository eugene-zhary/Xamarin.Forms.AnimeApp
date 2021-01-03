using Anime.DataServices;
using Anime.Models;
using Anime.Navigable;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class ProfileViewModel : ANavigableViewModel
    {
        public HistoryViewModel HistoryViewModel { get; set; }
        public UserInfoViewModel UserInfoViewModel { get; set; }

        public ProfileViewModel(INavigationService navigationService) : base(navigationService)
        {
            UserInfoViewModel = new UserInfoViewModel(navigationService);
            HistoryViewModel = new HistoryViewModel(navigationService);
        }

        public ICommand SettingsCommand => new Command(() => {
            NavigationService.NavigateFromMenuToAsync<SettingsViewModel>();
        });
    }
}
