using Anime.DataServices;
using Anime.Models;
using Anime.Navigable;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class TopViewModel : ANavigableViewModel
    {
        public string Header { get; set; }

        public ObservableCollection<AnimeModel> AnimeCollection { get; set; }

        public TopViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Header = "ТОП 100";
            AnimeCollection = new ObservableCollection<AnimeModel>();

            MainThread.BeginInvokeOnMainThread(async () => {
                await Load();
            });
        }

        async Task Load()
        {
            var data = DataService.GetData(DataType.Anime) as ObservableCollection<AnimeModel>;

            foreach (var item in data) {
                AnimeCollection.Add(item);
            }

            await Task.Delay(5000);
        }
    }
}
