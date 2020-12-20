using Anime.DataServices;
using Anime.Models;
using Anime.Navigable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class TopViewModel : ANavigableViewModel
    {
        public string Header { get; set; }

        public ObservableCollection<AnimeModel> AnimeCollection { get; set; }

        public TopViewModel(INavigationService navigationService):base(navigationService)
        {
            this.Header = "ТОП 100";
            AnimeCollection = new ObservableCollection<AnimeModel>();

            var data = DataService.GetData(DataType.Anime);
            for (int i = 0; i < data.GetLength(0); i++) {
                AnimeCollection.Add(new AnimeModel() {
                    Title = data[i, 0].ToString(),
                    Rating = data[i, 1].ToString(),
                    //ImgPath = "https://cdn.myanimelist.net/images/anime/13/17405.jpg"
                });
            }
        }
    }
}
