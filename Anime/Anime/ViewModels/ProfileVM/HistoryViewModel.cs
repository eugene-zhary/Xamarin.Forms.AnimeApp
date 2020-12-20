using Anime.DataServices;
using Anime.Models;
using Anime.Navigable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Anime.ViewModels
{
    public class HistoryViewModel  : ANavigableViewModel
    {
        public string Header { get; set; }
        public ObservableCollection<AnimeModel> History { get; set; }

        public HistoryViewModel(INavigationService navigationService) : base(navigationService)
        {
            Header = "ИСТОРИЯ";
            History = (DataService.GetData(DataType.History) as ObservableCollection<AnimeModel>);
        }
    }
}
