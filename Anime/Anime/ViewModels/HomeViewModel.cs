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
    public class HomeViewModel : ANavigableViewModel
    {
        public event EventHandler<string> SelectionChangedEv;
        public ObservableCollection<AnimeModel> TestItems { get; set; }

        public HomeViewModel(INavigationService navigationService) :base(navigationService)
        {
            TestItems = new ObservableCollection<AnimeModel>() {
                new AnimeModel(){ImgPath="naruto.jpg" ,Title = "Naruto", Rating="8/10"},
                new AnimeModel(){ImgPath="berserk.jpg" ,Title = "Berserk", Rating="8/10"},
                new AnimeModel(){ImgPath="bleach.jpg" ,Title = "Bleach", Rating="8/10"},
                new AnimeModel(){ImgPath="eva.jpg" ,Title = "Eva", Rating="5/10"},
                new AnimeModel(){ImgPath="dragonball.jpg" ,Title = "Dragonball", Rating="9/10"},
                new AnimeModel(){ImgPath="pokemon.jpg" ,Title = "Pokemon", Rating="9/10"},
                new AnimeModel(){ImgPath="rezero.jpg" ,Title = "Re:zero", Rating="6/10"},
            };
        }

        public ICommand TappedOnItem => new Command((item) => {
            if(item is AnimeModel anime)
                SelectionChangedEv?.Invoke(this, anime.Title);
        });
    }
}
