using Anime.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Anime.ViewModels
{
    public class ProfileViewModel
    {
        public ObservableCollection<AnimeModel> History { get; set; }


        public ProfileViewModel()
        {
            History = new ObservableCollection<AnimeModel>() {
                new AnimeModel(){ImgPath="naruto.jpg" ,Title = "naruto", Rating="8/10"},
                new AnimeModel(){ImgPath="berserk.jpg" ,Title = "berserk", Rating="8/10"},
                new AnimeModel(){ImgPath="bleach.jpg" ,Title = "bleach", Rating="8/10"},
                new AnimeModel(){ImgPath="eva.jpg" ,Title = "eva", Rating="5/10"},
                new AnimeModel(){ImgPath="dragonball.jpg" ,Title = "dragonball", Rating="9/10"},
                new AnimeModel(){ImgPath="pokemon.jpg" ,Title = "pokemon", Rating="9/10"},
                new AnimeModel(){ImgPath="rezero.jpg" ,Title = "rezero", Rating="6/10"},
            };
        }

    }
}
