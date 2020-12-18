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
        public string Header { get; set; }
        public ObservableCollection<string> AnimeTypes { get; set; }

        public TypesViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Header = "ТИПЫ";
            this.AnimeTypes = new ObservableCollection<string>();
        }

        public ICommand TappedOnItem => new Command((item) => {

        });
    }
}
