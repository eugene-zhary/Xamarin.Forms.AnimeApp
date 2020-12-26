using Anime.DataServices;
using Anime.Models;
using Anime.Navigable;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class TypesViewModel : ANavigableViewModel
    {
        public string Header { get; set; }
        public ObservableCollection<CategoryModel> DataCollection { get; set; }


        public TypesViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Header = "ТИПЫ";
            this.DataCollection = (DataService.GetData(DataType.Types) as ObservableCollection<CategoryModel>);
        }

    }
}
