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
        public string Header { get; set; }
        public ObservableCollection<string> DataCollection { get; set; }

        public GenresViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Header = "ЖАНРЫ";
            this.DataCollection = new ObservableCollection<string>();
        }

        public override async Task Load()
        {
            var data = await DataService.GetData(DataType.AnimeGenrs);

            for (int i = 0; i < data.GetLength(0); i++) {
                DataCollection.Add(data[i, 0].ToString());
            }
        }


        public ICommand TappedOnItem => new Command((item) => {

        });
    }
}
