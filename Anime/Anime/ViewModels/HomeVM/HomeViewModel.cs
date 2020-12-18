using Anime.Models;
using Anime.Navigable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

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
