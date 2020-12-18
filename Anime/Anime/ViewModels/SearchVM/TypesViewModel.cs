using Anime.DataServices;
using Anime.Navigable;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class TypesViewModel : ANavigableViewModel
    {
        private IDataService dataService;


        public string Header { get; set; }
        public ObservableCollection<string> DataCollection { get; set; }

        public TypesViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Header = "ТИПЫ";
            this.DataCollection = new ObservableCollection<string>();
            this.dataService = new DataService();
        }

        public override async Task Load()
        {
            var data = await dataService.GetData(DataType.AnimeTypes);

            for (int i = 0; i < data.Length; i++) {
                DataCollection.Add(data[i]);
            }
        }


        public ICommand TappedOnItem => new Command((item) => {

        });
    }
}
