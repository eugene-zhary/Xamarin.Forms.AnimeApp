using Anime.DataServices;
using Anime.Models;
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
        public ObservableCollection<CategoryModel> DataCollection { get; set; }

        public GenresViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Header = "ЖАНРЫ";
            this.DataCollection = (DataService.GetData(DataType.Genrs) as ObservableCollection<CategoryModel>);
        }
    }
}
