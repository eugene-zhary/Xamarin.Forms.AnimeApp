using Anime.Models;
using Anime.Navigable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anime.ViewModels
{
    public class SearchViewModel : ANavigableViewModel
    {
        public event EventHandler<string> SelectionChangedEv;

        public ObservableCollection<string> AnimeTypes { get; set; }
        public ObservableCollection<string> AnimeGenres { get; set; }

        public SearchViewModel(INavigationService navigationService) : base(navigationService) 
        {
            this.AnimeTypes = new ObservableCollection<string>() {
                "Кодомо",
                "Сёнэн",
                "Сёдзё",
                "Сэйнэн",
                "Дзё",
                "OAV/OVA",
                "ТВ-сериал",
                "ТВ-фильм",
                "короткометражные ",
            };
            this.AnimeGenres = new ObservableCollection<string>() {
                "Боевик",
                "Повседневность",
                "Романтика",
                "Паропанк",
                "Киберпанк",
                "Спокон",
                "Сэнтай",
                "Меха",
                "Научная фантастика",
                "Драма",
                "История",
                "Комедия",
                "Сказка",
                "Детектив",
                "Мистика",
            };
        }

        public ICommand TappedOnItem => new Command((item) => {
            if(item is string title)
                SelectionChangedEv?.Invoke(this, title);
        });
    }
}
