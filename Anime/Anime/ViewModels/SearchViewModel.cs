using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Anime.ViewModels
{
    public class SearchViewModel : ViewModel
    {
        public ObservableCollection<string> AnimeTypes { get; set; }
        public ObservableCollection<string> AnimeGenres { get; set; }


        public SearchViewModel()
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
    }
}
