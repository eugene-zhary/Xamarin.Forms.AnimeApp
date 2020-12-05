using Anime.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Anime.ViewModels
{
    public class HomePageViewModel : ViewModel
    {
        public ObservableCollection<WrapedItemModel> TestItems { get; set; }

        public HomePageViewModel()
        {
            TestItems = new ObservableCollection<WrapedItemModel>() {
                new WrapedItemModel(){ImgPath="naruto.jpg" ,Title = "naruto", Rating="8/10"},
                new WrapedItemModel(){ImgPath="berserk.jpg" ,Title = "berserk", Rating="8/10"},
                new WrapedItemModel(){ImgPath="bleach.jpg" ,Title = "bleach", Rating="8/10"},
                new WrapedItemModel(){ImgPath="eva.jpg" ,Title = "eva", Rating="5/10"},
                new WrapedItemModel(){ImgPath="dragonball.jpg" ,Title = "dragonball", Rating="9/10"},
                new WrapedItemModel(){ImgPath="pokemon.jpg" ,Title = "pokemon", Rating="9/10"},
                new WrapedItemModel(){ImgPath="rezero.jpg" ,Title = "rezero", Rating="6/10"},
            };
        }

    }
}
