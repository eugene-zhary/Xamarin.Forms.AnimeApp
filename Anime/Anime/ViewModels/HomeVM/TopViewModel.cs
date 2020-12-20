using Anime.DataServices;
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
    public class TopViewModel : ANavigableViewModel
    {
        public string Header { get; set; }

        public ObservableCollection<AnimeModel> AnimeCollection { get; set; }

        public TopViewModel(INavigationService navigationService):base(navigationService)
        {
            this.Header = "ТОП 100";
            AnimeCollection = new ObservableCollection<AnimeModel>();
        }
    }
}
