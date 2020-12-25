using Anime.DataServices;
using Anime.Models;
using Anime.Navigable;
using System.Collections.ObjectModel;

namespace Anime.ViewModels
{
    public class TopViewModel : ANavigableViewModel
    {
        public string Header { get; set; }

        public ObservableCollection<AnimeModel> AnimeCollection { get; set; }

        public TopViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Header = "ТОП 100";
            AnimeCollection = (DataService.GetData(DataType.Anime) as ObservableCollection<AnimeModel>);
        }
    }
}
