using Anime.DataServices;
using Anime.Navigable;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class GenresViewModel : ANavigableViewModel
    {
        private IDataService dataService;

        public string Header { get; set; }
        public ObservableCollection<string> DataCollection { get; set; }

        public GenresViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.dataService = new DataService();
            this.Header = "ЖАНРЫ";
            this.DataCollection = new ObservableCollection<string>();

        }

        public override async Task Load()
        {
            var data = await dataService.GetData(DataType.AnimeGenrs);

            for (int i = 0; i < data.Length; i++) {
                DataCollection.Add(data[i]);
            }
        }


        public ICommand TappedOnItem => new Command((item) => {

        });
    }
}
