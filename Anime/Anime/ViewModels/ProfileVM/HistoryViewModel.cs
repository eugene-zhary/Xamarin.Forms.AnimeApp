using Anime.DataServices;
using Anime.Models;
using Anime.Navigable;
using System.Collections.ObjectModel;

namespace Anime.ViewModels
{
    public class HistoryViewModel  : ANavigableViewModel
    {
        public string Header { get; set; }
        public ObservableCollection<AnimeModel> History { get; set; }

        public HistoryViewModel(INavigationService navigationService) : base(navigationService)
        {
            Header = "ИСТОРИЯ";
            History = (DataService.GetData(DataType.History, 1) as ObservableCollection<AnimeModel>);
        }
    }
}
