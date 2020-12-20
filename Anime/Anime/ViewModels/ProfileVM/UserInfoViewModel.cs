using Anime.Models;
using Anime.Navigable;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anime.ViewModels
{
    public class UserInfoViewModel : ANavigableViewModel
    {
        public UserModel User { get; set; }


        public UserInfoViewModel(INavigationService navigationService) : base(navigationService)
        {
            User = new UserModel() {
                Name = "Евгений",
                ImgUrl = "demoAvatar.jpg",
                BDay = new DateTime(2001, 1, 5),
                Sex = "Male",
                AboutMe = "software developer from Ukraine"
            };
        }
    }
}
