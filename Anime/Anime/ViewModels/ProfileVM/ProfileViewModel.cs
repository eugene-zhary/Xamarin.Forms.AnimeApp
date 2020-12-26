using Anime.Models;
using Anime.Navigable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
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
    }
}
