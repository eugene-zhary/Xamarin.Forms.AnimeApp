using Anime.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Anime.ViewModels
{
    public class ProfileViewModel
    {
        public UserModel User { get; set; }
        public ObservableCollection<AnimeModel> History { get; set; }


        public ProfileViewModel()
        {
            User = new UserModel() {
                Name = "Евгений",
                ImgPath = "demoAvatar.jpg",
                BDay = new DateTime(2001, 1,5),
                Sex = "Male",
                AboutMe = "software developer from Ukraine"
            };

            History = new ObservableCollection<AnimeModel>() {
                new AnimeModel(){ImgPath="naruto.jpg" ,Title = "Naruto", Rating="8/10"},
                new AnimeModel(){ImgPath="berserk.jpg" ,Title = "Berserk", Rating="8/10"},
                new AnimeModel(){ImgPath="bleach.jpg" ,Title = "Bleach", Rating="8/10"},
                new AnimeModel(){ImgPath="eva.jpg" ,Title = "Eva", Rating="5/10"},
                new AnimeModel(){ImgPath="dragonball.jpg" ,Title = "Dragonball", Rating="9/10"},
                new AnimeModel(){ImgPath="pokemon.jpg" ,Title = "Pokemon", Rating="9/10"},
                new AnimeModel(){ImgPath="rezero.jpg" ,Title = "Re:zero", Rating="6/10"},
            };
        }

    }
}
