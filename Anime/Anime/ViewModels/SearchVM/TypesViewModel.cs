using Anime.DataServices;
using Anime.Navigable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class TypesViewModel : ANavigableViewModel
    {
        private IDataService dataService;


        public string Header { get; set; }
        public ObservableCollection<string> AnimeTypes { get; set; }

        public TypesViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Header = "ТИПЫ";
            this.AnimeTypes = new ObservableCollection<string>();
            this.dataService = new DataService();
        }

        public override void Load()
        {
            var data = dataService.GetData(DataType.AnimeTypes);
            for (int i = 0; i < data.Length; i++) {
                AnimeTypes.Add(data[i]);
            }
        }

        public ICommand TappedOnItem => new Command((item) => {

        });
    }
}
