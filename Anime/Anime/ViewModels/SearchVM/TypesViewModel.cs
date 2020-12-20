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
        public string Header { get; set; }
        public ObservableCollection<string> DataCollection { get; set; }


        public TypesViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Header = "ТИПЫ";
            this.DataCollection = new ObservableCollection<string>();

            var data = DataService.GetData(DataType.AnimeTypes);

            for (int i = 0; i < data.GetLength(0); i++) {
                DataCollection.Add(data[i, 0].ToString());
            }
        }
    }
}
