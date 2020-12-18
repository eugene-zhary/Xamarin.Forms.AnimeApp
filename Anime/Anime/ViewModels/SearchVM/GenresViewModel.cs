using Anime.DataServices;
using Anime.Navigable;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class GenresViewModel : ANavigableViewModel
    {
        private IDataService dataService;

        public string Header { get; set; }
        public ObservableCollection<string> AnimeGenres { get; set; }

        public GenresViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.dataService = new DataService();
            this.Header = "ЖАНРЫ";
            this.AnimeGenres = new ObservableCollection<string>();
        }

        public override void Load()
        {
            var data = dataService.GetData(DataType.AnimeGenrs);
            for (int i = 0; i < data.Length; i++) {
                AnimeGenres.Add(data[i]);
            }
        }

        public ICommand TappedOnItem => new Command((item) => {

        });
    }
}
